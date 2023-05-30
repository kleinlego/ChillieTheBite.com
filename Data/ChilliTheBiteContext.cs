using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChilliTheBite.Models;

namespace ChilliTheBite.Data
{
    public class ChilliTheBiteContext : DbContext
    {
        public ChilliTheBiteContext (DbContextOptions<ChilliTheBiteContext> options)
            : base(options)
        {
        }

        public DbSet<ChilliTheBite.Models.Saurce> Saurce { get; set; } = default!;
    }
}
