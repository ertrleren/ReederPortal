using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReederPortal.Migrations
{
    /// <inheritdoc />
    public partial class ReederPartalMig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sifre",
                table: "Personels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "Sifre",
                table: "Personels");
        }
    }
}
