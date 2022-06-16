using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectML.Core.Enum;
using ProjectML.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectML.Infrastructure.Context
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Algorithm> Algorithms { get; set; }
        public DbSet<ContentEssay> ContentEssays { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<TopicAlgorithm> TopicAlgorithms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<Roles, string>(
               v => v.ToString(),
               v => (Roles)Enum.Parse(typeof(Roles), v));
            modelBuilder
                .Entity<User>()
                .Property(e => e.Role)
                //.HasDefaultValue(Roles.System)
                .HasConversion(converter);

            //modelBuilder.Entity<User>()
            //    .Property(c => c.Role)
            //    .HasConversion<string>();
        }

    }
}
