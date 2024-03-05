using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GigaBankLab.Migrations
{
    /// <inheritdoc />
    public partial class Deposits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cities_CityOfResidenceId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Citizenships_CitizenshipId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Disabilities_DisabilityId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MaritalStatuses_MaritalStatusId",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentDates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Accounts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    IsRevocable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deposits_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromAccountId = table.Column<int>(type: "int", nullable: false),
                    ToAccountId = table.Column<int>(type: "int", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_FromAccountId",
                        column: x => x.FromAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_ToAccountId",
                        column: x => x.ToAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepositContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAccountId = table.Column<int>(type: "int", nullable: false),
                    PercentAccountId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    DepositId = table.Column<int>(type: "int", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositContracts_Accounts_CurrentAccountId",
                        column: x => x.CurrentAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepositContracts_Accounts_PercentAccountId",
                        column: x => x.PercentAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepositContracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DepositContracts_Deposits_DepositId",
                        column: x => x.DepositId,
                        principalTable: "Deposits",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BYN" },
                    { 2, "RUB" },
                    { 3, "USD" },
                    { 4, "EUR" }
                });

            migrationBuilder.InsertData(
                table: "CurrentDates",
                columns: new[] { "Id", "Value" },
                values: new object[] { 1, new DateTime(2024, 3, 4, 12, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_ClientId",
                table: "DepositContracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_CurrentAccountId",
                table: "DepositContracts",
                column: "CurrentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_DepositId",
                table: "DepositContracts",
                column: "DepositId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_PercentAccountId",
                table: "DepositContracts",
                column: "PercentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_CurrencyId",
                table: "Deposits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                column: "ToAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cities_CityOfResidenceId",
                table: "Clients",
                column: "CityOfResidenceId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Citizenships_CitizenshipId",
                table: "Clients",
                column: "CitizenshipId",
                principalTable: "Citizenships",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Disabilities_DisabilityId",
                table: "Clients",
                column: "DisabilityId",
                principalTable: "Disabilities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MaritalStatuses_MaritalStatusId",
                table: "Clients",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Cities_CityOfResidenceId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Citizenships_CitizenshipId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Disabilities_DisabilityId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MaritalStatuses_MaritalStatusId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "CurrentDates");

            migrationBuilder.DropTable(
                name: "DepositContracts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Cities_CityOfResidenceId",
                table: "Clients",
                column: "CityOfResidenceId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Citizenships_CitizenshipId",
                table: "Clients",
                column: "CitizenshipId",
                principalTable: "Citizenships",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Disabilities_DisabilityId",
                table: "Clients",
                column: "DisabilityId",
                principalTable: "Disabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MaritalStatuses_MaritalStatusId",
                table: "Clients",
                column: "MaritalStatusId",
                principalTable: "MaritalStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
