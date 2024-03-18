using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addlocalizforname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "DName",
                table: "Departments",
                newName: "DNameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNameAr",
                table: "Departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DNameAr",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DNameEn",
                table: "Departments",
                newName: "DName");
        }
    }
}
