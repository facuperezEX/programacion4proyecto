using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto4programacion.Migrations
{
    /// <inheritdoc />
    public partial class AddSolicitudEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    FechaCierre = table.Column<DateOnly>(type: "date", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    ActivoId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateOnly>(type: "date", nullable: false),
                    ReferenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitudes");
        }
    }
}
