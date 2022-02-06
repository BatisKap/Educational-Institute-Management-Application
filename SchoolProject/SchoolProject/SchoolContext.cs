using SchoolProject.Entities;
using SchoolProject.Services;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SchoolProject
{
    public partial class SchoolContext : DbContext
    {
        public SchoolContext()
            : base("name=School")
        {
        }

        public virtual DbSet<Assignment> assignments { get; set; }
        public virtual DbSet<Course> courses { get; set; }
        public virtual DbSet<Student> students { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Trainer> trainers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.courses)
                .WithMany(e => e.assignments)
                .Map(m => m.ToTable("AssignmentsToCourses").MapLeftKey("AssignmentID").MapRightKey("CourseID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.students)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("studentsToCourses").MapLeftKey("CourseID").MapRightKey("StudentID"));

            modelBuilder.Entity<Course>()
                .HasMany(e => e.trainers)
                .WithMany(e => e.courses)
                .Map(m => m.ToTable("TrainersToCourses").MapLeftKey("CourseID").MapRightKey("TrainerID"));
        }
    }
}
