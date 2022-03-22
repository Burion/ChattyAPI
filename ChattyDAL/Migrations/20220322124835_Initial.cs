using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChattyDAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    AuthorLogin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReceiverLogin = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachedImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => new { x.AuthorLogin, x.ReceiverLogin, x.SendingDate });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Login = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplyedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Login);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
