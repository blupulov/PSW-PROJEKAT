using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "EMail", "Gender", "Jmbg", "Name", "Password", "PhoneNumber", "Role", "Surname", "Username" },
                values: new object[] { 2L, "Dositejea 2", "mm@gmail.com", 0, "321321321", "Mika", "123", "023857555", 0, "Mikic", "mika" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
