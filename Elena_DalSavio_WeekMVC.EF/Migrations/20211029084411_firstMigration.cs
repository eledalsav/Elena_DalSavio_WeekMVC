using Microsoft.EntityFrameworkCore.Migrations;

namespace Elena_DalSavio_WeekMVC.EF.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuPiattiId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuPiattiId);
                });

            migrationBuilder.CreateTable(
                name: "Piatto",
                columns: table => new
                {
                    PiattoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipologia = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MenuPiattiId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Piatto", x => x.PiattoId);
                    table.ForeignKey(
                        name: "FK_Piatto_Menu_MenuPiattiId",
                        column: x => x.MenuPiattiId,
                        principalTable: "Menu",
                        principalColumn: "MenuPiattiId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Piatto_MenuPiattiId",
                table: "Piatto",
                column: "MenuPiattiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Piatto");

            migrationBuilder.DropTable(
                name: "Menu");
        }
    }
}
