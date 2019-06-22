-- THIS SCRIPT NEEDS TO RUN FROM THE CONTEXT OF THE MEMBERSHIP DB
BEGIN TRANSACTION MigrateRisks
USE AskrindoMVCDevelopment

INSERT INTO Askrindo2019.dbo.CauseGroups
SELECT * FROM CauseGroups;

INSERT INTO Askrindo2019.dbo.CauseTypes
SELECT * FROM CauseTypes;

INSERT INTO Askrindo2019.dbo.Causes
SELECT * FROM Causes;

INSERT INTO Askrindo2019.dbo.RiskLevels
SELECT * FROM RiskLevels;

INSERT INTO Askrindo2019.dbo.EffectGroups
SELECT * FROM EffectGroups;

INSERT INTO Askrindo2019.dbo.EffectTypes
SELECT * FROM EffectTypes;

INSERT INTO Askrindo2019.dbo.Effects
SELECT * FROM Effects;

INSERT INTO Askrindo2019.dbo.RiskCats
SELECT * FROM RiskCats;

INSERT INTO Askrindo2019.dbo.RiskGroups
SELECT * FROM RiskGroups;

INSERT INTO Askrindo2019.dbo.Freqs
SELECT * FROM Freqs;

INSERT INTO Askrindo2019.dbo.ProbLevels
SELECT * FROM ProbLevels;

INSERT INTO Askrindo2019.dbo.RiskProbs
SELECT * FROM RiskProbs;

INSERT INTO Askrindo2019.dbo.ImpactLevels
SELECT * FROM ImpactLevels;

INSERT INTO Askrindo2019.dbo.bisnis
SELECT * FROM bisnis;

INSERT INTO Askrindo2019.dbo.bisnis_aktifitas
SELECT * FROM bisnis_aktifitas;

INSERT INTO Askrindo2019.dbo.RiskTypes
SELECT * FROM RiskTypes;

INSERT INTO Askrindo2019.dbo.RiskEvents
SELECT * FROM RiskEvent;

SET IDENTITY_INSERT Askrindo2019.dbo.Risks ON;
INSERT INTO Askrindo2019.dbo.Risks
(
			[RiskId]
		   ,[UserId]
           ,[RiskCode]
           ,[RiskName]
           ,[RiskDate]
           ,[OrgPos]
           ,[DeptId]
           ,[SubDeptId]
           ,[DivisionId]
           ,[SubDivId]
           ,[BranchId]
           ,[SubBranchId]
           ,[BizUnitId]
           ,[CauseGroupId]
           ,[CauseTypeId]
           ,[CauseId]
           ,[EffectGroupId]
           ,[EffectTypeId]
           ,[EffectId]
           ,[RiskCatId]
           ,[RiskGroupId]
           ,[RiskTypeId]
           ,[JobTitle]
           ,[ProbValue]
           ,[ProbLevelId]
           ,[ImpactLevelId]
           ,[ImpactMoney]
           ,[RiskLevel]
           ,[ApprovalDate]
           ,[CloseDate]
           ,[IsReadOnly]
           ,[RiskEventId]
           ,[bisnisid]
           ,[aktifitasid]
           ,[FRiskDate])
SELECT * FROM Risks;
SET IDENTITY_INSERT Askrindo2019.dbo.Risks OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.RiskAttachments ON;
INSERT INTO Askrindo2019.dbo.RiskAttachments
(
	 [AttachId]
	,[RiskId]
	,[AttachName]
	,[Notes]
	,[Filename]
	,[ContentType]
	,[ContentLength]
	,[Data]
)
SELECT RiskAttachments.* FROM RiskAttachments WHERE EXISTS (SELECT * FROM Risks WHERE RiskAttachments.RiskId = Risks.RiskId);
SET IDENTITY_INSERT Askrindo2019.dbo.RiskAttachments OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.RiskApprovals ON;
INSERT INTO Askrindo2019.dbo.RiskApprovals
([ApprovalId]
      ,[RiskId]
      ,[OrgPos]
      ,[DeptId]
      ,[SubDeptId]
      ,[DivisionId]
      ,[SubDivId]
      ,[BranchId]
      ,[SubBranchId]
      ,[BizUnitId]
      ,[OrgName]
      ,[UserId]
      ,[JobTitle]
      ,[ApprovalDate]
      ,[LimitDate]
      ,[LastApproval]
      ,[IsReadOnly])
SELECT * FROM RiskApprovals;
SET IDENTITY_INSERT Askrindo2019.dbo.RiskApprovals OFF;

IF @@ERROR <> 0
BEGIN
	ROLLBACK TRANSACTION MigrateRisks
END
ELSE
BEGIN
	COMMIT TRANSACTION MigrateRisks
END