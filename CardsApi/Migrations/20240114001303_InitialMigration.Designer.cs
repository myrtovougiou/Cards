﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CardsApi.Migrations
{
    [DbContext(typeof(CardsDbContext))]
    [Migration("20240114001303_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CardsApi.Models.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasMaxLength(7)
                        .HasColumnType("nvarchar(7)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33831db2-83f7-4f8f-9409-18fb48d4bd5b"),
                            Color = "#234567",
                            DateCreated = new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "First description",
                            Name = "First",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("93f19770-c1d3-41b2-94bf-5db0e3f28a37"),
                            Color = "#238867",
                            DateCreated = new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Second description",
                            Name = "Second",
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("8ff693bb-2284-4b76-bdc4-b1359555c028"),
                            Color = "#888867",
                            DateCreated = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Third description",
                            Name = "Third",
                            Status = 1
                        });
                });

            modelBuilder.Entity("CardsApi.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0da8be2b-9059-4460-baf9-5bb3b09e1ea8"),
                            DateCreated = new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "myrto@gmail.com",
                            Password = "test"
                        },
                        new
                        {
                            Id = new Guid("f9a44f3f-a33f-4404-813e-8dd96a00ab06"),
                            DateCreated = new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "lou@gmail.com",
                            Password = "test2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
