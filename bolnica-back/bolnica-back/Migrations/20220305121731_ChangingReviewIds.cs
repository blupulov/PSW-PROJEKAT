using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class ChangingReviewIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "StartTime",
                value: new DateTime(2022, 2, 26, 12, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "StartTime",
                value: new DateTime(2022, 12, 26, 12, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "DoctorId", "Duration", "IsCanceled", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 1L, 2L, 30, false, new DateTime(2022, 2, 26, 10, 20, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 2L, 2L, 30, false, new DateTime(2022, 2, 26, 11, 20, 0, 0, DateTimeKind.Unspecified), 1L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L,
                column: "StartTime",
                value: new DateTime(2022, 2, 26, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L,
                column: "StartTime",
                value: new DateTime(2022, 2, 26, 11, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "DoctorId", "Duration", "IsCanceled", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 5L, 2L, 30, false, new DateTime(2022, 2, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 6L, 2L, 30, false, new DateTime(2022, 12, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), 1L }
                });
        }
    }
}
