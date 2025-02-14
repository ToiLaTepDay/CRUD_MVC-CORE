﻿using ASP_CORE_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_CORE_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get;   set; }  
    }
}
