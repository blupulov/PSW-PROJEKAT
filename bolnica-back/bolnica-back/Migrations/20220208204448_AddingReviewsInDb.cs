using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class AddingReviewsInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "DoctorId", "Duration", "IsCanceled", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 3L, 1L, 30, false, new DateTime(2022, 2, 26, 10, 20, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 4L, 1L, 30, false, new DateTime(2022, 2, 26, 11, 20, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 5L, 1L, 30, false, new DateTime(2022, 2, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), 1L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L);
        }
    }
}
