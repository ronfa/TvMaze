using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using TvMaze.Domain.Models;
using System;
namespace TvMaze.Core.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Show> Shows { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<ImportRun> ImportRuns { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Show>().ToTable("Shows");
            builder.Entity<Show>().HasKey(p => p.Id);
            builder.Entity<Show>().Property(p => p.Id).IsRequired();
            builder.Entity<Show>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<Show>().HasMany(p => p.CastMembers).WithOne(p => p.Show); //.HasForeignKey(p => p.ShowId);

            builder.Entity<Show>().HasData
            (
                new Show { Id = 1, Name = "Friends" },
                new Show { Id = 2, Name = "Seinfeld" }
            );

            builder.Entity<CastMember>().ToTable("CastMembers");
            builder.Entity<CastMember>().HasKey(p => p.Id);
            builder.Entity<CastMember>().Property(p => p.Id).IsRequired();
            builder.Entity<CastMember>().Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Entity<CastMember>().Property(p => p.Birthday).IsRequired();

            builder.Entity<CastMember>().HasData
            (
                new CastMember { Id = 1, Name = "Jeniffer Aniston", Birthday = DateTime.Now.AddYears(-30), ShowId = 1 },
                new CastMember { Id = 2, Name = "Jerry Seinfeld", Birthday = DateTime.Now.AddYears(-40), ShowId = 2 }
            );

            builder.Entity<ImportRun>().ToTable("ImportRun");
            builder.Entity<ImportRun>().HasKey(p => p.Id);
            builder.Entity<ImportRun>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<ImportRun>().Property(p => p.StartTime).IsRequired();
            builder.Entity<ImportRun>().Property(p => p.StartPageNum).IsRequired();
            builder.Entity<ImportRun>().Property(p => p.EndPageNum).IsRequired();


        }
    }
}