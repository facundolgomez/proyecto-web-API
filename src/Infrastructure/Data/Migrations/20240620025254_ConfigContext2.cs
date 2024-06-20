using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigContext2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Guarderias_GuarderiaId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "GuarderiaId",
                table: "Reservas",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Guarderias_GuarderiaId",
                table: "Reservas",
                column: "GuarderiaId",
                principalTable: "Guarderias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Guarderias_GuarderiaId",
                table: "Reservas");

            migrationBuilder.AlterColumn<int>(
                name: "GuarderiaId",
                table: "Reservas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Guarderias_GuarderiaId",
                table: "Reservas",
                column: "GuarderiaId",
                principalTable: "Guarderias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
