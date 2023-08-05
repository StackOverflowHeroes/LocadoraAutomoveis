using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace LocadoraAutomoveis.Infra.MassaDados
{
    public class GeradorMassaDados
    {
        IRepositorioParceiro repositorioParceiro;
        IRepositorioTaxaServico repositorioTaxaServico;
        IRepositorioFuncionario repositorioFuncionario;

        public GeradorMassaDados(IRepositorioParceiro repositorioParceiro, IRepositorioTaxaServico repositorioTaxaServico, IRepositorioFuncionario repositorioFuncionario)
        {
            this.repositorioParceiro = repositorioParceiro;
            this.repositorioTaxaServico = repositorioTaxaServico;
            this.repositorioFuncionario = repositorioFuncionario;
        }

        public void IncrementarDados()
        {
            //LimparTabelas();
            IncrementarDadosParceiros();
            IncrementarDadosTaxaServico();
            //IncrementarDadosFuncionario();
        }

        //private void IncrementarDadosFuncionario()
        //{
        //    Funcionario f1 = new Funcionario();
        //}

        public void IncrementarDadosTaxaServico()
        {
            TaxaServico ts1 = new TaxaServico(true, "Cadeirinha", 25.50m);
            TaxaServico ts2 = new TaxaServico(true, "GPS", 20.00m);
            TaxaServico ts3 = new TaxaServico(false, "Lavação", 10.00m);
            TaxaServico ts4 = new TaxaServico(false, "Translado", 25.00m);
            TaxaServico ts5 = new TaxaServico(true, "Seguro", 25.00m);

            List<TaxaServico> taxaServicos = new List<TaxaServico>() { ts1, ts2, ts3, ts4, ts5 };

            foreach (TaxaServico ts in taxaServicos)
            {
                repositorioTaxaServico.Inserir(ts);
            }
        }

        public void IncrementarDadosParceiros()
        {
            Parceiro p1 = new Parceiro("KmDeVantagens");
            Parceiro p2 = new Parceiro("Mastercard");
            Parceiro p3 = new Parceiro("Bradesco");
            Parceiro p4 = new Parceiro("Swan");
            Parceiro p5 = new Parceiro("Inter");

            List<Parceiro> parceiros = new List<Parceiro>() { p1, p2, p3, p4, p5 };

            foreach (Parceiro p in parceiros)
            {
                repositorioParceiro.Inserir(p);
            }
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

        public void LimparTabelas()
        {
            string? connectionString = ObterConnectionString();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string sqlLimpezaTabela =
                @"
                DELETE FROM [DBO].[TBPARCEIRO];
                DELETE FROM [DBO].[TBTAXASERVICO];
                DELETE FROM [DBO].[TBFUNCIONARIO];";

            SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            sqlConnection.Open();

            comando.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
