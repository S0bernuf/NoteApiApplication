using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApplication.Database
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Note-User relationship
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notes)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Note-Category relationship
            modelBuilder.Entity<Note>()
                .HasOne(n => n.Category)
                .WithMany(c => c.Notes)
                .HasForeignKey(n => n.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Category-User relationship
            modelBuilder.Entity<Category>()
                .HasOne(c => c.User)
                .WithMany(u => u.Categories)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);



            base.OnModelCreating(modelBuilder);
        }
    }
}
