using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_Context_Library.Migrations
{
    public partial class InitalDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    PriorityID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PriorityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityID);
                });

            migrationBuilder.CreateTable(
                name: "Bugs",
                columns: table => new
                {
                    BugID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BugName = table.Column<string>(nullable: true),
                    DateTimeReported = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Images = table.Column<byte[]>(nullable: true),
                    BugPriorityPriorityID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugs", x => x.BugID);
                    table.ForeignKey(
                        name: "FK_Bugs_Priority_BugPriorityPriorityID",
                        column: x => x.BugPriorityPriorityID,
                        principalTable: "Priority",
                        principalColumn: "PriorityID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoteText = table.Column<string>(nullable: true),
                    BugID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_Bugs_BugID",
                        column: x => x.BugID,
                        principalTable: "Bugs",
                        principalColumn: "BugID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_BugPriorityPriorityID",
                table: "Bugs",
                column: "BugPriorityPriorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BugID",
                table: "Notes",
                column: "BugID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Bugs");

            migrationBuilder.DropTable(
                name: "Priority");
        }
    }
}
