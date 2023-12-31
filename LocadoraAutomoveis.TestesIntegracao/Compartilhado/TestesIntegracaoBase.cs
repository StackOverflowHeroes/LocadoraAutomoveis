﻿using FizzWare.NBuilder;
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
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infra.Orm.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infra.Orm.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Infra.Orm.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infra.Orm.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Infra.Orm.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Infra.Orm.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Infra.Orm.ModuloAluguel;

namespace LocadoraAutomoveis.TestesIntegracao.Compartilhado
{
    [TestClass]
    public class TestesIntegracaoBase
    {
        protected IRepositorioParceiro repositorioParceiro;
        protected IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        protected IRepositorioFuncionario repositorioFuncionario;
        protected IRepositorioCliente repositorioCliente;
        protected IRepositorioPlanoCobranca repositorioPlanoCobranca;
        protected IRepositorioCupom repositorioCupom;
        protected IRepositorioCondutor repositorioCondutor;
        protected IRepositorioAutomovel repositorioAutomovel;
        protected IRepositorioAluguel repositorioAluguel;

        protected IRepositorioTaxaServico repositorioTaxaServico;
        public TestesIntegracaoBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder<GeradorTestesDbContext>();

            optionsBuilder.UseSqlServer(connectionString);

            var dbContext = new GeradorTestesDbContext(optionsBuilder.Options);

            repositorioParceiro = new RepositorioParceiroEmOrm(dbContext);
           
            repositorioPlanoCobranca = new RepositorioPlanoCobrancaEmOrm(dbContext);
          
            repositorioTaxaServico = new RepositorioTaxaServicoEmOrm(dbContext);
            repositorioFuncionario = new RepositorioFuncionarioEmOrm(dbContext);
            repositorioCliente = new RepositorioClienteOrm(dbContext);
            repositorioGrupoAutomovel = new RepositorioGrupoAutomovelEmOrm(dbContext);
            repositorioCupom = new RepositorioCupomEmOrm(dbContext);
            repositorioCondutor = new RepositorioCondutorEmOrm(dbContext);
            repositorioAutomovel = new RepositorioAutomovelEmOrm(dbContext);
            repositorioAluguel = new RepositorioAluguelOrm(dbContext);

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(repositorioParceiro.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<GrupoAutomovel>(repositorioGrupoAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Funcionario>(repositorioFuncionario.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxaServico.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cliente>(repositorioCliente.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<PlanoCobranca>(repositorioPlanoCobranca.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Cupom>(repositorioCupom.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<TaxaServico>(repositorioTaxaServico.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Condutor>(repositorioCondutor.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Automovel>(repositorioAutomovel.Inserir);
            BuilderSetup.SetCreatePersistenceMethod<Aluguel>(repositorioAluguel.Inserir);

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
                DELETE FROM [DBO].[TBALUGUEL];
                DELETE FROM [DBO].[TBCONDUTOR];
                DELETE FROM [DBO].[TBCLIENTE];
                DELETE FROM [DBO].[TBCUPOM];
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBTAXASERVICO];
                DELETE FROM [DBO].[TBFUNCIONARIO];
                DELETE FROM [DBO].[TBAUTOMOVEL];
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
