// Copyright (c) Diego Santacruz. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

#nullable disable

namespace ApiCreditSimulator.Api.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    /// <inheritdoc />
    public partial class ModificationCredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyFee",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Credits");

            migrationBuilder.AddColumn<double>(
                name: "AnnualEffectiveRate",
                table: "Credits",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "AnnualNominalRate",
                table: "Credits",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalInterest",
                table: "Credits",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalPayment",
                table: "Credits",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualEffectiveRate",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "AnnualNominalRate",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "TotalInterest",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "TotalPayment",
                table: "Credits");

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyFee",
                table: "Credits",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rate",
                table: "Credits",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "Credits",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Credits",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
