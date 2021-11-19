using Microsoft.EntityFrameworkCore.Migrations;

namespace bolnica_back.Migrations
{
    public partial class isAdminmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Gender",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Address", "Gender" },
                values: new object[] { "Dositejeva 2", 0 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "EMail", "Gender", "IsAdmin", "IsBlocked", "Jmbg", "Name", "Password", "PhoneNumber", "Surname", "Username" },
                values: new object[] { 3L, "Pupinova 222", "nn@gmail.com", 1, false, false, "98989898", "Nadica", "123", "023857999", "Nadic", "nada" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Gender", "Role" },
                values: new object[] { "muski", "pacijent" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "Address", "Gender", "Role" },
                values: new object[] { "Dositejea 2", "muski", "pacijent" });
        }
    }
}
