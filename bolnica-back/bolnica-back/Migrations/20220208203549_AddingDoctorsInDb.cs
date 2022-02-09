using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class AddingDoctorsInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "EMail", "Name", "Password", "Phone", "Surname", "Username", "WorkingDuration", "WorkingStart" },
                values: new object[,]
                {
                    { 2L, "ss@gmail.com", "Stole", "123", "347237942", "Stosic", "stole", 5, 10 },
                    { 3L, "misa@gmail.com", "Misa", "123", "7998237", "Misic", "misa", 8, 10 },
                    { 4L, "rada@gmail.com", "Rada", "123", "480238048", "Radic", "rada", 4, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
