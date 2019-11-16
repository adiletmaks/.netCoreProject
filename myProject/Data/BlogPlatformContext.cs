using Microsoft.EntityFrameworkCore;
using myProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myProject.Data
{
    public class BlogPlatformContext : DbContext
    {
        public BlogPlatformContext(DbContextOptions options) : base(options)
        {
           
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>()
               .HasMany(p => p.Comments)
               .WithOne(c => c.Post)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PostTag>()
                .HasKey(pt => new { pt.PostId, pt.TagId });
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId);
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);

            modelBuilder.Entity<User>()
               .HasIndex(b => b.Email)
               .IsUnique();

            modelBuilder.Entity<Role>().HasData(
                new { Id = (uint) 1, Slug = "user" },
                new { Id = (uint) 2, Slug = "admin" }
             );
        }

        public DbSet<myProject.Models.PostTag> PostTag { get; set; }
    }
}
