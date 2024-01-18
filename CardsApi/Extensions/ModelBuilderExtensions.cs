using CardsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsApi.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void RegisterCardEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity => 
            {
                entity.Property(x => x.Name).IsRequired();
                entity.Property(x => x.Color).HasMaxLength(7);
                entity.Property(x => x.DateCreated).HasColumnType("date");

                entity.HasKey(x => x.Id);
            });
        }

        public static void RegisterUserEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(x => x.Email).IsUnique();
                entity.Property(x => x.Password).IsRequired();

                entity.HasKey(x => x.Id);
            });
        }

        public static void SeedCards(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().HasData(
                new Card
                {
                    Id = Guid.Parse("33831db2-83f7-4f8f-9409-18fb48d4bd5b"),
                    Name = "First",
                    Description = "First description",
                    Color = "#234567",
                    Status = Enums.Status.ToDo,
                    DateCreated = new DateTime(2023, 10, 10)
                },
                new Card
                {
                    Id = Guid.Parse("93f19770-c1d3-41b2-94bf-5db0e3f28a37"),
                    Name = "Second",
                    Description = "Second description",
                    Color = "#238867",
                    Status = Enums.Status.ToDo,
                    DateCreated = new DateTime(2023, 11, 10)
                },
                new Card
                {
                    Id = Guid.Parse("8ff693bb-2284-4b76-bdc4-b1359555c028"),
                    Name = "Third",
                    Description = "Third description",
                    Color = "#888867",
                    Status = Enums.Status.InProgress,
                    DateCreated = new DateTime(2023, 11, 12)
                }
            );
        }

        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("0da8be2b-9059-4460-baf9-5bb3b09e1ea8"),
                    Email = "myrto@gmail.com",
                    Password = "test",
                    DateCreated = new DateTime(2023, 11, 12)
                },
                new User
                {
                    Id = Guid.Parse("f9a44f3f-a33f-4404-813e-8dd96a00ab06"),
                    Email = "lou@gmail.com",
                    Password = "test2",
                    DateCreated = new DateTime(2023, 5, 12)
                }
            );
        }
    }
}
