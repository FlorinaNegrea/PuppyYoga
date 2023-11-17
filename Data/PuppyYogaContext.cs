using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PuppyYoga.Models;

namespace PuppyYoga.Data
{
    public class PuppyYogaContext : DbContext
    {
        public PuppyYogaContext (DbContextOptions<PuppyYogaContext> options)
            : base(options)
        {
        }

        public DbSet<PuppyYoga.Models.User> User { get; set; } = default!;

        public DbSet<PuppyYoga.Models.Instructor> Instructors { get; set; }

        public DbSet<YogaClass> YogaClasses { get; set; }


        public DbSet<PuppyYoga.Models.Enrollment>? Enrollment { get; set; }

        public DbSet<PuppyYoga.Models.Feedback>? Feedback { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<YogaClass>()
                .HasOne(y => y.Instructor) 
                .WithMany(i => i.YogaClasses)
                .HasForeignKey(y => y.InstructorId) 
                ;
        }


    }
}
