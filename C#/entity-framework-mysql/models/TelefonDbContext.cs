using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Telok.models
{
    public class TelefonDbContext : DbContext
    {
        public DbSet<Telefon> telefonok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=telefonok;user=root;password=");
        }
    }
}
