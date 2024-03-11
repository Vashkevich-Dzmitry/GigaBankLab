using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GigaBankLab.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citizenships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citizenships", x => x.Id);
                });

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
                name: "Disabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disabilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Annuity = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditProducts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DepositProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    IsRevocable = table.Column<bool>(type: "bit", nullable: false),
                    IsPartialWithdrawal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepositProducts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PassportSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssuingAuthority = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityOfResidenceId = table.Column<int>(type: "int", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Workplace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    MaritalStatusId = table.Column<int>(type: "int", nullable: false),
                    CitizenshipId = table.Column<int>(type: "int", nullable: false),
                    DisabilityId = table.Column<int>(type: "int", nullable: false),
                    IsPensioner = table.Column<bool>(type: "bit", nullable: false),
                    IsMilitaryServiceRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Cities_CityOfResidenceId",
                        column: x => x.CityOfResidenceId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Citizenships_CitizenshipId",
                        column: x => x.CitizenshipId,
                        principalTable: "Citizenships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_Disabilities_DisabilityId",
                        column: x => x.DisabilityId,
                        principalTable: "Disabilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clients_MaritalStatuses_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatuses",
                        principalColumn: "Id");
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
                name: "CreditContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAccountId = table.Column<int>(type: "int", nullable: false),
                    PercentAccountId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CreditProductId = table.Column<int>(type: "int", nullable: false),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sum = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsClosed = table.Column<bool>(type: "bit", nullable: false),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCardPIN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditContracts_Accounts_CurrentAccountId",
                        column: x => x.CurrentAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditContracts_Accounts_PercentAccountId",
                        column: x => x.PercentAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditContracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CreditContracts_CreditProducts_CreditProductId",
                        column: x => x.CreditProductId,
                        principalTable: "CreditProducts",
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
                    DepositProductId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_DepositContracts_DepositProducts_DepositProductId",
                        column: x => x.DepositProductId,
                        principalTable: "DepositProducts",
                        principalColumn: "Id");
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

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Пинск" },
                    { 2, "Брест" },
                    { 3, "Белоозёрск" },
                    { 4, "Берёза" },
                    { 5, "Минск" }
                });

            migrationBuilder.InsertData(
                table: "Citizenships",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "РБ" },
                    { 2, "РФ" },
                    { 3, "КНР" }
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
                values: new object[] { 1, new DateTime(2024, 3, 4, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Disabilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "нет" },
                    { 2, "1 группа" },
                    { 3, "2 группа" },
                    { 4, "3 группа" }
                });

            migrationBuilder.InsertData(
                table: "MaritalStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Женат" },
                    { 2, "Холост" },
                    { 3, "Замужем" },
                    { 4, "Незамужем" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "ClientId", "Credit", "CurrencyId", "Debit", "Number", "Type" },
                values: new object[,]
                {
                    { 1, null, 0m, 1, 0m, "1010000000002", 0 },
                    { 2, null, 1000000m, 1, 0m, "7327000000009", 1 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "CitizenshipId", "CityOfResidenceId", "DateOfBirth", "DisabilityId", "Email", "FirstName", "HomePhone", "IdentificationNumber", "IsMilitaryServiceRequired", "IsPensioner", "IssueDate", "IssuingAuthority", "LastName", "MaritalStatusId", "MobilePhone", "MonthlyIncome", "PassportNumber", "PassportSeries", "Patronymic", "PlaceOfBirth", "Position", "ResidentialAddress", "Workplace" },
                values: new object[,]
                {
                    { 1, 1, 3, new DateTime(2003, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dzmitry.vashkevich.a@gmail.com", "Дмитрий", "+375(33)6076677", "1234567D123DD1", true, false, new DateTime(2013, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Дрогичинский ГОМ", "Вашкевич", 2, "+375(33)6077766", 799.10m, "1234567", "AA", "Александрович", "г. Белоозёрск", "Техник", "ул. Пушкина, д. 3", "Белгипрозем" },
                    { 2, 1, 1, new DateTime(2002, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "knux.a@yandex.ru", "Артём", "+375(29)9998811", "5434567F123RD1", true, false, new DateTime(2017, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пинский ГОВД", "Кнюх", 2, null, 800.00m, "7654321", "AB", "Игоревич", "г. Пинск", "Техник", "ул. Ботская, д. 13", "Белгипрозем" },
                    { 3, 1, 5, new DateTime(2003, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dzmitry.vashkevich.a@gmail.com", "Александр", "+375(33)6076677", "5411567A123BB1", true, false, new DateTime(2015, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пинский ГОВД", "Каминский", 2, null, 1000000.00m, "7777777", "AB", "Викторович", "г. Пинск", "Программист", "ул. Речная, д. 66, кв. 6", "ПАРАМЕТРЫ ЗАПУСКА" },
                    { 4, 1, 5, new DateTime(2003, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "dzmitry.vashkevich.a@gmail.com", "Андрей", "+375(33)6076677", "1234567A123RB1", true, false, new DateTime(2018, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Вороновский РОВД", "Кугач", 2, "+375(16)4353919", 680.00m, "0987654", "AC", "Владимирович", "г. Берёза, д. 1002", "Техник", "ул. Антиботская, д. 7", "МДА" },
                    { 5, 1, 5, new DateTime(2003, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, "Вадим", null, "1111111A123BB1", true, true, new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Витебский РОВД", "Шамко", 2, null, null, "1112227", "RR", "Сергеевич", "г. Витебск", null, "ул. Конфетная, д. 1", null }
                });

            migrationBuilder.InsertData(
                table: "CreditProducts",
                columns: new[] { "Id", "Annuity", "CurrencyId", "Description", "Duration", "Name", "Percent" },
                values: new object[,]
                {
                    { 1, true, 1, "Больше чем на Личное - 12 месяцев - 16.63% - BYN - Аннуитетные платежи", 12, "Больше чем на Личное", 16.629999999999999 },
                    { 2, false, 1, "На личное - 6 месяцев - 11% - BYN - Дифференцированные платежи", 6, "На личное", 11.0 }
                });

            migrationBuilder.InsertData(
                table: "DepositProducts",
                columns: new[] { "Id", "CurrencyId", "Description", "Duration", "IsPartialWithdrawal", "IsRevocable", "Name", "Percent" },
                values: new object[,]
                {
                    { 1, 1, "Хуткі - 2 месяца - 9.5% - BYN - Не отзывной - С частичными снятиями", 2, true, false, "Хуткі", 9.5 },
                    { 2, 1, "На мару - 3 месяца - 0.3% - BYN - Отзывной - Без снятий", 3, false, true, "На мару", 0.29999999999999999 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CitizenshipId",
                table: "Clients",
                column: "CitizenshipId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CityOfResidenceId",
                table: "Clients",
                column: "CityOfResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_DisabilityId",
                table: "Clients",
                column: "DisabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MaritalStatusId",
                table: "Clients",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_ClientId",
                table: "CreditContracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_CreditProductId",
                table: "CreditContracts",
                column: "CreditProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_CurrentAccountId",
                table: "CreditContracts",
                column: "CurrentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditContracts_PercentAccountId",
                table: "CreditContracts",
                column: "PercentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditProducts_CurrencyId",
                table: "CreditProducts",
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
                name: "IX_DepositContracts_DepositProductId",
                table: "DepositContracts",
                column: "DepositProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositContracts_PercentAccountId",
                table: "DepositContracts",
                column: "PercentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositProducts_CurrencyId",
                table: "DepositProducts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FromAccountId",
                table: "Transactions",
                column: "FromAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ToAccountId",
                table: "Transactions",
                column: "ToAccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditContracts");

            migrationBuilder.DropTable(
                name: "CurrentDates");

            migrationBuilder.DropTable(
                name: "DepositContracts");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CreditProducts");

            migrationBuilder.DropTable(
                name: "DepositProducts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Citizenships");

            migrationBuilder.DropTable(
                name: "Disabilities");

            migrationBuilder.DropTable(
                name: "MaritalStatuses");
        }
    }
}
