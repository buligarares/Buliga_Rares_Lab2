using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Buliga_Rares_Lab2.Models;

namespace Buliga_Rares_Lab2.Data
{
    public class Buliga_Rares_Lab2Context : DbContext
    {
        public Buliga_Rares_Lab2Context (DbContextOptions<Buliga_Rares_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Buliga_Rares_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Buliga_Rares_Lab2.Models.Author>? Author { get; set; }

        public DbSet<Buliga_Rares_Lab2.Models.Publisher>? Publisher { get; set; }
    }
}
