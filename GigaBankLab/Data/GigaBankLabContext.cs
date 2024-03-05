using Microsoft.EntityFrameworkCore;
using GigaBankLab.Models;

namespace GigaBankLab.Data
{ 
    public class GigaBankLabContext : DbContext
    {
        public GigaBankLabContext(DbContextOptions<GigaBankLabContext> options)
            : base(options)
        {
        }

        public DbSet<GigaBankLab.Models.Client> Clients { get; set; } = default!;
        public DbSet<GigaBankLab.Models.City> Cities { get; set; } = default!;
        public DbSet<GigaBankLab.Models.Citizenship> Citizenships { get; set; } = default!;
        public DbSet<GigaBankLab.Models.Disability> Disabilities { get; set; } = default!;
        public DbSet<GigaBankLab.Models.MaritalStatus> MaritalStatuses { get; set; } = default!;

        public DbSet<GigaBankLab.Models.Account> Accounts { get; set; } = default!;
        public DbSet<GigaBankLab.Models.Currency> Currencies { get; set; } = default!;
        public DbSet<GigaBankLab.Models.CurrentDate> CurrentDates { get; set; } = default!;
        public DbSet<GigaBankLab.Models.Deposit> Deposits { get; set; } = default!;
        public DbSet<GigaBankLab.Models.DepositContract> DepositContracts { get; set; } = default!;
        public DbSet<GigaBankLab.Models.Transaction> Transactions { get; set; } = default!;

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
                builder.HasOne(dc => dc.Deposit).WithMany().HasForeignKey(t => t.DepositId).OnDelete(DeleteBehavior.NoAction);
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

            modelBuilder.Entity<Currency>(builder => builder.HasData(new Currency { Id = 1, Name = "BYN"}, new Currency { Id = 2, Name = "RUB" }, 
                new Currency { Id = 3, Name = "USD" }, new Currency { Id = 4, Name = "EUR" } ));

            modelBuilder.Entity<CurrentDate>(builder =>
            {
                builder.HasData(
                    new CurrentDate { Id = 1, Value = new DateTime(2024, 03, 04, 12, 00, 00, DateTimeKind.Utc) });
            });
        }
    }
}
