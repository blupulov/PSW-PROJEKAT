using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class reviewsForTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "DoctorId", "Duration", "IsCanceled", "StartTime", "UserId" },
                values: new object[,]
                {
                    { 5L, 2L, 30, false, new DateTime(2022, 6, 22, 12, 20, 0, 0, DateTimeKind.Unspecified), 1L },
                    { 6L, 2L, 30, false, new DateTime(2022, 6, 21, 12, 20, 0, 0, DateTimeKind.Unspecified), 1L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
