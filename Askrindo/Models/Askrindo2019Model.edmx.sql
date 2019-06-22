
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2019 11:12:36
-- Generated from EDMX file: F:\Askrindo\Askrindo\Models\Askrindo2019Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Askrindo2019];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseTypes_CauseGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CauseTypes] DROP CONSTRAINT [FK_CauseTypes_CauseGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_CauseGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_CauseGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Causes_CauseTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Causes] DROP CONSTRAINT [FK_Causes_CauseTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_Causes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_Causes];
GO
IF OBJECT_ID(N'[dbo].[FK_EffectTypes_EffectGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EffectTypes] DROP CONSTRAINT [FK_EffectTypes_EffectGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_EffectGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_EffectGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Effects_EffectTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Effects] DROP CONSTRAINT [FK_Effects_EffectTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_Effects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_Effects];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskTypes_RiskGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskTypes] DROP CONSTRAINT [FK_RiskTypes_RiskGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_RiskGroups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_RiskGroups];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskGroups_RiskCats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskGroups] DROP CONSTRAINT [FK_RiskGroups_RiskCats];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfos_Depts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_UserInfos_Depts];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskApprovals_Depts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskApprovals] DROP CONSTRAINT [FK_RiskApprovals_Depts];
GO
IF OBJECT_ID(N'[dbo].[FK_SubDepts_Depts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubDepts] DROP CONSTRAINT [FK_SubDepts_Depts];
GO
IF OBJECT_ID(N'[dbo].[FK_Divisions_Depts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Divisions] DROP CONSTRAINT [FK_Divisions_Depts];
GO
IF OBJECT_ID(N'[dbo].[FK_Branches_Depts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branches] DROP CONSTRAINT [FK_Branches_Depts];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_Depts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_Depts];
GO
IF OBJECT_ID(N'[dbo].[FK_Branches_BranchClasses]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Branches] DROP CONSTRAINT [FK_Branches_BranchClasses];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskProbs_ProbLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskProbs] DROP CONSTRAINT [FK_RiskProbs_ProbLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskStates_ProbLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskStates] DROP CONSTRAINT [FK_RiskStates_ProbLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskMitigations_ProbLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskMitigations] DROP CONSTRAINT [FK_RiskMitigations_ProbLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_MITIGATI_REFERENCE_PROBLEVE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationsActions] DROP CONSTRAINT [FK_MITIGATI_REFERENCE_PROBLEVE];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_ProbLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_ProbLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactDetails_ImpactLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImpactDetails] DROP CONSTRAINT [FK_ImpactDetails_ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskImpacts_ImpactLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskImpacts] DROP CONSTRAINT [FK_RiskImpacts_ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskNonMoneyImpacts_ImpactLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskNonMoneyImpacts] DROP CONSTRAINT [FK_RiskNonMoneyImpacts_ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskStates_ImpactLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskStates] DROP CONSTRAINT [FK_RiskStates_ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskMitigations_ImpactLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskMitigations] DROP CONSTRAINT [FK_RiskMitigations_ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_MITIGATI_REFERENCE_IMPACTLE]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationsActions] DROP CONSTRAINT [FK_MITIGATI_REFERENCE_IMPACTLE];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_ImpactLevels]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactTypes_ImpactCats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImpactTypes] DROP CONSTRAINT [FK_ImpactTypes_ImpactCats];
GO
IF OBJECT_ID(N'[dbo].[FK_MitigationTypes_MitigationCats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationTypes] DROP CONSTRAINT [FK_MitigationTypes_MitigationCats];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskMitigations_MitigationCats]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskMitigations] DROP CONSTRAINT [FK_RiskMitigations_MitigationCats];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskProbs_Freqs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskProbs] DROP CONSTRAINT [FK_RiskProbs_Freqs];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskNonMoneyImpacts_ImpactDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskNonMoneyImpacts] DROP CONSTRAINT [FK_RiskNonMoneyImpacts_ImpactDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskAttachments_Risks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskAttachments] DROP CONSTRAINT [FK_RiskAttachments_Risks];
GO
IF OBJECT_ID(N'[dbo].[FK_MitigationAttachments_RiskMitigations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationAttachments] DROP CONSTRAINT [FK_MitigationAttachments_RiskMitigations];
GO
IF OBJECT_ID(N'[dbo].[FK_SubDivs_Divisions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubDivs] DROP CONSTRAINT [FK_SubDivs_Divisions];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskApprovals_SubDivs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskApprovals] DROP CONSTRAINT [FK_RiskApprovals_SubDivs];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfos_SubDivs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_UserInfos_SubDivs];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_SubDivs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_SubDivs];
GO
IF OBJECT_ID(N'[dbo].[FK_SubBranches_Branches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubBranches] DROP CONSTRAINT [FK_SubBranches_Branches];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskApprovals_SubBranches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskApprovals] DROP CONSTRAINT [FK_RiskApprovals_SubBranches];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfos_SubBranches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_UserInfos_SubBranches];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_SubBranches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_SubBranches];
GO
IF OBJECT_ID(N'[dbo].[FK_BizUnits_Branches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BizUnits] DROP CONSTRAINT [FK_BizUnits_Branches];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskApprovals_BizUnits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskApprovals] DROP CONSTRAINT [FK_RiskApprovals_BizUnits];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfos_BizUnits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_UserInfos_BizUnits];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_BizUnits]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_BizUnits];
GO
IF OBJECT_ID(N'[dbo].[FK_MitigationApprovals_UserInfos]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationApprovals] DROP CONSTRAINT [FK_MitigationApprovals_UserInfos];
GO
IF OBJECT_ID(N'[dbo].[FK_MitigationApprovals_RiskMitigations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationApprovals] DROP CONSTRAINT [FK_MitigationApprovals_RiskMitigations];
GO
IF OBJECT_ID(N'[dbo].[FK_HelpDocs_HelpMenus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[HelpDocs] DROP CONSTRAINT [FK_HelpDocs_HelpMenus];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskEvent_RiskTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskEvents] DROP CONSTRAINT [FK_RiskEvent_RiskTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_RiskEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_RiskEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_Mitigationunit2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationUnits] DROP CONSTRAINT [FK_Mitigationunit2];
GO
IF OBJECT_ID(N'[dbo].[FK_Mitigationunit1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationUnits] DROP CONSTRAINT [FK_Mitigationunit1];
GO
IF OBJECT_ID(N'[dbo].[FK_BISNIS_A_REFERENCE_BISNIS]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[bisnis_aktifitas] DROP CONSTRAINT [FK_BISNIS_A_REFERENCE_BISNIS];
GO
IF OBJECT_ID(N'[dbo].[FK_Risks_bisnis]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_Risks_bisnis];
GO
IF OBJECT_ID(N'[dbo].[FK_ACTIONAP_REFERENCE_MITIGATI]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionApprovals] DROP CONSTRAINT [FK_ACTIONAP_REFERENCE_MITIGATI];
GO
IF OBJECT_ID(N'[dbo].[FK_ACTIONAP_REFERENCE_USERINFO]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionApprovals] DROP CONSTRAINT [FK_ACTIONAP_REFERENCE_USERINFO];
GO
IF OBJECT_ID(N'[dbo].[FK_ACTIONPR_REFERENCE_MITIGATI]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActionProgresses] DROP CONSTRAINT [FK_ACTIONPR_REFERENCE_MITIGATI];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_AspNetUserUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskCauseLineCauseType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskCauseLines] DROP CONSTRAINT [FK_RiskCauseLineCauseType];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskCauseLineCause1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskCauseLines] DROP CONSTRAINT [FK_RiskCauseLineCause1];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseGroupRiskCauseLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskCauseLines] DROP CONSTRAINT [FK_CauseGroupRiskCauseLine];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskEffectLineEffect]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskEffectLines] DROP CONSTRAINT [FK_RiskEffectLineEffect];
GO
IF OBJECT_ID(N'[dbo].[FK_EffectTypeRiskEffectLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskEffectLines] DROP CONSTRAINT [FK_EffectTypeRiskEffectLine];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskEffectLineEffectGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskEffectLines] DROP CONSTRAINT [FK_RiskEffectLineEffectGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskCauseLineRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskCauseLines] DROP CONSTRAINT [FK_RiskCauseLineRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskEffectLineRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskEffectLines] DROP CONSTRAINT [FK_RiskEffectLineRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskRiskMitigation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskMitigations] DROP CONSTRAINT [FK_RiskRiskMitigation];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskRiskApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskApprovals] DROP CONSTRAINT [FK_RiskRiskApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRiskApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskApprovals] DROP CONSTRAINT [FK_UserInfoRiskApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_UserInfoRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_DivisionRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_DivisionRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactTypeRiskNonMoneyImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskNonMoneyImpacts] DROP CONSTRAINT [FK_ImpactTypeRiskNonMoneyImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactTypeImpactDetail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImpactDetails] DROP CONSTRAINT [FK_ImpactTypeImpactDetail];
GO
IF OBJECT_ID(N'[dbo].[FK_MitigationTypeRiskMitigation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskMitigations] DROP CONSTRAINT [FK_MitigationTypeRiskMitigation];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoRiskMitigation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RiskMitigations] DROP CONSTRAINT [FK_UserInfoRiskMitigation];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskMitigationMitigationsAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MitigationsActions] DROP CONSTRAINT [FK_RiskMitigationMitigationsAction];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoKRINonInvestData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRINonInvestDatas] DROP CONSTRAINT [FK_UserInfoKRINonInvestData];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoKRIInvestData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIInvestDatas] DROP CONSTRAINT [FK_UserInfoKRIInvestData];
GO
IF OBJECT_ID(N'[dbo].[FK_KRINonInvestKRINonInvestParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRINonInvestParameters] DROP CONSTRAINT [FK_KRINonInvestKRINonInvestParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_KRINonInvestKRINonInvestData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRINonInvestDatas] DROP CONSTRAINT [FK_KRINonInvestKRINonInvestData];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIInvestKRIInvestData]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIInvestDatas] DROP CONSTRAINT [FK_KRIInvestKRIInvestData];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIInvestKRIInvestParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIInvestParameters] DROP CONSTRAINT [FK_KRIInvestKRIInvestParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_BranchRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskCatRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_RiskCatRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_RiskTypeRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_RiskTypeRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_SubDeptRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Risks] DROP CONSTRAINT [FK_SubDeptRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_DivisionUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_DivisionUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_SubDeptUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_SubDeptUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_BranchUserInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserInfos] DROP CONSTRAINT [FK_BranchUserInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_KRINonInvestDataSRNonInvest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SRNonInvests] DROP CONSTRAINT [FK_KRINonInvestDataSRNonInvest];
GO
IF OBJECT_ID(N'[dbo].[FK_SRNonInvestSRNonInvestProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SRNonInvestProgresses] DROP CONSTRAINT [FK_SRNonInvestSRNonInvestProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_SRNonInvestProgressSRNIProgressAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SRNIProgressActions] DROP CONSTRAINT [FK_SRNonInvestProgressSRNIProgressAction];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseKRIRiskCauseLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskCauseLines] DROP CONSTRAINT [FK_CauseKRIRiskCauseLine];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseGroupKRIRiskCauseLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskCauseLines] DROP CONSTRAINT [FK_CauseGroupKRIRiskCauseLine];
GO
IF OBJECT_ID(N'[dbo].[FK_CauseTypeKRIRiskCauseLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskCauseLines] DROP CONSTRAINT [FK_CauseTypeKRIRiskCauseLine];
GO
IF OBJECT_ID(N'[dbo].[FK_EffectKRIRiskEffectLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskEffectLines] DROP CONSTRAINT [FK_EffectKRIRiskEffectLine];
GO
IF OBJECT_ID(N'[dbo].[FK_EffectGroupKRIRiskEffectLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskEffectLines] DROP CONSTRAINT [FK_EffectGroupKRIRiskEffectLine];
GO
IF OBJECT_ID(N'[dbo].[FK_EffectTypeKRIRiskEffectLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskEffectLines] DROP CONSTRAINT [FK_EffectTypeKRIRiskEffectLine];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskCauseLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskCauseLines] DROP CONSTRAINT [FK_KRIRiskKRIRiskCauseLine];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskEffectLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskEffectLines] DROP CONSTRAINT [FK_KRIRiskKRIRiskEffectLine];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskApprovals] DROP CONSTRAINT [FK_KRIRiskKRIRiskApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoKRIRiskApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskApprovals] DROP CONSTRAINT [FK_UserInfoKRIRiskApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskAttachment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskAttachments] DROP CONSTRAINT [FK_KRIRiskKRIRiskAttachment];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskMitigationKRIMitigationAttachment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIMitigationAttachments] DROP CONSTRAINT [FK_KRIRiskMitigationKRIMitigationAttachment];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoKRIRisk]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRisks] DROP CONSTRAINT [FK_UserInfoKRIRisk];
GO
IF OBJECT_ID(N'[dbo].[FK_FreqKRIRiskProb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskProbs] DROP CONSTRAINT [FK_FreqKRIRiskProb];
GO
IF OBJECT_ID(N'[dbo].[FK_ProbLevelKRIRiskProb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskProbs] DROP CONSTRAINT [FK_ProbLevelKRIRiskProb];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskProb]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskProbs] DROP CONSTRAINT [FK_KRIRiskKRIRiskProb];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactLevelKRIRiskImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskImpacts] DROP CONSTRAINT [FK_ImpactLevelKRIRiskImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskImpacts] DROP CONSTRAINT [FK_KRIRiskKRIRiskImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskNonMoneyImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts] DROP CONSTRAINT [FK_KRIRiskKRIRiskNonMoneyImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactDetailKRIRiskNonMoneyImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts] DROP CONSTRAINT [FK_ImpactDetailKRIRiskNonMoneyImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactLevelKRIRiskNonMoneyImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts] DROP CONSTRAINT [FK_ImpactLevelKRIRiskNonMoneyImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_ImpactTypeKRIRiskNonMoneyImpact]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts] DROP CONSTRAINT [FK_ImpactTypeKRIRiskNonMoneyImpact];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskKRIRiskMitigation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIRiskMitigations] DROP CONSTRAINT [FK_KRIRiskKRIRiskMitigation];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskMitigationKRIMitigationAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIMitigationActions] DROP CONSTRAINT [FK_KRIRiskMitigationKRIMitigationAction];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIRiskMitigationKRIMitigationApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIMitigationApprovals] DROP CONSTRAINT [FK_KRIRiskMitigationKRIMitigationApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoKRIMitigationApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIMitigationApprovals] DROP CONSTRAINT [FK_UserInfoKRIMitigationApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIMitigationActionKRIActionApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIActionApprovals] DROP CONSTRAINT [FK_KRIMitigationActionKRIActionApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIMitigationActionKRIActionProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIActionProgresses] DROP CONSTRAINT [FK_KRIMitigationActionKRIActionProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_UserInfoKRIActionApproval]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KRIActionApprovals] DROP CONSTRAINT [FK_UserInfoKRIActionApproval];
GO
IF OBJECT_ID(N'[dbo].[FK_SRInvestSRInvestProgress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SRInvestProgresses] DROP CONSTRAINT [FK_SRInvestSRInvestProgress];
GO
IF OBJECT_ID(N'[dbo].[FK_SRInvestProgressSRIProgressAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SRIProgressActions] DROP CONSTRAINT [FK_SRInvestProgressSRIProgressAction];
GO
IF OBJECT_ID(N'[dbo].[FK_KRIInvestDataSRInvest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SRInvests] DROP CONSTRAINT [FK_KRIInvestDataSRInvest];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[C__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[C__MigrationHistory];
GO
IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[CauseGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CauseGroups];
GO
IF OBJECT_ID(N'[dbo].[Causes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Causes];
GO
IF OBJECT_ID(N'[dbo].[CauseTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CauseTypes];
GO
IF OBJECT_ID(N'[dbo].[EffectGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EffectGroups];
GO
IF OBJECT_ID(N'[dbo].[Effects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Effects];
GO
IF OBJECT_ID(N'[dbo].[EffectTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EffectTypes];
GO
IF OBJECT_ID(N'[dbo].[RiskGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskGroups];
GO
IF OBJECT_ID(N'[dbo].[RiskTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskTypes];
GO
IF OBJECT_ID(N'[dbo].[Depts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Depts];
GO
IF OBJECT_ID(N'[dbo].[BranchClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BranchClasses];
GO
IF OBJECT_ID(N'[dbo].[ProbLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProbLevels];
GO
IF OBJECT_ID(N'[dbo].[ImpactLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImpactLevels];
GO
IF OBJECT_ID(N'[dbo].[ImpactCats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImpactCats];
GO
IF OBJECT_ID(N'[dbo].[ImpactDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImpactDetails];
GO
IF OBJECT_ID(N'[dbo].[ImpactTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImpactTypes];
GO
IF OBJECT_ID(N'[dbo].[MitigationCats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigationCats];
GO
IF OBJECT_ID(N'[dbo].[MitigationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigationTypes];
GO
IF OBJECT_ID(N'[dbo].[UserInfos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserInfos];
GO
IF OBJECT_ID(N'[dbo].[SerialNumbers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SerialNumbers];
GO
IF OBJECT_ID(N'[dbo].[Freqs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Freqs];
GO
IF OBJECT_ID(N'[dbo].[RiskProbs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskProbs];
GO
IF OBJECT_ID(N'[dbo].[RiskImpacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskImpacts];
GO
IF OBJECT_ID(N'[dbo].[RiskNonMoneyImpacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskNonMoneyImpacts];
GO
IF OBJECT_ID(N'[dbo].[RiskAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskAttachments];
GO
IF OBJECT_ID(N'[dbo].[RiskApprovals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskApprovals];
GO
IF OBJECT_ID(N'[dbo].[MitigationAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigationAttachments];
GO
IF OBJECT_ID(N'[dbo].[SubDepts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubDepts];
GO
IF OBJECT_ID(N'[dbo].[Divisions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisions];
GO
IF OBJECT_ID(N'[dbo].[SubDivs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubDivs];
GO
IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[SubBranches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubBranches];
GO
IF OBJECT_ID(N'[dbo].[BizUnits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BizUnits];
GO
IF OBJECT_ID(N'[dbo].[ImpactRefs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImpactRefs];
GO
IF OBJECT_ID(N'[dbo].[RiskStates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskStates];
GO
IF OBJECT_ID(N'[dbo].[RiskLevels]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskLevels];
GO
IF OBJECT_ID(N'[dbo].[MitigationApprovals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigationApprovals];
GO
IF OBJECT_ID(N'[dbo].[RiskMitigations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskMitigations];
GO
IF OBJECT_ID(N'[dbo].[HelpDocs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HelpDocs];
GO
IF OBJECT_ID(N'[dbo].[HelpMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[HelpMenus];
GO
IF OBJECT_ID(N'[dbo].[RiskEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskEvents];
GO
IF OBJECT_ID(N'[dbo].[MitigationUnits]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigationUnits];
GO
IF OBJECT_ID(N'[dbo].[bisnis]', 'U') IS NOT NULL
    DROP TABLE [dbo].[bisnis];
GO
IF OBJECT_ID(N'[dbo].[bisnis_aktifitas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[bisnis_aktifitas];
GO
IF OBJECT_ID(N'[dbo].[aspnet_Profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[aspnet_Profile];
GO
IF OBJECT_ID(N'[dbo].[ActionApprovals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionApprovals];
GO
IF OBJECT_ID(N'[dbo].[ActionProgresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionProgresses];
GO
IF OBJECT_ID(N'[dbo].[MitigationsActions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MitigationsActions];
GO
IF OBJECT_ID(N'[dbo].[UserGroups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserGroups];
GO
IF OBJECT_ID(N'[dbo].[KlasifikasiKerugians]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlasifikasiKerugians];
GO
IF OBJECT_ID(N'[dbo].[Korwils]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Korwils];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[LossEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LossEvents];
GO
IF OBJECT_ID(N'[dbo].[Risks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Risks];
GO
IF OBJECT_ID(N'[dbo].[RiskCats]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskCats];
GO
IF OBJECT_ID(N'[dbo].[RiskCauses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskCauses];
GO
IF OBJECT_ID(N'[dbo].[RiskCauseLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskCauseLines];
GO
IF OBJECT_ID(N'[dbo].[RiskEffectLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RiskEffectLines];
GO
IF OBJECT_ID(N'[dbo].[KRINonInvests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRINonInvests];
GO
IF OBJECT_ID(N'[dbo].[KRIInvests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIInvests];
GO
IF OBJECT_ID(N'[dbo].[KRINonInvestParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRINonInvestParameters];
GO
IF OBJECT_ID(N'[dbo].[KRIInvestParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIInvestParameters];
GO
IF OBJECT_ID(N'[dbo].[KRINonInvestDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRINonInvestDatas];
GO
IF OBJECT_ID(N'[dbo].[KRIInvestDatas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIInvestDatas];
GO
IF OBJECT_ID(N'[dbo].[LossEventKantorViews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LossEventKantorViews];
GO
IF OBJECT_ID(N'[dbo].[LossEventPemilikViews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LossEventPemilikViews];
GO
IF OBJECT_ID(N'[dbo].[LossEventTahunViews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LossEventTahunViews];
GO
IF OBJECT_ID(N'[dbo].[LossEventBulanViews]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LossEventBulanViews];
GO
IF OBJECT_ID(N'[dbo].[SRNonInvests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SRNonInvests];
GO
IF OBJECT_ID(N'[dbo].[SRNonInvestProgresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SRNonInvestProgresses];
GO
IF OBJECT_ID(N'[dbo].[SRNIProgressActions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SRNIProgressActions];
GO
IF OBJECT_ID(N'[dbo].[KRIRisks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRisks];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskCauseLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskCauseLines];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskEffectLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskEffectLines];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskAttachments];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskApprovals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskApprovals];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskMitigations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskMitigations];
GO
IF OBJECT_ID(N'[dbo].[KRIMitigationAttachments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIMitigationAttachments];
GO
IF OBJECT_ID(N'[dbo].[KRIMitigationApprovals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIMitigationApprovals];
GO
IF OBJECT_ID(N'[dbo].[KRIMitigationActions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIMitigationActions];
GO
IF OBJECT_ID(N'[dbo].[KRIActionProgresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIActionProgresses];
GO
IF OBJECT_ID(N'[dbo].[KRIActionApprovals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIActionApprovals];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskProbs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskProbs];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskImpacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskImpacts];
GO
IF OBJECT_ID(N'[dbo].[KRIRiskNonMoneyImpacts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KRIRiskNonMoneyImpacts];
GO
IF OBJECT_ID(N'[dbo].[SRInvests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SRInvests];
GO
IF OBJECT_ID(N'[dbo].[SRInvestProgresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SRInvestProgresses];
GO
IF OBJECT_ID(N'[dbo].[SRIProgressActions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SRIProgressActions];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'CauseGroups'
CREATE TABLE [dbo].[CauseGroups] (
    [CauseGroupId] int  NOT NULL,
    [CauseGroupName] varchar(200)  NOT NULL
);
GO

-- Creating table 'Causes'
CREATE TABLE [dbo].[Causes] (
    [CauseId] int  NOT NULL,
    [CauseTypeId] int  NOT NULL,
    [CauseName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'CauseTypes'
CREATE TABLE [dbo].[CauseTypes] (
    [CauseTypeId] int  NOT NULL,
    [CauseGroupId] int  NOT NULL,
    [CauseTypeName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'EffectGroups'
CREATE TABLE [dbo].[EffectGroups] (
    [EffectGroupId] int  NOT NULL,
    [EffectGroupName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Effects'
CREATE TABLE [dbo].[Effects] (
    [EffectId] int  NOT NULL,
    [EffectTypeId] int  NOT NULL,
    [EffectName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'EffectTypes'
CREATE TABLE [dbo].[EffectTypes] (
    [EffectTypeId] int  NOT NULL,
    [EffectGroupId] int  NOT NULL,
    [EffectTypeName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'RiskGroups'
CREATE TABLE [dbo].[RiskGroups] (
    [RiskGroupId] int  NOT NULL,
    [RiskCatId] int  NOT NULL,
    [RiskGroupName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'RiskTypes'
CREATE TABLE [dbo].[RiskTypes] (
    [RiskTypeId] int  NOT NULL,
    [RiskGroupId] int  NOT NULL,
    [RiskTypeName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Depts'
CREATE TABLE [dbo].[Depts] (
    [DeptId] int  NOT NULL,
    [DeptName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'BranchClasses'
CREATE TABLE [dbo].[BranchClasses] (
    [ClassId] int  NOT NULL,
    [ClassName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ProbLevels'
CREATE TABLE [dbo].[ProbLevels] (
    [ProbLevelId] int  NOT NULL,
    [ProbLevelName] nvarchar(50)  NOT NULL,
    [PctMin] int  NOT NULL,
    [PctMax] int  NOT NULL,
    [DescriptionGeneral] nvarchar(250)  NULL,
    [DescriptionProject] nvarchar(250)  NULL
);
GO

-- Creating table 'ImpactLevels'
CREATE TABLE [dbo].[ImpactLevels] (
    [ImpactLevelId] int  NOT NULL,
    [ImpactLevelName] nvarchar(50)  NOT NULL,
    [PctMin] int  NOT NULL,
    [PctMax] int  NOT NULL,
    [MoneyMin] decimal(19,4)  NOT NULL,
    [MoneyMax] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'ImpactCats'
CREATE TABLE [dbo].[ImpactCats] (
    [ImpactCatId] int  NOT NULL,
    [ImpactCatName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ImpactDetails'
CREATE TABLE [dbo].[ImpactDetails] (
    [ImpactDetailId] int  NOT NULL,
    [ImpactTypeId] int  NOT NULL,
    [ImpactLevelId] int  NOT NULL,
    [ImpactDetailName] nvarchar(1000)  NOT NULL
);
GO

-- Creating table 'ImpactTypes'
CREATE TABLE [dbo].[ImpactTypes] (
    [ImpactTypeId] int  NOT NULL,
    [ImpactCatId] int  NOT NULL,
    [ImpactTypeName] nvarchar(200)  NOT NULL,
    [Notes] nvarchar(200)  NULL
);
GO

-- Creating table 'MitigationCats'
CREATE TABLE [dbo].[MitigationCats] (
    [MitigationCatId] int  NOT NULL,
    [MitigationCatName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'MitigationTypes'
CREATE TABLE [dbo].[MitigationTypes] (
    [MitigationTypeId] int  NOT NULL,
    [MitigationCatId] int  NOT NULL,
    [MitigationTypeName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'UserInfos'
CREATE TABLE [dbo].[UserInfos] (
    [UserId] uniqueidentifier  NOT NULL,
    [FullName] nvarchar(100)  NOT NULL,
    [JobTitle] nvarchar(200)  NULL,
    [IsRiskOwner] bit  NOT NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [OrgPos] int  NOT NULL,
    [StsPC] bit  NULL,
    [Status] bit  NULL,
    [AspNetUser_Id] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'SerialNumbers'
CREATE TABLE [dbo].[SerialNumbers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Year] int  NOT NULL,
    [SN] int  NOT NULL
);
GO

-- Creating table 'Freqs'
CREATE TABLE [dbo].[Freqs] (
    [FreqId] int  NOT NULL,
    [FreqName] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'RiskProbs'
CREATE TABLE [dbo].[RiskProbs] (
    [RiskId] int  NOT NULL,
    [ProbOption] int  NOT NULL,
    [Poisson1] int  NULL,
    [Poisson2] int  NULL,
    [Binom1] int  NULL,
    [Binom2] int  NULL,
    [Approx1] decimal(18,2)  NULL,
    [Approx2] decimal(18,2)  NULL,
    [Approx3] decimal(18,2)  NULL,
    [Compare] decimal(18,2)  NULL,
    [FreqId] int  NULL,
    [ProbValue] decimal(9,2)  NULL,
    [ProbLevelId] int  NULL
);
GO

-- Creating table 'RiskImpacts'
CREATE TABLE [dbo].[RiskImpacts] (
    [RiskId] int  NOT NULL,
    [IsMoneyImpact] bit  NOT NULL,
    [MoneyDirect] decimal(19,4)  NULL,
    [MoneyIndirect] decimal(19,4)  NULL,
    [ImpactLevelId] int  NULL
);
GO

-- Creating table 'RiskNonMoneyImpacts'
CREATE TABLE [dbo].[RiskNonMoneyImpacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RiskId] int  NOT NULL,
    [ImpactDetailId] int  NOT NULL,
    [ImpactTypeId] int  NOT NULL,
    [ImpactLevelId] int  NOT NULL
);
GO

-- Creating table 'RiskAttachments'
CREATE TABLE [dbo].[RiskAttachments] (
    [AttachId] int IDENTITY(1,1) NOT NULL,
    [RiskId] int  NOT NULL,
    [AttachName] nvarchar(200)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Filename] nvarchar(200)  NOT NULL,
    [ContentType] nvarchar(200)  NOT NULL,
    [ContentLength] int  NULL,
    [Data] varbinary(max)  NOT NULL
);
GO

-- Creating table 'RiskApprovals'
CREATE TABLE [dbo].[RiskApprovals] (
    [ApprovalId] int IDENTITY(1,1) NOT NULL,
    [RiskId] int  NOT NULL,
    [OrgPos] int  NOT NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [OrgName] nvarchar(200)  NULL,
    [UserId] uniqueidentifier  NULL,
    [JobTitle] nvarchar(200)  NULL,
    [ApprovalDate] datetime  NULL,
    [LimitDate] datetime  NULL,
    [LastApproval] bit  NOT NULL,
    [IsReadOnly] bit  NOT NULL
);
GO

-- Creating table 'MitigationAttachments'
CREATE TABLE [dbo].[MitigationAttachments] (
    [AttachId] int IDENTITY(1,1) NOT NULL,
    [MitigationId] int  NOT NULL,
    [AttachName] nvarchar(200)  NOT NULL,
    [Notes] nvarchar(max)  NULL,
    [Filename] nvarchar(200)  NOT NULL,
    [ContentType] nvarchar(200)  NOT NULL,
    [ContentLength] int  NULL,
    [Data] varbinary(max)  NOT NULL
);
GO

-- Creating table 'SubDepts'
CREATE TABLE [dbo].[SubDepts] (
    [SubDeptId] int  NOT NULL,
    [DeptId] int  NOT NULL,
    [SubDeptName] nvarchar(200)  NOT NULL,
    [IsSupporting] bit  NOT NULL
);
GO

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [DivisionId] int  NOT NULL,
    [DeptId] int  NOT NULL,
    [DivisionName] nvarchar(200)  NOT NULL,
    [IsSupporting] bit  NOT NULL
);
GO

-- Creating table 'SubDivs'
CREATE TABLE [dbo].[SubDivs] (
    [SubDivId] int  NOT NULL,
    [DivisionId] int  NOT NULL,
    [SubDivName] nvarchar(200)  NOT NULL,
    [IsSupporting] bit  NOT NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [BranchId] int  NOT NULL,
    [DeptId] int  NOT NULL,
    [BranchName] nvarchar(200)  NOT NULL,
    [ClassId] int  NOT NULL,
    [BranchCode] nvarchar(3)  NULL,
    [IsSupporting] bit  NOT NULL,
    [KorwilId] int  NULL
);
GO

-- Creating table 'SubBranches'
CREATE TABLE [dbo].[SubBranches] (
    [SubBranchId] int  NOT NULL,
    [BranchId] int  NOT NULL,
    [SubBranchName] nvarchar(200)  NOT NULL,
    [IsSupporting] bit  NOT NULL
);
GO

-- Creating table 'BizUnits'
CREATE TABLE [dbo].[BizUnits] (
    [BizUnitId] int  NOT NULL,
    [BranchId] int  NOT NULL,
    [BizUnitName] nvarchar(200)  NOT NULL,
    [BizUnitCode] nvarchar(3)  NULL,
    [IsSupporting] bit  NOT NULL,
    [statusf] bit  NULL
);
GO

-- Creating table 'ImpactRefs'
CREATE TABLE [dbo].[ImpactRefs] (
    [ImpactRefId] int  NOT NULL,
    [MaxMoney] decimal(19,4)  NOT NULL,
    [HQPct] decimal(9,2)  NOT NULL,
    [Branch1Pct] decimal(9,2)  NOT NULL,
    [Branch2Pct] decimal(9,2)  NOT NULL,
    [Branch3Pct] decimal(9,2)  NOT NULL,
    [BizUnitPct] decimal(9,2)  NOT NULL,
    [SupportingHQPct] decimal(9,2)  NOT NULL,
    [SupportingBranchPct] decimal(9,2)  NOT NULL,
    [SupportingBizUnitPct] decimal(9,2)  NOT NULL
);
GO

-- Creating table 'RiskStates'
CREATE TABLE [dbo].[RiskStates] (
    [StateId] int IDENTITY(1,1) NOT NULL,
    [RiskId] int  NOT NULL,
    [MitigationId] int  NULL,
    [StateDate] datetime  NOT NULL,
    [ProbLevelId] int  NOT NULL,
    [ImpactLevelId] int  NOT NULL,
    [RiskLevel] int  NOT NULL
);
GO

-- Creating table 'RiskLevels'
CREATE TABLE [dbo].[RiskLevels] (
    [LevelId] int  NOT NULL,
    [LevelName] nvarchar(50)  NOT NULL,
    [MinValue] int  NOT NULL,
    [MaxValue] int  NOT NULL,
    [Action] nvarchar(100)  NULL,
    [BackColor] nvarchar(10)  NULL,
    [ForeColor] nvarchar(10)  NULL
);
GO

-- Creating table 'MitigationApprovals'
CREATE TABLE [dbo].[MitigationApprovals] (
    [ApprovalId] int IDENTITY(1,1) NOT NULL,
    [MitigationId] int  NOT NULL,
    [OrgPos] int  NOT NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [OrgName] nvarchar(200)  NULL,
    [UserId] uniqueidentifier  NULL,
    [JobTitle] nvarchar(200)  NULL,
    [ApprovalDate] datetime  NULL,
    [LimitDate] datetime  NULL,
    [LastApproval] bit  NOT NULL,
    [IsReadOnly] bit  NOT NULL
);
GO

-- Creating table 'RiskMitigations'
CREATE TABLE [dbo].[RiskMitigations] (
    [MitigationId] int IDENTITY(1,1) NOT NULL,
    [RiskId] int  NOT NULL,
    [MitigationCode] nvarchar(24)  NOT NULL,
    [MitigationName] nvarchar(2000)  NOT NULL,
    [InputDate] datetime  NOT NULL,
    [MitigationDate] datetime  NOT NULL,
    [Cost] decimal(19,4)  NULL,
    [MitigationCatId] int  NULL,
    [MitigationTypeId] int  NULL,
    [ProbLevelId] int  NULL,
    [ImpactLevelId] int  NULL,
    [RiskLevel] int  NULL,
    [LimitDate] datetime  NULL,
    [ApprovalDate] datetime  NULL,
    [UserId] uniqueidentifier  NULL,
    [JobTitle] nvarchar(200)  NULL,
    [OrgPos] int  NOT NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [IsReadOnly] bit  NOT NULL
);
GO

-- Creating table 'HelpDocs'
CREATE TABLE [dbo].[HelpDocs] (
    [DocId] int  NOT NULL,
    [MenuId] int  NOT NULL,
    [DocName] nvarchar(200)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [DocInfo] nvarchar(100)  NULL,
    [IsVisible] bit  NOT NULL,
    [Filename] nvarchar(200)  NULL,
    [ContentType] nvarchar(200)  NULL,
    [ContentLength] int  NULL,
    [Data] varbinary(max)  NULL
);
GO

-- Creating table 'HelpMenus'
CREATE TABLE [dbo].[HelpMenus] (
    [MenuId] int  NOT NULL,
    [MenuName] nvarchar(100)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [IsVisible] bit  NOT NULL
);
GO

-- Creating table 'RiskEvents'
CREATE TABLE [dbo].[RiskEvents] (
    [RiskEventID] int  NOT NULL,
    [RiskEvent1] nvarchar(2000)  NULL,
    [RiskTypeId] int  NULL,
    [input_date] datetime  NULL
);
GO

-- Creating table 'MitigationUnits'
CREATE TABLE [dbo].[MitigationUnits] (
    [MitigationUnitId] int IDENTITY(1,1) NOT NULL,
    [MitigationId] int  NOT NULL,
    [DivisionId] int  NOT NULL
);
GO

-- Creating table 'bisnis'
CREATE TABLE [dbo].[bisnis] (
    [bisnisid] int  NOT NULL,
    [bisnis] varchar(50)  NULL
);
GO

-- Creating table 'bisnis_aktifitas'
CREATE TABLE [dbo].[bisnis_aktifitas] (
    [aktifitasid] int  NOT NULL,
    [bisnisid] int  NULL,
    [aktifitas] varchar(100)  NULL
);
GO

-- Creating table 'aspnet_Profile'
CREATE TABLE [dbo].[aspnet_Profile] (
    [UserId] uniqueidentifier  NOT NULL,
    [PropertyNames] nvarchar(max)  NOT NULL,
    [PropertyValuesString] nvarchar(max)  NOT NULL,
    [PropertyValuesBinary] varbinary(max)  NOT NULL,
    [LastUpdatedDate] datetime  NOT NULL
);
GO

-- Creating table 'ActionApprovals'
CREATE TABLE [dbo].[ActionApprovals] (
    [ActionID] int  NOT NULL,
    [UserId] uniqueidentifier  NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [JobTitle] nvarchar(200)  NULL,
    [ApprovelDate] datetime  NULL,
    [LastApproval] bit  NULL,
    [IsReadonly] bit  NULL,
    [status] int  NULL
);
GO

-- Creating table 'ActionProgresses'
CREATE TABLE [dbo].[ActionProgresses] (
    [ActionProgressID] int IDENTITY(1,1) NOT NULL,
    [ActionID] int  NULL,
    [ActionProgress1] decimal(5,2)  NULL,
    [RecordDate] datetime  NULL
);
GO

-- Creating table 'MitigationsActions'
CREATE TABLE [dbo].[MitigationsActions] (
    [ActionID] int IDENTITY(1,1) NOT NULL,
    [MitigationId] int  NULL,
    [UserId] uniqueidentifier  NULL,
    [ProbLevelId] int  NULL,
    [ImpactLevelId] int  NULL,
    [PIC] uniqueidentifier  NULL,
    [ActionCode] nvarchar(26)  NULL,
    [ActionName] nvarchar(2000)  NULL,
    [ActionDate] datetime  NULL,
    [Require] nvarchar(2000)  NULL,
    [RKAPF] bit  NULL,
    [RiskLevel] int  NULL,
    [LimitDate] datetime  NULL,
    [IsReadOnly] bit  NULL,
    [TotalProgress] decimal(5,2)  NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [Biaya] decimal(18,2)  NULL,
    [PIC2] varchar(200)  NULL
);
GO

-- Creating table 'UserGroups'
CREATE TABLE [dbo].[UserGroups] (
    [UserGroupID] smallint  NOT NULL,
    [UserGroup1] varchar(100)  NULL
);
GO

-- Creating table 'KlasifikasiKerugians'
CREATE TABLE [dbo].[KlasifikasiKerugians] (
    [KlasifikasiId] nvarchar(4)  NOT NULL,
    [Klasifikasi] nvarchar(50)  NULL
);
GO

-- Creating table 'Korwils'
CREATE TABLE [dbo].[Korwils] (
    [KorwilId] int  NOT NULL,
    [Korwil1] nvarchar(50)  NULL,
    [Status] bit  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'LossEvents'
CREATE TABLE [dbo].[LossEvents] (
    [LossEventId] int IDENTITY(1,1) NOT NULL,
    [LossEventCode] nvarchar(20)  NULL,
    [InputDate] datetime  NULL,
    [KlasifikasiId] nvarchar(50)  NULL,
    [LossEventName] nvarchar(300)  NULL,
    [LossDate] datetime  NULL,
    [LossCause] nvarchar(200)  NULL,
    [Assets] decimal(18,2)  NULL,
    [Location] nvarchar(200)  NULL,
    [PihakTerlibat] nvarchar(500)  NULL,
    [ImpactNonFinancial] nvarchar(100)  NULL,
    [ImpactFinancial] decimal(18,2)  NULL,
    [Action] nvarchar(2000)  NULL,
    [Keterangan] nvarchar(2000)  NULL,
    [Status] nvarchar(1)  NULL,
    [ApproveDate] datetime  NULL,
    [UserId] uniqueidentifier  NULL,
    [ApproveId] uniqueidentifier  NULL,
    [DeptId] int  NULL,
    [SubDeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [BranchId] int  NULL,
    [SubBranchIs] int  NULL,
    [BizUnitId] int  NULL,
    [JobTitle] nvarchar(200)  NULL,
    [LossOwner] nvarchar(max)  NULL,
    [ProductType] nvarchar(max)  NULL,
    [Tertanggung] nvarchar(max)  NULL,
    [DebiturTertanggung] nvarchar(max)  NULL,
    [Obligee] nvarchar(max)  NULL,
    [Principal] nvarchar(max)  NULL,
    [NilaiJaminan] nvarchar(max)  NULL,
    [Collateral] nvarchar(max)  NULL,
    [Project] nvarchar(max)  NULL,
    [CasePosition] nvarchar(max)  NULL,
    [Affiliate] nvarchar(max)  NULL,
    [CaseType] nvarchar(max)  NULL,
    [Coverage] nvarchar(max)  NULL,
    [Units] nvarchar(max)  NULL,
    [LossType] nvarchar(max)  NULL
);
GO

-- Creating table 'Risks'
CREATE TABLE [dbo].[Risks] (
    [RiskId] int IDENTITY(1,1) NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [RiskCode] nvarchar(20)  NOT NULL,
    [RiskName] nvarchar(2000)  NOT NULL,
    [RiskDate] datetime  NOT NULL,
    [OrgPos] int  NOT NULL,
    [DeptId] int  NULL,
    [DivisionId] int  NULL,
    [SubDivId] int  NULL,
    [SubBranchId] int  NULL,
    [BizUnitId] int  NULL,
    [CauseGroupId] int  NULL,
    [CauseTypeId] int  NULL,
    [CauseId] int  NULL,
    [EffectGroupId] int  NULL,
    [EffectTypeId] int  NULL,
    [EffectId] int  NULL,
    [RiskGroupId] int  NULL,
    [JobTitle] nvarchar(200)  NULL,
    [ProbValue] decimal(9,2)  NULL,
    [ProbLevelId] int  NULL,
    [ImpactLevelId] int  NULL,
    [ImpactMoney] decimal(19,4)  NULL,
    [RiskLevel] int  NULL,
    [ApprovalDate] datetime  NULL,
    [CloseDate] datetime  NULL,
    [IsReadOnly] bit  NOT NULL,
    [RiskEventId] int  NULL,
    [bisnisid] int  NULL,
    [aktifitasid] int  NULL,
    [FRiskDate] datetime  NULL,
    [IsMultiCE] bit  NULL,
    [IsProbSet] bit  NULL,
    [IsImpactSet] bit  NULL,
    [BranchId] int  NULL,
    [RiskCatId] int  NULL,
    [RiskTypeId] int  NULL,
    [SubDeptId] int  NULL
);
GO

-- Creating table 'RiskCats'
CREATE TABLE [dbo].[RiskCats] (
    [RiskCatId] int  NOT NULL,
    [RiskCatName] nvarchar(200)  NOT NULL,
    [Grup] nvarchar(1)  NULL,
    [Status] bit  NOT NULL
);
GO

-- Creating table 'RiskCauses'
CREATE TABLE [dbo].[RiskCauses] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'RiskCauseLines'
CREATE TABLE [dbo].[RiskCauseLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomCause] nvarchar(max)  NOT NULL,
    [CauseTypeCauseTypeId] int  NOT NULL,
    [CauseCauseId] int  NOT NULL,
    [CauseGroupCauseGroupId] int  NOT NULL,
    [RiskRiskId] int  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RiskEffectLines'
CREATE TABLE [dbo].[RiskEffectLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomEffect] nvarchar(max)  NOT NULL,
    [EffectEffectId] int  NOT NULL,
    [EffectTypeEffectTypeId] int  NOT NULL,
    [EffectGroupEffectGroupId] int  NOT NULL,
    [RiskRiskId] int  NOT NULL,
    [Note] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KRINonInvests'
CREATE TABLE [dbo].[KRINonInvests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Division] nvarchar(max)  NOT NULL,
    [DivisionCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KRIInvests'
CREATE TABLE [dbo].[KRIInvests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Division] nvarchar(max)  NOT NULL,
    [DivisionCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KRINonInvestParameters'
CREATE TABLE [dbo].[KRINonInvestParameters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Target] decimal(18,2)  NULL,
    [Order] nvarchar(max)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [KRINonInvestId] int  NOT NULL,
    [Min1] decimal(18,2)  NULL,
    [Max1] decimal(18,2)  NULL,
    [Min2] decimal(18,2)  NOT NULL,
    [Max2] decimal(18,2)  NOT NULL,
    [Min3] decimal(18,2)  NOT NULL,
    [Max3] decimal(18,2)  NOT NULL,
    [Min4] decimal(18,2)  NULL,
    [Max4] decimal(18,2)  NULL
);
GO

-- Creating table 'KRIInvestParameters'
CREATE TABLE [dbo].[KRIInvestParameters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Target] decimal(18,2)  NULL,
    [Order] nvarchar(max)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [KRIInvestId] int  NOT NULL,
    [Min1] decimal(18,2)  NULL,
    [Max1] decimal(18,2)  NULL,
    [Min2] decimal(18,2)  NOT NULL,
    [Max2] decimal(18,2)  NOT NULL,
    [Min3] decimal(18,2)  NOT NULL,
    [Max3] decimal(18,2)  NOT NULL,
    [Min4] decimal(18,2)  NULL,
    [Max4] decimal(18,2)  NULL
);
GO

-- Creating table 'KRINonInvestDatas'
CREATE TABLE [dbo].[KRINonInvestDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] decimal(18,2)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Grade] nvarchar(max)  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [KRINonInvestId] int  NOT NULL,
    [Target] decimal(18,2)  NOT NULL,
    [TransactionDate] datetime  NOT NULL
);
GO

-- Creating table 'KRIInvestDatas'
CREATE TABLE [dbo].[KRIInvestDatas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] decimal(18,2)  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Grade] nvarchar(max)  NOT NULL,
    [UserId] uniqueidentifier  NOT NULL,
    [KRIInvestId] int  NOT NULL,
    [Target] decimal(18,2)  NOT NULL,
    [TransactionDate] datetime  NOT NULL
);
GO

-- Creating table 'LossEventKantorViews'
CREATE TABLE [dbo].[LossEventKantorViews] (
    [tanggal] datetime  NULL,
    [pemilik] nvarchar(200)  NULL,
    [id_pemilik] int  NULL,
    [LossEvent] nvarchar(300)  NULL,
    [jml_kasus] int  NOT NULL
);
GO

-- Creating table 'LossEventPemilikViews'
CREATE TABLE [dbo].[LossEventPemilikViews] (
    [tahun] int  NULL,
    [pemilik] nvarchar(200)  NULL,
    [id_pemilik] int  NULL,
    [Klasifikasi] nvarchar(50)  NULL,
    [id_klasifikasi] nvarchar(4)  NOT NULL,
    [Expr1] int  NULL,
    [Expr2] decimal(38,2)  NULL,
    [jml_kasus] int  NOT NULL,
    [ImpactFinancial] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'LossEventTahunViews'
CREATE TABLE [dbo].[LossEventTahunViews] (
    [tahun] int  NULL,
    [pemilik] nvarchar(200)  NULL,
    [id_pemilik] int  NULL,
    [LossEvent] nvarchar(300)  NULL,
    [Expr1] int  NULL,
    [Expr2] decimal(38,2)  NULL,
    [jml_kasus] int  NOT NULL,
    [ImpactFinancial] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'LossEventBulanViews'
CREATE TABLE [dbo].[LossEventBulanViews] (
    [tahun] int  NULL,
    [bulan] int  NULL,
    [pemilik] nvarchar(200)  NULL,
    [id_pemilik] int  NULL,
    [LossEvents] nvarchar(300)  NULL,
    [Expr1] int  NULL,
    [Expr2] decimal(38,2)  NULL,
    [jml_kasus] int  NOT NULL,
    [ImpactFinancial] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'SRNonInvests'
CREATE TABLE [dbo].[SRNonInvests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KRIDataId] int  NOT NULL,
    [CauseAnalysis] nvarchar(2000)  NOT NULL,
    [StrategicResponse] nvarchar(2000)  NOT NULL,
    [SubmitDate] datetime  NOT NULL
);
GO

-- Creating table 'SRNonInvestProgresses'
CREATE TABLE [dbo].[SRNonInvestProgresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SRId] int  NOT NULL,
    [PIC] nvarchar(2000)  NOT NULL,
    [Resources] nvarchar(2000)  NOT NULL,
    [FTargetDate] datetime  NOT NULL,
    [RKAPF] bit  NOT NULL
);
GO

-- Creating table 'SRNIProgressActions'
CREATE TABLE [dbo].[SRNIProgressActions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Detail] nvarchar(2000)  NOT NULL,
    [Progress] decimal(18,2)  NOT NULL,
    [Tanggal] datetime  NOT NULL,
    [SRNonInvestProgressId] int  NOT NULL
);
GO

-- Creating table 'KRIRisks'
CREATE TABLE [dbo].[KRIRisks] (
    [RiskId] int IDENTITY(1,1) NOT NULL,
    [RiskCode] nvarchar(20)  NOT NULL,
    [RiskName] nvarchar(2000)  NOT NULL,
    [RiskDate] datetime  NOT NULL,
    [OrgPos] int  NOT NULL,
    [OrgPosId] nvarchar(max)  NOT NULL,
    [JobTitle] nvarchar(200)  NULL,
    [ProbValue] decimal(9,2)  NULL,
    [ImpactMoney] decimal(19,4)  NULL,
    [RiskLevel] int  NULL,
    [ApprovalDate] datetime  NULL,
    [CloseDate] datetime  NULL,
    [IsReadOnly] bit  NOT NULL,
    [RiskEventId] int  NULL,
    [FRiskDate] datetime  NULL,
    [IsProbSet] bit  NULL,
    [IsImpactSet] bit  NULL,
    [KRIDataId] int  NOT NULL,
    [UserInfoUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'KRIRiskCauseLines'
CREATE TABLE [dbo].[KRIRiskCauseLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomCause] nvarchar(2000)  NOT NULL,
    [Note] nvarchar(2000)  NOT NULL,
    [CauseCauseId] int  NOT NULL,
    [CauseGroupCauseGroupId] int  NOT NULL,
    [CauseTypeCauseTypeId] int  NOT NULL,
    [KRIRiskRiskId] int  NOT NULL
);
GO

-- Creating table 'KRIRiskEffectLines'
CREATE TABLE [dbo].[KRIRiskEffectLines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomEffect] nvarchar(2000)  NOT NULL,
    [Note] nvarchar(2000)  NOT NULL,
    [EffectEffectId] int  NOT NULL,
    [EffectGroupEffectGroupId] int  NOT NULL,
    [EffectTypeEffectTypeId] int  NOT NULL,
    [KRIRiskRiskId] int  NOT NULL
);
GO

-- Creating table 'KRIRiskAttachments'
CREATE TABLE [dbo].[KRIRiskAttachments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AttachName] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(2000)  NOT NULL,
    [Filename] nvarchar(max)  NOT NULL,
    [ContentType] nvarchar(max)  NOT NULL,
    [ContentLength] int  NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [KRIRiskRiskId] int  NOT NULL
);
GO

-- Creating table 'KRIRiskApprovals'
CREATE TABLE [dbo].[KRIRiskApprovals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KRIRiskRiskId] int  NOT NULL,
    [OrgPos] int  NOT NULL,
    [OrgPosId] int  NOT NULL,
    [OrgName] nvarchar(max)  NOT NULL,
    [ApprovalDate] datetime  NOT NULL,
    [LimitDate] datetime  NOT NULL,
    [LastApproval] bit  NOT NULL,
    [IsReadOnly] bit  NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [UserInfoUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'KRIRiskMitigations'
CREATE TABLE [dbo].[KRIRiskMitigations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MitigationCode] nvarchar(max)  NOT NULL,
    [MitigationName] nvarchar(max)  NOT NULL,
    [InputDate] datetime  NOT NULL,
    [MitigationDate] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL,
    [RiskLevel] nvarchar(max)  NOT NULL,
    [LimitDate] nvarchar(max)  NOT NULL,
    [ApprovalDate] nvarchar(max)  NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [OrgPos] nvarchar(max)  NOT NULL,
    [OrgPosId] nvarchar(max)  NOT NULL,
    [IsReadOnly] nvarchar(max)  NOT NULL,
    [KRIRiskRiskId] int  NOT NULL
);
GO

-- Creating table 'KRIMitigationAttachments'
CREATE TABLE [dbo].[KRIMitigationAttachments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AttachName] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(2000)  NOT NULL,
    [Filename] nvarchar(max)  NOT NULL,
    [ContentType] nvarchar(max)  NOT NULL,
    [ContentLength] int  NOT NULL,
    [Data] varbinary(max)  NOT NULL,
    [KRIRiskMitigationId] int  NOT NULL
);
GO

-- Creating table 'KRIMitigationApprovals'
CREATE TABLE [dbo].[KRIMitigationApprovals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OrgPos] nvarchar(max)  NOT NULL,
    [OrgPosId] nvarchar(max)  NOT NULL,
    [OrgName] nvarchar(max)  NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [ApprovalDate] nvarchar(max)  NOT NULL,
    [LimitDate] nvarchar(max)  NOT NULL,
    [LastApproval] nvarchar(max)  NOT NULL,
    [IsReadOnly] nvarchar(max)  NOT NULL,
    [KRIRiskMitigationId] int  NOT NULL,
    [UserInfoUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'KRIMitigationActions'
CREATE TABLE [dbo].[KRIMitigationActions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PIC] nvarchar(max)  NOT NULL,
    [ActionCode] nvarchar(max)  NOT NULL,
    [ActionName] nvarchar(max)  NOT NULL,
    [ActionDate] nvarchar(max)  NOT NULL,
    [Require] nvarchar(max)  NOT NULL,
    [RKAPF] nvarchar(max)  NOT NULL,
    [RiskLevel] nvarchar(max)  NOT NULL,
    [LimitDate] nvarchar(max)  NOT NULL,
    [IsReadOnly] nvarchar(max)  NOT NULL,
    [TotalProgress] nvarchar(max)  NOT NULL,
    [Biaya] nvarchar(max)  NOT NULL,
    [PIC2] nvarchar(max)  NOT NULL,
    [KRIRiskMitigationId] int  NOT NULL
);
GO

-- Creating table 'KRIActionProgresses'
CREATE TABLE [dbo].[KRIActionProgresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActionProgress] nvarchar(max)  NOT NULL,
    [RecordDate] nvarchar(max)  NOT NULL,
    [KRIMitigationActionId] int  NOT NULL
);
GO

-- Creating table 'KRIActionApprovals'
CREATE TABLE [dbo].[KRIActionApprovals] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JobTitle] nvarchar(max)  NOT NULL,
    [ApprovalDate] nvarchar(max)  NOT NULL,
    [LastApproval] nvarchar(max)  NOT NULL,
    [IsReadOnly] nvarchar(max)  NOT NULL,
    [status] nvarchar(max)  NOT NULL,
    [KRIMitigationActionId] int  NOT NULL,
    [UserInfoUserId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'KRIRiskProbs'
CREATE TABLE [dbo].[KRIRiskProbs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProbOption] int  NOT NULL,
    [Poisson1] nvarchar(max)  NOT NULL,
    [Poisson2] nvarchar(max)  NOT NULL,
    [Binom1] nvarchar(max)  NOT NULL,
    [Binom2] nvarchar(max)  NOT NULL,
    [Approx1] decimal(18,2)  NOT NULL,
    [Approx2] decimal(18,2)  NOT NULL,
    [Approx3] decimal(18,2)  NOT NULL,
    [Compare] decimal(18,2)  NOT NULL,
    [ProbValue] decimal(9,2)  NOT NULL,
    [FreqFreqId] int  NOT NULL,
    [ProbLevelProbLevelId] int  NOT NULL,
    [KRIRiskRiskId] int  NOT NULL
);
GO

-- Creating table 'KRIRiskImpacts'
CREATE TABLE [dbo].[KRIRiskImpacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MoneyDirect] nvarchar(max)  NOT NULL,
    [MoneyIndirect] nvarchar(max)  NOT NULL,
    [ImpactLevelImpactLevelId] int  NOT NULL,
    [KRIRiskRiskId] int  NULL
);
GO

-- Creating table 'KRIRiskNonMoneyImpacts'
CREATE TABLE [dbo].[KRIRiskNonMoneyImpacts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KRIRiskRiskId] int  NULL,
    [ImpactDetailImpactDetailId] int  NOT NULL,
    [ImpactLevelImpactLevelId] int  NOT NULL,
    [ImpactTypeImpactTypeId] int  NOT NULL
);
GO

-- Creating table 'SRInvests'
CREATE TABLE [dbo].[SRInvests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CauseAnalysis] nvarchar(2000)  NOT NULL,
    [StrategicResponse] nvarchar(2000)  NOT NULL,
    [SubmitDate] datetime  NOT NULL,
    [KRIInvestDataId] int  NOT NULL
);
GO

-- Creating table 'SRInvestProgresses'
CREATE TABLE [dbo].[SRInvestProgresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PIC] nvarchar(2000)  NOT NULL,
    [Resources] nvarchar(2000)  NOT NULL,
    [FTargetDate] datetime  NOT NULL,
    [SRInvestId] int  NOT NULL,
    [RKAPF] bit  NOT NULL
);
GO

-- Creating table 'SRIProgressActions'
CREATE TABLE [dbo].[SRIProgressActions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Detail] nvarchar(2000)  NOT NULL,
    [Progress] decimal(18,2)  NOT NULL,
    [Tanggal] datetime  NOT NULL,
    [SRInvestProgressId] int  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CauseGroupId] in table 'CauseGroups'
ALTER TABLE [dbo].[CauseGroups]
ADD CONSTRAINT [PK_CauseGroups]
    PRIMARY KEY CLUSTERED ([CauseGroupId] ASC);
GO

-- Creating primary key on [CauseId] in table 'Causes'
ALTER TABLE [dbo].[Causes]
ADD CONSTRAINT [PK_Causes]
    PRIMARY KEY CLUSTERED ([CauseId] ASC);
GO

-- Creating primary key on [CauseTypeId] in table 'CauseTypes'
ALTER TABLE [dbo].[CauseTypes]
ADD CONSTRAINT [PK_CauseTypes]
    PRIMARY KEY CLUSTERED ([CauseTypeId] ASC);
GO

-- Creating primary key on [EffectGroupId] in table 'EffectGroups'
ALTER TABLE [dbo].[EffectGroups]
ADD CONSTRAINT [PK_EffectGroups]
    PRIMARY KEY CLUSTERED ([EffectGroupId] ASC);
GO

-- Creating primary key on [EffectId] in table 'Effects'
ALTER TABLE [dbo].[Effects]
ADD CONSTRAINT [PK_Effects]
    PRIMARY KEY CLUSTERED ([EffectId] ASC);
GO

-- Creating primary key on [EffectTypeId] in table 'EffectTypes'
ALTER TABLE [dbo].[EffectTypes]
ADD CONSTRAINT [PK_EffectTypes]
    PRIMARY KEY CLUSTERED ([EffectTypeId] ASC);
GO

-- Creating primary key on [RiskGroupId] in table 'RiskGroups'
ALTER TABLE [dbo].[RiskGroups]
ADD CONSTRAINT [PK_RiskGroups]
    PRIMARY KEY CLUSTERED ([RiskGroupId] ASC);
GO

-- Creating primary key on [RiskTypeId] in table 'RiskTypes'
ALTER TABLE [dbo].[RiskTypes]
ADD CONSTRAINT [PK_RiskTypes]
    PRIMARY KEY CLUSTERED ([RiskTypeId] ASC);
GO

-- Creating primary key on [DeptId] in table 'Depts'
ALTER TABLE [dbo].[Depts]
ADD CONSTRAINT [PK_Depts]
    PRIMARY KEY CLUSTERED ([DeptId] ASC);
GO

-- Creating primary key on [ClassId] in table 'BranchClasses'
ALTER TABLE [dbo].[BranchClasses]
ADD CONSTRAINT [PK_BranchClasses]
    PRIMARY KEY CLUSTERED ([ClassId] ASC);
GO

-- Creating primary key on [ProbLevelId] in table 'ProbLevels'
ALTER TABLE [dbo].[ProbLevels]
ADD CONSTRAINT [PK_ProbLevels]
    PRIMARY KEY CLUSTERED ([ProbLevelId] ASC);
GO

-- Creating primary key on [ImpactLevelId] in table 'ImpactLevels'
ALTER TABLE [dbo].[ImpactLevels]
ADD CONSTRAINT [PK_ImpactLevels]
    PRIMARY KEY CLUSTERED ([ImpactLevelId] ASC);
GO

-- Creating primary key on [ImpactCatId] in table 'ImpactCats'
ALTER TABLE [dbo].[ImpactCats]
ADD CONSTRAINT [PK_ImpactCats]
    PRIMARY KEY CLUSTERED ([ImpactCatId] ASC);
GO

-- Creating primary key on [ImpactDetailId] in table 'ImpactDetails'
ALTER TABLE [dbo].[ImpactDetails]
ADD CONSTRAINT [PK_ImpactDetails]
    PRIMARY KEY CLUSTERED ([ImpactDetailId] ASC);
GO

-- Creating primary key on [ImpactTypeId] in table 'ImpactTypes'
ALTER TABLE [dbo].[ImpactTypes]
ADD CONSTRAINT [PK_ImpactTypes]
    PRIMARY KEY CLUSTERED ([ImpactTypeId] ASC);
GO

-- Creating primary key on [MitigationCatId] in table 'MitigationCats'
ALTER TABLE [dbo].[MitigationCats]
ADD CONSTRAINT [PK_MitigationCats]
    PRIMARY KEY CLUSTERED ([MitigationCatId] ASC);
GO

-- Creating primary key on [MitigationTypeId] in table 'MitigationTypes'
ALTER TABLE [dbo].[MitigationTypes]
ADD CONSTRAINT [PK_MitigationTypes]
    PRIMARY KEY CLUSTERED ([MitigationTypeId] ASC);
GO

-- Creating primary key on [UserId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [PK_UserInfos]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Id] in table 'SerialNumbers'
ALTER TABLE [dbo].[SerialNumbers]
ADD CONSTRAINT [PK_SerialNumbers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FreqId] in table 'Freqs'
ALTER TABLE [dbo].[Freqs]
ADD CONSTRAINT [PK_Freqs]
    PRIMARY KEY CLUSTERED ([FreqId] ASC);
GO

-- Creating primary key on [RiskId] in table 'RiskProbs'
ALTER TABLE [dbo].[RiskProbs]
ADD CONSTRAINT [PK_RiskProbs]
    PRIMARY KEY CLUSTERED ([RiskId] ASC);
GO

-- Creating primary key on [RiskId] in table 'RiskImpacts'
ALTER TABLE [dbo].[RiskImpacts]
ADD CONSTRAINT [PK_RiskImpacts]
    PRIMARY KEY CLUSTERED ([RiskId] ASC);
GO

-- Creating primary key on [Id] in table 'RiskNonMoneyImpacts'
ALTER TABLE [dbo].[RiskNonMoneyImpacts]
ADD CONSTRAINT [PK_RiskNonMoneyImpacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AttachId] in table 'RiskAttachments'
ALTER TABLE [dbo].[RiskAttachments]
ADD CONSTRAINT [PK_RiskAttachments]
    PRIMARY KEY CLUSTERED ([AttachId] ASC);
GO

-- Creating primary key on [ApprovalId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [PK_RiskApprovals]
    PRIMARY KEY CLUSTERED ([ApprovalId] ASC);
GO

-- Creating primary key on [AttachId] in table 'MitigationAttachments'
ALTER TABLE [dbo].[MitigationAttachments]
ADD CONSTRAINT [PK_MitigationAttachments]
    PRIMARY KEY CLUSTERED ([AttachId] ASC);
GO

-- Creating primary key on [SubDeptId] in table 'SubDepts'
ALTER TABLE [dbo].[SubDepts]
ADD CONSTRAINT [PK_SubDepts]
    PRIMARY KEY CLUSTERED ([SubDeptId] ASC);
GO

-- Creating primary key on [DivisionId] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([DivisionId] ASC);
GO

-- Creating primary key on [SubDivId] in table 'SubDivs'
ALTER TABLE [dbo].[SubDivs]
ADD CONSTRAINT [PK_SubDivs]
    PRIMARY KEY CLUSTERED ([SubDivId] ASC);
GO

-- Creating primary key on [BranchId] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([BranchId] ASC);
GO

-- Creating primary key on [SubBranchId] in table 'SubBranches'
ALTER TABLE [dbo].[SubBranches]
ADD CONSTRAINT [PK_SubBranches]
    PRIMARY KEY CLUSTERED ([SubBranchId] ASC);
GO

-- Creating primary key on [BizUnitId] in table 'BizUnits'
ALTER TABLE [dbo].[BizUnits]
ADD CONSTRAINT [PK_BizUnits]
    PRIMARY KEY CLUSTERED ([BizUnitId] ASC);
GO

-- Creating primary key on [ImpactRefId] in table 'ImpactRefs'
ALTER TABLE [dbo].[ImpactRefs]
ADD CONSTRAINT [PK_ImpactRefs]
    PRIMARY KEY CLUSTERED ([ImpactRefId] ASC);
GO

-- Creating primary key on [StateId] in table 'RiskStates'
ALTER TABLE [dbo].[RiskStates]
ADD CONSTRAINT [PK_RiskStates]
    PRIMARY KEY CLUSTERED ([StateId] ASC);
GO

-- Creating primary key on [LevelId] in table 'RiskLevels'
ALTER TABLE [dbo].[RiskLevels]
ADD CONSTRAINT [PK_RiskLevels]
    PRIMARY KEY CLUSTERED ([LevelId] ASC);
GO

-- Creating primary key on [ApprovalId] in table 'MitigationApprovals'
ALTER TABLE [dbo].[MitigationApprovals]
ADD CONSTRAINT [PK_MitigationApprovals]
    PRIMARY KEY CLUSTERED ([ApprovalId] ASC);
GO

-- Creating primary key on [MitigationId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [PK_RiskMitigations]
    PRIMARY KEY CLUSTERED ([MitigationId] ASC);
GO

-- Creating primary key on [DocId] in table 'HelpDocs'
ALTER TABLE [dbo].[HelpDocs]
ADD CONSTRAINT [PK_HelpDocs]
    PRIMARY KEY CLUSTERED ([DocId] ASC);
GO

-- Creating primary key on [MenuId] in table 'HelpMenus'
ALTER TABLE [dbo].[HelpMenus]
ADD CONSTRAINT [PK_HelpMenus]
    PRIMARY KEY CLUSTERED ([MenuId] ASC);
GO

-- Creating primary key on [RiskEventID] in table 'RiskEvents'
ALTER TABLE [dbo].[RiskEvents]
ADD CONSTRAINT [PK_RiskEvents]
    PRIMARY KEY CLUSTERED ([RiskEventID] ASC);
GO

-- Creating primary key on [MitigationUnitId] in table 'MitigationUnits'
ALTER TABLE [dbo].[MitigationUnits]
ADD CONSTRAINT [PK_MitigationUnits]
    PRIMARY KEY CLUSTERED ([MitigationUnitId] ASC);
GO

-- Creating primary key on [bisnisid] in table 'bisnis'
ALTER TABLE [dbo].[bisnis]
ADD CONSTRAINT [PK_bisnis]
    PRIMARY KEY CLUSTERED ([bisnisid] ASC);
GO

-- Creating primary key on [aktifitasid] in table 'bisnis_aktifitas'
ALTER TABLE [dbo].[bisnis_aktifitas]
ADD CONSTRAINT [PK_bisnis_aktifitas]
    PRIMARY KEY CLUSTERED ([aktifitasid] ASC);
GO

-- Creating primary key on [UserId] in table 'aspnet_Profile'
ALTER TABLE [dbo].[aspnet_Profile]
ADD CONSTRAINT [PK_aspnet_Profile]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [ActionID] in table 'ActionApprovals'
ALTER TABLE [dbo].[ActionApprovals]
ADD CONSTRAINT [PK_ActionApprovals]
    PRIMARY KEY CLUSTERED ([ActionID] ASC);
GO

-- Creating primary key on [ActionProgressID] in table 'ActionProgresses'
ALTER TABLE [dbo].[ActionProgresses]
ADD CONSTRAINT [PK_ActionProgresses]
    PRIMARY KEY CLUSTERED ([ActionProgressID] ASC);
GO

-- Creating primary key on [ActionID] in table 'MitigationsActions'
ALTER TABLE [dbo].[MitigationsActions]
ADD CONSTRAINT [PK_MitigationsActions]
    PRIMARY KEY CLUSTERED ([ActionID] ASC);
GO

-- Creating primary key on [UserGroupID] in table 'UserGroups'
ALTER TABLE [dbo].[UserGroups]
ADD CONSTRAINT [PK_UserGroups]
    PRIMARY KEY CLUSTERED ([UserGroupID] ASC);
GO

-- Creating primary key on [KlasifikasiId] in table 'KlasifikasiKerugians'
ALTER TABLE [dbo].[KlasifikasiKerugians]
ADD CONSTRAINT [PK_KlasifikasiKerugians]
    PRIMARY KEY CLUSTERED ([KlasifikasiId] ASC);
GO

-- Creating primary key on [KorwilId] in table 'Korwils'
ALTER TABLE [dbo].[Korwils]
ADD CONSTRAINT [PK_Korwils]
    PRIMARY KEY CLUSTERED ([KorwilId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [LossEventId] in table 'LossEvents'
ALTER TABLE [dbo].[LossEvents]
ADD CONSTRAINT [PK_LossEvents]
    PRIMARY KEY CLUSTERED ([LossEventId] ASC);
GO

-- Creating primary key on [RiskId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [PK_Risks]
    PRIMARY KEY CLUSTERED ([RiskId] ASC);
GO

-- Creating primary key on [RiskCatId] in table 'RiskCats'
ALTER TABLE [dbo].[RiskCats]
ADD CONSTRAINT [PK_RiskCats]
    PRIMARY KEY CLUSTERED ([RiskCatId] ASC);
GO

-- Creating primary key on [Id] in table 'RiskCauses'
ALTER TABLE [dbo].[RiskCauses]
ADD CONSTRAINT [PK_RiskCauses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RiskCauseLines'
ALTER TABLE [dbo].[RiskCauseLines]
ADD CONSTRAINT [PK_RiskCauseLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RiskEffectLines'
ALTER TABLE [dbo].[RiskEffectLines]
ADD CONSTRAINT [PK_RiskEffectLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRINonInvests'
ALTER TABLE [dbo].[KRINonInvests]
ADD CONSTRAINT [PK_KRINonInvests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIInvests'
ALTER TABLE [dbo].[KRIInvests]
ADD CONSTRAINT [PK_KRIInvests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRINonInvestParameters'
ALTER TABLE [dbo].[KRINonInvestParameters]
ADD CONSTRAINT [PK_KRINonInvestParameters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIInvestParameters'
ALTER TABLE [dbo].[KRIInvestParameters]
ADD CONSTRAINT [PK_KRIInvestParameters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRINonInvestDatas'
ALTER TABLE [dbo].[KRINonInvestDatas]
ADD CONSTRAINT [PK_KRINonInvestDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIInvestDatas'
ALTER TABLE [dbo].[KRIInvestDatas]
ADD CONSTRAINT [PK_KRIInvestDatas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [jml_kasus] in table 'LossEventKantorViews'
ALTER TABLE [dbo].[LossEventKantorViews]
ADD CONSTRAINT [PK_LossEventKantorViews]
    PRIMARY KEY CLUSTERED ([jml_kasus] ASC);
GO

-- Creating primary key on [id_klasifikasi], [jml_kasus], [ImpactFinancial] in table 'LossEventPemilikViews'
ALTER TABLE [dbo].[LossEventPemilikViews]
ADD CONSTRAINT [PK_LossEventPemilikViews]
    PRIMARY KEY CLUSTERED ([id_klasifikasi], [jml_kasus], [ImpactFinancial] ASC);
GO

-- Creating primary key on [jml_kasus], [ImpactFinancial] in table 'LossEventTahunViews'
ALTER TABLE [dbo].[LossEventTahunViews]
ADD CONSTRAINT [PK_LossEventTahunViews]
    PRIMARY KEY CLUSTERED ([jml_kasus], [ImpactFinancial] ASC);
GO

-- Creating primary key on [jml_kasus], [ImpactFinancial] in table 'LossEventBulanViews'
ALTER TABLE [dbo].[LossEventBulanViews]
ADD CONSTRAINT [PK_LossEventBulanViews]
    PRIMARY KEY CLUSTERED ([jml_kasus], [ImpactFinancial] ASC);
GO

-- Creating primary key on [Id] in table 'SRNonInvests'
ALTER TABLE [dbo].[SRNonInvests]
ADD CONSTRAINT [PK_SRNonInvests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SRNonInvestProgresses'
ALTER TABLE [dbo].[SRNonInvestProgresses]
ADD CONSTRAINT [PK_SRNonInvestProgresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SRNIProgressActions'
ALTER TABLE [dbo].[SRNIProgressActions]
ADD CONSTRAINT [PK_SRNIProgressActions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RiskId] in table 'KRIRisks'
ALTER TABLE [dbo].[KRIRisks]
ADD CONSTRAINT [PK_KRIRisks]
    PRIMARY KEY CLUSTERED ([RiskId] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskCauseLines'
ALTER TABLE [dbo].[KRIRiskCauseLines]
ADD CONSTRAINT [PK_KRIRiskCauseLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskEffectLines'
ALTER TABLE [dbo].[KRIRiskEffectLines]
ADD CONSTRAINT [PK_KRIRiskEffectLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskAttachments'
ALTER TABLE [dbo].[KRIRiskAttachments]
ADD CONSTRAINT [PK_KRIRiskAttachments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskApprovals'
ALTER TABLE [dbo].[KRIRiskApprovals]
ADD CONSTRAINT [PK_KRIRiskApprovals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskMitigations'
ALTER TABLE [dbo].[KRIRiskMitigations]
ADD CONSTRAINT [PK_KRIRiskMitigations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIMitigationAttachments'
ALTER TABLE [dbo].[KRIMitigationAttachments]
ADD CONSTRAINT [PK_KRIMitigationAttachments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIMitigationApprovals'
ALTER TABLE [dbo].[KRIMitigationApprovals]
ADD CONSTRAINT [PK_KRIMitigationApprovals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIMitigationActions'
ALTER TABLE [dbo].[KRIMitigationActions]
ADD CONSTRAINT [PK_KRIMitigationActions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIActionProgresses'
ALTER TABLE [dbo].[KRIActionProgresses]
ADD CONSTRAINT [PK_KRIActionProgresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIActionApprovals'
ALTER TABLE [dbo].[KRIActionApprovals]
ADD CONSTRAINT [PK_KRIActionApprovals]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskProbs'
ALTER TABLE [dbo].[KRIRiskProbs]
ADD CONSTRAINT [PK_KRIRiskProbs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskImpacts'
ALTER TABLE [dbo].[KRIRiskImpacts]
ADD CONSTRAINT [PK_KRIRiskImpacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KRIRiskNonMoneyImpacts'
ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts]
ADD CONSTRAINT [PK_KRIRiskNonMoneyImpacts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SRInvests'
ALTER TABLE [dbo].[SRInvests]
ADD CONSTRAINT [PK_SRInvests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SRInvestProgresses'
ALTER TABLE [dbo].[SRInvestProgresses]
ADD CONSTRAINT [PK_SRInvestProgresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SRIProgressActions'
ALTER TABLE [dbo].[SRIProgressActions]
ADD CONSTRAINT [PK_SRIProgressActions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- Creating foreign key on [CauseGroupId] in table 'CauseTypes'
ALTER TABLE [dbo].[CauseTypes]
ADD CONSTRAINT [FK_CauseTypes_CauseGroups]
    FOREIGN KEY ([CauseGroupId])
    REFERENCES [dbo].[CauseGroups]
        ([CauseGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseTypes_CauseGroups'
CREATE INDEX [IX_FK_CauseTypes_CauseGroups]
ON [dbo].[CauseTypes]
    ([CauseGroupId]);
GO

-- Creating foreign key on [CauseGroupId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_CauseGroups]
    FOREIGN KEY ([CauseGroupId])
    REFERENCES [dbo].[CauseGroups]
        ([CauseGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_CauseGroups'
CREATE INDEX [IX_FK_Risks_CauseGroups]
ON [dbo].[Risks]
    ([CauseGroupId]);
GO

-- Creating foreign key on [CauseTypeId] in table 'Causes'
ALTER TABLE [dbo].[Causes]
ADD CONSTRAINT [FK_Causes_CauseTypes]
    FOREIGN KEY ([CauseTypeId])
    REFERENCES [dbo].[CauseTypes]
        ([CauseTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Causes_CauseTypes'
CREATE INDEX [IX_FK_Causes_CauseTypes]
ON [dbo].[Causes]
    ([CauseTypeId]);
GO

-- Creating foreign key on [CauseId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_Causes]
    FOREIGN KEY ([CauseId])
    REFERENCES [dbo].[Causes]
        ([CauseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_Causes'
CREATE INDEX [IX_FK_Risks_Causes]
ON [dbo].[Risks]
    ([CauseId]);
GO

-- Creating foreign key on [EffectGroupId] in table 'EffectTypes'
ALTER TABLE [dbo].[EffectTypes]
ADD CONSTRAINT [FK_EffectTypes_EffectGroups]
    FOREIGN KEY ([EffectGroupId])
    REFERENCES [dbo].[EffectGroups]
        ([EffectGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EffectTypes_EffectGroups'
CREATE INDEX [IX_FK_EffectTypes_EffectGroups]
ON [dbo].[EffectTypes]
    ([EffectGroupId]);
GO

-- Creating foreign key on [EffectGroupId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_EffectGroups]
    FOREIGN KEY ([EffectGroupId])
    REFERENCES [dbo].[EffectGroups]
        ([EffectGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_EffectGroups'
CREATE INDEX [IX_FK_Risks_EffectGroups]
ON [dbo].[Risks]
    ([EffectGroupId]);
GO

-- Creating foreign key on [EffectTypeId] in table 'Effects'
ALTER TABLE [dbo].[Effects]
ADD CONSTRAINT [FK_Effects_EffectTypes]
    FOREIGN KEY ([EffectTypeId])
    REFERENCES [dbo].[EffectTypes]
        ([EffectTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Effects_EffectTypes'
CREATE INDEX [IX_FK_Effects_EffectTypes]
ON [dbo].[Effects]
    ([EffectTypeId]);
GO

-- Creating foreign key on [EffectId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_Effects]
    FOREIGN KEY ([EffectId])
    REFERENCES [dbo].[Effects]
        ([EffectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_Effects'
CREATE INDEX [IX_FK_Risks_Effects]
ON [dbo].[Risks]
    ([EffectId]);
GO

-- Creating foreign key on [RiskGroupId] in table 'RiskTypes'
ALTER TABLE [dbo].[RiskTypes]
ADD CONSTRAINT [FK_RiskTypes_RiskGroups]
    FOREIGN KEY ([RiskGroupId])
    REFERENCES [dbo].[RiskGroups]
        ([RiskGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskTypes_RiskGroups'
CREATE INDEX [IX_FK_RiskTypes_RiskGroups]
ON [dbo].[RiskTypes]
    ([RiskGroupId]);
GO

-- Creating foreign key on [RiskGroupId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_RiskGroups]
    FOREIGN KEY ([RiskGroupId])
    REFERENCES [dbo].[RiskGroups]
        ([RiskGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_RiskGroups'
CREATE INDEX [IX_FK_Risks_RiskGroups]
ON [dbo].[Risks]
    ([RiskGroupId]);
GO

-- Creating foreign key on [RiskCatId] in table 'RiskGroups'
ALTER TABLE [dbo].[RiskGroups]
ADD CONSTRAINT [FK_RiskGroups_RiskCats]
    FOREIGN KEY ([RiskCatId])
    REFERENCES [dbo].[RiskCats]
        ([RiskCatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskGroups_RiskCats'
CREATE INDEX [IX_FK_RiskGroups_RiskCats]
ON [dbo].[RiskGroups]
    ([RiskCatId]);
GO

-- Creating foreign key on [DeptId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_UserInfos_Depts]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Depts]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfos_Depts'
CREATE INDEX [IX_FK_UserInfos_Depts]
ON [dbo].[UserInfos]
    ([DeptId]);
GO

-- Creating foreign key on [DeptId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [FK_RiskApprovals_Depts]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Depts]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskApprovals_Depts'
CREATE INDEX [IX_FK_RiskApprovals_Depts]
ON [dbo].[RiskApprovals]
    ([DeptId]);
GO

-- Creating foreign key on [DeptId] in table 'SubDepts'
ALTER TABLE [dbo].[SubDepts]
ADD CONSTRAINT [FK_SubDepts_Depts]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Depts]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubDepts_Depts'
CREATE INDEX [IX_FK_SubDepts_Depts]
ON [dbo].[SubDepts]
    ([DeptId]);
GO

-- Creating foreign key on [DeptId] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [FK_Divisions_Depts]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Depts]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Divisions_Depts'
CREATE INDEX [IX_FK_Divisions_Depts]
ON [dbo].[Divisions]
    ([DeptId]);
GO

-- Creating foreign key on [DeptId] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [FK_Branches_Depts]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Depts]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Branches_Depts'
CREATE INDEX [IX_FK_Branches_Depts]
ON [dbo].[Branches]
    ([DeptId]);
GO

-- Creating foreign key on [DeptId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_Depts]
    FOREIGN KEY ([DeptId])
    REFERENCES [dbo].[Depts]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_Depts'
CREATE INDEX [IX_FK_Risks_Depts]
ON [dbo].[Risks]
    ([DeptId]);
GO

-- Creating foreign key on [ClassId] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [FK_Branches_BranchClasses]
    FOREIGN KEY ([ClassId])
    REFERENCES [dbo].[BranchClasses]
        ([ClassId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Branches_BranchClasses'
CREATE INDEX [IX_FK_Branches_BranchClasses]
ON [dbo].[Branches]
    ([ClassId]);
GO

-- Creating foreign key on [ProbLevelId] in table 'RiskProbs'
ALTER TABLE [dbo].[RiskProbs]
ADD CONSTRAINT [FK_RiskProbs_ProbLevels]
    FOREIGN KEY ([ProbLevelId])
    REFERENCES [dbo].[ProbLevels]
        ([ProbLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskProbs_ProbLevels'
CREATE INDEX [IX_FK_RiskProbs_ProbLevels]
ON [dbo].[RiskProbs]
    ([ProbLevelId]);
GO

-- Creating foreign key on [ProbLevelId] in table 'RiskStates'
ALTER TABLE [dbo].[RiskStates]
ADD CONSTRAINT [FK_RiskStates_ProbLevels]
    FOREIGN KEY ([ProbLevelId])
    REFERENCES [dbo].[ProbLevels]
        ([ProbLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskStates_ProbLevels'
CREATE INDEX [IX_FK_RiskStates_ProbLevels]
ON [dbo].[RiskStates]
    ([ProbLevelId]);
GO

-- Creating foreign key on [ProbLevelId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [FK_RiskMitigations_ProbLevels]
    FOREIGN KEY ([ProbLevelId])
    REFERENCES [dbo].[ProbLevels]
        ([ProbLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskMitigations_ProbLevels'
CREATE INDEX [IX_FK_RiskMitigations_ProbLevels]
ON [dbo].[RiskMitigations]
    ([ProbLevelId]);
GO

-- Creating foreign key on [ProbLevelId] in table 'MitigationsActions'
ALTER TABLE [dbo].[MitigationsActions]
ADD CONSTRAINT [FK_MITIGATI_REFERENCE_PROBLEVE]
    FOREIGN KEY ([ProbLevelId])
    REFERENCES [dbo].[ProbLevels]
        ([ProbLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MITIGATI_REFERENCE_PROBLEVE'
CREATE INDEX [IX_FK_MITIGATI_REFERENCE_PROBLEVE]
ON [dbo].[MitigationsActions]
    ([ProbLevelId]);
GO

-- Creating foreign key on [ProbLevelId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_ProbLevels]
    FOREIGN KEY ([ProbLevelId])
    REFERENCES [dbo].[ProbLevels]
        ([ProbLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_ProbLevels'
CREATE INDEX [IX_FK_Risks_ProbLevels]
ON [dbo].[Risks]
    ([ProbLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'ImpactDetails'
ALTER TABLE [dbo].[ImpactDetails]
ADD CONSTRAINT [FK_ImpactDetails_ImpactLevels]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactDetails_ImpactLevels'
CREATE INDEX [IX_FK_ImpactDetails_ImpactLevels]
ON [dbo].[ImpactDetails]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'RiskImpacts'
ALTER TABLE [dbo].[RiskImpacts]
ADD CONSTRAINT [FK_RiskImpacts_ImpactLevels]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskImpacts_ImpactLevels'
CREATE INDEX [IX_FK_RiskImpacts_ImpactLevels]
ON [dbo].[RiskImpacts]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'RiskNonMoneyImpacts'
ALTER TABLE [dbo].[RiskNonMoneyImpacts]
ADD CONSTRAINT [FK_RiskNonMoneyImpacts_ImpactLevels]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskNonMoneyImpacts_ImpactLevels'
CREATE INDEX [IX_FK_RiskNonMoneyImpacts_ImpactLevels]
ON [dbo].[RiskNonMoneyImpacts]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'RiskStates'
ALTER TABLE [dbo].[RiskStates]
ADD CONSTRAINT [FK_RiskStates_ImpactLevels]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskStates_ImpactLevels'
CREATE INDEX [IX_FK_RiskStates_ImpactLevels]
ON [dbo].[RiskStates]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [FK_RiskMitigations_ImpactLevels]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskMitigations_ImpactLevels'
CREATE INDEX [IX_FK_RiskMitigations_ImpactLevels]
ON [dbo].[RiskMitigations]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'MitigationsActions'
ALTER TABLE [dbo].[MitigationsActions]
ADD CONSTRAINT [FK_MITIGATI_REFERENCE_IMPACTLE]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MITIGATI_REFERENCE_IMPACTLE'
CREATE INDEX [IX_FK_MITIGATI_REFERENCE_IMPACTLE]
ON [dbo].[MitigationsActions]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactLevelId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_ImpactLevels]
    FOREIGN KEY ([ImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_ImpactLevels'
CREATE INDEX [IX_FK_Risks_ImpactLevels]
ON [dbo].[Risks]
    ([ImpactLevelId]);
GO

-- Creating foreign key on [ImpactCatId] in table 'ImpactTypes'
ALTER TABLE [dbo].[ImpactTypes]
ADD CONSTRAINT [FK_ImpactTypes_ImpactCats]
    FOREIGN KEY ([ImpactCatId])
    REFERENCES [dbo].[ImpactCats]
        ([ImpactCatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactTypes_ImpactCats'
CREATE INDEX [IX_FK_ImpactTypes_ImpactCats]
ON [dbo].[ImpactTypes]
    ([ImpactCatId]);
GO

-- Creating foreign key on [MitigationCatId] in table 'MitigationTypes'
ALTER TABLE [dbo].[MitigationTypes]
ADD CONSTRAINT [FK_MitigationTypes_MitigationCats]
    FOREIGN KEY ([MitigationCatId])
    REFERENCES [dbo].[MitigationCats]
        ([MitigationCatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MitigationTypes_MitigationCats'
CREATE INDEX [IX_FK_MitigationTypes_MitigationCats]
ON [dbo].[MitigationTypes]
    ([MitigationCatId]);
GO

-- Creating foreign key on [MitigationCatId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [FK_RiskMitigations_MitigationCats]
    FOREIGN KEY ([MitigationCatId])
    REFERENCES [dbo].[MitigationCats]
        ([MitigationCatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskMitigations_MitigationCats'
CREATE INDEX [IX_FK_RiskMitigations_MitigationCats]
ON [dbo].[RiskMitigations]
    ([MitigationCatId]);
GO

-- Creating foreign key on [FreqId] in table 'RiskProbs'
ALTER TABLE [dbo].[RiskProbs]
ADD CONSTRAINT [FK_RiskProbs_Freqs]
    FOREIGN KEY ([FreqId])
    REFERENCES [dbo].[Freqs]
        ([FreqId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskProbs_Freqs'
CREATE INDEX [IX_FK_RiskProbs_Freqs]
ON [dbo].[RiskProbs]
    ([FreqId]);
GO

-- Creating foreign key on [ImpactDetailId] in table 'RiskNonMoneyImpacts'
ALTER TABLE [dbo].[RiskNonMoneyImpacts]
ADD CONSTRAINT [FK_RiskNonMoneyImpacts_ImpactDetails]
    FOREIGN KEY ([ImpactDetailId])
    REFERENCES [dbo].[ImpactDetails]
        ([ImpactDetailId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskNonMoneyImpacts_ImpactDetails'
CREATE INDEX [IX_FK_RiskNonMoneyImpacts_ImpactDetails]
ON [dbo].[RiskNonMoneyImpacts]
    ([ImpactDetailId]);
GO

-- Creating foreign key on [RiskId] in table 'RiskAttachments'
ALTER TABLE [dbo].[RiskAttachments]
ADD CONSTRAINT [FK_RiskAttachments_Risks]
    FOREIGN KEY ([RiskId])
    REFERENCES [dbo].[Risks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskAttachments_Risks'
CREATE INDEX [IX_FK_RiskAttachments_Risks]
ON [dbo].[RiskAttachments]
    ([RiskId]);
GO

-- Creating foreign key on [MitigationId] in table 'MitigationAttachments'
ALTER TABLE [dbo].[MitigationAttachments]
ADD CONSTRAINT [FK_MitigationAttachments_RiskMitigations]
    FOREIGN KEY ([MitigationId])
    REFERENCES [dbo].[RiskMitigations]
        ([MitigationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MitigationAttachments_RiskMitigations'
CREATE INDEX [IX_FK_MitigationAttachments_RiskMitigations]
ON [dbo].[MitigationAttachments]
    ([MitigationId]);
GO

-- Creating foreign key on [DivisionId] in table 'SubDivs'
ALTER TABLE [dbo].[SubDivs]
ADD CONSTRAINT [FK_SubDivs_Divisions]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([DivisionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubDivs_Divisions'
CREATE INDEX [IX_FK_SubDivs_Divisions]
ON [dbo].[SubDivs]
    ([DivisionId]);
GO

-- Creating foreign key on [SubDivId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [FK_RiskApprovals_SubDivs]
    FOREIGN KEY ([SubDivId])
    REFERENCES [dbo].[SubDivs]
        ([SubDivId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskApprovals_SubDivs'
CREATE INDEX [IX_FK_RiskApprovals_SubDivs]
ON [dbo].[RiskApprovals]
    ([SubDivId]);
GO

-- Creating foreign key on [SubDivId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_UserInfos_SubDivs]
    FOREIGN KEY ([SubDivId])
    REFERENCES [dbo].[SubDivs]
        ([SubDivId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfos_SubDivs'
CREATE INDEX [IX_FK_UserInfos_SubDivs]
ON [dbo].[UserInfos]
    ([SubDivId]);
GO

-- Creating foreign key on [SubDivId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_SubDivs]
    FOREIGN KEY ([SubDivId])
    REFERENCES [dbo].[SubDivs]
        ([SubDivId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_SubDivs'
CREATE INDEX [IX_FK_Risks_SubDivs]
ON [dbo].[Risks]
    ([SubDivId]);
GO

-- Creating foreign key on [BranchId] in table 'SubBranches'
ALTER TABLE [dbo].[SubBranches]
ADD CONSTRAINT [FK_SubBranches_Branches]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([BranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubBranches_Branches'
CREATE INDEX [IX_FK_SubBranches_Branches]
ON [dbo].[SubBranches]
    ([BranchId]);
GO

-- Creating foreign key on [SubBranchId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [FK_RiskApprovals_SubBranches]
    FOREIGN KEY ([SubBranchId])
    REFERENCES [dbo].[SubBranches]
        ([SubBranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskApprovals_SubBranches'
CREATE INDEX [IX_FK_RiskApprovals_SubBranches]
ON [dbo].[RiskApprovals]
    ([SubBranchId]);
GO

-- Creating foreign key on [SubBranchId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_UserInfos_SubBranches]
    FOREIGN KEY ([SubBranchId])
    REFERENCES [dbo].[SubBranches]
        ([SubBranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfos_SubBranches'
CREATE INDEX [IX_FK_UserInfos_SubBranches]
ON [dbo].[UserInfos]
    ([SubBranchId]);
GO

-- Creating foreign key on [SubBranchId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_SubBranches]
    FOREIGN KEY ([SubBranchId])
    REFERENCES [dbo].[SubBranches]
        ([SubBranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_SubBranches'
CREATE INDEX [IX_FK_Risks_SubBranches]
ON [dbo].[Risks]
    ([SubBranchId]);
GO

-- Creating foreign key on [BranchId] in table 'BizUnits'
ALTER TABLE [dbo].[BizUnits]
ADD CONSTRAINT [FK_BizUnits_Branches]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([BranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BizUnits_Branches'
CREATE INDEX [IX_FK_BizUnits_Branches]
ON [dbo].[BizUnits]
    ([BranchId]);
GO

-- Creating foreign key on [BizUnitId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [FK_RiskApprovals_BizUnits]
    FOREIGN KEY ([BizUnitId])
    REFERENCES [dbo].[BizUnits]
        ([BizUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskApprovals_BizUnits'
CREATE INDEX [IX_FK_RiskApprovals_BizUnits]
ON [dbo].[RiskApprovals]
    ([BizUnitId]);
GO

-- Creating foreign key on [BizUnitId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_UserInfos_BizUnits]
    FOREIGN KEY ([BizUnitId])
    REFERENCES [dbo].[BizUnits]
        ([BizUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfos_BizUnits'
CREATE INDEX [IX_FK_UserInfos_BizUnits]
ON [dbo].[UserInfos]
    ([BizUnitId]);
GO

-- Creating foreign key on [BizUnitId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_BizUnits]
    FOREIGN KEY ([BizUnitId])
    REFERENCES [dbo].[BizUnits]
        ([BizUnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_BizUnits'
CREATE INDEX [IX_FK_Risks_BizUnits]
ON [dbo].[Risks]
    ([BizUnitId]);
GO

-- Creating foreign key on [UserId] in table 'MitigationApprovals'
ALTER TABLE [dbo].[MitigationApprovals]
ADD CONSTRAINT [FK_MitigationApprovals_UserInfos]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MitigationApprovals_UserInfos'
CREATE INDEX [IX_FK_MitigationApprovals_UserInfos]
ON [dbo].[MitigationApprovals]
    ([UserId]);
GO

-- Creating foreign key on [MitigationId] in table 'MitigationApprovals'
ALTER TABLE [dbo].[MitigationApprovals]
ADD CONSTRAINT [FK_MitigationApprovals_RiskMitigations]
    FOREIGN KEY ([MitigationId])
    REFERENCES [dbo].[RiskMitigations]
        ([MitigationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MitigationApprovals_RiskMitigations'
CREATE INDEX [IX_FK_MitigationApprovals_RiskMitigations]
ON [dbo].[MitigationApprovals]
    ([MitigationId]);
GO

-- Creating foreign key on [MenuId] in table 'HelpDocs'
ALTER TABLE [dbo].[HelpDocs]
ADD CONSTRAINT [FK_HelpDocs_HelpMenus]
    FOREIGN KEY ([MenuId])
    REFERENCES [dbo].[HelpMenus]
        ([MenuId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_HelpDocs_HelpMenus'
CREATE INDEX [IX_FK_HelpDocs_HelpMenus]
ON [dbo].[HelpDocs]
    ([MenuId]);
GO

-- Creating foreign key on [RiskTypeId] in table 'RiskEvents'
ALTER TABLE [dbo].[RiskEvents]
ADD CONSTRAINT [FK_RiskEvent_RiskTypes]
    FOREIGN KEY ([RiskTypeId])
    REFERENCES [dbo].[RiskTypes]
        ([RiskTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskEvent_RiskTypes'
CREATE INDEX [IX_FK_RiskEvent_RiskTypes]
ON [dbo].[RiskEvents]
    ([RiskTypeId]);
GO

-- Creating foreign key on [RiskEventId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_RiskEvent]
    FOREIGN KEY ([RiskEventId])
    REFERENCES [dbo].[RiskEvents]
        ([RiskEventID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_RiskEvent'
CREATE INDEX [IX_FK_Risks_RiskEvent]
ON [dbo].[Risks]
    ([RiskEventId]);
GO

-- Creating foreign key on [DivisionId] in table 'MitigationUnits'
ALTER TABLE [dbo].[MitigationUnits]
ADD CONSTRAINT [FK_Mitigationunit2]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([DivisionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mitigationunit2'
CREATE INDEX [IX_FK_Mitigationunit2]
ON [dbo].[MitigationUnits]
    ([DivisionId]);
GO

-- Creating foreign key on [MitigationId] in table 'MitigationUnits'
ALTER TABLE [dbo].[MitigationUnits]
ADD CONSTRAINT [FK_Mitigationunit1]
    FOREIGN KEY ([MitigationId])
    REFERENCES [dbo].[RiskMitigations]
        ([MitigationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Mitigationunit1'
CREATE INDEX [IX_FK_Mitigationunit1]
ON [dbo].[MitigationUnits]
    ([MitigationId]);
GO

-- Creating foreign key on [bisnisid] in table 'bisnis_aktifitas'
ALTER TABLE [dbo].[bisnis_aktifitas]
ADD CONSTRAINT [FK_BISNIS_A_REFERENCE_BISNIS]
    FOREIGN KEY ([bisnisid])
    REFERENCES [dbo].[bisnis]
        ([bisnisid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BISNIS_A_REFERENCE_BISNIS'
CREATE INDEX [IX_FK_BISNIS_A_REFERENCE_BISNIS]
ON [dbo].[bisnis_aktifitas]
    ([bisnisid]);
GO

-- Creating foreign key on [bisnisid] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_Risks_bisnis]
    FOREIGN KEY ([bisnisid])
    REFERENCES [dbo].[bisnis]
        ([bisnisid])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Risks_bisnis'
CREATE INDEX [IX_FK_Risks_bisnis]
ON [dbo].[Risks]
    ([bisnisid]);
GO

-- Creating foreign key on [ActionID] in table 'ActionApprovals'
ALTER TABLE [dbo].[ActionApprovals]
ADD CONSTRAINT [FK_ACTIONAP_REFERENCE_MITIGATI]
    FOREIGN KEY ([ActionID])
    REFERENCES [dbo].[MitigationsActions]
        ([ActionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'ActionApprovals'
ALTER TABLE [dbo].[ActionApprovals]
ADD CONSTRAINT [FK_ACTIONAP_REFERENCE_USERINFO]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ACTIONAP_REFERENCE_USERINFO'
CREATE INDEX [IX_FK_ACTIONAP_REFERENCE_USERINFO]
ON [dbo].[ActionApprovals]
    ([UserId]);
GO

-- Creating foreign key on [ActionID] in table 'ActionProgresses'
ALTER TABLE [dbo].[ActionProgresses]
ADD CONSTRAINT [FK_ACTIONPR_REFERENCE_MITIGATI]
    FOREIGN KEY ([ActionID])
    REFERENCES [dbo].[MitigationsActions]
        ([ActionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ACTIONPR_REFERENCE_MITIGATI'
CREATE INDEX [IX_FK_ACTIONPR_REFERENCE_MITIGATI]
ON [dbo].[ActionProgresses]
    ([ActionID]);
GO

-- Creating foreign key on [AspNetUser_Id] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_AspNetUserUserInfo]
    FOREIGN KEY ([AspNetUser_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserUserInfo'
CREATE INDEX [IX_FK_AspNetUserUserInfo]
ON [dbo].[UserInfos]
    ([AspNetUser_Id]);
GO

-- Creating foreign key on [CauseTypeCauseTypeId] in table 'RiskCauseLines'
ALTER TABLE [dbo].[RiskCauseLines]
ADD CONSTRAINT [FK_RiskCauseLineCauseType]
    FOREIGN KEY ([CauseTypeCauseTypeId])
    REFERENCES [dbo].[CauseTypes]
        ([CauseTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskCauseLineCauseType'
CREATE INDEX [IX_FK_RiskCauseLineCauseType]
ON [dbo].[RiskCauseLines]
    ([CauseTypeCauseTypeId]);
GO

-- Creating foreign key on [CauseCauseId] in table 'RiskCauseLines'
ALTER TABLE [dbo].[RiskCauseLines]
ADD CONSTRAINT [FK_RiskCauseLineCause1]
    FOREIGN KEY ([CauseCauseId])
    REFERENCES [dbo].[Causes]
        ([CauseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskCauseLineCause1'
CREATE INDEX [IX_FK_RiskCauseLineCause1]
ON [dbo].[RiskCauseLines]
    ([CauseCauseId]);
GO

-- Creating foreign key on [CauseGroupCauseGroupId] in table 'RiskCauseLines'
ALTER TABLE [dbo].[RiskCauseLines]
ADD CONSTRAINT [FK_CauseGroupRiskCauseLine]
    FOREIGN KEY ([CauseGroupCauseGroupId])
    REFERENCES [dbo].[CauseGroups]
        ([CauseGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseGroupRiskCauseLine'
CREATE INDEX [IX_FK_CauseGroupRiskCauseLine]
ON [dbo].[RiskCauseLines]
    ([CauseGroupCauseGroupId]);
GO

-- Creating foreign key on [EffectEffectId] in table 'RiskEffectLines'
ALTER TABLE [dbo].[RiskEffectLines]
ADD CONSTRAINT [FK_RiskEffectLineEffect]
    FOREIGN KEY ([EffectEffectId])
    REFERENCES [dbo].[Effects]
        ([EffectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskEffectLineEffect'
CREATE INDEX [IX_FK_RiskEffectLineEffect]
ON [dbo].[RiskEffectLines]
    ([EffectEffectId]);
GO

-- Creating foreign key on [EffectTypeEffectTypeId] in table 'RiskEffectLines'
ALTER TABLE [dbo].[RiskEffectLines]
ADD CONSTRAINT [FK_EffectTypeRiskEffectLine]
    FOREIGN KEY ([EffectTypeEffectTypeId])
    REFERENCES [dbo].[EffectTypes]
        ([EffectTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EffectTypeRiskEffectLine'
CREATE INDEX [IX_FK_EffectTypeRiskEffectLine]
ON [dbo].[RiskEffectLines]
    ([EffectTypeEffectTypeId]);
GO

-- Creating foreign key on [EffectGroupEffectGroupId] in table 'RiskEffectLines'
ALTER TABLE [dbo].[RiskEffectLines]
ADD CONSTRAINT [FK_RiskEffectLineEffectGroup]
    FOREIGN KEY ([EffectGroupEffectGroupId])
    REFERENCES [dbo].[EffectGroups]
        ([EffectGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskEffectLineEffectGroup'
CREATE INDEX [IX_FK_RiskEffectLineEffectGroup]
ON [dbo].[RiskEffectLines]
    ([EffectGroupEffectGroupId]);
GO

-- Creating foreign key on [RiskRiskId] in table 'RiskCauseLines'
ALTER TABLE [dbo].[RiskCauseLines]
ADD CONSTRAINT [FK_RiskCauseLineRisk]
    FOREIGN KEY ([RiskRiskId])
    REFERENCES [dbo].[Risks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskCauseLineRisk'
CREATE INDEX [IX_FK_RiskCauseLineRisk]
ON [dbo].[RiskCauseLines]
    ([RiskRiskId]);
GO

-- Creating foreign key on [RiskRiskId] in table 'RiskEffectLines'
ALTER TABLE [dbo].[RiskEffectLines]
ADD CONSTRAINT [FK_RiskEffectLineRisk]
    FOREIGN KEY ([RiskRiskId])
    REFERENCES [dbo].[Risks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskEffectLineRisk'
CREATE INDEX [IX_FK_RiskEffectLineRisk]
ON [dbo].[RiskEffectLines]
    ([RiskRiskId]);
GO

-- Creating foreign key on [RiskId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [FK_RiskRiskMitigation]
    FOREIGN KEY ([RiskId])
    REFERENCES [dbo].[Risks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskRiskMitigation'
CREATE INDEX [IX_FK_RiskRiskMitigation]
ON [dbo].[RiskMitigations]
    ([RiskId]);
GO

-- Creating foreign key on [RiskId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [FK_RiskRiskApproval]
    FOREIGN KEY ([RiskId])
    REFERENCES [dbo].[Risks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskRiskApproval'
CREATE INDEX [IX_FK_RiskRiskApproval]
ON [dbo].[RiskApprovals]
    ([RiskId]);
GO

-- Creating foreign key on [UserId] in table 'RiskApprovals'
ALTER TABLE [dbo].[RiskApprovals]
ADD CONSTRAINT [FK_UserInfoRiskApproval]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRiskApproval'
CREATE INDEX [IX_FK_UserInfoRiskApproval]
ON [dbo].[RiskApprovals]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_UserInfoRisk]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRisk'
CREATE INDEX [IX_FK_UserInfoRisk]
ON [dbo].[Risks]
    ([UserId]);
GO

-- Creating foreign key on [DivisionId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_DivisionRisk]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([DivisionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DivisionRisk'
CREATE INDEX [IX_FK_DivisionRisk]
ON [dbo].[Risks]
    ([DivisionId]);
GO

-- Creating foreign key on [ImpactTypeId] in table 'RiskNonMoneyImpacts'
ALTER TABLE [dbo].[RiskNonMoneyImpacts]
ADD CONSTRAINT [FK_ImpactTypeRiskNonMoneyImpact]
    FOREIGN KEY ([ImpactTypeId])
    REFERENCES [dbo].[ImpactTypes]
        ([ImpactTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactTypeRiskNonMoneyImpact'
CREATE INDEX [IX_FK_ImpactTypeRiskNonMoneyImpact]
ON [dbo].[RiskNonMoneyImpacts]
    ([ImpactTypeId]);
GO

-- Creating foreign key on [ImpactTypeId] in table 'ImpactDetails'
ALTER TABLE [dbo].[ImpactDetails]
ADD CONSTRAINT [FK_ImpactTypeImpactDetail]
    FOREIGN KEY ([ImpactTypeId])
    REFERENCES [dbo].[ImpactTypes]
        ([ImpactTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactTypeImpactDetail'
CREATE INDEX [IX_FK_ImpactTypeImpactDetail]
ON [dbo].[ImpactDetails]
    ([ImpactTypeId]);
GO

-- Creating foreign key on [MitigationTypeId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [FK_MitigationTypeRiskMitigation]
    FOREIGN KEY ([MitigationTypeId])
    REFERENCES [dbo].[MitigationTypes]
        ([MitigationTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MitigationTypeRiskMitigation'
CREATE INDEX [IX_FK_MitigationTypeRiskMitigation]
ON [dbo].[RiskMitigations]
    ([MitigationTypeId]);
GO

-- Creating foreign key on [UserId] in table 'RiskMitigations'
ALTER TABLE [dbo].[RiskMitigations]
ADD CONSTRAINT [FK_UserInfoRiskMitigation]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoRiskMitigation'
CREATE INDEX [IX_FK_UserInfoRiskMitigation]
ON [dbo].[RiskMitigations]
    ([UserId]);
GO

-- Creating foreign key on [MitigationId] in table 'MitigationsActions'
ALTER TABLE [dbo].[MitigationsActions]
ADD CONSTRAINT [FK_RiskMitigationMitigationsAction]
    FOREIGN KEY ([MitigationId])
    REFERENCES [dbo].[RiskMitigations]
        ([MitigationId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskMitigationMitigationsAction'
CREATE INDEX [IX_FK_RiskMitigationMitigationsAction]
ON [dbo].[MitigationsActions]
    ([MitigationId]);
GO

-- Creating foreign key on [UserId] in table 'KRINonInvestDatas'
ALTER TABLE [dbo].[KRINonInvestDatas]
ADD CONSTRAINT [FK_UserInfoKRINonInvestData]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoKRINonInvestData'
CREATE INDEX [IX_FK_UserInfoKRINonInvestData]
ON [dbo].[KRINonInvestDatas]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'KRIInvestDatas'
ALTER TABLE [dbo].[KRIInvestDatas]
ADD CONSTRAINT [FK_UserInfoKRIInvestData]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoKRIInvestData'
CREATE INDEX [IX_FK_UserInfoKRIInvestData]
ON [dbo].[KRIInvestDatas]
    ([UserId]);
GO

-- Creating foreign key on [KRINonInvestId] in table 'KRINonInvestParameters'
ALTER TABLE [dbo].[KRINonInvestParameters]
ADD CONSTRAINT [FK_KRINonInvestKRINonInvestParameter]
    FOREIGN KEY ([KRINonInvestId])
    REFERENCES [dbo].[KRINonInvests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRINonInvestKRINonInvestParameter'
CREATE INDEX [IX_FK_KRINonInvestKRINonInvestParameter]
ON [dbo].[KRINonInvestParameters]
    ([KRINonInvestId]);
GO

-- Creating foreign key on [KRINonInvestId] in table 'KRINonInvestDatas'
ALTER TABLE [dbo].[KRINonInvestDatas]
ADD CONSTRAINT [FK_KRINonInvestKRINonInvestData]
    FOREIGN KEY ([KRINonInvestId])
    REFERENCES [dbo].[KRINonInvests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRINonInvestKRINonInvestData'
CREATE INDEX [IX_FK_KRINonInvestKRINonInvestData]
ON [dbo].[KRINonInvestDatas]
    ([KRINonInvestId]);
GO

-- Creating foreign key on [KRIInvestId] in table 'KRIInvestDatas'
ALTER TABLE [dbo].[KRIInvestDatas]
ADD CONSTRAINT [FK_KRIInvestKRIInvestData]
    FOREIGN KEY ([KRIInvestId])
    REFERENCES [dbo].[KRIInvests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIInvestKRIInvestData'
CREATE INDEX [IX_FK_KRIInvestKRIInvestData]
ON [dbo].[KRIInvestDatas]
    ([KRIInvestId]);
GO

-- Creating foreign key on [KRIInvestId] in table 'KRIInvestParameters'
ALTER TABLE [dbo].[KRIInvestParameters]
ADD CONSTRAINT [FK_KRIInvestKRIInvestParameter]
    FOREIGN KEY ([KRIInvestId])
    REFERENCES [dbo].[KRIInvests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIInvestKRIInvestParameter'
CREATE INDEX [IX_FK_KRIInvestKRIInvestParameter]
ON [dbo].[KRIInvestParameters]
    ([KRIInvestId]);
GO

-- Creating foreign key on [BranchId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_BranchRisk]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([BranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchRisk'
CREATE INDEX [IX_FK_BranchRisk]
ON [dbo].[Risks]
    ([BranchId]);
GO

-- Creating foreign key on [RiskCatId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_RiskCatRisk]
    FOREIGN KEY ([RiskCatId])
    REFERENCES [dbo].[RiskCats]
        ([RiskCatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskCatRisk'
CREATE INDEX [IX_FK_RiskCatRisk]
ON [dbo].[Risks]
    ([RiskCatId]);
GO

-- Creating foreign key on [RiskTypeId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_RiskTypeRisk]
    FOREIGN KEY ([RiskTypeId])
    REFERENCES [dbo].[RiskTypes]
        ([RiskTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RiskTypeRisk'
CREATE INDEX [IX_FK_RiskTypeRisk]
ON [dbo].[Risks]
    ([RiskTypeId]);
GO

-- Creating foreign key on [SubDeptId] in table 'Risks'
ALTER TABLE [dbo].[Risks]
ADD CONSTRAINT [FK_SubDeptRisk]
    FOREIGN KEY ([SubDeptId])
    REFERENCES [dbo].[SubDepts]
        ([SubDeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubDeptRisk'
CREATE INDEX [IX_FK_SubDeptRisk]
ON [dbo].[Risks]
    ([SubDeptId]);
GO

-- Creating foreign key on [DivisionId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_DivisionUserInfo]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([DivisionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DivisionUserInfo'
CREATE INDEX [IX_FK_DivisionUserInfo]
ON [dbo].[UserInfos]
    ([DivisionId]);
GO

-- Creating foreign key on [SubDeptId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_SubDeptUserInfo]
    FOREIGN KEY ([SubDeptId])
    REFERENCES [dbo].[SubDepts]
        ([SubDeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubDeptUserInfo'
CREATE INDEX [IX_FK_SubDeptUserInfo]
ON [dbo].[UserInfos]
    ([SubDeptId]);
GO

-- Creating foreign key on [BranchId] in table 'UserInfos'
ALTER TABLE [dbo].[UserInfos]
ADD CONSTRAINT [FK_BranchUserInfo]
    FOREIGN KEY ([BranchId])
    REFERENCES [dbo].[Branches]
        ([BranchId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BranchUserInfo'
CREATE INDEX [IX_FK_BranchUserInfo]
ON [dbo].[UserInfos]
    ([BranchId]);
GO

-- Creating foreign key on [KRIDataId] in table 'SRNonInvests'
ALTER TABLE [dbo].[SRNonInvests]
ADD CONSTRAINT [FK_KRINonInvestDataSRNonInvest]
    FOREIGN KEY ([KRIDataId])
    REFERENCES [dbo].[KRINonInvestDatas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRINonInvestDataSRNonInvest'
CREATE INDEX [IX_FK_KRINonInvestDataSRNonInvest]
ON [dbo].[SRNonInvests]
    ([KRIDataId]);
GO

-- Creating foreign key on [SRId] in table 'SRNonInvestProgresses'
ALTER TABLE [dbo].[SRNonInvestProgresses]
ADD CONSTRAINT [FK_SRNonInvestSRNonInvestProgress]
    FOREIGN KEY ([SRId])
    REFERENCES [dbo].[SRNonInvests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SRNonInvestSRNonInvestProgress'
CREATE INDEX [IX_FK_SRNonInvestSRNonInvestProgress]
ON [dbo].[SRNonInvestProgresses]
    ([SRId]);
GO

-- Creating foreign key on [SRNonInvestProgressId] in table 'SRNIProgressActions'
ALTER TABLE [dbo].[SRNIProgressActions]
ADD CONSTRAINT [FK_SRNonInvestProgressSRNIProgressAction]
    FOREIGN KEY ([SRNonInvestProgressId])
    REFERENCES [dbo].[SRNonInvestProgresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SRNonInvestProgressSRNIProgressAction'
CREATE INDEX [IX_FK_SRNonInvestProgressSRNIProgressAction]
ON [dbo].[SRNIProgressActions]
    ([SRNonInvestProgressId]);
GO

-- Creating foreign key on [CauseCauseId] in table 'KRIRiskCauseLines'
ALTER TABLE [dbo].[KRIRiskCauseLines]
ADD CONSTRAINT [FK_CauseKRIRiskCauseLine]
    FOREIGN KEY ([CauseCauseId])
    REFERENCES [dbo].[Causes]
        ([CauseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseKRIRiskCauseLine'
CREATE INDEX [IX_FK_CauseKRIRiskCauseLine]
ON [dbo].[KRIRiskCauseLines]
    ([CauseCauseId]);
GO

-- Creating foreign key on [CauseGroupCauseGroupId] in table 'KRIRiskCauseLines'
ALTER TABLE [dbo].[KRIRiskCauseLines]
ADD CONSTRAINT [FK_CauseGroupKRIRiskCauseLine]
    FOREIGN KEY ([CauseGroupCauseGroupId])
    REFERENCES [dbo].[CauseGroups]
        ([CauseGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseGroupKRIRiskCauseLine'
CREATE INDEX [IX_FK_CauseGroupKRIRiskCauseLine]
ON [dbo].[KRIRiskCauseLines]
    ([CauseGroupCauseGroupId]);
GO

-- Creating foreign key on [CauseTypeCauseTypeId] in table 'KRIRiskCauseLines'
ALTER TABLE [dbo].[KRIRiskCauseLines]
ADD CONSTRAINT [FK_CauseTypeKRIRiskCauseLine]
    FOREIGN KEY ([CauseTypeCauseTypeId])
    REFERENCES [dbo].[CauseTypes]
        ([CauseTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CauseTypeKRIRiskCauseLine'
CREATE INDEX [IX_FK_CauseTypeKRIRiskCauseLine]
ON [dbo].[KRIRiskCauseLines]
    ([CauseTypeCauseTypeId]);
GO

-- Creating foreign key on [EffectEffectId] in table 'KRIRiskEffectLines'
ALTER TABLE [dbo].[KRIRiskEffectLines]
ADD CONSTRAINT [FK_EffectKRIRiskEffectLine]
    FOREIGN KEY ([EffectEffectId])
    REFERENCES [dbo].[Effects]
        ([EffectId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EffectKRIRiskEffectLine'
CREATE INDEX [IX_FK_EffectKRIRiskEffectLine]
ON [dbo].[KRIRiskEffectLines]
    ([EffectEffectId]);
GO

-- Creating foreign key on [EffectGroupEffectGroupId] in table 'KRIRiskEffectLines'
ALTER TABLE [dbo].[KRIRiskEffectLines]
ADD CONSTRAINT [FK_EffectGroupKRIRiskEffectLine]
    FOREIGN KEY ([EffectGroupEffectGroupId])
    REFERENCES [dbo].[EffectGroups]
        ([EffectGroupId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EffectGroupKRIRiskEffectLine'
CREATE INDEX [IX_FK_EffectGroupKRIRiskEffectLine]
ON [dbo].[KRIRiskEffectLines]
    ([EffectGroupEffectGroupId]);
GO

-- Creating foreign key on [EffectTypeEffectTypeId] in table 'KRIRiskEffectLines'
ALTER TABLE [dbo].[KRIRiskEffectLines]
ADD CONSTRAINT [FK_EffectTypeKRIRiskEffectLine]
    FOREIGN KEY ([EffectTypeEffectTypeId])
    REFERENCES [dbo].[EffectTypes]
        ([EffectTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EffectTypeKRIRiskEffectLine'
CREATE INDEX [IX_FK_EffectTypeKRIRiskEffectLine]
ON [dbo].[KRIRiskEffectLines]
    ([EffectTypeEffectTypeId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskCauseLines'
ALTER TABLE [dbo].[KRIRiskCauseLines]
ADD CONSTRAINT [FK_KRIRiskKRIRiskCauseLine]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskCauseLine'
CREATE INDEX [IX_FK_KRIRiskKRIRiskCauseLine]
ON [dbo].[KRIRiskCauseLines]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskEffectLines'
ALTER TABLE [dbo].[KRIRiskEffectLines]
ADD CONSTRAINT [FK_KRIRiskKRIRiskEffectLine]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskEffectLine'
CREATE INDEX [IX_FK_KRIRiskKRIRiskEffectLine]
ON [dbo].[KRIRiskEffectLines]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskApprovals'
ALTER TABLE [dbo].[KRIRiskApprovals]
ADD CONSTRAINT [FK_KRIRiskKRIRiskApproval]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskApproval'
CREATE INDEX [IX_FK_KRIRiskKRIRiskApproval]
ON [dbo].[KRIRiskApprovals]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [UserInfoUserId] in table 'KRIRiskApprovals'
ALTER TABLE [dbo].[KRIRiskApprovals]
ADD CONSTRAINT [FK_UserInfoKRIRiskApproval]
    FOREIGN KEY ([UserInfoUserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoKRIRiskApproval'
CREATE INDEX [IX_FK_UserInfoKRIRiskApproval]
ON [dbo].[KRIRiskApprovals]
    ([UserInfoUserId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskAttachments'
ALTER TABLE [dbo].[KRIRiskAttachments]
ADD CONSTRAINT [FK_KRIRiskKRIRiskAttachment]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskAttachment'
CREATE INDEX [IX_FK_KRIRiskKRIRiskAttachment]
ON [dbo].[KRIRiskAttachments]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [KRIRiskMitigationId] in table 'KRIMitigationAttachments'
ALTER TABLE [dbo].[KRIMitigationAttachments]
ADD CONSTRAINT [FK_KRIRiskMitigationKRIMitigationAttachment]
    FOREIGN KEY ([KRIRiskMitigationId])
    REFERENCES [dbo].[KRIRiskMitigations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskMitigationKRIMitigationAttachment'
CREATE INDEX [IX_FK_KRIRiskMitigationKRIMitigationAttachment]
ON [dbo].[KRIMitigationAttachments]
    ([KRIRiskMitigationId]);
GO

-- Creating foreign key on [UserInfoUserId] in table 'KRIRisks'
ALTER TABLE [dbo].[KRIRisks]
ADD CONSTRAINT [FK_UserInfoKRIRisk]
    FOREIGN KEY ([UserInfoUserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoKRIRisk'
CREATE INDEX [IX_FK_UserInfoKRIRisk]
ON [dbo].[KRIRisks]
    ([UserInfoUserId]);
GO

-- Creating foreign key on [FreqFreqId] in table 'KRIRiskProbs'
ALTER TABLE [dbo].[KRIRiskProbs]
ADD CONSTRAINT [FK_FreqKRIRiskProb]
    FOREIGN KEY ([FreqFreqId])
    REFERENCES [dbo].[Freqs]
        ([FreqId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FreqKRIRiskProb'
CREATE INDEX [IX_FK_FreqKRIRiskProb]
ON [dbo].[KRIRiskProbs]
    ([FreqFreqId]);
GO

-- Creating foreign key on [ProbLevelProbLevelId] in table 'KRIRiskProbs'
ALTER TABLE [dbo].[KRIRiskProbs]
ADD CONSTRAINT [FK_ProbLevelKRIRiskProb]
    FOREIGN KEY ([ProbLevelProbLevelId])
    REFERENCES [dbo].[ProbLevels]
        ([ProbLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProbLevelKRIRiskProb'
CREATE INDEX [IX_FK_ProbLevelKRIRiskProb]
ON [dbo].[KRIRiskProbs]
    ([ProbLevelProbLevelId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskProbs'
ALTER TABLE [dbo].[KRIRiskProbs]
ADD CONSTRAINT [FK_KRIRiskKRIRiskProb]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskProb'
CREATE INDEX [IX_FK_KRIRiskKRIRiskProb]
ON [dbo].[KRIRiskProbs]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [ImpactLevelImpactLevelId] in table 'KRIRiskImpacts'
ALTER TABLE [dbo].[KRIRiskImpacts]
ADD CONSTRAINT [FK_ImpactLevelKRIRiskImpact]
    FOREIGN KEY ([ImpactLevelImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactLevelKRIRiskImpact'
CREATE INDEX [IX_FK_ImpactLevelKRIRiskImpact]
ON [dbo].[KRIRiskImpacts]
    ([ImpactLevelImpactLevelId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskImpacts'
ALTER TABLE [dbo].[KRIRiskImpacts]
ADD CONSTRAINT [FK_KRIRiskKRIRiskImpact]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskImpact'
CREATE INDEX [IX_FK_KRIRiskKRIRiskImpact]
ON [dbo].[KRIRiskImpacts]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskNonMoneyImpacts'
ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts]
ADD CONSTRAINT [FK_KRIRiskKRIRiskNonMoneyImpact]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskNonMoneyImpact'
CREATE INDEX [IX_FK_KRIRiskKRIRiskNonMoneyImpact]
ON [dbo].[KRIRiskNonMoneyImpacts]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [ImpactDetailImpactDetailId] in table 'KRIRiskNonMoneyImpacts'
ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts]
ADD CONSTRAINT [FK_ImpactDetailKRIRiskNonMoneyImpact]
    FOREIGN KEY ([ImpactDetailImpactDetailId])
    REFERENCES [dbo].[ImpactDetails]
        ([ImpactDetailId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactDetailKRIRiskNonMoneyImpact'
CREATE INDEX [IX_FK_ImpactDetailKRIRiskNonMoneyImpact]
ON [dbo].[KRIRiskNonMoneyImpacts]
    ([ImpactDetailImpactDetailId]);
GO

-- Creating foreign key on [ImpactLevelImpactLevelId] in table 'KRIRiskNonMoneyImpacts'
ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts]
ADD CONSTRAINT [FK_ImpactLevelKRIRiskNonMoneyImpact]
    FOREIGN KEY ([ImpactLevelImpactLevelId])
    REFERENCES [dbo].[ImpactLevels]
        ([ImpactLevelId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactLevelKRIRiskNonMoneyImpact'
CREATE INDEX [IX_FK_ImpactLevelKRIRiskNonMoneyImpact]
ON [dbo].[KRIRiskNonMoneyImpacts]
    ([ImpactLevelImpactLevelId]);
GO

-- Creating foreign key on [ImpactTypeImpactTypeId] in table 'KRIRiskNonMoneyImpacts'
ALTER TABLE [dbo].[KRIRiskNonMoneyImpacts]
ADD CONSTRAINT [FK_ImpactTypeKRIRiskNonMoneyImpact]
    FOREIGN KEY ([ImpactTypeImpactTypeId])
    REFERENCES [dbo].[ImpactTypes]
        ([ImpactTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ImpactTypeKRIRiskNonMoneyImpact'
CREATE INDEX [IX_FK_ImpactTypeKRIRiskNonMoneyImpact]
ON [dbo].[KRIRiskNonMoneyImpacts]
    ([ImpactTypeImpactTypeId]);
GO

-- Creating foreign key on [KRIRiskRiskId] in table 'KRIRiskMitigations'
ALTER TABLE [dbo].[KRIRiskMitigations]
ADD CONSTRAINT [FK_KRIRiskKRIRiskMitigation]
    FOREIGN KEY ([KRIRiskRiskId])
    REFERENCES [dbo].[KRIRisks]
        ([RiskId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskKRIRiskMitigation'
CREATE INDEX [IX_FK_KRIRiskKRIRiskMitigation]
ON [dbo].[KRIRiskMitigations]
    ([KRIRiskRiskId]);
GO

-- Creating foreign key on [KRIRiskMitigationId] in table 'KRIMitigationActions'
ALTER TABLE [dbo].[KRIMitigationActions]
ADD CONSTRAINT [FK_KRIRiskMitigationKRIMitigationAction]
    FOREIGN KEY ([KRIRiskMitigationId])
    REFERENCES [dbo].[KRIRiskMitigations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskMitigationKRIMitigationAction'
CREATE INDEX [IX_FK_KRIRiskMitigationKRIMitigationAction]
ON [dbo].[KRIMitigationActions]
    ([KRIRiskMitigationId]);
GO

-- Creating foreign key on [KRIRiskMitigationId] in table 'KRIMitigationApprovals'
ALTER TABLE [dbo].[KRIMitigationApprovals]
ADD CONSTRAINT [FK_KRIRiskMitigationKRIMitigationApproval]
    FOREIGN KEY ([KRIRiskMitigationId])
    REFERENCES [dbo].[KRIRiskMitigations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIRiskMitigationKRIMitigationApproval'
CREATE INDEX [IX_FK_KRIRiskMitigationKRIMitigationApproval]
ON [dbo].[KRIMitigationApprovals]
    ([KRIRiskMitigationId]);
GO

-- Creating foreign key on [UserInfoUserId] in table 'KRIMitigationApprovals'
ALTER TABLE [dbo].[KRIMitigationApprovals]
ADD CONSTRAINT [FK_UserInfoKRIMitigationApproval]
    FOREIGN KEY ([UserInfoUserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoKRIMitigationApproval'
CREATE INDEX [IX_FK_UserInfoKRIMitigationApproval]
ON [dbo].[KRIMitigationApprovals]
    ([UserInfoUserId]);
GO

-- Creating foreign key on [KRIMitigationActionId] in table 'KRIActionApprovals'
ALTER TABLE [dbo].[KRIActionApprovals]
ADD CONSTRAINT [FK_KRIMitigationActionKRIActionApproval]
    FOREIGN KEY ([KRIMitigationActionId])
    REFERENCES [dbo].[KRIMitigationActions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIMitigationActionKRIActionApproval'
CREATE INDEX [IX_FK_KRIMitigationActionKRIActionApproval]
ON [dbo].[KRIActionApprovals]
    ([KRIMitigationActionId]);
GO

-- Creating foreign key on [KRIMitigationActionId] in table 'KRIActionProgresses'
ALTER TABLE [dbo].[KRIActionProgresses]
ADD CONSTRAINT [FK_KRIMitigationActionKRIActionProgress]
    FOREIGN KEY ([KRIMitigationActionId])
    REFERENCES [dbo].[KRIMitigationActions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIMitigationActionKRIActionProgress'
CREATE INDEX [IX_FK_KRIMitigationActionKRIActionProgress]
ON [dbo].[KRIActionProgresses]
    ([KRIMitigationActionId]);
GO

-- Creating foreign key on [UserInfoUserId] in table 'KRIActionApprovals'
ALTER TABLE [dbo].[KRIActionApprovals]
ADD CONSTRAINT [FK_UserInfoKRIActionApproval]
    FOREIGN KEY ([UserInfoUserId])
    REFERENCES [dbo].[UserInfos]
        ([UserId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserInfoKRIActionApproval'
CREATE INDEX [IX_FK_UserInfoKRIActionApproval]
ON [dbo].[KRIActionApprovals]
    ([UserInfoUserId]);
GO

-- Creating foreign key on [SRInvestId] in table 'SRInvestProgresses'
ALTER TABLE [dbo].[SRInvestProgresses]
ADD CONSTRAINT [FK_SRInvestSRInvestProgress]
    FOREIGN KEY ([SRInvestId])
    REFERENCES [dbo].[SRInvests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SRInvestSRInvestProgress'
CREATE INDEX [IX_FK_SRInvestSRInvestProgress]
ON [dbo].[SRInvestProgresses]
    ([SRInvestId]);
GO

-- Creating foreign key on [SRInvestProgressId] in table 'SRIProgressActions'
ALTER TABLE [dbo].[SRIProgressActions]
ADD CONSTRAINT [FK_SRInvestProgressSRIProgressAction]
    FOREIGN KEY ([SRInvestProgressId])
    REFERENCES [dbo].[SRInvestProgresses]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SRInvestProgressSRIProgressAction'
CREATE INDEX [IX_FK_SRInvestProgressSRIProgressAction]
ON [dbo].[SRIProgressActions]
    ([SRInvestProgressId]);
GO

-- Creating foreign key on [KRIInvestDataId] in table 'SRInvests'
ALTER TABLE [dbo].[SRInvests]
ADD CONSTRAINT [FK_KRIInvestDataSRInvest]
    FOREIGN KEY ([KRIInvestDataId])
    REFERENCES [dbo].[KRIInvestDatas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KRIInvestDataSRInvest'
CREATE INDEX [IX_FK_KRIInvestDataSRInvest]
ON [dbo].[SRInvests]
    ([KRIInvestDataId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------