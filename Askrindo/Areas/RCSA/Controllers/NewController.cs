using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Askrindo.Areas.RCSA.Models;
using Askrindo.Models;
using Askrindo.Helpers;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Transactions;
using System.IO;

namespace Askrindo.Areas.RCSA.Controllers
{
    [Authorize]
    public class NewController : Controller
    {
        private AskrindoEntities db = new AskrindoEntities();

        // GET: RCSA/New
        public ActionResult Index()
        {
            ViewBag.currentPage = "Risiko Baru";

            var rcData = from s in db.RiskCats select s;

            if (Request.Params["riskType"] == "Bisnis")
            {
                rcData = rcData.Where(rc => rc.RiskCatName == "Proses Bisnis");
            }
            else if (Request.Params["riskType"] == "Fraud")
            {
                rcData = rcData.Where(rc => rc.RiskCatName == "Operasional");
            }
            else
            {
                rcData = rcData.Where(rc => rc.RiskCatName != "Proses Bisnis");
            }

            var user = Utils.LoadUserDataFromSession();
            var newVM = new RCSANewViewModel {
                KodeRisiko = Utils.GetFormattedSerialNumber(user),
                RiskCats = rcData.Where(rc => rc.Status).ToList(),
                CurrentDateTime = DateTime.Now,
                CauseGroups = db.CauseGroups.ToList(),
                EffectGroups = db.EffectGroups.ToList()
            };

            ViewBag.title = "Risiko Baru";
            return View(newVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitRisk(RCSARiskInputModel rCSARiskInputModel, HttpPostedFileBase imageFile) {
            //var formData = Request.Form;
            HttpPostedFile files= System.Web.HttpContext.Current.Request.Files["files"];
            byte[] fileData;
            RiskAttachment attachmentFile = new RiskAttachment();
            if(files!=null)
            {
                using (var binaryReader = new BinaryReader(files.InputStream))
                {
                    fileData = binaryReader.ReadBytes(files.ContentLength);
                }
                attachmentFile = new RiskAttachment()
                {
                    Data= fileData,
                    Filename = files.FileName,
                    ContentLength=files.ContentLength,
                    ContentType=files.ContentType
                };
                attachmentFile.AttachName = rCSARiskInputModel.attachName;
                attachmentFile.Notes = rCSARiskInputModel.notes;

            }
            var risk_event_id = rCSARiskInputModel.risk_event; //int.Parse(Request.Form["risk_event"]);
            var risk_event_note = rCSARiskInputModel.risk_event_note;//Request.Form["risk_event_note"];

            var risk_date = rCSARiskInputModel.risk_date; //Request.Form["risk_date"];

            var risk_causes = rCSARiskInputModel.risk_causes; //Request.Form.GetValues("risk_causes").Select(int.Parse).ToArray();
            var risk_cause_notes = rCSARiskInputModel.risk_cause_notes; //Request.Form.GetValues("risk_cause_notes");

            var risk_effects = rCSARiskInputModel.risk_effects; //Request.Form.GetValues("risk_effects").Select(int.Parse).ToArray();
            var risk_effect_notes = rCSARiskInputModel.risk_effect_notes; //Request.Form.GetValues("risk_effect_notes");

            var riskEvent = db.RiskEvents.First(d => d.RiskEventID == risk_event_id);

            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    var riskData = new Risk();
                    var data = Utils.LoadUserDataFromSession();

                    Risk risk = new Risk();
                    var re = db.RiskEvents.Where(m => m.RiskEventID == risk_event_id).FirstOrDefault();
                    risk.UserId = data.UserId;
                    risk.JobTitle = data.JobTitle;
                    risk.RiskCode = Utils.GetFormattedSerialNumber(data);
                    risk.RiskName = re.RiskEvent1;
                    risk.RiskDate = DateTime.Now;
                    risk.OrgPos = data.OrgPos;
                    risk.DeptId = data.DeptId;
                    risk.SubDeptId = data.SubDeptId;
                    risk.DivisionId = data.DivisionId;
                    risk.SubDivId = data.SubDivId;
                    risk.BranchId = data.BranchId;
                    risk.SubBranchId = data.SubBranchId;
                    risk.BizUnitId = data.BizUnitId;

                    risk.RiskCatId = riskEvent.RiskType.RiskGroup.RiskCat.RiskCatId;
                    risk.RiskGroupId = riskEvent.RiskType.RiskGroup.RiskGroupId;
                    risk.RiskTypeId = riskEvent.RiskType.RiskTypeId;

                    risk.ProbLevelId = Utils.PROBLEVEL1;
                    risk.ImpactLevelId = Utils.IMPACTLEVEL1;
                    risk.RiskLevel = risk.ProbLevelId * risk.ImpactLevelId;
                    risk.IsReadOnly = false;
                    risk.RiskEventId = risk_event_id;
                    risk.FRiskDate = DateTime.ParseExact(risk_date, "dddd, dd MMMM yyyy", null);

                    risk.IsMultiCE = true;

                    db.Risks.Add(risk);
                    db.SaveChanges();
                    if(attachmentFile.Data!=null)
                    {
                        attachmentFile.RiskId = risk.RiskId;
                        db.RiskAttachments.Add(attachmentFile);
                        db.SaveChanges();
                    }
                    RiskProb prob = new RiskProb();
                    prob.RiskId = risk.RiskId;
                    prob.ProbOption = Utils.PROBOPTION_FREQUENCY;
                    prob.FreqId = Utils.FREQUENCY1;
                    prob.ProbLevelId = Utils.PROBLEVEL1;
                    db.RiskProbs.Add(prob);
                    db.SaveChanges();

                    RiskImpact impact = new RiskImpact();
                    impact.RiskId = risk.RiskId;
                    impact.IsMoneyImpact = true;
                    impact.ImpactLevelId = Utils.IMPACTLEVEL1;
                    db.RiskImpacts.Add(impact);
                    db.SaveChanges();

                    Utils.CreateFirstApprovalSchedule(risk);
                    Utils.IncrementSerialNumber(db);

                    var riskCausesData = db.Causes.Where(d => risk_causes.Contains(d.CauseId)).ToList();
                    var riskEffectsData = db.Effects.Where(d => risk_effects.Contains(d.EffectId)).ToList();

                    for (var i = 0; i < risk_causes.Length; i++)
                    {
                        var current_value = riskCausesData.Find(d => d.CauseId == risk_causes[i]);
                        db.RiskCauseLines.Add(new RiskCauseLine
                        {
                            CauseGroupCauseGroupId = current_value.CauseType.CauseGroup.CauseGroupId,
                            CauseTypeCauseTypeId = current_value.CauseType.CauseTypeId,
                            CauseCauseId = current_value.CauseId,
                            Note ="",
                            RiskRiskId = risk.RiskId,
                            CustomCause = ""
                        });
                    }

                    for (var i = 0; i < risk_effects.Length; i++)
                    {
                        var current_value = riskEffectsData.Find(d => d.EffectId == risk_effects[i]);
                        db.RiskEffectLines.Add(new RiskEffectLine
                        {
                            EffectGroupEffectGroupId = current_value.EffectType.EffectGroup.EffectGroupId,
                            EffectTypeEffectTypeId = current_value.EffectType.EffectTypeId,
                            EffectEffectId = current_value.EffectId,
                            Note = "",
                            RiskRiskId = risk.RiskId,
                            CustomEffect = ""
                        });
                    }


                    //alvintan
                    var probType = rCSARiskInputModel.prob_type; ///formData["prob-type"];
                    var riskId = risk.RiskId;//int.Parse(formData["riskId"]);

                    double? value = null;
                    int probLevelId;

                    switch (probType)
                    {
                        case "avail":
                            var tbAvail = rCSARiskInputModel.tb_avail;

                            prob.ProbValue = (decimal)tbAvail;
                            prob.ProbOption = 1;

                            value = tbAvail;
                            break;
                        case "appr":
                            var tbAp1 = rCSARiskInputModel.tb_ap1;
                            var tbAp2 = rCSARiskInputModel.tb_ap2;
                            var tbAp3 = rCSARiskInputModel.tb_ap3;

                            prob.Approx1 = (decimal)tbAp1;
                            prob.Approx2 = (decimal)tbAp2;
                            prob.Approx3 = (decimal)tbAp3;

                            value = ((double)prob.Approx1 + 4 * (double)prob.Approx2 + (double)prob.Approx3) / 6;
                            prob.Poisson1 = null;
                            prob.Poisson2 = null;
                            prob.Binom1 = null;
                            prob.Binom2 = null;
                            prob.Compare = null;
                            prob.FreqId = null;

                            prob.ProbOption = 3;
                            break;
                        case "diff":
                            var tbDiff = rCSARiskInputModel.tb_diff;

                            prob.Compare = (decimal)tbDiff;

                            value = tbDiff;
                            prob.Poisson1 = null;
                            prob.Poisson2 = null;
                            prob.Binom1 = null;
                            prob.Binom2 = null;
                            prob.Approx1 = null;
                            prob.Approx2 = null;
                            prob.Approx3 = null;
                            prob.FreqId = null;

                            prob.ProbOption = 4;
                            break;
                        case "freq":
                            var sbFreq = rCSARiskInputModel.sb_freq;
                            prob.FreqId = sbFreq;

                            prob.ProbOption = 5;

                            break;
                        default:
                            break;
                    }


                    decimal? probValue = null;
                    if (value != null)
                    {
                        probValue = Convert.ToDecimal(value);
                        probLevelId = Utils.GetProbLevelFromValue((decimal)probValue);
                    }
                    else
                        probLevelId = (int)prob.FreqId;

                    prob.ProbValue = probValue;
                    prob.ProbLevelId = probLevelId;

                    risk.ProbValue = prob.ProbValue;
                    risk.ProbLevelId = prob.ProbLevelId;
                    Utils.CalcRiskLevel(risk);

                    risk.IsProbSet = true;
                    //
                    //alvintan2
                    if(rCSARiskInputModel.impact_type=="money")
                    {
                        impact.MoneyDirect = (decimal)rCSARiskInputModel.moneyDirect;
                        impact.MoneyIndirect = (decimal)rCSARiskInputModel.moneyIndirect;
                        decimal moneyValue = 0M;
                        if (impact.MoneyDirect != null)
                            moneyValue += (decimal)impact.MoneyDirect;
                        if (impact.MoneyIndirect != null)
                            moneyValue += (decimal)impact.MoneyIndirect;
                        var impactPos = Utils.GetImpactPos(data);
                        var level = Utils.GetImpactLevelFromMoney(moneyValue, impactPos);
                        risk.ImpactMoney = moneyValue;
                        risk.ImpactLevelId = level;
                        Utils.CalcRiskLevel(risk);
                        SetImpactFlag(risk);
                    }
                    else
                    {
                        var riskNM = new RiskNonMoneyImpact()
                        {
                            RiskId = risk.RiskId,
                            ImpactTypeId = rCSARiskInputModel.impactTypeId,
                            ImpactLevelId = rCSARiskInputModel.impactLevelId
                        };
                        riskNM.ImpactDetailId = db.ImpactDetails.Where(d => d.ImpactTypeId == riskNM.ImpactTypeId && d.ImpactLevelId == riskNM.ImpactLevelId).First().ImpactDetailId;
                        db.RiskNonMoneyImpacts.Add(riskNM);
                        SetImpactFlag(risk);
                    }
                    //
                    db.SaveChanges();
                    trans.Complete();
                    return Json(risk.RiskId);
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    return Json(e.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("- Source: \"{0}\", Error: \"{1}\"", e.Source, e.Message);
                    return Json(e.ToString());
                }
               
            }
        }
        private void SetImpactFlag(Risk risk)
        {
            risk.IsImpactSet = true;
            db.SaveChanges();
        }
        //
        // GET: /Account/Search
        public ActionResult Search()
        {
            ViewBag.currentPage = "Cari Risiko";
            ViewBag.title = "Risiko Baru";
            return View();
        }

        //
        // POST: /Account/Search
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel searchVM)
        {
            ViewBag.title = "Risiko Baru";
            string cleanKeyword = searchVM.Keyword.Trim();
            if (cleanKeyword.Length > 3)
            {
                string[] keywords = searchVM.Keyword.Split(' ');
                searchVM.RiskEvents = db.RiskEvents.Where(re => keywords.All(k => re.RiskEvent1.Contains(k))).Take(50).ToList();
            }

            return View(searchVM);
        }

