using bictly.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bictly.Data
{
    public class BictlyContext : DbContext 
    {
        public BictlyContext(DbContextOptions<BictlyContext> option) : base(option) { Database.EnsureCreated(); }
        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
