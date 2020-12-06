using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicData
{
    public class AppDbContext : DbContext
    {
        private readonly string _connectionString;

        public DBProvider DBProvider { get; set; }

        public AppDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = DBProvider switch
            {
                DBProvider.SQLServer => optionsBuilder.UseSqlServer(_connectionString),
                DBProvider.PGSQL => optionsBuilder.UseNpgsql(_connectionString),
                DBProvider.MySQL => optionsBuilder.UseMySQL(_connectionString),
                _ => optionsBuilder.UseInMemoryDatabase(_connectionString)
            };
        }
    }

    public enum DBProvider
    {
        SQLServer,
        PGSQL,
        Oracle,
        MySQL,
        SQLite,
        MongoDB,
        Cassandra
    }

}
