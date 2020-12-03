using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFPowerVote.Models
{
    public class piecesServerDbContext:DbContext
    {
        public piecesServerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<efusers> efusers { get; set; }
    }
}
