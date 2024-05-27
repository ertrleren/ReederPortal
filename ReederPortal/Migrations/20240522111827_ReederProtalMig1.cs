using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReederPortal.Migrations
{
    /// <inheritdoc />
    public partial class ReederProtalMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birims",
                columns: table => new
                {
                    BirimID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirimAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birims", x => x.BirimID);
                });

            migrationBuilder.CreateTable(
                name: "Unvans",
                columns: table => new
                {
                    UnvanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnvanAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unvans", x => x.UnvanID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TcKimlikNo = table.Column<long>(type: "bigint", nullable: true),
                    PersonelAd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonelSoyad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumYer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cinsiyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SurucuBelgesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedeniDurum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsCalismaDurum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CocukSayisi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SigaraKullanimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hobi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mezuniyet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IseBaslamaTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirimID = table.Column<int>(type: "int", nullable: false),
                    UnvanID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                    table.ForeignKey(
                        name: "FK_Personels_Birims_BirimID",
                        column: x => x.BirimID,
                        principalTable: "Birims",
                        principalColumn: "BirimID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personels_Unvans_UnvanID",
                        column: x => x.UnvanID,
                        principalTable: "Unvans",
                        principalColumn: "UnvanID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personels_BirimID",
                table: "Personels",
                column: "BirimID");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_UnvanID",
                table: "Personels",
                column: "UnvanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Birims");

            migrationBuilder.DropTable(
                name: "Unvans");
        }
    }
}
