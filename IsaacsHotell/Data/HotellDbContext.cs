using IsaacsHotell.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacsHotell.Data
{
    public class HotellDbContext : DbContext
    {
        public HotellDbContext(DbContextOptions<HotellDbContext> options) : base(options)
        {
        }

        public DbSet<Gäst> Gäster {get;set;}
        public DbSet<Anställd> Anställda { get; set; }
        public DbSet<Order> Ordrar { get; set; }
        public DbSet<Rum> Rum { get; set; }
        public DbSet<Bokning> Bokningar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Försökt fixa manuellt så att den ska veta relationerna. Problem
            //modelBuilder.Entity<Gäst>()
            //     .HasOne(a => a.Order)
            //     .WithOne(a => a.Gäst)
            //     .HasForeignKey<Order>(c => c.GästId);


            //modelBuilder.Entity<Bokning>()
            //    .HasOne(a => a.Gäst)
            //    .WithOne(a => a.Bokning)
            //    .HasForeignKey<Bokning>(c => c.GästId);
        }

      
    }
}
