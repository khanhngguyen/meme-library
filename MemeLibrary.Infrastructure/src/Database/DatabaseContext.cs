using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MemeLibrary.Domain.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace MemeLibrary.Infrastructure.src.Database
{
    public class DatabaseContext(DbContextOptions options, IConfiguration config) : DbContext(options)
    {
        private readonly IConfiguration _config = config;

        public DbSet<Meme> Memes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}