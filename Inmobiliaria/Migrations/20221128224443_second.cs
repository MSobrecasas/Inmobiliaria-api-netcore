using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inmobiliaria.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condicion",
                columns: table => new
                {
                    id_condicion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    des_condicion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condicion", x => x.id_condicion);
                });

            migrationBuilder.CreateTable(
                name: "TipoInmueble",
                columns: table => new
                {
                    id_tipo_inmueble = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    desc_inmueble = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInmueble", x => x.id_tipo_inmueble);
                });

            migrationBuilder.CreateTable(
                name: "Inmueble",
                columns: table => new
                {
                    id_inmueble = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_tipo_inmueble = table.Column<int>(type: "int", nullable: false),
                    desc_inmueble = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ubic_inmueble = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    costo_inmueble = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inmueble", x => x.id_inmueble);
                    table.ForeignKey(
                        name: "FK_Inmueble_TipoInmueble_id_tipo_inmueble",
                        column: x => x.id_tipo_inmueble,
                        principalTable: "TipoInmueble",
                        principalColumn: "id_tipo_inmueble",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    id_venta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_inmueble = table.Column<int>(type: "int", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_condicion = table.Column<int>(type: "int", nullable: false),
                    id_forma_pago = table.Column<int>(type: "int", nullable: false),
                    desc_venta = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    total_venta = table.Column<float>(type: "real", nullable: false),
                    total_iva = table.Column<float>(type: "real", nullable: false),
                    total_general = table.Column<float>(type: "real", nullable: false),
                    fecha_venta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.id_venta);
                    table.ForeignKey(
                        name: "FK_Venta_Cliente_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "Cliente",
                        principalColumn: "id_cliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Condicion_id_condicion",
                        column: x => x.id_condicion,
                        principalTable: "Condicion",
                        principalColumn: "id_condicion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_FormaPago_id_forma_pago",
                        column: x => x.id_forma_pago,
                        principalTable: "FormaPago",
                        principalColumn: "id_forma_pago",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Venta_Inmueble_id_inmueble",
                        column: x => x.id_inmueble,
                        principalTable: "Inmueble",
                        principalColumn: "id_inmueble",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inmueble_id_tipo_inmueble",
                table: "Inmueble",
                column: "id_tipo_inmueble");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_cliente",
                table: "Venta",
                column: "id_cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_condicion",
                table: "Venta",
                column: "id_condicion");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_forma_pago",
                table: "Venta",
                column: "id_forma_pago");

            migrationBuilder.CreateIndex(
                name: "IX_Venta_id_inmueble",
                table: "Venta",
                column: "id_inmueble",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venta");

            migrationBuilder.DropTable(
                name: "Condicion");

            migrationBuilder.DropTable(
                name: "Inmueble");

            migrationBuilder.DropTable(
                name: "TipoInmueble");
        }
    }
}
