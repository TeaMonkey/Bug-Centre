using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DB_Context_Library.Migrations
{
    public partial class UpdateBugDBStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Bugs",
                newName: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Bugs",
                newName: "Images");
        }
    }
}
