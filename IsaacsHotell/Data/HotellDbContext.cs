﻿using IsaacsHotell.Models;
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
            //foreach (var e in modelBuilder.Model.GetEntityTypes())
            //{
            //    foreach (var fk in e.GetForeignKeys())
            //    {
            //        fk.DeleteBehavior = DeleteBehavior.Restrict;
            //    }
            //}

            modelBuilder.Entity<Gäst>()
                 .HasOne(a => a.Order)
                 .WithOne(a => a.Gäst);

            modelBuilder.Entity<Gäst>()
                .HasMany(a => a.Bokningar)
                .WithOne(b => b.Gäst);

            modelBuilder.Entity<Order>()
                .HasOne(a => a.Gäst)
                .WithOne(b => b.Order)
                .HasForeignKey<Gäst>(c => c.OrderId);

            modelBuilder.Entity<Rum>()
                .HasMany(a => a.Bokningar)
                .WithOne(b => b.Rum);

            modelBuilder.Entity<Bokning>()
                .HasOne(a => a.Gäst)
                .WithMany(b => b.Bokningar);

            modelBuilder.Entity<Bokning>()
                .HasOne(a => a.Rum)
                .WithMany(b => b.Bokningar);

            modelBuilder.Entity<Anställd>()
                .HasData(           new Anställd {Id=1, Förnamn = "Anders", Efternamn = "Anka", Roll = "Admin" },
                                    new Anställd {Id=2, Förnamn = "Bertil", Efternamn = "Bengtsson", Roll = "Receptionist" },
                                    new Anställd {Id=3, Förnamn = "Ceasar", Efternamn = "Cello", Roll = "Städare" });
            modelBuilder.Entity<Rum>()
                .HasData(new Rum { Id=1, Namn = "Jan", Antalsovplatser = 2, Smutsigt = false, BokningId = 1 });
            //fler rum
            modelBuilder.Entity<Bokning>()
                .HasData(new Bokning { Id=1, GästId = 1, RumId = 1, Incheckning = new DateTime(2021, 4, 22), Utcheckning= new DateTime(2021, 4, 23) });

            modelBuilder.Entity<Gäst>()
                .HasData(new Gäst { Id= 1, Förnamn = "Alf", Efternamn = "Aronsson", BokningId = 1, OrderId = 1 });

            modelBuilder.Entity<Order>()
                .HasData(new Order { Id=1, GästId = 1, Pris = 990 });
        }
    }
}
