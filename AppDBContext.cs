using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategicData
{
    public class AppDbContext : DbContext
    {
        private readonly string connectionString;

        public DBProvider DBProvider { get; set; } = DBProvider.InMemory;

        public AppDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _ = DBProvider switch
            {
                DBProvider.SQLServer => optionsBuilder.UseSqlServer(connectionString),
                DBProvider.PGSQL => optionsBuilder.UseNpgsql(connectionString),
                DBProvider.MySQL => optionsBuilder.UseMySQL(connectionString),
                DBProvider.SQLite => optionsBuilder.UseSqlite(connectionString),
                _ => optionsBuilder.UseInMemoryDatabase(connectionString)
            };
        }
    }

    public enum DBProvider
    {
        InMemory,
        SQLServer,
        PGSQL,
        Oracle,
        MySQL,
        SQLite,
        MongoDB,
        Cassandra
    }

}
