using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace data.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livres",
                columns: table => new
                {
                    IDLivre = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(nullable: true),
                    ISBN = table.Column<string>(nullable: true),
                    Auteur = table.Column<string>(nullable: true),
                    DateEdition = table.Column<DateTime>(nullable: false),
                    Categorie = table.Column<string>(nullable: true),
                    Disponibilite = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livres", x => x.IDLivre);
                });

            migrationBuilder.CreateTable(
                name: "Personnes",
                columns: table => new
                {
                    IDPersonne = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cin = table.Column<string>(nullable: true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    DateDeNaissance = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnes", x => x.IDPersonne);
                });

            migrationBuilder.CreateTable(
                name: "Exemplaires",
                columns: table => new
                {
                    IDExemplaire = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreExemplaire = table.Column<int>(nullable: false),
                    FKLivre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exemplaires", x => x.IDExemplaire);
                    table.ForeignKey(
                        name: "FK_Exemplaires_Livres_FKLivre",
                        column: x => x.FKLivre,
                        principalTable: "Livres",
                        principalColumn: "IDLivre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    IDReservation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Statut = table.Column<string>(nullable: true),
                    Commentaire = table.Column<string>(nullable: true),
                    FKLivre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.IDReservation);
                    table.ForeignKey(
                        name: "FK_Reservations_Livres_FKLivre",
                        column: x => x.FKLivre,
                        principalTable: "Livres",
                        principalColumn: "IDLivre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscrits",
                columns: table => new
                {
                    IDInscrit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeDInscription = table.Column<string>(nullable: true),
                    FaitDInscription = table.Column<DateTime>(nullable: false),
                    DateInscription = table.Column<DateTime>(nullable: false),
                    FKPersonne = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscrits", x => x.IDInscrit);
                    table.ForeignKey(
                        name: "FK_Inscrits_Personnes_FKPersonne",
                        column: x => x.FKPersonne,
                        principalTable: "Personnes",
                        principalColumn: "IDPersonne",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adherents",
                columns: table => new
                {
                    IDInscrit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateDInscription = table.Column<DateTime>(nullable: false),
                    FKInscrit = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adherents", x => x.IDInscrit);
                    table.ForeignKey(
                        name: "FK_Adherents_Inscrits_FKInscrit",
                        column: x => x.FKInscrit,
                        principalTable: "Inscrits",
                        principalColumn: "IDInscrit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprunts",
                columns: table => new
                {
                    IDEmprunt = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEmprunt = table.Column<DateTime>(nullable: false),
                    DateRetour = table.Column<DateTime>(nullable: false),
                    FKAdherent = table.Column<int>(nullable: false),
                    FKLivre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprunts", x => x.IDEmprunt);
                    table.ForeignKey(
                        name: "FK_Emprunts_Adherents_FKAdherent",
                        column: x => x.FKAdherent,
                        principalTable: "Adherents",
                        principalColumn: "IDInscrit",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprunts_Livres_FKLivre",
                        column: x => x.FKLivre,
                        principalTable: "Livres",
                        principalColumn: "IDLivre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adherents_FKInscrit",
                table: "Adherents",
                column: "FKInscrit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_FKAdherent",
                table: "Emprunts",
                column: "FKAdherent");

            migrationBuilder.CreateIndex(
                name: "IX_Emprunts_FKLivre",
                table: "Emprunts",
                column: "FKLivre");

            migrationBuilder.CreateIndex(
                name: "IX_Exemplaires_FKLivre",
                table: "Exemplaires",
                column: "FKLivre");

            migrationBuilder.CreateIndex(
                name: "IX_Inscrits_FKPersonne",
                table: "Inscrits",
                column: "FKPersonne");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FKLivre",
                table: "Reservations",
                column: "FKLivre");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprunts");

            migrationBuilder.DropTable(
                name: "Exemplaires");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Adherents");

            migrationBuilder.DropTable(
                name: "Livres");

            migrationBuilder.DropTable(
                name: "Inscrits");

            migrationBuilder.DropTable(
                name: "Personnes");
        }
    }
}
