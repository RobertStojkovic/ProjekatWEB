using Microsoft.EntityFrameworkCore.Migrations;

namespace Kafic_Backend.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kafic",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kapacitet = table.Column<int>(type: "int", nullable: false),
                    MaxLjudi = table.Column<int>(type: "int", nullable: false),
                    MaxLokala = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kafic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbina",
                columns: table => new
                {
                    IDPorudzbine = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deserti = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Pice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KaficID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbina", x => x.IDPorudzbine);
                    table.ForeignKey(
                        name: "FK_Porudzbina_Kafic_KaficID",
                        column: x => x.KaficID,
                        principalTable: "Kafic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sto",
                columns: table => new
                {
                    IDStola = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojStola = table.Column<int>(type: "int", nullable: false),
                    Stanje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MaxKapacitet = table.Column<int>(type: "int", nullable: false),
                    KapacitetStola = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    KaficID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sto", x => x.IDStola);
                    table.ForeignKey(
                        name: "FK_Sto_Kafic_KaficID",
                        column: x => x.KaficID,
                        principalTable: "Kafic",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_KaficID",
                table: "Porudzbina",
                column: "KaficID");

            migrationBuilder.CreateIndex(
                name: "IX_Sto_KaficID",
                table: "Sto",
                column: "KaficID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Porudzbina");

            migrationBuilder.DropTable(
                name: "Sto");

            migrationBuilder.DropTable(
                name: "Kafic");
        }
    }
}
