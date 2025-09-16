using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiApi.Migrations
{
    /// <inheritdoc />
    public partial class Mandril : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mandrils",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    apellido = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mandrils", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Habilidad",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nombre = table.Column<string>(type: "TEXT", nullable: false),
                    potencia = table.Column<int>(type: "INTEGER", nullable: false),
                    Mandrilid = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidad", x => x.id);
                    table.ForeignKey(
                        name: "FK_Habilidad_Mandrils_Mandrilid",
                        column: x => x.Mandrilid,
                        principalTable: "Mandrils",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Habilidad_Mandrilid",
                table: "Habilidad",
                column: "Mandrilid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Habilidad");

            migrationBuilder.DropTable(
                name: "Mandrils");
        }
    }
}
