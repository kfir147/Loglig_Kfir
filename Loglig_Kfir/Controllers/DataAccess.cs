using System;
using System.Collections.Generic;
using System.Data.Entity;
using Loglig_Kfir.Models;
using System.Linq;
using System.Web;

namespace Loglig_Kfir.DataAccess
{
    public class DataAccess : DbContext
    {
        public DbSet<Players> Players { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Players>().ToTable("Players");
        }

    }
}