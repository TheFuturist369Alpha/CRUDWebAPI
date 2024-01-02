using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPIUdemy.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "CityName" },
                values: new object[,]
                {
                    { new Guid("5822b3e4-f50a-4bb5-be5e-70a6474dc041"), "Glasgow" },
                    { new Guid("f65dee5c-a3bb-4b8e-a12c-78b6e3e7e517"), "Aberdeen" } 
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
