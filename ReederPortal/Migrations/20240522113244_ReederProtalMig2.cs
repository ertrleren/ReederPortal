using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReederPortal.Migrations
{
    /// <inheritdoc />
    public partial class ReederProtalMig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeviyeID",
                table: "Personels",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Seviyes",
                columns: table => new
                {
                    SeviyeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeviyeAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seviyes", x => x.SeviyeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_SeviyeID",
                table: "Personels",
                column: "SeviyeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_Seviyes_SeviyeID",
                table: "Personels",
                column: "SeviyeID",
                principalTable: "Seviyes",
                principalColumn: "SeviyeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personels_Seviyes_SeviyeID",
                table: "Personels");

            migrationBuilder.DropTable(
                name: "Seviyes");

            migrationBuilder.DropIndex(
                name: "IX_Personels_SeviyeID",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "SeviyeID",
                table: "Personels");
        }
    }
}
