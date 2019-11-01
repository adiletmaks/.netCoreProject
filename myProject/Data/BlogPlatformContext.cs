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
    }
}
