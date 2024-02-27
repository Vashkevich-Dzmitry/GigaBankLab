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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
        }
    }
}
