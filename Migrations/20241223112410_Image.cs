using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CorporateOffers.Migrations
{
    /// <inheritdoc />
    public partial class Image : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "offers",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "ImagePath", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 24, 11, 24, 10, 168, DateTimeKind.Utc).AddTicks(9067), "", new List<string> { "link1", "link2" }, new DateTime(2024, 12, 23, 11, 24, 10, 168, DateTimeKind.Utc).AddTicks(8722) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "ImagePath", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 25, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3646), "", new List<string>(), new DateTime(2024, 12, 23, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3645) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "ImagePath", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3661), "", new List<string> { "link3" }, new DateTime(2024, 12, 23, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3661) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "ImagePath", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 27, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3670), "", new List<string> { "link" }, new DateTime(2024, 12, 24, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3669) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "ImagePath", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 28, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3674), "", new List<string> { "link" }, new DateTime(2024, 12, 25, 11, 24, 10, 169, DateTimeKind.Utc).AddTicks(3673) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "offers");

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 23, 7, 17, 1, 594, DateTimeKind.Utc).AddTicks(3987), new List<string> { "link1", "link2" }, new DateTime(2024, 12, 22, 7, 17, 1, 594, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 24, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1664), new List<string>(), new DateTime(2024, 12, 22, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1663) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 25, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1691), new List<string> { "link3" }, new DateTime(2024, 12, 22, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1691) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 26, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1707), new List<string> { "link" }, new DateTime(2024, 12, 23, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1707) });

            migrationBuilder.UpdateData(
                table: "offers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "Links", "StartDate" },
                values: new object[] { new DateTime(2024, 12, 27, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1711), new List<string> { "link" }, new DateTime(2024, 12, 24, 7, 17, 1, 595, DateTimeKind.Utc).AddTicks(1710) });
        }
    }
}
