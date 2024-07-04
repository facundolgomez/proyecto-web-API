using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class migrationlol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Apellido", "Direccion", "Email", "Nombre" },
                values: new object[] { "Gerosa", "Salta 3572", "marianogerosa@gmail.com", "Mariano" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Apellido", "Direccion", "Email", "Nombre" },
                values: new object[] { "Gates", "Main Street", "billgates@gmail.com", "Bill" });
        }
    }
}
