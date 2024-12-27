using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CorporateOffers.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tokenBlacklist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Token = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Expiration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tokenBlacklist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Password = table.Column<byte[]>(type: "bytea", maxLength: 32, nullable: false),
                    LastLogin = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Annotation = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CompanyUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OfferType = table.Column<int>(type: "integer", nullable: true),
                    DiscountSize = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Links = table.Column<List<string>>(type: "text[]", nullable: false),
                    ImagePath = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_offers_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cityToOffer",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "integer", nullable: false),
                    OfferId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityToOffer", x => new { x.CityId, x.OfferId });
                    table.ForeignKey(
                        name: "FK_cityToOffer_cities_CityId",
                        column: x => x.CityId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cityToOffer_offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "offers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Спорт" },
                    { 2, "Отдых" },
                    { 3, "Дети" },
                    { 4, "Отели" }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Москва" },
                    { 2, "Санкт-Петербург" },
                    { 3, "Иркутск" },
                    { 4, "Новосибирск" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "FirstName", "LastLogin", "LastName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, "email@gmail.com", "Ivan", null, "Ivanov", new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 }, 1 },
                    { 2, "email", "Marina", null, "Ivanova", new byte[] { 166, 101, 164, 89, 32, 66, 47, 157, 65, 126, 72, 103, 239, 220, 79, 184, 160, 74, 31, 63, 255, 31, 160, 126, 153, 142, 134, 247, 247, 162, 122, 227 }, 0 }
                });

            migrationBuilder.InsertData(
                table: "offers",
                columns: new[] { "Id", "Annotation", "CategoryId", "CompanyUrl", "Description", "DiscountSize", "EndDate", "ImagePath", "Links", "Name", "OfferType", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, "annotation", 1, "url", "description", null, new DateTime(2024, 12, 28, 10, 56, 50, 713, DateTimeKind.Utc).AddTicks(7410), "", new List<string> { "link1", "link2" }, "name", 0, new DateTime(2024, 12, 27, 10, 56, 50, 713, DateTimeKind.Utc).AddTicks(7070), 0 },
                    { 2, "annotation2", 1, "url2", "description2", 10, new DateTime(2024, 12, 29, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1925), "", new List<string>(), "name2", 1, new DateTime(2024, 12, 27, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1924), 1 },
                    { 3, "annotation3", 2, null, "description3", 10, new DateTime(2024, 12, 30, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1942), "", new List<string> { "link3" }, null, 1, new DateTime(2024, 12, 27, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1941), 1 },
                    { 4, "annotation4", 1, "url4", "description4", null, new DateTime(2024, 12, 31, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1950), "", new List<string> { "link" }, "name4", 0, new DateTime(2024, 12, 28, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1950), 2 },
                    { 5, "annotation5", 2, "url5", "description5", null, new DateTime(2025, 1, 1, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1954), "", new List<string> { "link" }, "name5", 0, new DateTime(2024, 12, 29, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1953), 0 }
                });

            migrationBuilder.InsertData(
                table: "cityToOffer",
                columns: new[] { "CityId", "OfferId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_Name",
                table: "categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cities_Name",
                table: "cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cityToOffer_OfferId",
                table: "cityToOffer",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_offers_CategoryId",
                table: "offers",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityToOffer");

            migrationBuilder.DropTable(
                name: "tokenBlacklist");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
