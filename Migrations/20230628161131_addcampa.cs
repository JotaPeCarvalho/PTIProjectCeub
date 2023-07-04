using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProjectPTI.Migrations
{
    /// <inheritdoc />
    public partial class addcampa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "dtAula",
                table: "Aula",
                newName: "horaAula");

            migrationBuilder.AddColumn<int>(
                name: "diaAula",
                table: "Aula",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "diaAula",
                table: "Aula");

            migrationBuilder.RenameColumn(
                name: "horaAula",
                table: "Aula",
                newName: "dtAula");
        }
    }
}
