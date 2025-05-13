using BlazorHybrid.Api.Data.Entities;
using BlazorHybrid.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BlazorHybrid.Api.Data
{
    public class QuizContext : DbContext
    {
        private readonly  IPasswordHasher<User> _passwordHasher;
        public QuizContext(DbContextOptions<QuizContext> options, IPasswordHasher<User> passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }

       public DbSet<Category> Categories { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<StudentQuiz> StudentQuizzes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings =>
    warnings.Ignore(RelationalEventId.NonTransactionalMigrationOperationWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           var adminUser = new User
            {
                Id = 1,
                Name = "admin",
                Email = "admin@gmail.com",
                Phone = "1234567890",
                Role = nameof(UserRole.Admin),
                IsApproved = true,
            };
            //adminUser.PasswordHash = _passwordHasher.HashPassword(adminUser, "test!");
            adminUser.PasswordHash = "$2y$13$xeDfQumlmdm0Sco.4qmH1OGfUUmOcuRmfae0dPJhjX1Bq0yYhqbNi";

            modelBuilder.Entity<User>().HasData(adminUser);
        }
    }
}
