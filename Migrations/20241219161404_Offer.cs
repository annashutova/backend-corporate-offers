using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CorporateOffers.Migrations
{
    /// <inheritdoc />
    public partial class Offer : Migration
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
                    Link = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ImagePath = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
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
                    CitiesId = table.Column<int>(type: "integer", nullable: false),
                    OffersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityToOffer", x => new { x.CitiesId, x.OffersId });
                    table.ForeignKey(
                        name: "FK_cityToOffer_cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cityToOffer_offers_OffersId",
                        column: x => x.OffersId,
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
                    { 2, "Отдых" }
                });

            migrationBuilder.InsertData(
                table: "cities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Москва" },
                    { 2, "Санкт-Петербург" }
                });

            migrationBuilder.InsertData(
                table: "offers",
                columns: new[] { "Id", "Annotation", "CategoryId", "CompanyUrl", "Description", "DiscountSize", "EndDate", "ImagePath", "Link", "Name", "OfferType", "StartDate", "Status" },
                values: new object[] { 1, "annotation", 1, "url", "description", null, new DateTime(2024, 12, 20, 16, 14, 3, 556, DateTimeKind.Utc).AddTicks(1001), "imagePath", "link", "name", 0, new DateTime(2024, 12, 19, 16, 14, 3, 556, DateTimeKind.Utc).AddTicks(715), 0 });

            migrationBuilder.InsertData(
                table: "cityToOffer",
                columns: new[] { "CitiesId", "OffersId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 }
                });
            
            migrationBuilder.CreateIndex(
                name: "IX_cityToOffer_OffersId",
                table: "cityToOffer",
                column: "OffersId");

            migrationBuilder.CreateIndex(
                name: "IX_offers_CategoryId",
                table: "offers",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityToOffer");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.DropTable(
                name: "offers");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
