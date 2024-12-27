using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorporateOffers.Migrations
{
    /// <inheritdoc />
    public partial class SeedEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 28, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(745), new List<string> { "link1", "link2" }, new DateTime(2024, 12, 27, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(408) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 29, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5348), new List<string>(), new DateTime(2024, 12, 27, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5347) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 30, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5367), new List<string> { "link3" }, new DateTime(2024, 12, 27, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5367) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 31, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5377), new List<string> { "link" }, new DateTime(2024, 12, 28, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5376) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 1, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5380), new List<string> { "link" }, new DateTime(2024, 12, 29, 13, 28, 14, 941, DateTimeKind.Utc).AddTicks(5380) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "email@mail.ru");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 28, 10, 56, 50, 713, DateTimeKind.Utc).AddTicks(7410), new List<string> { "link1", "link2" }, new DateTime(2024, 12, 27, 10, 56, 50, 713, DateTimeKind.Utc).AddTicks(7070) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 29, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1925), new List<string>(), new DateTime(2024, 12, 27, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1924) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 30, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1942), new List<string> { "link3" }, new DateTime(2024, 12, 27, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1941) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 31, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1950), new List<string> { "link" }, new DateTime(2024, 12, 28, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1950) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 1, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1954), new List<string> { "link" }, new DateTime(2024, 12, 29, 10, 56, 50, 714, DateTimeKind.Utc).AddTicks(1953) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "email");
        }
    }
}
