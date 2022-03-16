#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelBuilderDemo.Models;

namespace ModelBuilderDemo.Data
{
    public class ModelBuilderDemoContext : DbContext
    {
        public ModelBuilderDemoContext (DbContextOptions<ModelBuilderDemoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Course>().HasKey(c => c.CourseNumber);
            builder.Entity<Student>().HasKey(s => s.StudentId);

            builder.Entity<Course>().HasMany(c => c.AuditingStudents)
                .WithOne(aus => aus.AuditingCourse)
                .HasForeignKey(aus => aus.AuditingCourseNumber);

            builder.Entity<Student>().HasOne(s => s.AttendingCourse)
                .WithMany(c => c.AttendingStudents)
                .HasForeignKey(s => s.AttendingCourseNumber);

            builder.Entity<Course>().Property(c => c.Title)
                .HasMaxLength(100)
                .HasColumnType("varchar(100)")
                .IsRequired()
                .HasColumnName("Course Title");
        }


        public DbSet<ModelBuilderDemo.Models.Course> Course { get; set; }
    }
}
