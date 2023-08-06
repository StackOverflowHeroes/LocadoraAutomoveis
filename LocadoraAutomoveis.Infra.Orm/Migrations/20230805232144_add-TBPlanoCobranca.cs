using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class addTBPlanoCobranca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Diaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco_KM = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    KM_disponivel = table.Column<int>(type: "int", nullable: true),
                    grupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBGrupoAutomovel",
                        column: x => x.grupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_grupoAutomovelId",
                table: "TBPlanoCobranca",
                column: "grupoAutomovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");
        }
    }
}
