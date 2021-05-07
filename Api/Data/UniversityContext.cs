using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data
{
    public class UniversityContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        
        public UniversityContext(DbContextOptions<UniversityContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<User>().ToTable("User");    
        }
    }
}
