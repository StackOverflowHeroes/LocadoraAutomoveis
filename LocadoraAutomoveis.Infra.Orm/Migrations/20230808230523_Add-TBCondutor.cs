using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddTBCondutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCondutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(50)", nullable: false),
                    CNH = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "date", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCondutor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCondutor_TBCliente",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBCondutor");
        }
    }
}
