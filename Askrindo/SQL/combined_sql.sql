-- THIS SCRIPT NEEDS TO RUN FROM THE CONTEXT OF THE MEMBERSHIP DB
BEGIN TRANSACTION MigrateUsersAndRoles
USE AskrindoMVCDevelopment

-- INSERT USERS
INSERT INTO Askrindo2019.dbo.AspNetUsers
            (Id,
             UserName,
             PasswordHash,
             SecurityStamp,
             EmailConfirmed,
             PhoneNumber,
             PhoneNumberConfirmed,
             TwoFactorEnabled,
             LockoutEndDateUtc,
             LockoutEnabled,
             AccessFailedCount,
             Email)
SELECT aspnet_Users.UserId,
       aspnet_Users.UserName,
       -- Creates an empty password since passwords don't map between the 2 schemas
       '',
       /*
        The SecurityStamp token is used to verify the state of an account and 
        is subject to change at any time. It should be initialized as a new ID.
       */
       NewID(),
       /*
        EmailConfirmed is set when a new user is created and confirmed via email.
        Users must have this set during migration to reset passwords.
       */
       1,
       aspnet_Users.MobileAlias,
       CASE
         WHEN aspnet_Users.MobileAlias IS NULL THEN 0
         ELSE 1
       END,
       -- 2FA likely wasn't setup in Membership for users, so setting as false.
       0,
       CASE
         -- Setting lockout date to time in the future (1,000 years)
         WHEN aspnet_Membership.IsLockedOut = 1 THEN Dateadd(year, 1000,
                                                     Sysutcdatetime())
         ELSE NULL
       END,
       aspnet_Membership.IsLockedOut,
       /*
        AccessFailedAccount is used to track failed logins. This is stored in
        Membership in multiple columns. Setting to 0 arbitrarily.
       */
       0,
       aspnet_Membership.Email
FROM   aspnet_Users
       LEFT OUTER JOIN aspnet_Membership
                    ON aspnet_Membership.ApplicationId =
                       aspnet_Users.ApplicationId
                       AND aspnet_Users.UserId = aspnet_Membership.UserId
       LEFT OUTER JOIN Askrindo2019.dbo.AspNetUsers
                    ON aspnet_Membership.UserId = AspNetUsers.Id
WHERE  AspNetUsers.Id IS NULL

-- INSERT ROLES
INSERT INTO Askrindo2019.dbo.AspNetRoles(Id, Name)
SELECT RoleId, RoleName
FROM aspnet_Roles;

-- INSERT USER ROLES
INSERT INTO Askrindo2019.dbo.AspNetUserRoles(AspNetUsers_Id, AspNetRoles_Id)
SELECT UserId, RoleId
FROM aspnet_UsersInRoles;

IF @@ERROR <> 0
BEGIN
	ROLLBACK TRANSACTION MigrateUsersAndRoles
END
ELSE
BEGIN
	COMMIT TRANSACTION MigrateUsersAndRoles
END

-- THIS SCRIPT NEEDS TO RUN FROM THE CONTEXT OF THE MEMBERSHIP DB
BEGIN TRANSACTION MigrateUsersInfo
USE AskrindoMVCDevelopment

INSERT INTO Askrindo2019.dbo.Depts
SELECT * FROM Depts

INSERT INTO Askrindo2019.dbo.SubDepts
SELECT * FROM SubDepts

INSERT INTO Askrindo2019.dbo.Divisions
SELECT * FROM Divisions

INSERT INTO Askrindo2019.dbo.SubDivs
SELECT * FROM SubDivs

INSERT INTO Askrindo2019.dbo.BranchClasses
SELECT * FROM BranchClasses

INSERT INTO Askrindo2019.dbo.Branches
SELECT * FROM Branches

INSERT INTO Askrindo2019.dbo.SubBranches
SELECT * FROM SubBranches

INSERT INTO Askrindo2019.dbo.BizUnits
SELECT * FROM BizUnits

INSERT INTO [Askrindo2019].dbo.UserInfos
           ([UserId]
           ,[FullName]
           ,[JobTitle]
           ,[IsRiskOwner]
           ,[DeptId]
           ,[SubDeptId]
           ,[DivisionId]
           ,[SubDivId]
           ,[BranchId]
           ,[SubBranchId]
           ,[BizUnitId]
           ,[OrgPos]
           ,[StsPC]
           ,[Status]
           ,[AspNetUser_Id])
