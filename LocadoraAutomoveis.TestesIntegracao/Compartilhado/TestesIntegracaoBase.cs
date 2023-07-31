using FizzWare.NBuilder;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace GeradorTestes.TestesIntegracao.Compartilhado
{
    public class TestesIntegracaoBase
    {
        //protected IRepositorioDisciplina repositorioDisciplina;
        //protected IRepositorioMateria repositorioMateria;
        //protected IRepositorioQuestao repositorioQuestao;

        public TestesIntegracaoBase()
        {
            LimparTabelas();

            string connectionString = ObterConnectionString();

            //repositorioDisciplina = new RepositorioDisciplinaEmSql(connectionString);
            //repositorioMateria = new RepositorioMateriaEmSql(connectionString);
            //repositorioQuestao = new RepositorioQuestaoEmSql(connectionString);

            //BuilderSetup.SetCreatePersistenceMethod<Disciplina>(repositorioDisciplina.Inserir);
            //BuilderSetup.SetCreatePersistenceMethod<Materia>(repositorioMateria.Inserir);
            //BuilderSetup.SetCreatePersistenceMethod<Questao>(repositorioQuestao.Inserir);
        }

        protected static void LimparTabelas()
        {
            //string? connectionString = ObterConnectionString();

            //SqlConnection sqlConnection = new SqlConnection(connectionString);

            //string sqlLimpezaTabela =
            //    @"
            //    DELETE FROM [DBO].[TBQUESTAO]
            //    DBCC CHECKIDENT ('[TBQUESTAO]', RESEED, 0);

            //    DELETE FROM [DBO].[TBMATERIA]
            //    DBCC CHECKIDENT ('[TBMATERIA]', RESEED, 0);

            //    DELETE FROM [DBO].[TBDISCIPLINA]
            //    DBCC CHECKIDENT ('[TBDISCIPLINA]', RESEED, 0);";

            //SqlCommand comando = new SqlCommand(sqlLimpezaTabela, sqlConnection);

            //sqlConnection.Open();

            //comando.ExecuteNonQuery();

            //sqlConnection.Close();
        }

        protected static string ObterConnectionString()
        {
            var configuracao = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");
            return connectionString;
        }
    }
}