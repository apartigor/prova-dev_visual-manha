using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Igor.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Folhas_folhaId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_folhaId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "folhaId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "funcionarioId",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_funcionarioId",
                table: "Folhas",
                column: "funcionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_funcionarioId",
                table: "Folhas",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "funcionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_funcionarioId",
                table: "Folhas");

            migrationBuilder.DropIndex(
                name: "IX_Folhas_funcionarioId",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "funcionarioId",
                table: "Folhas");

            migrationBuilder.AddColumn<int>(
                name: "folhaId",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_folhaId",
                table: "Funcionarios",
                column: "folhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Folhas_folhaId",
                table: "Funcionarios",
                column: "folhaId",
                principalTable: "Folhas",
                principalColumn: "folhaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