SELECT *, UserId FROM UserInfos

IF @@ERROR <> 0
BEGIN
	ROLLBACK TRANSACTION MigrateUsersInfo
END
ELSE
BEGIN
	COMMIT TRANSACTION MigrateUsersInfo
END

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
	
-- THIS SCRIPT NEEDS TO RUN FROM THE CONTEXT OF THE MEMBERSHIP DB
BEGIN TRANSACTION MigrateRisks
USE AskrindoMVCDevelopment

INSERT INTO Askrindo2019.dbo.Korwils
SELECT * FROM Korwil;

INSERT INTO Askrindo2019.dbo.KlasifikasiKerugians
SELECT * FROM KlasifikasiKerugian;
/*
INSERT INTO Askrindo2019.dbo.PJOK
SELECT * FROM PJOK;
*/
INSERT INTO Askrindo2019.dbo.SerialNumbers
SELECT [Year], SN FROM SerialNumbers;

IF @@ERROR <> 0
  BEGIN
    ROLLBACK TRANSACTION MigrateMitigations
    RETURN
  END
ELSE
	BEGIN
		COMMIT TRANSACTION MigrateMitigations
	END
	
USE Askrindo2019;
GO

/****** Object:  StoredProcedure [dbo].[RisikoBerulangKantorCabang]    Script Date: 5/7/2019 9:16:44 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RisikoBerulangKantorCabang] 
	@TglSebelumAwal DATE, 
	@TglSebelumAkhir DATE,
	@TglBerjalanAwal DATE,
	@TglBerjalanAkhir DATE
AS
BEGIN
	SELECT BranchId, BranchName,
		sum(CASE WHEN sebelum = 0 AND berjalan > 0 THEN total END) AS baru,
		sum(CASE WHEN sebelum > 0 AND berjalan = 0 THEN total END) AS t_berulang,
		sum(CASE WHEN sebelum > 0 AND berjalan > 0 THEN berjalan END) AS berulang,
		sum(total) AS total
	FROM
	(
		SELECT Branches.BranchId, Branches.BranchName, RiskEvents.RiskEvent1, 
		sum(CASE WHEN Risks.RiskDate >= @TglSebelumAwal AND Risks.RiskDate <= @TglSebelumAkhir THEN 1 ELSE 0 END ) AS sebelum,
		sum(CASE WHEN Risks.RiskDate >= @TglBerjalanAwal AND Risks.RiskDate <= @TglBerjalanAkhir THEN 1 ELSE 0 END ) AS berjalan,
		count(*) AS total 
		FROM Risks
		JOIN Branches ON Branches.BranchId = Risks.BranchId
		LEFT JOIN RiskEvents ON RiskEvents.RiskEventID = Risks.RiskEventId
		WHERE risks.RiskDate BETWEEN  @TglSebelumAwal AND @TglBerjalanAkhir 
		GROUP BY Branches.BranchId, Branches.BranchName, RiskEvents.RiskEvent1
	) AS a
	GROUP BY BranchId, BranchName
END


GO


/****** Object:  StoredProcedure [dbo].[RisikoBerulangKantorPusat]    Script Date: 5/7/2019 9:19:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RisikoBerulangKantorPusat]
	@TglSebelumAwal DATE, 
	@TglSebelumAkhir DATE,
	@TglBerjalanAwal DATE,
	@TglBerjalanAkhir DATE
AS
BEGIN	
	SELECT DivisionId, DivisionName, SubDivId, SubDivName,
		sum(CASE WHEN sebelum = 0 AND berjalan > 0 THEN total END) AS baru,
		sum(CASE WHEN sebelum > 0 AND berjalan = 0 THEN total END) AS t_berulang,
		sum(CASE WHEN sebelum > 0 AND berjalan > 0 THEN berjalan END) AS berulang,
		sum(total) AS total
	FROM
		(
		SELECT SubDivs.SubDivId, SubDivs.SubDivName, RiskEvents.RiskEvent1, Divisions.DivisionId, Divisions.DivisionName,
		sum(CASE WHEN Risks.RiskDate >= @TglSebelumAwal AND Risks.RiskDate <= @TglSebelumAkhir THEN 1 ELSE 0 END ) AS sebelum,
		sum(CASE WHEN Risks.RiskDate >= @TglBerjalanAwal AND Risks.RiskDate <= @TglBerjalanAkhir THEN 1 ELSE 0 END ) AS berjalan,
		count(*) AS total 
		FROM Risks
		LEFT JOIN RiskEvents ON RiskEvents.RiskEventID = Risks.RiskEventId
		JOIN SubDivs ON SubDivs.SubDivId = Risks.SubDivId
		JOIN Divisions ON Divisions.DivisionId = SubDivs.DivisionId
		WHERE 
		risks.RiskDate BETWEEN @TglSebelumAwal  AND @TglBerjalanAkhir
	GROUP BY SubDivs.SubDivId, SubDivs.SubDivName, RiskEvents.RiskEvent1,Divisions.DivisionId, Divisions.DivisionName
	) AS a
	GROUP BY SubDivId, SubDivName, DivisionId, DivisionName
END


GO


/****** Object:  StoredProcedure [dbo].[RisikoBerulangRisikoUtama]    Script Date: 5/7/2019 9:20:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RisikoBerulangRisikoUtama] 
	@TglSebelumAwal DATE, 
	@TglSebelumAkhir DATE,
	@TglBerjalanAwal DATE,
	@TglBerjalanAkhir DATE
AS
BEGIN
	SELECT RiskCatName, RiskCatId,
		sum(CASE WHEN sebelum = 0 AND berjalan > 0 THEN total END) AS baru,
		sum(CASE WHEN sebelum > 0 AND berjalan = 0 THEN total END) AS t_berulang,
		sum(CASE WHEN sebelum > 0 AND berjalan > 0 THEN berjalan END) AS berulang,
		sum(total) as total
	FROM
		(
		SELECT RiskCats.RiskCatName, RiskEvents.RiskEvent1, RiskCats.RiskCatId,
		sum(CASE WHEN Risks.RiskDate >= @TglSebelumAwal AND Risks.RiskDate <= @TglSebelumAkhir THEN 1 ELSE 0 END ) AS sebelum,
		sum(CASE WHEN Risks.RiskDate >= @TglBerjalanAwal AND Risks.RiskDate <= @TglBerjalanAkhir THEN 1 ELSE 0 END ) AS berjalan,
		count(*) AS total 
		FROM Risks 
		JOIN RiskCats ON Risks.RiskCatId = RiskCats.RiskCatId
		LEFT JOIN RiskEvents ON Risks.RiskEventID = RiskEvents.RiskEventId 
		WHERE risks.RiskDate BETWEEN @TglSebelumAwal AND @TglBerjalanAkhir 
		AND RiskCats.Grup = '1'
		AND RiskCats.Status <> '0'
	GROUP BY RiskCats.RiskCatName, RiskEvents.RiskEvent1, RiskCats.RiskCatId
	) AS a
	GROUP BY RiskCatName, RiskCatId
END




GO


/****** Object:  StoredProcedure [dbo].[RisikoBerulangSebabUtama]    Script Date: 5/7/2019 9:20:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RisikoBerulangSebabUtama]
	@TglSebelumAwal DATE, 
	@TglSebelumAkhir DATE,
	@TglBerjalanAwal DATE,
	@TglBerjalanAkhir DATE
AS
BEGIN
	SELECT CauseGroupId, CauseGroupName,
		sum(CASE WHEN sebelum = 0 AND berjalan > 0 THEN total END) AS baru,
		sum(CASE WHEN sebelum > 0 AND berjalan = 0 THEN total END) AS t_berulang,
		sum(CASE WHEN sebelum > 0 AND berjalan > 0 THEN berjalan END) AS berulang,
		sum(total)
	FROM
	(
		SELECT RiskEvents.RiskEvent1, CauseGroups.CauseGroupId, CauseGroups.CauseGroupName,
		sum(CASE WHEN Risks.RiskDate >= @TglSebelumAwal AND Risks.RiskDate <= @TglSebelumAkhir THEN 1 ELSE 0 END ) AS sebelum,
		sum(CASE WHEN Risks.RiskDate >= @TglBerjalanAwal AND Risks.RiskDate <= @TglBerjalanAkhir THEN 1 ELSE 0 END ) AS berjalan,
		count(*) AS total 
		FROM 
		Risks 
		LEFT JOIN RiskEvents ON RiskEvents.RiskEventID = Risks.RiskEventId
		JOIN CauseGroups ON CauseGroups.CauseGroupId = Risks.CauseGroupId
		WHERE
		risks.RiskDate BETWEEN @TglSebelumAwal AND @TglBerjalanAkhir
		GROUP BY  CauseGroups.CauseGroupId, RiskEvents.RiskEvent1, CauseGroups.CauseGroupName
	) AS a
	GROUP BY CauseGroupId, CauseGroupName
END


GO


/****** Object:  StoredProcedure [dbo].[RisikoBerulangTingkatRisiko]    Script Date: 5/7/2019 9:21:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RisikoBerulangTingkatRisiko]
	
	@TglSebelumAwal DATE, 
	@TglSebelumAkhir DATE,
	@TglBerjalanAwal DATE,
	@TglBerjalanAkhir DATE
	
AS
BEGIN
	SELECT LevelId,
		sum(CASE WHEN sebelum = 0 AND berjalan > 0 THEN total END) AS baru,
		sum(CASE WHEN sebelum > 0 AND berjalan = 0 THEN total END) AS t_berulang,
		sum(CASE WHEN sebelum > 0 AND berjalan > 0 THEN berjalan END) AS berulang,
		sum(total) AS total
	FROM
	(
		SELECT RiskEvents.RiskEvent1, RiskLevels.LevelId,
		sum(CASE WHEN Risks.RiskDate >= @TglSebelumAwal AND Risks.RiskDate <= @TglSebelumAkhir THEN 1 ELSE 0 END ) AS sebelum,
		sum(CASE WHEN Risks.RiskDate >= @TglBerjalanAwal AND Risks.RiskDate <= @TglBerjalanAkhir THEN 1 ELSE 0 END ) AS berjalan,
		count(*) AS total 
		FROM Risks 
		LEFT JOIN RiskEvents ON Risks.RiskEventId = RiskEvents.RiskEventID
		JOIN RiskLevels ON Risks.RiskLevel BETWEEN RiskLevels.MinValue AND RiskLevels.MaxValue
		WHERE 
		risks.RiskDate BETWEEN @TglSebelumAwal AND @TglBerjalanAkhir
	GROUP BY RiskEvents.RiskEvent1, RiskLevels.LevelId
	) AS a
	GROUP BY LevelId
END


GO


USE Askrindo2019;
GO

/****** Object:  View [dbo].[LossEventsBulanView]    Script Date: 4/2/2019 10:47:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[LossEventsBulanView]
AS
SELECT     tahun, bulan, pemilik, id_pemilik, LossEvents, COUNT(jml_kasus) AS Expr1, SUM(ImpactFinancial) AS Expr2, jml_kasus, ImpactFinancial
FROM         (SELECT     YEAR(dbo.LossEvents.LossDate) AS tahun, MONTH(dbo.LossEvents.LossDate) AS bulan, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptName
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivName
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchName
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS pemilik, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptId
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivId
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchId
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS id_pemilik, dbo.LossEvents.LossEventName AS LossEvents, 1 AS jml_kasus, 
                                              ISNULL(dbo.LossEvents.ImpactFinancial, 0) AS ImpactFinancial
                       FROM          dbo.LossEvents INNER JOIN
                                              dbo.KlasifikasiKerugians ON dbo.LossEvents.KlasifikasiId = dbo.KlasifikasiKerugians.KlasifikasiId
                       WHERE      (dbo.LossEvents.LossDate BETWEEN '2010/01/01' AND GETDATE())) AS tabel
GROUP BY tahun, bulan, pemilik, id_pemilik, LossEvents, jml_kasus, ImpactFinancial


GO



USE Askrindo2019;
GO

/****** Object:  View [dbo].[LossEventKantorView]    Script Date: 4/2/2019 10:49:26 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[LossEventKantorView]
AS
SELECT     tanggal, pemilik, id_pemilik, LossEvent, jml_kasus
FROM         (SELECT     dbo.LossEvents.LossDate AS tanggal, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptName
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivName
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchName
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS pemilik, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptId
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivId
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchId
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS id_pemilik, dbo.LossEvents.LossEventName AS LossEvent, 1 AS jml_kasus
                       FROM          dbo.LossEvents INNER JOIN
                                              dbo.KlasifikasiKerugians ON dbo.LossEvents.KlasifikasiId = dbo.KlasifikasiKerugians.KlasifikasiId
                       WHERE      (dbo.LossEvents.LossDate BETWEEN '2010/01/01' AND GETDATE())) AS tabel
GROUP BY tanggal, pemilik, id_pemilik, LossEvent, jml_kasus


GO


USE Askrindo2019;
GO

/****** Object:  View [dbo].[LossEventPemilikView]    Script Date: 4/2/2019 10:51:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[LossEventPemilikView]
AS
SELECT     tahun, pemilik, id_pemilik, Klasifikasi, id_klasifikasi, COUNT(jml_kasus) AS Expr1, SUM(ImpactFinancial) AS Expr2, jml_kasus, ImpactFinancial
FROM         (SELECT     YEAR(dbo.LossEvents.LossDate) AS tahun, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptName
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivName
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchName
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS pemilik, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptId
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivId
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchId
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS id_pemilik, dbo.KlasifikasiKerugians.Klasifikasi, 
                                              dbo.KlasifikasiKerugians.KlasifikasiId AS id_klasifikasi, 1 AS jml_kasus, ISNULL(dbo.LossEvents.ImpactFinancial, 0) AS ImpactFinancial
                       FROM          dbo.LossEvents INNER JOIN
                                              dbo.KlasifikasiKerugians ON dbo.LossEvents.KlasifikasiId = dbo.KlasifikasiKerugians.KlasifikasiId
                       WHERE      (dbo.LossEvents.LossDate BETWEEN '2010/01/01' AND GETDATE())) AS tabel
GROUP BY tahun, pemilik, id_pemilik, Klasifikasi, id_klasifikasi, jml_kasus, ImpactFinancial


GO


USE Askrindo2019
GO

/****** Object:  View [dbo].[LossEventTahunView]    Script Date: 4/2/2019 10:51:23 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[LossEventTahunView]
AS
SELECT     tahun, pemilik, id_pemilik, LossEvent, COUNT(jml_kasus) AS Expr1, SUM(ImpactFinancial) AS Expr2, jml_kasus, ImpactFinancial
FROM         (SELECT     YEAR(dbo.LossEvents.LossDate) AS tahun, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptName
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivName
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchName
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS pemilik, (CASE WHEN LossEvents.SubDeptId IS NOT NULL THEN
                                                  (SELECT     SubDeptId
                                                    FROM          SubDepts
                                                    WHERE      SubDeptId = LossEvents.SubDeptId) ELSE (CASE WHEN LossEvents.SubDivId IS NOT NULL THEN
                                                  (SELECT     SubDivId
                                                    FROM          SubDivs
                                                    WHERE      SubDivId = LossEvents.SubDivId) ELSE (CASE WHEN LossEvents.BranchId IS NOT NULL THEN
                                                  (SELECT     Branches.BranchId
                                                    FROM          Branches
                                                    WHERE      BranchId = LossEvents.BranchId) ELSE '' END) END) END) AS id_pemilik, dbo.LossEvents.LossEventName AS LossEvent, 1 AS jml_kasus, 
                                              ISNULL(dbo.LossEvents.ImpactFinancial, 0) AS ImpactFinancial
                       FROM          dbo.LossEvents INNER JOIN
                                              dbo.KlasifikasiKerugians ON dbo.LossEvents.KlasifikasiId = dbo.KlasifikasiKerugians.KlasifikasiId
                       WHERE      (dbo.LossEvents.LossDate BETWEEN '2010/01/01' AND GETDATE())) AS tabel
GROUP BY tahun, pemilik, id_pemilik, LossEvent, jml_kasus, ImpactFinancial


GO
