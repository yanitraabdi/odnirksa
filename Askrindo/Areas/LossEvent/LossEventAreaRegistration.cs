using System.Web.Mvc;

namespace Askrindo.Areas.LossEvent
{
    public class LossEventAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "LossEvent";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "LossEvent_default",
                "LossEvent/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
