using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LFTV.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmissionNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JourDeLaSemaine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenuNom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contenus_Emissions_EmissionId",
                        column: x => x.EmissionId,
                        principalTable: "Emissions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contenus_EmissionId",
                table: "Contenus",
                column: "EmissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contenus");

            migrationBuilder.DropTable(
                name: "Emissions");
        }
    }
}
