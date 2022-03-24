using Microsoft.EntityFrameworkCore.Migrations;

namespace ChattyDAL.Migrations
{
    public partial class Fixnaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplyedName",
                table: "Users",
                newName: "DisplayedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayedName",
                table: "Users",
                newName: "DisplyedName");
        }
    }
}
