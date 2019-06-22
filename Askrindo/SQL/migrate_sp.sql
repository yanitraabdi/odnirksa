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


