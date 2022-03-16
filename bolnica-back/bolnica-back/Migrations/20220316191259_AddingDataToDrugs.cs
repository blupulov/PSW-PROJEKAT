using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace bolnica_back.Migrations
{
    public partial class AddingDataToDrugs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Drugs",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Drugs",
                columns: new[] { "Id", "Description", "Name", "Quantity" },
                values: new object[,]
                {
                    { 1L, "Za ublazavanje bolove u kostima", "Diklofenak duo", 10 },
                    { 2L, "Za ublazavanje bolova", "Panadol", 20 },
                    { 3L, "Za otklanjanje simptoma prehlade i gripa", "Coldrex 10", 20 },
                    { 4L, "Za otklanjanje povisene telesne temperature", "Brufen 400", 50 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Drugs",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Drugs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
