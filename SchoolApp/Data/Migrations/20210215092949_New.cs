using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolApp.Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass");

            migrationBuilder.RenameTable(
                name: "SchoolClass",
                newName: "SchoolClasses");

            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "SchoolClasses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_TeacherId",
                table: "SchoolClasses",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_AspNetUsers_TeacherId",
                table: "SchoolClasses",
                column: "TeacherId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_AspNetUsers_TeacherId",
                table: "SchoolClasses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SchoolClasses",
                table: "SchoolClasses");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_TeacherId",
                table: "SchoolClasses");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "SchoolClasses");

            migrationBuilder.RenameTable(
                name: "SchoolClasses",
                newName: "SchoolClass");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SchoolClass",
                table: "SchoolClass",
                column: "Id");
        }
    }
}
