-- THIS SCRIPT NEEDS TO RUN FROM THE CONTEXT OF THE MEMBERSHIP DB
BEGIN TRANSACTION MigrateDLE
USE AskrindoMVCDevelopment

SET IDENTITY_INSERT Askrindo2019.dbo.LossEvents ON;
INSERT INTO Askrindo2019.dbo.LossEvents
(
[LossEventId]
      ,[LossEventCode]
      ,[InputDate]
      ,[KlasifikasiId]
      ,[LossEventName]
      ,[LossDate]
      ,[LossCause]
      ,[Assets]
      ,[Location]
      ,[PihakTerlibat]
      ,[ImpactNonFinancial]
      ,[ImpactFinancial]
      ,[Action]
      ,[Keterangan]
      ,[Status]
      ,[ApproveDate]
      ,[UserId]
      ,[ApproveId]
      ,[DeptId]
      ,[SubDeptId]
      ,[DivisionId]
      ,[SubDivId]
      ,[BranchId]
      ,[SubBranchIs]
      ,[BizUnitId]
      ,[JobTitle]
)
SELECT [LossEventId]
      ,[LossEventCode]
      ,CONVERT(DATETIME, IIF([InputDate] = '0001-01-01' OR [InputDate] IS NULL OR '01-01-1753' > [InputDate], '01-01-1753', [InputDate]))
      ,[KlasifikasiId]
      ,[LossEventName]
      ,CONVERT(DATETIME, IIF([LossDate] = '0001-01-01' OR [LossDate] IS NULL OR '01-01-1753' > [LossDate], '01-01-1753', [LossDate]))
      ,[LossCause]
      ,[Assets]
      ,[Location]
      ,[PihakTerlibat]
      ,[ImpactNonFinancial]
      ,[ImpactFinancial]
      ,[Action]
      ,[Keterangan]
      ,[Status]
      ,CONVERT(DATETIME, IIF([ApproveDate] = '0001-01-01' OR [ApproveDate] IS NULL OR '01-01-1753' > [ApproveDate], '01-01-1753', [ApproveDate]))
      ,[UserId]
      ,[ApproveId]
      ,[DeptId]
      ,[SubDeptId]
      ,[DivisionId]
      ,[SubDivId]
      ,[BranchId]
      ,[SubBranchIs]
      ,[BizUnitId]
      ,[JobTitle] FROM LossEvent;
SET IDENTITY_INSERT Askrindo2019.dbo.LossEvents OFF;

IF @@ERROR <> 0
  BEGIN
    ROLLBACK TRANSACTION MigrateDLE
    RETURN
  END
ELSE
	BEGIN
		COMMIT TRANSACTION MigrateDLE
	END