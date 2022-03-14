using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class AddSpecialists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "EMail", "Name", "Password", "Phone", "Specialist", "Surname", "Username", "WorkingDuration", "WorkingStart" },
                values: new object[,]
                {
                    { 5L, "lale@gmail.com", "Lale", "123", "648236486", true, "Lakic", "laki", 8, 10 },
                    { 6L, "anci@gmail.com", "Ana", "123", "73320220", true, "Lakic", "ana", 6, 12 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6L);
        }
    }
}
