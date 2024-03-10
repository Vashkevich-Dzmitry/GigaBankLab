﻿// <auto-generated />
using System;
using GigaBankLab.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GigaBankLab.Migrations
{
    [DbContext(typeof(GigaBankLabContext))]
    partial class GigaBankLabContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GigaBankLab.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<decimal>("Credit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Debit")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Credit = 0m,
                            CurrencyId = 1,
                            Debit = 0m,
                            Number = "1010000000002",
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Credit = 1000000m,
                            CurrencyId = 1,
                            Debit = 0m,
                            Number = "7327000000009",
                            Type = 1
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.Citizenship", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Citizenships");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "РБ"
                        },
                        new
                        {
                            Id = 2,
                            Name = "РФ"
                        },
                        new
                        {
                            Id = 3,
                            Name = "КНР"
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Пинск"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Брест"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Белоозёрск"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Берёза"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Минск"
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CitizenshipId")
                        .HasColumnType("int");

                    b.Property<int>("CityOfResidenceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisabilityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HomePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMilitaryServiceRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPensioner")
                        .HasColumnType("bit");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("IssuingAuthority")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaritalStatusId")
                        .HasColumnType("int");

                    b.Property<string>("MobilePhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MonthlyIncome")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Workplace")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CitizenshipId");

                    b.HasIndex("CityOfResidenceId");

                    b.HasIndex("DisabilityId");

                    b.HasIndex("MaritalStatusId");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CitizenshipId = 1,
                            CityOfResidenceId = 3,
                            DateOfBirth = new DateTime(2003, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisabilityId = 1,
                            Email = "dzmitry.vashkevich.a@gmail.com",
                            FirstName = "Дмитрий",
                            HomePhone = "+375(33)6076677",
                            IdentificationNumber = "1234567D123DD1",
                            IsMilitaryServiceRequired = true,
                            IsPensioner = false,
                            IssueDate = new DateTime(2013, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssuingAuthority = "Дрогичинский ГОМ",
                            LastName = "Вашкевич",
                            MaritalStatusId = 2,
                            MobilePhone = "+375(33)6077766",
                            MonthlyIncome = 799.10m,
                            PassportNumber = "1234567",
                            PassportSeries = "AA",
                            Patronymic = "Александрович",
                            PlaceOfBirth = "г. Белоозёрск",
                            Position = "Техник",
                            ResidentialAddress = "ул. Пушкина, д. 3",
                            Workplace = "Белгипрозем"
                        },
                        new
                        {
                            Id = 2,
                            CitizenshipId = 1,
                            CityOfResidenceId = 1,
                            DateOfBirth = new DateTime(2002, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisabilityId = 1,
                            Email = "knux.a@yandex.ru",
                            FirstName = "Артём",
                            HomePhone = "+375(29)9998811",
                            IdentificationNumber = "5434567F123RD1",
                            IsMilitaryServiceRequired = true,
                            IsPensioner = false,
                            IssueDate = new DateTime(2017, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssuingAuthority = "Пинский ГОВД",
                            LastName = "Кнюх",
                            MaritalStatusId = 2,
                            MonthlyIncome = 800.00m,
                            PassportNumber = "7654321",
                            PassportSeries = "AB",
                            Patronymic = "Игоревич",
                            PlaceOfBirth = "г. Пинск",
                            Position = "Техник",
                            ResidentialAddress = "ул. Ботская, д. 13",
                            Workplace = "Белгипрозем"
                        },
                        new
                        {
                            Id = 3,
                            CitizenshipId = 1,
                            CityOfResidenceId = 5,
                            DateOfBirth = new DateTime(2003, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisabilityId = 1,
                            Email = "dzmitry.vashkevich.a@gmail.com",
                            FirstName = "Александр",
                            HomePhone = "+375(33)6076677",
                            IdentificationNumber = "5411567A123BB1",
                            IsMilitaryServiceRequired = true,
                            IsPensioner = false,
                            IssueDate = new DateTime(2015, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssuingAuthority = "Пинский ГОВД",
                            LastName = "Каминский",
                            MaritalStatusId = 2,
                            MonthlyIncome = 1000000.00m,
                            PassportNumber = "7777777",
                            PassportSeries = "AB",
                            Patronymic = "Викторович",
                            PlaceOfBirth = "г. Пинск",
                            Position = "Программист",
                            ResidentialAddress = "ул. Речная, д. 66, кв. 6",
                            Workplace = "ПАРАМЕТРЫ ЗАПУСКА"
                        },
                        new
                        {
                            Id = 4,
                            CitizenshipId = 1,
                            CityOfResidenceId = 5,
                            DateOfBirth = new DateTime(2003, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisabilityId = 1,
                            Email = "dzmitry.vashkevich.a@gmail.com",
                            FirstName = "Андрей",
                            HomePhone = "+375(33)6076677",
                            IdentificationNumber = "1234567A123RB1",
                            IsMilitaryServiceRequired = true,
                            IsPensioner = false,
                            IssueDate = new DateTime(2018, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssuingAuthority = "Вороновский РОВД",
                            LastName = "Кугач",
                            MaritalStatusId = 2,
                            MobilePhone = "+375(16)4353919",
                            MonthlyIncome = 680.00m,
                            PassportNumber = "0987654",
                            PassportSeries = "AC",
                            Patronymic = "Владимирович",
                            PlaceOfBirth = "г. Берёза, д. 1002",
                            Position = "Техник",
                            ResidentialAddress = "ул. Антиботская, д. 7",
                            Workplace = "МДА"
                        },
                        new
                        {
                            Id = 5,
                            CitizenshipId = 1,
                            CityOfResidenceId = 5,
                            DateOfBirth = new DateTime(2003, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DisabilityId = 1,
                            FirstName = "Вадим",
                            IdentificationNumber = "1111111A123BB1",
                            IsMilitaryServiceRequired = true,
                            IsPensioner = true,
                            IssueDate = new DateTime(2011, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IssuingAuthority = "Витебский РОВД",
                            LastName = "Шамко",
                            MaritalStatusId = 2,
                            PassportNumber = "1112227",
                            PassportSeries = "RR",
                            Patronymic = "Сергеевич",
                            PlaceOfBirth = "г. Витебск",
                            ResidentialAddress = "ул. Конфетная, д. 1"
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "BYN"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RUB"
                        },
                        new
                        {
                            Id = 3,
                            Name = "USD"
                        },
                        new
                        {
                            Id = 4,
                            Name = "EUR"
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.CurrentDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Value")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CurrentDates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Value = new DateTime(2024, 3, 4, 12, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.Deposit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<bool>("IsRevocable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Deposits");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyId = 1,
                            Description = "Фиксированная ставка. Выплата процентов ежедневно. Частичное снятие невозможно. Вклад застрахован.",
                            Duration = 10,
                            IsRevocable = false,
                            Name = "Хуткі",
                            Percent = 9.5
                        },
                        new
                        {
                            Id = 2,
                            CurrencyId = 1,
                            Description = "Фиксированная ставка. Отзывный. Вклад застрахован.",
                            Duration = 15,
                            IsRevocable = true,
                            Name = "На мару",
                            Percent = 0.29999999999999999
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.DepositContract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CloseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentAccountId")
                        .HasColumnType("int");

                    b.Property<int>("DepositId")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PercentAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("CurrentAccountId");

                    b.HasIndex("DepositId");

                    b.HasIndex("PercentAccountId");

                    b.ToTable("DepositContracts");
                });

            modelBuilder.Entity("GigaBankLab.Models.Disability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Disabilities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "нет"
                        },
                        new
                        {
                            Id = 2,
                            Name = "1 группа"
                        },
                        new
                        {
                            Id = 3,
                            Name = "2 группа"
                        },
                        new
                        {
                            Id = 4,
                            Name = "3 группа"
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.MaritalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MaritalStatuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Женат"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Холост"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Замужем"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Незамужем"
                        });
                });

            modelBuilder.Entity("GigaBankLab.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("GigaBankLab.Models.Account", b =>
                {
                    b.HasOne("GigaBankLab.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("GigaBankLab.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("GigaBankLab.Models.Client", b =>
                {
                    b.HasOne("GigaBankLab.Models.Citizenship", "Citizenship")
                        .WithMany()
                        .HasForeignKey("CitizenshipId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.City", "CityOfResidence")
                        .WithMany()
                        .HasForeignKey("CityOfResidenceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.Disability", "Disability")
                        .WithMany()
                        .HasForeignKey("DisabilityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.MaritalStatus", "MaritalStatus")
                        .WithMany()
                        .HasForeignKey("MaritalStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Citizenship");

                    b.Navigation("CityOfResidence");

                    b.Navigation("Disability");

                    b.Navigation("MaritalStatus");
                });

            modelBuilder.Entity("GigaBankLab.Models.Deposit", b =>
                {
                    b.HasOne("GigaBankLab.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("GigaBankLab.Models.DepositContract", b =>
                {
                    b.HasOne("GigaBankLab.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.Account", "CurrentAccount")
                        .WithMany()
                        .HasForeignKey("CurrentAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.Deposit", "Deposit")
                        .WithMany()
                        .HasForeignKey("DepositId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.Account", "PercentAccount")
                        .WithMany()
                        .HasForeignKey("PercentAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("CurrentAccount");

                    b.Navigation("Deposit");

                    b.Navigation("PercentAccount");
                });

            modelBuilder.Entity("GigaBankLab.Models.Transaction", b =>
                {
                    b.HasOne("GigaBankLab.Models.Account", "FromAccount")
                        .WithMany()
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("GigaBankLab.Models.Account", "ToAccount")
                        .WithMany()
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });
#pragma warning restore 612, 618
        }
    }
}
