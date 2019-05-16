using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBLivros.Migrations
{
    public partial class InicialComDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    AutorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.AutorId);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    LivroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    AutorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.LivroId);
                    table.ForeignKey(
                        name: "FK_Livros_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Capitulos",
                columns: table => new
                {
                    CapituloId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LivroId = table.Column<int>(nullable: false),
                    Conteudo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Capitulos", x => x.CapituloId);
                    table.ForeignKey(
                        name: "FK_Capitulos_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroCategorias",
                columns: table => new
                {
                    LivroId = table.Column<int>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroCategorias", x => new { x.LivroId, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_LivroCategorias_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivroCategorias_Livros_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livros",
                        principalColumn: "LivroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Autores",
                columns: new[] { "AutorId", "Nome" },
                values: new object[,]
                {
                    { -1, "Andre" },
                    { -2, "Carlos" },
                    { -3, "Tassia" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "CategoriaId", "Descricao" },
                values: new object[,]
                {
                    { -1, "Ficção" },
                    { -2, "Infantil" },
                    { -3, "Romance" },
                    { -4, "Mais vendidos" }
                });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "LivroId", "AutorId", "Nome" },
                values: new object[] { -1, -1, "Livro de Ficção" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "LivroId", "AutorId", "Nome" },
                values: new object[] { -2, -2, "Livro Infantil" });

            migrationBuilder.InsertData(
                table: "Livros",
                columns: new[] { "LivroId", "AutorId", "Nome" },
                values: new object[] { -3, -3, "Livro de Romance" });

            migrationBuilder.InsertData(
                table: "Capitulos",
                columns: new[] { "CapituloId", "Conteudo", "LivroId" },
                values: new object[,]
                {
                    { -1, "Primeiro capitulo de ficção", -1 },
                    { -2, "Segundo capitulo de ficção", -1 },
                    { -3, "Terceiro capitulo de ficção", -1 },
                    { -4, "Primeiro capitulo de infantil", -2 },
                    { -5, "Segundo capitulo de infantil", -2 },
                    { -6, "Primeiro capitulo de romance", -3 },
                    { -7, "Segundo capitulo de romance", -3 }
                });

            migrationBuilder.InsertData(
                table: "LivroCategorias",
                columns: new[] { "LivroId", "CategoriaId" },
                values: new object[,]
                {
                    { -1, -1 },
                    { -1, -4 },
                    { -2, -2 },
                    { -2, -4 },
                    { -3, -3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Capitulos_LivroId",
                table: "Capitulos",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroCategorias_CategoriaId",
                table: "LivroCategorias",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_AutorId",
                table: "Livros",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Capitulos");

            migrationBuilder.DropTable(
                name: "LivroCategorias");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
