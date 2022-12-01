using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venta_id_inmueble",
                table: "Venta");

            migrationBuilder.AddColumn<bool>(
                name: "vendido",
                table: "Inmueble",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_inmueble",
                table: "Venta",
                column: "id_inmueble");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Venta_id_inmueble",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "vendido",
                table: "Inmueble");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_inmueble",
                table: "Venta",
                column: "id_inmueble",
                unique: true);
        }
    }
}
