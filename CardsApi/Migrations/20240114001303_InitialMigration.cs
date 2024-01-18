using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CardsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "Color", "DateCreated", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { new Guid("33831db2-83f7-4f8f-9409-18fb48d4bd5b"), "#234567", new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "First description", "First", 0 },
                    { new Guid("8ff693bb-2284-4b76-bdc4-b1359555c028"), "#888867", new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Third description", "Third", 1 },
                    { new Guid("93f19770-c1d3-41b2-94bf-5db0e3f28a37"), "#238867", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Second description", "Second", 0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "Password" },
                values: new object[,]
                {
                    { new Guid("0da8be2b-9059-4460-baf9-5bb3b09e1ea8"), new DateTime(2023, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "myrto@gmail.com", "test" },
                    { new Guid("f9a44f3f-a33f-4404-813e-8dd96a00ab06"), new DateTime(2023, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "lou@gmail.com", "test2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
