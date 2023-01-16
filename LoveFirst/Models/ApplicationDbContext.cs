using System;
using LoveFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace LoveFirst
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<Counters> Counters { get; set; }
        public DbSet<Participants> Participants{ get; set; }
        public DbSet<Operations> Operations{ get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Counters>()
                .HasOne(p => p.Profiles)
                .WithMany(c => c.Counters)
                .HasForeignKey(p => p.ProfileId);

            modelBuilder.Entity<Participants>()
                .HasOne(c => c.Counters)
                .WithMany(p => p.Participants)
                .HasForeignKey(c => c.CounterId);

            modelBuilder.Entity<Operations>()
                .HasOne(c => c.Counters)
                .WithMany(o => o.Operations)
                .HasForeignKey(c => c.CounterId);


            modelBuilder.Entity<Profiles>().HasData(new Profiles { 
                ProfileId = 1,
                Login = "test",
                PasswordHash = "9f86d081884c7d659a2feaa0c55ad015a3bf4f1b2b0b822cd15d6c15b0f00a08"
            });

            modelBuilder.Entity<Counters>().HasData(new Counters
            {
                CounterId = 1,
                ProfileId = 1,
                TotalScores = 3
            });

            modelBuilder.Entity<Participants>().HasData(new Participants
            {
                ParticipantId = 1,
                CounterId = 1,
                NameParticipant = "Danila",
                NumberScore = 2
            });

            modelBuilder.Entity<Participants>().HasData(new Participants
            {
                ParticipantId = 2,
                CounterId = 1,
                NameParticipant = "An",
                NumberScore = 1
            });

            modelBuilder.Entity<Operations>().HasData(new Operations
            {
                OperationId = 1,
                CounterId = 1,
                ParticipantId = 1,
                Score = 1,
                DateOperation = DateTime.Now
            });

            modelBuilder.Entity<Operations>().HasData(new Operations
            {
                OperationId = 2,
                CounterId = 1,
                ParticipantId = 2,
                Score = 1,
                DateOperation = DateTime.Now
            });

            modelBuilder.Entity<Operations>().HasData(new Operations
            {
                OperationId = 3,
                CounterId = 1,
                ParticipantId = 1,
                Score = 1,
                DateOperation = DateTime.Now
            });

        }

    }
}
