using FizzWare.NBuilder;
using GeradorTestes.Infra.Orm.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infra.Orm.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using LocadoraAutomoveis.Infra.Orm.ModuloParceiro;
using LocadoraAutomoveis.Infra.Orm.ModuloTaxaServico;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infra.Orm.ModuloCupom;

namespace LocadoraAutomoveis.TestesIntegracao.Compartilhado
{
    [TestClass]
    public class TestesIntegracaoBase
    {
        protected IRepositorioParceiro repositorioParceiro;
        protected IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        protected IRepositorioPlanoCobranca repositorioPlanoCobranca;
        protected IRepositorioCupom repositorioCupom;

        protected IRepositorioTaxaServico repositorioTaxaServico;
        public TestesIntegracaoBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<GeradorTestesDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new GeradorTestesDbContext(optionsBuilder.Options);

            repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
            repositorioTaxaServico = new RepositorioTaxaServicoEmOrm(dbContext);
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmOrm(dbContext);
            repositorioGrupoAutomovel = new RepositorioGrupoAutomovelEmOrm(dbContext);
            repositorioCupom = new RepositorioCupomEmOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupoAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);

            BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxaServico.Inserir);

        }

        private string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }

        private void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"         
                DELETE FROM [DBO].[TBCUPOM];
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBTAXASERVICO];
                DELETE FROM [DBO].[TBPLANOCOBRANCA];
                DELETE FROM [DBO].[TBGRUPOAUTOMOVEL];
                ";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
