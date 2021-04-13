using Microsoft.EntityFrameworkCore.Migrations;

namespace SISCLINICO.Migrations
{
    public partial class relacionpaciente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Procedimientos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pacienteIdPaciente",
                table: "Procedimientos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pacienteIdPaciente",
                table: "Odontograma",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "HistoricoPago",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pacienteIdPaciente",
                table: "HistoricoPago",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdPaciente",
                table: "Factura",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "pacienteIdPaciente",
                table: "Factura",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pacienteIdPaciente",
                table: "Cotizacion",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedimientos_pacienteIdPaciente",
                table: "Procedimientos",
                column: "pacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Odontograma_pacienteIdPaciente",
                table: "Odontograma",
                column: "pacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoPago_pacienteIdPaciente",
                table: "HistoricoPago",
                column: "pacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_pacienteIdPaciente",
                table: "Factura",
                column: "pacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Cotizacion_pacienteIdPaciente",
                table: "Cotizacion",
                column: "pacienteIdPaciente");

            migrationBuilder.AddForeignKey(
                name: "FK_Cotizacion_Paciente_pacienteIdPaciente",
                table: "Cotizacion",
                column: "pacienteIdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Factura_Paciente_pacienteIdPaciente",
                table: "Factura",
                column: "pacienteIdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoricoPago_Paciente_pacienteIdPaciente",
                table: "HistoricoPago",
                column: "pacienteIdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Odontograma_Paciente_pacienteIdPaciente",
                table: "Odontograma",
                column: "pacienteIdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Procedimientos_Paciente_pacienteIdPaciente",
                table: "Procedimientos",
                column: "pacienteIdPaciente",
                principalTable: "Paciente",
                principalColumn: "IdPaciente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cotizacion_Paciente_pacienteIdPaciente",
                table: "Cotizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Factura_Paciente_pacienteIdPaciente",
                table: "Factura");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoricoPago_Paciente_pacienteIdPaciente",
                table: "HistoricoPago");

            migrationBuilder.DropForeignKey(
                name: "FK_Odontograma_Paciente_pacienteIdPaciente",
                table: "Odontograma");

            migrationBuilder.DropForeignKey(
                name: "FK_Procedimientos_Paciente_pacienteIdPaciente",
                table: "Procedimientos");

            migrationBuilder.DropIndex(
                name: "IX_Procedimientos_pacienteIdPaciente",
                table: "Procedimientos");

            migrationBuilder.DropIndex(
                name: "IX_Odontograma_pacienteIdPaciente",
                table: "Odontograma");

            migrationBuilder.DropIndex(
                name: "IX_HistoricoPago_pacienteIdPaciente",
                table: "HistoricoPago");

            migrationBuilder.DropIndex(
                name: "IX_Factura_pacienteIdPaciente",
                table: "Factura");

            migrationBuilder.DropIndex(
                name: "IX_Cotizacion_pacienteIdPaciente",
                table: "Cotizacion");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Procedimientos");

            migrationBuilder.DropColumn(
                name: "pacienteIdPaciente",
                table: "Procedimientos");

            migrationBuilder.DropColumn(
                name: "pacienteIdPaciente",
                table: "Odontograma");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "HistoricoPago");

            migrationBuilder.DropColumn(
                name: "pacienteIdPaciente",
                table: "HistoricoPago");

            migrationBuilder.DropColumn(
                name: "IdPaciente",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "pacienteIdPaciente",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "pacienteIdPaciente",
                table: "Cotizacion");
        }
    }
}
