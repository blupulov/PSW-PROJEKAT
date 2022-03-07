using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace bolnica_back.Migrations
{
    public partial class AddingSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Surveys",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Grade = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    IsAnonymous = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Surveys_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Surveys",
                columns: new[] { "Id", "Comment", "CreationDate", "Grade", "IsAnonymous", "IsPublished", "UserId" },
                values: new object[,]
                {
                    { 1L, "Neki komentar 1", new DateTime(2021, 12, 10, 10, 10, 10, 0, DateTimeKind.Unspecified), 4, false, false, 1L },
                    { 2L, "Neki komentar 2", new DateTime(2022, 1, 12, 12, 30, 55, 0, DateTimeKind.Unspecified), 3, true, false, 1L },
                    { 3L, "Neki komentar 3", new DateTime(2021, 10, 1, 8, 21, 22, 0, DateTimeKind.Unspecified), 5, false, false, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surveys_UserId",
                table: "Surveys",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveys");
        }
    }
}
