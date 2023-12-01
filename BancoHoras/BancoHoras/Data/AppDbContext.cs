﻿using BancoHoras.Models;
using Microsoft.EntityFrameworkCore;

namespace BancoHoras.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; } = null!;
    }
}
