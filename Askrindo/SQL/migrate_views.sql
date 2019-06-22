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
