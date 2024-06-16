using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnInMascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tipoMascota",
                table: "Mascotas",
                newName: "TipoMascota");

            migrationBuilder.AddColumn<int>(
                name: "ReservaId",
                table: "Mascotas",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReservaId",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "TipoMascota",
                table: "Mascotas",
                newName: "tipoMascota");
        }
    }
}
