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