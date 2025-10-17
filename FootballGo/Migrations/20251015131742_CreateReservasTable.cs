using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FootballGo.Migrations
{
    /// <inheritdoc />
    public partial class CreateReservasTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canchas",
                columns: table => new
                {
                    IdCancha = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NroCancha = table.Column<int>(type: "int", nullable: false),
                    EstadoCancha = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TipoCancha = table.Column<int>(type: "int", nullable: false),
                    PrecioPorHora = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canchas", x => x.IdCancha);
                    table.CheckConstraint("CK_Canchas_Estado", "EstadoCancha IN ('Disponible','Mantenimiento','Ocupada')");
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    IdReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCancha = table.Column<int>(type: "int", nullable: false),
                    mailUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservas_Canchas_IdCancha",
                        column: x => x.IdCancha,
                        principalTable: "Canchas",
                        principalColumn: "IdCancha",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canchas_NroCancha",
                table: "Canchas",
                column: "NroCancha",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_IdCancha",
                table: "Reservas",
                column: "IdCancha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Canchas");
        }
    }
}
