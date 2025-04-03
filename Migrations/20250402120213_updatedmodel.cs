using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TscLoanManagement.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Dealers");

            migrationBuilder.RenameColumn(
                name: "SanctionLimit",
                table: "Dealers",
                newName: "WaiverAmount");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Dealers",
                newName: "StockAuditStatus");

            migrationBuilder.RenameColumn(
                name: "ProcessingFee",
                table: "Dealers",
                newName: "UtilizationPercentage");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Dealers",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Dealers",
                newName: "RelationshipManager");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Dealers",
                newName: "PAN");

            migrationBuilder.AddColumn<decimal>(
                name: "AmountReceived",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AvailableLimit",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfOnboarding",
                table: "Dealers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DealerCode",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "DelayInterestAccrued",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DelayInterestReceived",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DelayROI",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DocumentStatus",
                table: "Dealers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EntityType",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "InterestAccrued",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "InterestReceived",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "LoanProposalNo",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Dealers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "OutstandingAmount",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OverdueCount",
                table: "Dealers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PFAcrued",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PFReceived",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PrincipalOutstanding",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ROI",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SanctionAmount",
                table: "Dealers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountReceived",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "AvailableLimit",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DateOfOnboarding",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DealerCode",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DelayInterestAccrued",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DelayInterestReceived",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DelayROI",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "DocumentStatus",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "EntityType",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "InterestAccrued",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "InterestReceived",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "LoanProposalNo",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "OutstandingAmount",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "OverdueCount",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "PFAcrued",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "PFReceived",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "PrincipalOutstanding",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "ROI",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "SanctionAmount",
                table: "Dealers");

            migrationBuilder.RenameColumn(
                name: "WaiverAmount",
                table: "Dealers",
                newName: "SanctionLimit");

            migrationBuilder.RenameColumn(
                name: "UtilizationPercentage",
                table: "Dealers",
                newName: "ProcessingFee");

            migrationBuilder.RenameColumn(
                name: "StockAuditStatus",
                table: "Dealers",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Dealers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "RelationshipManager",
                table: "Dealers",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "PAN",
                table: "Dealers",
                newName: "Address");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Dealers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Dealers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
