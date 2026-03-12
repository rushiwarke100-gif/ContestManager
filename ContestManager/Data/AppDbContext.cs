
using ContestManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ContestManager.Data;

namespace ContestManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserContest> UserContests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>().HasData(
              new User { Id = 1, Username = "TestUser", Role = "Normal" }
          );


            modelBuilder.Entity<Contest>().HasData(
                new Contest
                {
                    Id = 101,
                    Name = "Sample Math Contest",
                    AccessLevel = "Normal",
                    StartTime = DateTime.UtcNow,
                    EndTime = DateTime.UtcNow.AddDays(1)
                }
            );


            modelBuilder.Entity<Question>().HasData(
                new Question { Id = 1, ContestId = 101, Text = "What is 2+2?", Type = "Single" },
                new Question { Id = 2, ContestId = 101, Text = "Select all even numbers.", Type = "Multi" },
                new Question { Id = 3, ContestId = 101, Text = "The sky is blue. (True/False)", Type = "TrueFalse" }
            );


            modelBuilder.Entity<Option>().HasData(

                new Option { Id = 1, QuestionId = 1, Text = "3", IsCorrect = false },
                new Option { Id = 2, QuestionId = 1, Text = "5", IsCorrect = false },
                new Option { Id = 3, QuestionId = 1, Text = "4", IsCorrect = true },


                new Option { Id = 4, QuestionId = 2, Text = "1", IsCorrect = false },
                new Option { Id = 7, QuestionId = 2, Text = "2", IsCorrect = true },
                new Option { Id = 8, QuestionId = 2, Text = "4", IsCorrect = true },


                new Option { Id = 10, QuestionId = 3, Text = "False", IsCorrect = false },
                new Option { Id = 11, QuestionId = 3, Text = "True", IsCorrect = true }
            );
        }
    }
}
