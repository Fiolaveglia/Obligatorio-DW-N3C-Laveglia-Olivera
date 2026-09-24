using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Obligatorio.Infraestructura.Migrations
{
    /// <inheritdoc />
    public partial class Historias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "Email_Email");

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: true),
                    TipoCapitulo = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Contador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sinopsis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    CapituloInicialId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historias_Capitulos_CapituloInicialId",
                        column: x => x.CapituloInicialId,
                        principalTable: "Capitulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Opcion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapituloDestinoId = table.Column<int>(type: "int", nullable: false),
                    CapituloId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcion_Capitulos_CapituloDestinoId",
                        column: x => x.CapituloDestinoId,
                        principalTable: "Capitulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Opcion_Capitulos_CapituloId",
                        column: x => x.CapituloId,
                        principalTable: "Capitulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaHistoria",
                columns: table => new
                {
                    CategoriasId = table.Column<int>(type: "int", nullable: false),
                    HistoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaHistoria", x => new { x.CategoriasId, x.HistoriaId });
                    table.ForeignKey(
                        name: "FK_CategoriaHistoria_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaHistoria_Historias_HistoriaId",
                        column: x => x.HistoriaId,
                        principalTable: "Historias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capitulos_HistoriaId",
                table: "Capitulos",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaHistoria_HistoriaId",
                table: "CategoriaHistoria",
                column: "HistoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Historias_CapituloInicialId",
                table: "Historias",
                column: "CapituloInicialId");

            migrationBuilder.CreateIndex(
                name: "IX_Opcion_CapituloDestinoId",
                table: "Opcion",
                column: "CapituloDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Opcion_CapituloId",
                table: "Opcion",
                column: "CapituloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Capitulos_Historias_HistoriaId",
                table: "Capitulos",
                column: "HistoriaId",
                principalTable: "Historias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Capitulos_Historias_HistoriaId",
                table: "Capitulos");

            migrationBuilder.DropTable(
                name: "CategoriaHistoria");

            migrationBuilder.DropTable(
                name: "Opcion");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Historias");

            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.RenameColumn(
                name: "Email_Email",
                table: "Usuarios",
                newName: "Email");
        }
    }
}
