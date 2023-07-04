using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjectPTI.Migrations
{
    /// <inheritdoc />
    public partial class removingContract : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Aluno = table.Column<int>(type: "int", nullable: false),
                    Id_Professor = table.Column<int>(type: "int", nullable: false),
                    dtPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Aluno_Id_Aluno",
                        column: x => x.Id_Aluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_Professores_Id_Professor",
                        column: x => x.Id_Professor,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_Id_Aluno",
                table: "Contrato",
                column: "Id_Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_Id_Professor",
                table: "Contrato",
                column: "Id_Professor");
        }
    }
}
