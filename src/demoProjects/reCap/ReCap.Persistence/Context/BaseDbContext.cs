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

        public BaseDbContext(IConfiguration configuration, DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(b =>
            {
                //create table
                b.ToTable("Brands").HasKey(k => k.Id);
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
            });

            Brand[] brandSeed = { new(1, "Test"), new(2, "Test") };
            modelBuilder.Entity<Brand>().HasData(brandSeed);
        }
    }
}