        public JsonResult GetRiskGroup(int filterId, bool? isFraud)
        {
            bool isFraudRisk = isFraud ?? false;
            var riskGroupData = from s in db.RiskGroups select s;

            if (isFraudRisk)
            {
                riskGroupData = riskGroupData.Where(s => s.RiskGroupName == "Fraud");
            }
            else
            {
                riskGroupData = riskGroupData.Where(s => s.RiskGroupName != "Fraud");
            }

            return Json(riskGroupData.Where(d => d.RiskCatId == filterId).Select(d => new {
                Value = d.RiskGroupId,
                Text = d.RiskGroupName
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRiskType(int filterId)
        {
            return Json(db.RiskTypes.Where(d => d.RiskGroupId == filterId).Select(d => new {
                Value = d.RiskTypeId,
                Text = d.RiskTypeName
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRiskEvent(int filterId)
        {
            return Json(db.RiskEvents.Where(d => d.RiskTypeId == filterId).Select(d => new {
                Value = d.RiskEventID,
                Text = d.RiskEvent1,
                InputDate = d.input_date
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCauseTypes(int filterId)
        {
            return Json(db.CauseTypes.Where(d => d.CauseGroupId == filterId).Select(d => new {
                Value = d.CauseTypeId,
                Text = d.CauseTypeName
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCauses(int filterId)
        {
            return Json(db.Causes.Where(d => d.CauseTypeId == filterId).Select(d => new {
                Value = d.CauseId,
                Text = d.CauseName
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEffectTypes(int filterId)
        {
            return Json(db.EffectTypes.Where(d => d.EffectGroupId == filterId).Select(d => new {
                Value = d.EffectTypeId,
                Text = d.EffectTypeName
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEffects(int filterId)
        {
            return Json(db.Effects.Where(d => d.EffectTypeId == filterId).Select(d => new {
                Value = d.EffectId,
                Text = d.EffectName
            }), JsonRequestBehavior.AllowGet);
        }
    }
}