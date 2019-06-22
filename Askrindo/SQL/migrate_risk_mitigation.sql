-- THIS SCRIPT NEEDS TO RUN FROM THE CONTEXT OF THE MEMBERSHIP DB
BEGIN TRANSACTION MigrateMitigations
USE AskrindoMVCDevelopment

--ImpactDetail
--ImpactRef
--RiskNonMoneyImpact
--RiskImpact
--RiskState
--MitigationCat
--MitigationType

--RiskMitigation
--MitigationAttachment
--MitigationApproval
--MitigationUnit

--MitigationAction
--ActionApproval
--ActionProgress

INSERT INTO Askrindo2019.dbo.ImpactCats
SELECT * FROM ImpactCats;
INSERT INTO Askrindo2019.dbo.ImpactTypes
SELECT * FROM ImpactTypes;
INSERT INTO Askrindo2019.dbo.ImpactDetails
SELECT * FROM ImpactDetails;
INSERT INTO Askrindo2019.dbo.ImpactRefs
SELECT * FROM ImpactRefs;

INSERT INTO Askrindo2019.dbo.MitigationCats
SELECT * FROM MitigationCats;
INSERT INTO Askrindo2019.dbo.MitigationTypes
SELECT * FROM MitigationTypes;

SET IDENTITY_INSERT Askrindo2019.dbo.RiskMitigations ON;
INSERT INTO Askrindo2019.dbo.RiskMitigations
([MitigationId]
,[RiskId]
,[MitigationCode]
,[MitigationName]
,[InputDate]
,[MitigationDate]
,[Cost]
,[MitigationCatId]
,[MitigationTypeId]
,[ProbLevelId]
,[ImpactLevelId]
,[RiskLevel]
,[LimitDate]
,[ApprovalDate]
,[UserId]
,[JobTitle]
,[OrgPos]
,[DeptId]
,[SubDeptId]
,[DivisionId]
,[SubDivId]
,[BranchId]
,[SubBranchId]
,[BizUnitId]
,[IsReadOnly])
SELECT [MitigationId]
,[RiskId]
,[MitigationCode]
,[MitigationName]
,[InputDate]
,CONVERT(DATETIME, IIF([MitigationDate] = '0001-01-01', '01-01-1753', [MitigationDate]))
,[Cost]
,[MitigationCatId]
,[MitigationTypeId]
,[ProbLevelId]
,[ImpactLevelId]
,[RiskLevel]
,[LimitDate]
,[ApprovalDate]
,[UserId]
,[JobTitle]
,[OrgPos]
,[DeptId]
,[SubDeptId]
,[DivisionId]
,[SubDivId]
,[BranchId]
,[SubBranchId]
,[BizUnitId]
,[IsReadOnly]
FROM RiskMitigations WHERE RiskId IN (SELECT RiskId FROM Risks);
SET IDENTITY_INSERT Askrindo2019.dbo.RiskMitigations OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.MitigationUnits ON;
INSERT INTO Askrindo2019.dbo.MitigationUnits([MitigationUnitId], [MitigationId]
           ,[DivisionId])
SELECT [MitigationUnitId], [MitigationId], [DivisionId] FROM MitigationUnit;
SET IDENTITY_INSERT Askrindo2019.dbo.MitigationUnits OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.MitigationsActions ON;
INSERT INTO Askrindo2019.dbo.MitigationsActions([ActionID]
      ,[MitigationId]
      ,[UserId]
      ,[ProbLevelId]
      ,[ImpactLevelId]
      ,[PIC]
      ,[ActionCode]
      ,[ActionName]
      ,[ActionDate]
      ,[Require]
      ,[RKAPF]
      ,[RiskLevel]
      ,[LimitDate]
      ,[IsReadOnly]
      ,[TotalProgress]
      ,[DeptId]
      ,[SubDeptId]
      ,[DivisionId]
      ,[SubDivId]
      ,[BranchId]
      ,[SubBranchId]
      ,[BizUnitId]
      ,[Biaya]
      ,[PIC2])
