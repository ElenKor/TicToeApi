using System;
using Microsoft.EntityFrameworkCore;
using TicToeAPI.Models;

namespace TicToeAPI.Data;

    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            Database.EnsureCreated();
        }
    public DbSet<Game> TicToeGames { get; set; }
}




