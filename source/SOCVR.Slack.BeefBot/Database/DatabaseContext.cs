using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOCVR.Slack.BeefBot.Database
{
    public class DatabaseContext : DbContext
    {
        private string connectionString;

        public DatabaseContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<BeefEntry> BeefEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
