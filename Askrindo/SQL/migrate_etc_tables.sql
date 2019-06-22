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