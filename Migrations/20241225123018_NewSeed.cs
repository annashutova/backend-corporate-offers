using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CorporateOffers.Migrations
{
    /// <inheritdoc />
    public partial class NewSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cityToOffer",
                columns: new[] { "CityId", "OfferId" },
                values: new object[,]
                {
                    { 2, 5 },
                    { 3, 5 },
                    { 4, 5 }
                });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 12, 30, 17, 562, DateTimeKind.Utc).AddTicks(6948), new List<string> { "link1", "link2" }, new DateTime(2024, 12, 25, 12, 30, 17, 562, DateTimeKind.Utc).AddTicks(6598) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 27, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1479), new List<string>(), new DateTime(2024, 12, 25, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1478) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 28, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1494), new List<string> { "link3" }, new DateTime(2024, 12, 25, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1494) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 29, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1504), new List<string> { "link" }, new DateTime(2024, 12, 26, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 30, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1508), new List<string> { "link" }, new DateTime(2024, 12, 27, 12, 30, 17, 563, DateTimeKind.Utc).AddTicks(1507) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cityToOffer",
                keyColumns: new[] { "CityId", "OfferId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "cityToOffer",
                keyColumns: new[] { "CityId", "OfferId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "cityToOffer",
                keyColumns: new[] { "CityId", "OfferId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 24, 11, 24, 10, 168, DateTimeKind.Utc).AddTicks(9067), new List<string> { "link1", "link2" }, new DateTime(2024, 12, 23, 11, 24, 10, 168, DateTimeKind.Utc).AddTicks(8722) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 25, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3646), new List<string>(), new DateTime(2024, 12, 23, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3661), new List<string> { "link3" }, new DateTime(2024, 12, 23, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3661) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 27, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3670), new List<string> { "link" }, new DateTime(2024, 12, 24, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 28, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3674), new List<string> { "link" }, new DateTime(2024, 12, 25, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3673) });
        }
    }
}
