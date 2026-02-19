using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvictionFiler.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUserNav : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UserDatabases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Transactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "TblRemainderCenter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "SubscriptionTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstVirtualPlatforms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstUnits",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstTypeOfOwners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstTenancyTypesForBuilding",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstTenancyTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstSubCaseTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstStates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstServiceMethod",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstReportingTypePerDiems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstRenewalStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstReminderEscalates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstReminderCategory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstRemainderTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstReliefRespondentTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstReliefPetitionerTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstRegulationStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstRegistrationstatuses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstReasonHoldover",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstRateTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstPremiseTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstPaymentMethods",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstPartyRepresents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstPartyRepresentPerDiems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstLanguages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstLandlordTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstIsUnitIllegal",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstHarassmentTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstFormTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstFilingMethod",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstExemptionReason",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstExemptionBasic",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstDocumentTypePerDiems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstDocumentType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstDefenseTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstDateRent",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCourtType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCourtTodayType",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCounties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstClientRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCategories",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCaseTypesHPD",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCaseTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCaseTypePerdiems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCaseSubTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCaseStatus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstCaseProgram",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstBuildingTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstBilingTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstAppearanceTypesPerDiems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstAppearanceTypesForHearing",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstAppearanceTypes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstAppearanceModes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "MstAdjournedReasons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Marshal",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "LegalCases",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "LandLords",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Firms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Courts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CourtPart",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseWarrants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseNoticeInfo",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseNotes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseHearings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseForms",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseFilings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseDocument",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseAppearances",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseAdditionalTenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseAdditionalResondents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "CaseAdditionalPetitioners",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Calanders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "Buildings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "ArrearLedgers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AdditionalOccupants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "AdditioanlTenants",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserDatabases_CreatedById",
                table: "UserDatabases",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreatedById",
                table: "Transactions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_CreatedById",
                table: "Tenants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_TblRemainderCenter_CreatedById",
                table: "TblRemainderCenter",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionTypes_CreatedById",
                table: "SubscriptionTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstVirtualPlatforms_CreatedById",
                table: "MstVirtualPlatforms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstUnits_CreatedById",
                table: "MstUnits",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstTypeOfOwners_CreatedById",
                table: "MstTypeOfOwners",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstTenancyTypesForBuilding_CreatedById",
                table: "MstTenancyTypesForBuilding",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstTenancyTypes_CreatedById",
                table: "MstTenancyTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstSubCaseTypes_CreatedById",
                table: "MstSubCaseTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstStates_CreatedById",
                table: "MstStates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstServiceMethod_CreatedById",
                table: "MstServiceMethod",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstReportingTypePerDiems_CreatedById",
                table: "MstReportingTypePerDiems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstRenewalStatus_CreatedById",
                table: "MstRenewalStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstReminderEscalates_CreatedById",
                table: "MstReminderEscalates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstReminderCategory_CreatedById",
                table: "MstReminderCategory",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstRemainderTypes_CreatedById",
                table: "MstRemainderTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstReliefRespondentTypes_CreatedById",
                table: "MstReliefRespondentTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstReliefPetitionerTypes_CreatedById",
                table: "MstReliefPetitionerTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstRegulationStatus_CreatedById",
                table: "MstRegulationStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstRegistrationstatuses_CreatedById",
                table: "MstRegistrationstatuses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstReasonHoldover_CreatedById",
                table: "MstReasonHoldover",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstRateTypes_CreatedById",
                table: "MstRateTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstPremiseTypes_CreatedById",
                table: "MstPremiseTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstPaymentMethods_CreatedById",
                table: "MstPaymentMethods",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstPartyRepresents_CreatedById",
                table: "MstPartyRepresents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstPartyRepresentPerDiems_CreatedById",
                table: "MstPartyRepresentPerDiems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstLanguages_CreatedById",
                table: "MstLanguages",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstLandlordTypes_CreatedById",
                table: "MstLandlordTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstIsUnitIllegal_CreatedById",
                table: "MstIsUnitIllegal",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstHarassmentTypes_CreatedById",
                table: "MstHarassmentTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstFormTypes_CreatedById",
                table: "MstFormTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstFilingMethod_CreatedById",
                table: "MstFilingMethod",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstExemptionReason_CreatedById",
                table: "MstExemptionReason",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstExemptionBasic_CreatedById",
                table: "MstExemptionBasic",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstDocumentTypePerDiems_CreatedById",
                table: "MstDocumentTypePerDiems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstDocumentType_CreatedById",
                table: "MstDocumentType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstDefenseTypes_CreatedById",
                table: "MstDefenseTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstDateRent_CreatedById",
                table: "MstDateRent",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCourtType_CreatedById",
                table: "MstCourtType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCourtTodayType_CreatedById",
                table: "MstCourtTodayType",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCounties_CreatedById",
                table: "MstCounties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstClientRoles_CreatedById",
                table: "MstClientRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCities_CreatedById",
                table: "MstCities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCategories_CreatedById",
                table: "MstCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCaseTypesHPD_CreatedById",
                table: "MstCaseTypesHPD",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCaseTypes_CreatedById",
                table: "MstCaseTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCaseTypePerdiems_CreatedById",
                table: "MstCaseTypePerdiems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCaseSubTypes_CreatedById",
                table: "MstCaseSubTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCaseStatus_CreatedById",
                table: "MstCaseStatus",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstCaseProgram_CreatedById",
                table: "MstCaseProgram",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstBuildingTypes_CreatedById",
                table: "MstBuildingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstBilingTypes_CreatedById",
                table: "MstBilingTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstAppearanceTypesPerDiems_CreatedById",
                table: "MstAppearanceTypesPerDiems",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstAppearanceTypesForHearing_CreatedById",
                table: "MstAppearanceTypesForHearing",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstAppearanceTypes_CreatedById",
                table: "MstAppearanceTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstAppearanceModes_CreatedById",
                table: "MstAppearanceModes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MstAdjournedReasons_CreatedById",
                table: "MstAdjournedReasons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Marshal_CreatedById",
                table: "Marshal",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LegalCases_CreatedById",
                table: "LegalCases",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LandLords_CreatedById",
                table: "LandLords",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_CreatedById",
                table: "Firms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Courts_CreatedById",
                table: "Courts",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CourtPart_CreatedById",
                table: "CourtPart",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseWarrants_CreatedById",
                table: "CaseWarrants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseNoticeInfo_CreatedById",
                table: "CaseNoticeInfo",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseNotes_CreatedById",
                table: "CaseNotes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseHearings_CreatedById",
                table: "CaseHearings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseForms_CreatedById",
                table: "CaseForms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseFilings_CreatedById",
                table: "CaseFilings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseDocument_CreatedById",
                table: "CaseDocument",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAppearances_CreatedById",
                table: "CaseAppearances",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalTenants_CreatedById",
                table: "CaseAdditionalTenants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalResondents_CreatedById",
                table: "CaseAdditionalResondents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CaseAdditionalPetitioners_CreatedById",
                table: "CaseAdditionalPetitioners",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Calanders_CreatedById",
                table: "Calanders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_CreatedById",
                table: "Buildings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ArrearLedgers_CreatedById",
                table: "ArrearLedgers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalOccupants_CreatedById",
                table: "AdditionalOccupants",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AdditioanlTenants_CreatedById",
                table: "AdditioanlTenants",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditioanlTenants_AspNetUsers_CreatedById",
                table: "AdditioanlTenants",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalOccupants_AspNetUsers_CreatedById",
                table: "AdditionalOccupants",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ArrearLedgers_AspNetUsers_CreatedById",
                table: "ArrearLedgers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_AspNetUsers_CreatedById",
                table: "Buildings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calanders_AspNetUsers_CreatedById",
                table: "Calanders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdditionalPetitioners_AspNetUsers_CreatedById",
                table: "CaseAdditionalPetitioners",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdditionalResondents_AspNetUsers_CreatedById",
                table: "CaseAdditionalResondents",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAdditionalTenants_AspNetUsers_CreatedById",
                table: "CaseAdditionalTenants",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseAppearances_AspNetUsers_CreatedById",
                table: "CaseAppearances",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseDocument_AspNetUsers_CreatedById",
                table: "CaseDocument",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFilings_AspNetUsers_CreatedById",
                table: "CaseFilings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseForms_AspNetUsers_CreatedById",
                table: "CaseForms",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseHearings_AspNetUsers_CreatedById",
                table: "CaseHearings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNotes_AspNetUsers_CreatedById",
                table: "CaseNotes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseNoticeInfo_AspNetUsers_CreatedById",
                table: "CaseNoticeInfo",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseWarrants_AspNetUsers_CreatedById",
                table: "CaseWarrants",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedById",
                table: "Clients",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourtPart_AspNetUsers_CreatedById",
                table: "CourtPart",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courts_AspNetUsers_CreatedById",
                table: "Courts",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Firms_AspNetUsers_CreatedById",
                table: "Firms",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LandLords_AspNetUsers_CreatedById",
                table: "LandLords",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LegalCases_AspNetUsers_CreatedById",
                table: "LegalCases",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Marshal_AspNetUsers_CreatedById",
                table: "Marshal",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstAdjournedReasons_AspNetUsers_CreatedById",
                table: "MstAdjournedReasons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstAppearanceModes_AspNetUsers_CreatedById",
                table: "MstAppearanceModes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstAppearanceTypes_AspNetUsers_CreatedById",
                table: "MstAppearanceTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstAppearanceTypesForHearing_AspNetUsers_CreatedById",
                table: "MstAppearanceTypesForHearing",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstAppearanceTypesPerDiems_AspNetUsers_CreatedById",
                table: "MstAppearanceTypesPerDiems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstBilingTypes_AspNetUsers_CreatedById",
                table: "MstBilingTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstBuildingTypes_AspNetUsers_CreatedById",
                table: "MstBuildingTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCaseProgram_AspNetUsers_CreatedById",
                table: "MstCaseProgram",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCaseStatus_AspNetUsers_CreatedById",
                table: "MstCaseStatus",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCaseSubTypes_AspNetUsers_CreatedById",
                table: "MstCaseSubTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCaseTypePerdiems_AspNetUsers_CreatedById",
                table: "MstCaseTypePerdiems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCaseTypes_AspNetUsers_CreatedById",
                table: "MstCaseTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCaseTypesHPD_AspNetUsers_CreatedById",
                table: "MstCaseTypesHPD",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCategories_AspNetUsers_CreatedById",
                table: "MstCategories",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCities_AspNetUsers_CreatedById",
                table: "MstCities",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstClientRoles_AspNetUsers_CreatedById",
                table: "MstClientRoles",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCounties_AspNetUsers_CreatedById",
                table: "MstCounties",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCourtTodayType_AspNetUsers_CreatedById",
                table: "MstCourtTodayType",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstCourtType_AspNetUsers_CreatedById",
                table: "MstCourtType",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstDateRent_AspNetUsers_CreatedById",
                table: "MstDateRent",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstDefenseTypes_AspNetUsers_CreatedById",
                table: "MstDefenseTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstDocumentType_AspNetUsers_CreatedById",
                table: "MstDocumentType",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstDocumentTypePerDiems_AspNetUsers_CreatedById",
                table: "MstDocumentTypePerDiems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstExemptionBasic_AspNetUsers_CreatedById",
                table: "MstExemptionBasic",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstExemptionReason_AspNetUsers_CreatedById",
                table: "MstExemptionReason",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFilingMethod_AspNetUsers_CreatedById",
                table: "MstFilingMethod",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstFormTypes_AspNetUsers_CreatedById",
                table: "MstFormTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstHarassmentTypes_AspNetUsers_CreatedById",
                table: "MstHarassmentTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstIsUnitIllegal_AspNetUsers_CreatedById",
                table: "MstIsUnitIllegal",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstLandlordTypes_AspNetUsers_CreatedById",
                table: "MstLandlordTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstLanguages_AspNetUsers_CreatedById",
                table: "MstLanguages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstPartyRepresentPerDiems_AspNetUsers_CreatedById",
                table: "MstPartyRepresentPerDiems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstPartyRepresents_AspNetUsers_CreatedById",
                table: "MstPartyRepresents",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstPaymentMethods_AspNetUsers_CreatedById",
                table: "MstPaymentMethods",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstPremiseTypes_AspNetUsers_CreatedById",
                table: "MstPremiseTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstRateTypes_AspNetUsers_CreatedById",
                table: "MstRateTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstReasonHoldover_AspNetUsers_CreatedById",
                table: "MstReasonHoldover",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstRegistrationstatuses_AspNetUsers_CreatedById",
                table: "MstRegistrationstatuses",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstRegulationStatus_AspNetUsers_CreatedById",
                table: "MstRegulationStatus",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstReliefPetitionerTypes_AspNetUsers_CreatedById",
                table: "MstReliefPetitionerTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstReliefRespondentTypes_AspNetUsers_CreatedById",
                table: "MstReliefRespondentTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstRemainderTypes_AspNetUsers_CreatedById",
                table: "MstRemainderTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstReminderCategory_AspNetUsers_CreatedById",
                table: "MstReminderCategory",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstReminderEscalates_AspNetUsers_CreatedById",
                table: "MstReminderEscalates",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstRenewalStatus_AspNetUsers_CreatedById",
                table: "MstRenewalStatus",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstReportingTypePerDiems_AspNetUsers_CreatedById",
                table: "MstReportingTypePerDiems",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstServiceMethod_AspNetUsers_CreatedById",
                table: "MstServiceMethod",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstStates_AspNetUsers_CreatedById",
                table: "MstStates",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstSubCaseTypes_AspNetUsers_CreatedById",
                table: "MstSubCaseTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstTenancyTypes_AspNetUsers_CreatedById",
                table: "MstTenancyTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstTenancyTypesForBuilding_AspNetUsers_CreatedById",
                table: "MstTenancyTypesForBuilding",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstTypeOfOwners_AspNetUsers_CreatedById",
                table: "MstTypeOfOwners",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstUnits_AspNetUsers_CreatedById",
                table: "MstUnits",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MstVirtualPlatforms_AspNetUsers_CreatedById",
                table: "MstVirtualPlatforms",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionTypes_AspNetUsers_CreatedById",
                table: "SubscriptionTypes",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TblRemainderCenter_AspNetUsers_CreatedById",
                table: "TblRemainderCenter",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_AspNetUsers_CreatedById",
                table: "Tenants",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_CreatedById",
                table: "Transactions",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserDatabases_AspNetUsers_CreatedById",
                table: "UserDatabases",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditioanlTenants_AspNetUsers_CreatedById",
                table: "AdditioanlTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalOccupants_AspNetUsers_CreatedById",
                table: "AdditionalOccupants");

            migrationBuilder.DropForeignKey(
                name: "FK_ArrearLedgers_AspNetUsers_CreatedById",
                table: "ArrearLedgers");

            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_AspNetUsers_CreatedById",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Calanders_AspNetUsers_CreatedById",
                table: "Calanders");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdditionalPetitioners_AspNetUsers_CreatedById",
                table: "CaseAdditionalPetitioners");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdditionalResondents_AspNetUsers_CreatedById",
                table: "CaseAdditionalResondents");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAdditionalTenants_AspNetUsers_CreatedById",
                table: "CaseAdditionalTenants");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseAppearances_AspNetUsers_CreatedById",
                table: "CaseAppearances");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseDocument_AspNetUsers_CreatedById",
                table: "CaseDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseFilings_AspNetUsers_CreatedById",
                table: "CaseFilings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseForms_AspNetUsers_CreatedById",
                table: "CaseForms");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseHearings_AspNetUsers_CreatedById",
                table: "CaseHearings");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseNotes_AspNetUsers_CreatedById",
                table: "CaseNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseNoticeInfo_AspNetUsers_CreatedById",
                table: "CaseNoticeInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_CaseWarrants_AspNetUsers_CreatedById",
                table: "CaseWarrants");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_AspNetUsers_CreatedById",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_CourtPart_AspNetUsers_CreatedById",
                table: "CourtPart");

            migrationBuilder.DropForeignKey(
                name: "FK_Courts_AspNetUsers_CreatedById",
                table: "Courts");

            migrationBuilder.DropForeignKey(
                name: "FK_Firms_AspNetUsers_CreatedById",
                table: "Firms");

            migrationBuilder.DropForeignKey(
                name: "FK_LandLords_AspNetUsers_CreatedById",
                table: "LandLords");

            migrationBuilder.DropForeignKey(
                name: "FK_LegalCases_AspNetUsers_CreatedById",
                table: "LegalCases");

            migrationBuilder.DropForeignKey(
                name: "FK_Marshal_AspNetUsers_CreatedById",
                table: "Marshal");

            migrationBuilder.DropForeignKey(
                name: "FK_MstAdjournedReasons_AspNetUsers_CreatedById",
                table: "MstAdjournedReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_MstAppearanceModes_AspNetUsers_CreatedById",
                table: "MstAppearanceModes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstAppearanceTypes_AspNetUsers_CreatedById",
                table: "MstAppearanceTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstAppearanceTypesForHearing_AspNetUsers_CreatedById",
                table: "MstAppearanceTypesForHearing");

            migrationBuilder.DropForeignKey(
                name: "FK_MstAppearanceTypesPerDiems_AspNetUsers_CreatedById",
                table: "MstAppearanceTypesPerDiems");

            migrationBuilder.DropForeignKey(
                name: "FK_MstBilingTypes_AspNetUsers_CreatedById",
                table: "MstBilingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstBuildingTypes_AspNetUsers_CreatedById",
                table: "MstBuildingTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCaseProgram_AspNetUsers_CreatedById",
                table: "MstCaseProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCaseStatus_AspNetUsers_CreatedById",
                table: "MstCaseStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCaseSubTypes_AspNetUsers_CreatedById",
                table: "MstCaseSubTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCaseTypePerdiems_AspNetUsers_CreatedById",
                table: "MstCaseTypePerdiems");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCaseTypes_AspNetUsers_CreatedById",
                table: "MstCaseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCaseTypesHPD_AspNetUsers_CreatedById",
                table: "MstCaseTypesHPD");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCategories_AspNetUsers_CreatedById",
                table: "MstCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCities_AspNetUsers_CreatedById",
                table: "MstCities");

            migrationBuilder.DropForeignKey(
                name: "FK_MstClientRoles_AspNetUsers_CreatedById",
                table: "MstClientRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCounties_AspNetUsers_CreatedById",
                table: "MstCounties");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCourtTodayType_AspNetUsers_CreatedById",
                table: "MstCourtTodayType");

            migrationBuilder.DropForeignKey(
                name: "FK_MstCourtType_AspNetUsers_CreatedById",
                table: "MstCourtType");

            migrationBuilder.DropForeignKey(
                name: "FK_MstDateRent_AspNetUsers_CreatedById",
                table: "MstDateRent");

            migrationBuilder.DropForeignKey(
                name: "FK_MstDefenseTypes_AspNetUsers_CreatedById",
                table: "MstDefenseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstDocumentType_AspNetUsers_CreatedById",
                table: "MstDocumentType");

            migrationBuilder.DropForeignKey(
                name: "FK_MstDocumentTypePerDiems_AspNetUsers_CreatedById",
                table: "MstDocumentTypePerDiems");

            migrationBuilder.DropForeignKey(
                name: "FK_MstExemptionBasic_AspNetUsers_CreatedById",
                table: "MstExemptionBasic");

            migrationBuilder.DropForeignKey(
                name: "FK_MstExemptionReason_AspNetUsers_CreatedById",
                table: "MstExemptionReason");

            migrationBuilder.DropForeignKey(
                name: "FK_MstFilingMethod_AspNetUsers_CreatedById",
                table: "MstFilingMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_MstFormTypes_AspNetUsers_CreatedById",
                table: "MstFormTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstHarassmentTypes_AspNetUsers_CreatedById",
                table: "MstHarassmentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstIsUnitIllegal_AspNetUsers_CreatedById",
                table: "MstIsUnitIllegal");

            migrationBuilder.DropForeignKey(
                name: "FK_MstLandlordTypes_AspNetUsers_CreatedById",
                table: "MstLandlordTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstLanguages_AspNetUsers_CreatedById",
                table: "MstLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_MstPartyRepresentPerDiems_AspNetUsers_CreatedById",
                table: "MstPartyRepresentPerDiems");

            migrationBuilder.DropForeignKey(
                name: "FK_MstPartyRepresents_AspNetUsers_CreatedById",
                table: "MstPartyRepresents");

            migrationBuilder.DropForeignKey(
                name: "FK_MstPaymentMethods_AspNetUsers_CreatedById",
                table: "MstPaymentMethods");

            migrationBuilder.DropForeignKey(
                name: "FK_MstPremiseTypes_AspNetUsers_CreatedById",
                table: "MstPremiseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstRateTypes_AspNetUsers_CreatedById",
                table: "MstRateTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstReasonHoldover_AspNetUsers_CreatedById",
                table: "MstReasonHoldover");

            migrationBuilder.DropForeignKey(
                name: "FK_MstRegistrationstatuses_AspNetUsers_CreatedById",
                table: "MstRegistrationstatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_MstRegulationStatus_AspNetUsers_CreatedById",
                table: "MstRegulationStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_MstReliefPetitionerTypes_AspNetUsers_CreatedById",
                table: "MstReliefPetitionerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstReliefRespondentTypes_AspNetUsers_CreatedById",
                table: "MstReliefRespondentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstRemainderTypes_AspNetUsers_CreatedById",
                table: "MstRemainderTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstReminderCategory_AspNetUsers_CreatedById",
                table: "MstReminderCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_MstReminderEscalates_AspNetUsers_CreatedById",
                table: "MstReminderEscalates");

            migrationBuilder.DropForeignKey(
                name: "FK_MstRenewalStatus_AspNetUsers_CreatedById",
                table: "MstRenewalStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_MstReportingTypePerDiems_AspNetUsers_CreatedById",
                table: "MstReportingTypePerDiems");

            migrationBuilder.DropForeignKey(
                name: "FK_MstServiceMethod_AspNetUsers_CreatedById",
                table: "MstServiceMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_MstStates_AspNetUsers_CreatedById",
                table: "MstStates");

            migrationBuilder.DropForeignKey(
                name: "FK_MstSubCaseTypes_AspNetUsers_CreatedById",
                table: "MstSubCaseTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstTenancyTypes_AspNetUsers_CreatedById",
                table: "MstTenancyTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_MstTenancyTypesForBuilding_AspNetUsers_CreatedById",
                table: "MstTenancyTypesForBuilding");

            migrationBuilder.DropForeignKey(
                name: "FK_MstTypeOfOwners_AspNetUsers_CreatedById",
                table: "MstTypeOfOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_MstUnits_AspNetUsers_CreatedById",
                table: "MstUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_MstVirtualPlatforms_AspNetUsers_CreatedById",
                table: "MstVirtualPlatforms");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionTypes_AspNetUsers_CreatedById",
                table: "SubscriptionTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_TblRemainderCenter_AspNetUsers_CreatedById",
                table: "TblRemainderCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_AspNetUsers_CreatedById",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_CreatedById",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDatabases_AspNetUsers_CreatedById",
                table: "UserDatabases");

            migrationBuilder.DropIndex(
                name: "IX_UserDatabases_CreatedById",
                table: "UserDatabases");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_CreatedById",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Tenants_CreatedById",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_TblRemainderCenter_CreatedById",
                table: "TblRemainderCenter");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionTypes_CreatedById",
                table: "SubscriptionTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstVirtualPlatforms_CreatedById",
                table: "MstVirtualPlatforms");

            migrationBuilder.DropIndex(
                name: "IX_MstUnits_CreatedById",
                table: "MstUnits");

            migrationBuilder.DropIndex(
                name: "IX_MstTypeOfOwners_CreatedById",
                table: "MstTypeOfOwners");

            migrationBuilder.DropIndex(
                name: "IX_MstTenancyTypesForBuilding_CreatedById",
                table: "MstTenancyTypesForBuilding");

            migrationBuilder.DropIndex(
                name: "IX_MstTenancyTypes_CreatedById",
                table: "MstTenancyTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstSubCaseTypes_CreatedById",
                table: "MstSubCaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstStates_CreatedById",
                table: "MstStates");

            migrationBuilder.DropIndex(
                name: "IX_MstServiceMethod_CreatedById",
                table: "MstServiceMethod");

            migrationBuilder.DropIndex(
                name: "IX_MstReportingTypePerDiems_CreatedById",
                table: "MstReportingTypePerDiems");

            migrationBuilder.DropIndex(
                name: "IX_MstRenewalStatus_CreatedById",
                table: "MstRenewalStatus");

            migrationBuilder.DropIndex(
                name: "IX_MstReminderEscalates_CreatedById",
                table: "MstReminderEscalates");

            migrationBuilder.DropIndex(
                name: "IX_MstReminderCategory_CreatedById",
                table: "MstReminderCategory");

            migrationBuilder.DropIndex(
                name: "IX_MstRemainderTypes_CreatedById",
                table: "MstRemainderTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstReliefRespondentTypes_CreatedById",
                table: "MstReliefRespondentTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstReliefPetitionerTypes_CreatedById",
                table: "MstReliefPetitionerTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstRegulationStatus_CreatedById",
                table: "MstRegulationStatus");

            migrationBuilder.DropIndex(
                name: "IX_MstRegistrationstatuses_CreatedById",
                table: "MstRegistrationstatuses");

            migrationBuilder.DropIndex(
                name: "IX_MstReasonHoldover_CreatedById",
                table: "MstReasonHoldover");

            migrationBuilder.DropIndex(
                name: "IX_MstRateTypes_CreatedById",
                table: "MstRateTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstPremiseTypes_CreatedById",
                table: "MstPremiseTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstPaymentMethods_CreatedById",
                table: "MstPaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_MstPartyRepresents_CreatedById",
                table: "MstPartyRepresents");

            migrationBuilder.DropIndex(
                name: "IX_MstPartyRepresentPerDiems_CreatedById",
                table: "MstPartyRepresentPerDiems");

            migrationBuilder.DropIndex(
                name: "IX_MstLanguages_CreatedById",
                table: "MstLanguages");

            migrationBuilder.DropIndex(
                name: "IX_MstLandlordTypes_CreatedById",
                table: "MstLandlordTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstIsUnitIllegal_CreatedById",
                table: "MstIsUnitIllegal");

            migrationBuilder.DropIndex(
                name: "IX_MstHarassmentTypes_CreatedById",
                table: "MstHarassmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstFormTypes_CreatedById",
                table: "MstFormTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstFilingMethod_CreatedById",
                table: "MstFilingMethod");

            migrationBuilder.DropIndex(
                name: "IX_MstExemptionReason_CreatedById",
                table: "MstExemptionReason");

            migrationBuilder.DropIndex(
                name: "IX_MstExemptionBasic_CreatedById",
                table: "MstExemptionBasic");

            migrationBuilder.DropIndex(
                name: "IX_MstDocumentTypePerDiems_CreatedById",
                table: "MstDocumentTypePerDiems");

            migrationBuilder.DropIndex(
                name: "IX_MstDocumentType_CreatedById",
                table: "MstDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_MstDefenseTypes_CreatedById",
                table: "MstDefenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstDateRent_CreatedById",
                table: "MstDateRent");

            migrationBuilder.DropIndex(
                name: "IX_MstCourtType_CreatedById",
                table: "MstCourtType");

            migrationBuilder.DropIndex(
                name: "IX_MstCourtTodayType_CreatedById",
                table: "MstCourtTodayType");

            migrationBuilder.DropIndex(
                name: "IX_MstCounties_CreatedById",
                table: "MstCounties");

            migrationBuilder.DropIndex(
                name: "IX_MstClientRoles_CreatedById",
                table: "MstClientRoles");

            migrationBuilder.DropIndex(
                name: "IX_MstCities_CreatedById",
                table: "MstCities");

            migrationBuilder.DropIndex(
                name: "IX_MstCategories_CreatedById",
                table: "MstCategories");

            migrationBuilder.DropIndex(
                name: "IX_MstCaseTypesHPD_CreatedById",
                table: "MstCaseTypesHPD");

            migrationBuilder.DropIndex(
                name: "IX_MstCaseTypes_CreatedById",
                table: "MstCaseTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstCaseTypePerdiems_CreatedById",
                table: "MstCaseTypePerdiems");

            migrationBuilder.DropIndex(
                name: "IX_MstCaseSubTypes_CreatedById",
                table: "MstCaseSubTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstCaseStatus_CreatedById",
                table: "MstCaseStatus");

            migrationBuilder.DropIndex(
                name: "IX_MstCaseProgram_CreatedById",
                table: "MstCaseProgram");

            migrationBuilder.DropIndex(
                name: "IX_MstBuildingTypes_CreatedById",
                table: "MstBuildingTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstBilingTypes_CreatedById",
                table: "MstBilingTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstAppearanceTypesPerDiems_CreatedById",
                table: "MstAppearanceTypesPerDiems");

            migrationBuilder.DropIndex(
                name: "IX_MstAppearanceTypesForHearing_CreatedById",
                table: "MstAppearanceTypesForHearing");

            migrationBuilder.DropIndex(
                name: "IX_MstAppearanceTypes_CreatedById",
                table: "MstAppearanceTypes");

            migrationBuilder.DropIndex(
                name: "IX_MstAppearanceModes_CreatedById",
                table: "MstAppearanceModes");

            migrationBuilder.DropIndex(
                name: "IX_MstAdjournedReasons_CreatedById",
                table: "MstAdjournedReasons");

            migrationBuilder.DropIndex(
                name: "IX_Marshal_CreatedById",
                table: "Marshal");

            migrationBuilder.DropIndex(
                name: "IX_LegalCases_CreatedById",
                table: "LegalCases");

            migrationBuilder.DropIndex(
                name: "IX_LandLords_CreatedById",
                table: "LandLords");

            migrationBuilder.DropIndex(
                name: "IX_Firms_CreatedById",
                table: "Firms");

            migrationBuilder.DropIndex(
                name: "IX_Courts_CreatedById",
                table: "Courts");

            migrationBuilder.DropIndex(
                name: "IX_CourtPart_CreatedById",
                table: "CourtPart");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CreatedById",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_CaseWarrants_CreatedById",
                table: "CaseWarrants");

            migrationBuilder.DropIndex(
                name: "IX_CaseNoticeInfo_CreatedById",
                table: "CaseNoticeInfo");

            migrationBuilder.DropIndex(
                name: "IX_CaseNotes_CreatedById",
                table: "CaseNotes");

            migrationBuilder.DropIndex(
                name: "IX_CaseHearings_CreatedById",
                table: "CaseHearings");

            migrationBuilder.DropIndex(
                name: "IX_CaseForms_CreatedById",
                table: "CaseForms");

            migrationBuilder.DropIndex(
                name: "IX_CaseFilings_CreatedById",
                table: "CaseFilings");

            migrationBuilder.DropIndex(
                name: "IX_CaseDocument_CreatedById",
                table: "CaseDocument");

            migrationBuilder.DropIndex(
                name: "IX_CaseAppearances_CreatedById",
                table: "CaseAppearances");

            migrationBuilder.DropIndex(
                name: "IX_CaseAdditionalTenants_CreatedById",
                table: "CaseAdditionalTenants");

            migrationBuilder.DropIndex(
                name: "IX_CaseAdditionalResondents_CreatedById",
                table: "CaseAdditionalResondents");

            migrationBuilder.DropIndex(
                name: "IX_CaseAdditionalPetitioners_CreatedById",
                table: "CaseAdditionalPetitioners");

            migrationBuilder.DropIndex(
                name: "IX_Calanders_CreatedById",
                table: "Calanders");

            migrationBuilder.DropIndex(
                name: "IX_Buildings_CreatedById",
                table: "Buildings");

            migrationBuilder.DropIndex(
                name: "IX_ArrearLedgers_CreatedById",
                table: "ArrearLedgers");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalOccupants_CreatedById",
                table: "AdditionalOccupants");

            migrationBuilder.DropIndex(
                name: "IX_AdditioanlTenants_CreatedById",
                table: "AdditioanlTenants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UserDatabases");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TblRemainderCenter");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "SubscriptionTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstVirtualPlatforms");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstUnits");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstTypeOfOwners");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstTenancyTypesForBuilding");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstTenancyTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstSubCaseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstStates");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstServiceMethod");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstReportingTypePerDiems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstRenewalStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstReminderEscalates");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstReminderCategory");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstRemainderTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstReliefRespondentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstReliefPetitionerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstRegulationStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstRegistrationstatuses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstReasonHoldover");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstRateTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstPremiseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstPaymentMethods");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstPartyRepresents");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstPartyRepresentPerDiems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstLanguages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstLandlordTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstIsUnitIllegal");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstHarassmentTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstFormTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstFilingMethod");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstExemptionReason");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstExemptionBasic");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstDocumentTypePerDiems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstDocumentType");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstDefenseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstDateRent");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCourtType");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCourtTodayType");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCounties");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstClientRoles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCities");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCategories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCaseTypesHPD");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCaseTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCaseTypePerdiems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCaseSubTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCaseStatus");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstCaseProgram");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstBuildingTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstBilingTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstAppearanceTypesPerDiems");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstAppearanceTypesForHearing");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstAppearanceTypes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstAppearanceModes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MstAdjournedReasons");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Marshal");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "LegalCases");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "LandLords");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Firms");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CourtPart");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseWarrants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseNoticeInfo");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseNotes");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseHearings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseForms");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseFilings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseDocument");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseAppearances");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseAdditionalTenants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseAdditionalResondents");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "CaseAdditionalPetitioners");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Calanders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Buildings");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ArrearLedgers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AdditionalOccupants");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AdditioanlTenants");
        }
    }
}
