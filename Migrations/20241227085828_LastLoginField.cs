using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorporateOffers.Migrations
{
    /// <inheritdoc />
    public partial class LastLoginField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastLogin",
                table: "users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 28, 8, 58, 27, 546, DateTimeKind.Utc).AddTicks(5071), new List<string> { "link1", "link2" }, new DateTime(2024, 12, 27, 8, 58, 27, 546, DateTimeKind.Utc).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 29, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1107), new List<string>(), new DateTime(2024, 12, 27, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 30, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1162), new List<string> { "link3" }, new DateTime(2024, 12, 27, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1161) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 31, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1193), new List<string> { "link" }, new DateTime(2024, 12, 28, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1190) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2025, 1, 1, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1204), new List<string> { "link" }, new DateTime(2024, 12, 29, 8, 58, 27, 548, DateTimeKind.Utc).AddTicks(1202) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastLogin",
                value: null);

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastLogin",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastLogin",
                table: "users");

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
    }
}
