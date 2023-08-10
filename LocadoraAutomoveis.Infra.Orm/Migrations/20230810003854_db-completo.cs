using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class dbcompleto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBCliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    Documento = table.Column<string>(type: "varchar(20)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(60)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(120)", nullable: false),
                    Rua = table.Column<string>(type: "varchar(100)", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBFuncionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBGrupoAutomovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomovel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBParceiro",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBParceiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBTaxaServico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoDiario = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTaxaServico", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TBAutomovel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImagemAutomovel = table.Column<byte[]>(type: "image", nullable: false),
                    GrupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Quilometragem = table.Column<int>(type: "int", nullable: false),
                    Cor = table.Column<string>(type: "varchar(100)", nullable: false),
                    Placa = table.Column<string>(type: "varchar(100)", nullable: false),
                    Combustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeLitros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomovel_TBGrupoAutomovel",
                        column: x => x.GrupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBPlanoCobranca",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Diaria = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Preco_KM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    KM_disponivel = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    grupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Plano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPlanoCobranca", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPlanoCobranca_TBGrupoAutomovel_grupoAutomovelId",
                        column: x => x.grupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBCupom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParceiroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCupom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBCupom_TBParceiro",
                        column: x => x.ParceiroId,
                        principalTable: "TBParceiro",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TBAluguel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrupoAutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlanoCobrancaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AutomovelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    quilometroAutomovel = table.Column<int>(type: "int", nullable: false),
                    CupomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataLocacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataPrevisaoRetorno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuilometrosRodados = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    CombustivelRestante = table.Column<int>(type: "int", nullable: true),
                    ValorTotal = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBAutomovel",
                        column: x => x.AutomovelId,
                        principalTable: "TBAutomovel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCliente",
                        column: x => x.ClienteId,
                        principalTable: "TBCliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCondutor",
                        column: x => x.CondutorId,
                        principalTable: "TBCondutor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBCupom",
                        column: x => x.CupomId,
                        principalTable: "TBCupom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBFuncionario",
                        column: x => x.FuncionarioId,
                        principalTable: "TBFuncionario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBGrupoAutomovel",
                        column: x => x.GrupoAutomovelId,
                        principalTable: "TBGrupoAutomovel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBPlanoCobranca_PlanoCobrancaId",
                        column: x => x.PlanoCobrancaId,
                        principalTable: "TBPlanoCobranca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBAluguel_TBTaxaEServico",
                columns: table => new
                {
                    AluguelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaxaServicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAluguel_TBTaxaEServico", x => new { x.AluguelId, x.TaxaServicosId });
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxaEServico_TBAluguel_AluguelId",
                        column: x => x.AluguelId,
                        principalTable: "TBAluguel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBAluguel_TBTaxaEServico_TBTaxaServico_TaxaServicosId",
                        column: x => x.TaxaServicosId,
                        principalTable: "TBTaxaServico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_AutomovelId",
                table: "TBAluguel",
                column: "AutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_ClienteId",
                table: "TBAluguel",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CondutorId",
                table: "TBAluguel",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_CupomId",
                table: "TBAluguel",
                column: "CupomId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_FuncionarioId",
                table: "TBAluguel",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_GrupoAutomovelId",
                table: "TBAluguel",
                column: "GrupoAutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_PlanoCobrancaId",
                table: "TBAluguel",
                column: "PlanoCobrancaId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAluguel_TBTaxaEServico_TaxaServicosId",
                table: "TBAluguel_TBTaxaEServico",
                column: "TaxaServicosId");

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomovel_GrupoAutomovelId",
                table: "TBAutomovel",
                column: "GrupoAutomovelId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_ClienteId",
                table: "TBCondutor",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_TBCupom_ParceiroId",
                table: "TBCupom",
                column: "ParceiroId");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_grupoAutomovelId",
                table: "TBPlanoCobranca",
                column: "grupoAutomovelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAluguel_TBTaxaEServico");

            migrationBuilder.DropTable(
                name: "TBAluguel");

            migrationBuilder.DropTable(
                name: "TBTaxaServico");

            migrationBuilder.DropTable(
                name: "TBAutomovel");

            migrationBuilder.DropTable(
                name: "TBCondutor");

            migrationBuilder.DropTable(
                name: "TBCupom");

            migrationBuilder.DropTable(
                name: "TBFuncionario");

            migrationBuilder.DropTable(
                name: "TBPlanoCobranca");

            migrationBuilder.DropTable(
                name: "TBCliente");

            migrationBuilder.DropTable(
                name: "TBParceiro");

            migrationBuilder.DropTable(
                name: "TBGrupoAutomovel");
        }
    }
}
