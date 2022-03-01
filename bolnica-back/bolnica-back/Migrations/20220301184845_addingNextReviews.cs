using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class addingNextReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "DoctorId", "Duration", "IsCanceled", "StartTime", "UserId" },
                values: new object[] { 6L, 2L, 30, false, new DateTime(2022, 12, 26, 12, 20, 0, 0, DateTimeKind.Unspecified), 1L });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
