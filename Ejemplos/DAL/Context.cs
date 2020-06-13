using Ejemplos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejemplos.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\SQLEXPRESS; Database=EFCore-SchoolDB; Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne<Grade>(s => s.Grade)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GradeId);

            modelBuilder.Entity<Grade>()
                .HasMany<Student>(g => g.Students)
                .WithOne(s => s.Grade)
                .HasForeignKey(s => s.GradeId)
                .OnDelete(DeleteBehavior.Cascade);

        }



        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
      
    }
}