SELECT [ActionID]
      ,[MitigationId]
      ,[UserId]
      ,[ProbLevelId]
      ,[ImpactLevelId]
      ,[PIC]
      ,[ActionCode]
      ,[ActionName]
      ,[ActionDate]
      ,[Require]
      ,[RKAPF]
      ,[RiskLevel]
      ,[LimitDate]
      ,[IsReadOnly]
      ,[TotalProgress]
      ,[DeptId]
      ,[SubDeptId]
      ,[DivisionId]
      ,[SubDivId]
      ,[BranchId]
      ,[SubBranchId]
      ,[BizUnitId]
      ,[Biaya]
      ,[PIC2] FROM MitigationsAction WHERE MitigationId IN (SELECT MitigationId FROM RiskMitigations WHERE RiskId IN (SELECT RiskId FROM Risks));
SET IDENTITY_INSERT Askrindo2019.dbo.MitigationsActions OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.ActionProgresses ON;
INSERT INTO Askrindo2019.dbo.ActionProgresses([ActionProgressID]
      ,[ActionID]
      ,[ActionProgress1]
      ,[RecordDate])
SELECT [ActionProgressID]
      ,[ActionID]
      ,[ActionProgress]
      ,[RecordDate] FROM ActionProgress WHERE ActionID IN (SELECT ActionID FROM Askrindo2019.dbo.MitigationsActions);
SET IDENTITY_INSERT Askrindo2019.dbo.ActionProgresses OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.RiskNonMoneyImpacts ON;
INSERT INTO Askrindo2019.dbo.RiskNonMoneyImpacts
([Id]
,[RiskId]
,[ImpactDetailId]
,[ImpactTypeId]
,[ImpactLevelId])
SELECT * FROM RiskNonMoneyImpacts;
SET IDENTITY_INSERT Askrindo2019.dbo.RiskNonMoneyImpacts OFF;

INSERT INTO Askrindo2019.dbo.RiskImpacts
SELECT * FROM RiskImpacts;

SET IDENTITY_INSERT Askrindo2019.dbo.RiskStates ON;
INSERT INTO Askrindo2019.dbo.RiskStates
([StateId]
,[RiskId]
,[MitigationId]
,[StateDate]
,[ProbLevelId]
,[ImpactLevelId]
,[RiskLevel])
SELECT * FROM RiskStates;
SET IDENTITY_INSERT Askrindo2019.dbo.RiskStates OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.MitigationAttachments ON;
INSERT INTO Askrindo2019.dbo.MitigationAttachments
([AttachId], [MitigationId]
           ,[AttachName]
           ,[Notes]
           ,[Filename]
           ,[ContentType]
           ,[ContentLength]
           ,[Data])
SELECT * FROM MitigationAttachments;
SET IDENTITY_INSERT Askrindo2019.dbo.MitigationAttachments OFF;

SET IDENTITY_INSERT Askrindo2019.dbo.MitigationApprovals ON;
INSERT INTO Askrindo2019.dbo.MitigationApprovals
(
	[ApprovalId]
	,[MitigationId]
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
SELECT * FROM MitigationApprovals WHERE MitigationId IN (SELECT MitigationId FROM RiskMitigations WHERE RiskId IN (SELECT RiskId FROM Risks));
SET IDENTITY_INSERT Askrindo2019.dbo.MitigationApprovals OFF;


INSERT INTO Askrindo2019.dbo.ActionApprovals
SELECT * FROM ActionApproval WHERE ActionID IN (SELECT ActionID FROM Askrindo2019.dbo.MitigationsActions);

IF @@ERROR <> 0
  BEGIN
    ROLLBACK TRANSACTION MigrateMitigations
    RETURN
  END
ELSE
	BEGIN
		COMMIT TRANSACTION MigrateMitigations
	END