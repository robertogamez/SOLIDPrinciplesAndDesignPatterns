using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuilderPattern.Core
{
    public class AppDbContext : DbContext
    {
        public DbSet<ComputePart> ComputerParts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opts)
            : base(opts)
        {

        }
    }
}
