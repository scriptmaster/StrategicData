using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
            // 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 
        }
    }
}
