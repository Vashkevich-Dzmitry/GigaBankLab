using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GigaBankLab.Models;

namespace GigaBankLab.Data
{
    public class GigaBankLabContext : DbContext
    {
        public GigaBankLabContext (DbContextOptions<GigaBankLabContext> options)
            : base(options)
        {
        }

        public DbSet<GigaBankLab.Models.Client> Client { get; set; } = default!;
    }
}
