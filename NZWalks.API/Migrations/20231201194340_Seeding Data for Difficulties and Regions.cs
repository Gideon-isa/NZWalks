using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3e8cc177-361a-4ff0-80ae-f0e630e23102"), "Easy" },
                    { new Guid("5941638f-d849-4065-9741-17c865f40231"), "Hard" },
                    { new Guid("5fe1a4a8-ed09-4d56-b9fd-85dc5e2658c6"), "Meduim" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("3e8be49a-4dfb-444c-b4e3-27ec0e24b899"), "BOP", "Bay of Plenty", null },
                    { new Guid("47963b04-60d3-4711-958b-b3f85c834578"), "WGN", "Wellington", "Welligton.jpg" },
                    { new Guid("4fdc6c58-b84f-4ba8-88fa-1ff862f77695"), "NTL", "Northland", "northland.png" },
                    { new Guid("6fd79b96-a7ca-49d0-b5c0-c0561069265e"), "NSN", "Nelson", "nelson.jpg" },
                    { new Guid("822f3b53-46f5-4a00-bdf1-667bc4ccaa29"), "AKL", "Auckland", "auk.png" },
                    { new Guid("d082fb6d-9be6-4090-ad8a-13c991106cb3"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3e8cc177-361a-4ff0-80ae-f0e630e23102"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5941638f-d849-4065-9741-17c865f40231"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5fe1a4a8-ed09-4d56-b9fd-85dc5e2658c6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("3e8be49a-4dfb-444c-b4e3-27ec0e24b899"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("47963b04-60d3-4711-958b-b3f85c834578"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4fdc6c58-b84f-4ba8-88fa-1ff862f77695"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6fd79b96-a7ca-49d0-b5c0-c0561069265e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("822f3b53-46f5-4a00-bdf1-667bc4ccaa29"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d082fb6d-9be6-4090-ad8a-13c991106cb3"));
        }
    }
}
