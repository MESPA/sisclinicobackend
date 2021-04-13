using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISCLINICO.Migrations
{
    public partial class citas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    IdCitas = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdPaciente = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    pacienteIdPaciente = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    IdDoctores = table.Column<int>(nullable: false),
                    doctoresIdDoctores = table.Column<int>(nullable: true),
                    NombreCompletoPaciente = table.Column<string>(nullable: true),
                    NombreCompletoDoctor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.IdCitas);
                    table.ForeignKey(
                        name: "FK_Citas_Doctores_doctoresIdDoctores",
                        column: x => x.doctoresIdDoctores,
                        principalTable: "Doctores",
                        principalColumn: "IdDoctores",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Paciente_pacienteIdPaciente",
                        column: x => x.pacienteIdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_doctoresIdDoctores",
                table: "Citas",
                column: "doctoresIdDoctores");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_pacienteIdPaciente",
                table: "Citas",
                column: "pacienteIdPaciente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");
        }
    }
}
