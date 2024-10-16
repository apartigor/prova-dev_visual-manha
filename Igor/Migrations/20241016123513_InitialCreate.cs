using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Igor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folhas",
                columns: table => new
                {
                    folhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    mes = table.Column<int>(type: "INTEGER", nullable: false),
                    ano = table.Column<int>(type: "INTEGER", nullable: false),
                    salarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    impostoIrrf = table.Column<double>(type: "REAL", nullable: false),
                    impostoInss = table.Column<double>(type: "REAL", nullable: false),
                    impostoFgts = table.Column<double>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folhas", x => x.folhaId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nome = table.Column<string>(type: "TEXT", nullable: true),
                    cpf = table.Column<string>(type: "TEXT", nullable: true),
                    folhaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.funcionarioId);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Folhas_folhaId",
                        column: x => x.folhaId,
                        principalTable: "Folhas",
                        principalColumn: "folhaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_folhaId",
                table: "Funcionarios",
                column: "folhaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Folhas");
        }
    }
}
