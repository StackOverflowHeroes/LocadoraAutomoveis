using LocadoraAutomoveis.Dominio.ModuloAluguel;
using System.Text.Json.Serialization;

namespace LocadoraAutomoveis.Infra.Arquivos.Compartilhado
{
     public class RepositorioConfiguracaoEmArquivo : IRepositorioConfiguracaoPreco
     {
          private const string NOME_ARQUIVO = @"Compartilhado\ConfiguracoesPreco.json";

          public ConfiguracaoPreco configuracaoPreco;

          public RepositorioConfiguracaoEmArquivo(bool carregarDados)
          {
               if (carregarDados == true)
                    CarregarDoArquivoJson();
          }

          public void GravarConfiguracoesPreco(ConfiguracaoPreco configuracaoPreco)
          {
               this.configuracaoPreco = configuracaoPreco;

               JsonSerializerOptions config = ObterConfiguracoesDeSerializacao();

               string registrosJson = JsonSerializer.Serialize(configuracaoPreco, config)!;

               File.WriteAllText(NOME_ARQUIVO, registrosJson);
          }

          public ConfiguracaoPreco ObterConfiguracaoDePreco()
          {
               return configuracaoPreco;
          }

          private void CarregarDoArquivoJson()
          {
               JsonSerializerOptions config = ObterConfiguracoesDeSerializacao();

               if (File.Exists(NOME_ARQUIVO))
               {
                    string registrosJson = File.ReadAllText(NOME_ARQUIVO);

                    if (registrosJson.Length > 0)
                    {
                         configuracaoPreco = JsonSerializer.Deserialize<ConfiguracaoPreco>(registrosJson, config)!;
                    }
               }
               else
               {
                    configuracaoPreco = new ConfiguracaoPreco();
               }
          }

          private static JsonSerializerOptions ObterConfiguracoesDeSerializacao()
          {
               JsonSerializerOptions opcoes = new JsonSerializerOptions();
               opcoes.IncludeFields = true;
               opcoes.WriteIndented = true;
               
               return opcoes;
          }
     }
}
