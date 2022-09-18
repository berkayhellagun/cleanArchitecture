using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReCap.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCap.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        IConfiguration _configuration;
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                //create table for brands
            modelBuilder.Entity<Brand>(b =>
            {
                b.ToTable("Brands").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
                b.HasMany(p => p.Models);
            });

                //create table for models
            modelBuilder.Entity<Model>(b =>
            {
                b.ToTable("Models").HasKey(k => k.Id);
                b.Property(m => m.Id).HasColumnName("Id");
                b.Property(m => m.Name).HasColumnName("Name");
                b.Property(m => m.BrandId).HasColumnName("BrandId");
                b.Property(m => m.ImageUrl).HasColumnName("ImageUrl");
                b.Property(m => m.DailyPrice).HasColumnName("DailyPrice");
                b.HasOne(m => m.Brand);
            });

                // seed for brand
            Brand[] brandSeed = { new(1, "Test"), new(2, "Test") };
            modelBuilder.Entity<Brand>().HasData(brandSeed);
        }
    }
}
