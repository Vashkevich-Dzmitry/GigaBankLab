using Microsoft.EntityFrameworkCore;
using GigaBankLab.Models;
using GigaBankLab.Models.Atm;

namespace GigaBankLab.Data
{
    public class GigaBankLabContext : DbContext
    {
        public GigaBankLabContext(DbContextOptions<GigaBankLabContext> options)
            : base(options)
        {
            //RecreateDB();
        }

        private void RecreateDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; } = default!;
        public DbSet<City> Cities { get; set; } = default!;
        public DbSet<Citizenship> Citizenships { get; set; } = default!;
        public DbSet<Disability> Disabilities { get; set; } = default!;
        public DbSet<MaritalStatus> MaritalStatuses { get; set; } = default!;

        public DbSet<Account> Accounts { get; set; } = default!;
        public DbSet<Currency> Currencies { get; set; } = default!;
        public DbSet<CurrentDate> CurrentDates { get; set; } = default!;
        public DbSet<DepositProduct> DepositProducts { get; set; } = default!;
        public DbSet<DepositContract> DepositContracts { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;


        public DbSet<CreditProduct> CreditProducts { get; set; } = default!;
        public DbSet<CreditContract> CreditContracts { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>(builder =>
            {
                builder.Property(client => client.MonthlyIncome).HasPrecision(18, 2);
                builder.HasOne(client => client.CityOfResidence).WithMany().HasForeignKey(c => c.CityOfResidenceId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(client => client.MaritalStatus).WithMany().HasForeignKey(c => c.MaritalStatusId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(client => client.Disability).WithMany().HasForeignKey(c => c.DisabilityId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(client => client.Citizenship).WithMany().HasForeignKey(c => c.CitizenshipId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Transaction>(builder =>
            {
                builder.HasOne(transaction => transaction.FromAccount).WithMany().HasForeignKey(t => t.FromAccountId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(transaction => transaction.ToAccount).WithMany().HasForeignKey(t => t.ToAccountId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<DepositContract>(builder =>
            {
                builder.HasOne(dc => dc.CurrentAccount).WithMany().HasForeignKey(t => t.CurrentAccountId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(dc => dc.PercentAccount).WithMany().HasForeignKey(t => t.PercentAccountId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(dc => dc.Client).WithMany().HasForeignKey(t => t.ClientId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(dc => dc.DepositProduct).WithMany().HasForeignKey(t => t.DepositProductId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<CreditContract>(builder =>
            {
                builder.HasOne(dc => dc.CurrentAccount).WithMany().HasForeignKey(t => t.CurrentAccountId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(dc => dc.PercentAccount).WithMany().HasForeignKey(t => t.PercentAccountId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(dc => dc.Client).WithMany().HasForeignKey(t => t.ClientId).OnDelete(DeleteBehavior.NoAction);
                builder.HasOne(dc => dc.CreditProduct).WithMany().HasForeignKey(t => t.CreditProductId).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<City>(builder =>
            {
                builder.HasData(new City { Id = 1, Name = "Пинск" }, new City { Id = 2, Name = "Брест" },
                    new City { Id = 3, Name = "Белоозёрск" }, new City { Id = 4, Name = "Берёза" },
                    new City { Id = 5, Name = "Минск" });
            });

            modelBuilder.Entity<MaritalStatus>(builder =>
            {
                builder.HasData(new MaritalStatus { Id = 1, Name = "Женат" }, new MaritalStatus { Id = 2, Name = "Холост" },
                    new MaritalStatus { Id = 3, Name = "Замужем" }, new MaritalStatus { Id = 4, Name = "Незамужем" });
            });

            modelBuilder.Entity<Citizenship>(builder => builder.HasData(new Citizenship { Id = 1, Name = "РБ" },
                new Citizenship { Id = 2, Name = "РФ" }, new Citizenship { Id = 3, Name = "КНР" }));

            modelBuilder.Entity<Disability>(builder => builder.HasData(new Disability { Id = 1, Name = "нет" },
                new Disability { Id = 2, Name = "1 группа" }, new Disability { Id = 3, Name = "2 группа" }, new Disability { Id = 4, Name = "3 группа" }));

            modelBuilder.Entity<Currency>(builder => builder.HasData(new Currency { Id = 1, Name = "BYN" }, new Currency { Id = 2, Name = "RUB" },
                new Currency { Id = 3, Name = "USD" }, new Currency { Id = 4, Name = "EUR" }));

            modelBuilder.Entity<Client>(builder =>
            {
                builder.HasData(
                    new Client
                    {
                        Id = 1,
                        LastName = "Вашкевич",
                        FirstName = "Дмитрий",
                        Patronymic = "Александрович",
                        DateOfBirth = new DateTime(2003, 1, 2),
                        PassportSeries = "AA",
                        PassportNumber = "1234567",
                        IssuingAuthority = "Дрогичинский ГОМ",
                        IssueDate = new DateTime(2013, 12, 14),
                        IdentificationNumber = "1234567D123DD1",
                        PlaceOfBirth = "г. Белоозёрск",
                        CityOfResidenceId = 3,
                        ResidentialAddress = "ул. Пушкина, д. 3",
                        HomePhone = "+375(33)6076677",
                        MobilePhone = "+375(33)6077766",
                        Email = "dzmitry.vashkevich.a@gmail.com",
                        Workplace = "Белгипрозем",
                        Position = "Техник",
                        MonthlyIncome = 799.10m,
                        MaritalStatusId = 2,
                        CitizenshipId = 1,
                        DisabilityId = 1,
                        IsPensioner = false,
                        IsMilitaryServiceRequired = true
                    },
                    new Client
                    {
                        Id = 2,
                        LastName = "Кнюх",
                        FirstName = "Артём",
                        Patronymic = "Игоревич",
                        DateOfBirth = new DateTime(2002, 3, 13),
                        PassportSeries = "AB",
                        PassportNumber = "7654321",
                        IssuingAuthority = "Пинский ГОВД",
                        IssueDate = new DateTime(2017, 9, 28),
                        IdentificationNumber = "5434567F123RD1",
                        PlaceOfBirth = "г. Пинск",
                        CityOfResidenceId = 1,
                        ResidentialAddress = "ул. Ботская, д. 13",
                        HomePhone = "+375(29)9998811",
                        Email = "knux.a@yandex.ru",
                        Workplace = "Белгипрозем",
                        Position = "Техник",
                        MonthlyIncome = 800.00m,
                        MaritalStatusId = 2,
                        CitizenshipId = 1,
                        DisabilityId = 1,
                        IsPensioner = false,
                        IsMilitaryServiceRequired = true
                    },
                    new Client
                    {
                        Id = 3,
                        LastName = "Каминский",
                        FirstName = "Александр",
                        Patronymic = "Викторович",
                        DateOfBirth = new DateTime(2003, 7, 4),
                        PassportSeries = "AB",
                        PassportNumber = "7777777",
                        IssuingAuthority = "Пинский ГОВД",
                        IssueDate = new DateTime(2015, 2, 16),
                        IdentificationNumber = "5411567A123BB1",
                        PlaceOfBirth = "г. Пинск",
                        CityOfResidenceId = 5,
                        ResidentialAddress = "ул. Речная, д. 66, кв. 6",
                        HomePhone = "+375(33)6076677",
                        Email = "dzmitry.vashkevich.a@gmail.com",
                        Workplace = "ПАРАМЕТРЫ ЗАПУСКА",
                        Position = "Программист",
                        MonthlyIncome = 1000000.00m,
                        MaritalStatusId = 2,
                        CitizenshipId = 1,
                        DisabilityId = 1,
                        IsPensioner = false,
                        IsMilitaryServiceRequired = true
                    },
                    new Client
                    {
                        Id = 4,
                        LastName = "Кугач",
                        FirstName = "Андрей",
                        Patronymic = "Владимирович",
                        DateOfBirth = new DateTime(2003, 2, 18),
                        PassportSeries = "AC",
                        PassportNumber = "0987654",
                        IssuingAuthority = "Вороновский РОВД",
                        IssueDate = new DateTime(2018, 9, 19),
                        IdentificationNumber = "1234567A123RB1",
                        PlaceOfBirth = "г. Берёза, д. 1002",
                        CityOfResidenceId = 5,
                        ResidentialAddress = "ул. Антиботская, д. 7",
                        HomePhone = "+375(33)6076677",
                        MobilePhone = "+375(16)4353919",
                        Email = "dzmitry.vashkevich.a@gmail.com",
                        Workplace = "МДА",
                        Position = "Техник",
                        MonthlyIncome = 680.00m,
                        MaritalStatusId = 2,
                        CitizenshipId = 1,
                        DisabilityId = 1,
                        IsPensioner = false,
                        IsMilitaryServiceRequired = true
                    },
                    new Client
                    {
                        Id = 5,
                        LastName = "Шамко",
                        FirstName = "Вадим",
                        Patronymic = "Сергеевич",
                        DateOfBirth = new DateTime(2003, 1, 22),
                        PassportSeries = "RR",
                        PassportNumber = "1112227",
                        IssuingAuthority = "Витебский РОВД",
                        IssueDate = new DateTime(2011, 11, 11),
                        IdentificationNumber = "1111111A123BB1",
                        PlaceOfBirth = "г. Витебск",
                        CityOfResidenceId = 5,
                        ResidentialAddress = "ул. Конфетная, д. 1",
                        MaritalStatusId = 2,
                        CitizenshipId = 1,
                        DisabilityId = 1,
                        IsPensioner = true,
                        IsMilitaryServiceRequired = true
                    }
                    );

            });


            modelBuilder.Entity<Account>(builder =>
            {
                builder.HasData(
                    new Account { Id = 1, Number = Account.GenerateNumber(AccountCodes.CashboxAccountCode, 0, 0), Credit = 0, Debit = 0, ClientId = null, Type = AccountType.Active, CurrencyId = 1 },
                    new Account { Id = 2, Number = Account.GenerateNumber(AccountCodes.BankGrowthFundAccountCode, 0, 0), Credit = 1_000_000, Debit = 0, ClientId = null, Type = AccountType.Passive, CurrencyId = 1 }
                    );
            });

            modelBuilder.Entity<DepositProduct>(builder =>
            {
                builder.HasData(
                    new DepositProduct 
                    { 
                        Id = 1, 
                        CurrencyId = 1, 
                        Name = "Хуткі", 
                        Duration = 2,
                        Percent = 9.5, 
                        Description = "Хуткі - 2 месяца - 9.5% - BYN - Не отзывной - С частичными снятиями",
                        IsRevocable = false, 
                        IsPartialWithdrawal = true
                    },
                    new DepositProduct
                    {
                        Id = 2,
                        CurrencyId = 1,
                        Name = "На мару",
                        Duration = 3,
                        Percent = 0.3,
                        Description = "На мару - 3 месяца - 0.3% - BYN - Отзывной - Без снятий",
                        IsRevocable = true,
                        IsPartialWithdrawal = false
                    });
            });

            modelBuilder.Entity<CurrentDate>(builder =>
            {
                builder.HasData(
                    new CurrentDate { Id = 1, Value = new DateTime(2024, 03, 04, 00, 00, 00, DateTimeKind.Utc) }
                    );
            });

            modelBuilder.Entity<CreditProduct>(builder => {
                builder.HasData(
                    new CreditProduct 
                    { 
                        Id = 1, 
                        Name = "Больше чем на Личное", 
                        Duration = 12, 
                        Percent = 16.63,
                        Description = "Больше чем на Личное - 12 месяцев - 16.63% - BYN - Аннуитетные платежи",
                        CurrencyId = 1, 
                        Annuity = true 
                    },
                    new CreditProduct 
                    { 
                        Id = 2, 
                        Name = "На личное", 
                        Duration = 6, 
                        Percent = 11, 
                        Description = "На личное - 6 месяцев - 11% - BYN - Дифференцированные платежи",
                        CurrencyId = 1, 
                        Annuity = false
                    }
                );
            });
        }
    }
}
