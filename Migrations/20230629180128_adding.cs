using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjectPTI.Migrations
{
    /// <inheritdoc />
    public partial class adding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "diaAula",
                table: "Aula",
                newName: "diaSemanaAula");

            migrationBuilder.AddColumn<DateTime>(
                name: "dataMesAula",
                table: "Aula",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataMesAula",
                table: "Aula");

            migrationBuilder.RenameColumn(
                name: "diaSemanaAula",
                table: "Aula",
                newName: "diaAula");
        }
    }
}
