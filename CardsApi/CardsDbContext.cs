using CardsApi.Extensions;
using CardsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsApi
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base (options)
        {            
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RegisterCardEntity();
            modelBuilder.RegisterUserEntity();
            modelBuilder.SeedCards();
            modelBuilder.SeedUsers();
        }
    }
}
