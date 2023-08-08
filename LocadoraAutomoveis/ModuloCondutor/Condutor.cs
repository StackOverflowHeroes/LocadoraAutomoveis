using LocadoraAutomoveis.Dominio.ModuloCliente;

namespace LocadoraAutomoveis.Dominio.ModuloCondutor
{
     public class Condutor : EntidadeBase<Condutor>
     {
          public Condutor(string nome, string email, string telefone, string cPF, string cnh, DateTime dataValidade, Cliente cliente)
          {
               Nome = nome;
               Email = email;
               Telefone = telefone;
               CPF = cPF;
               CNH = cnh;
               DataValidade = dataValidade;
               Cliente = cliente;
          }

          public Condutor()
          {
               DataValidade = DateTime.Now;
          }


          public Condutor(string nome)
          {
               Nome = nome;
          }

          public Condutor(Guid id, string nome) : this(nome)
          {
               Id = id;
          }

          public Condutor(Guid id, string nome, string email, string telefone, string cpf, string cnh, DateTime dataValidade, Cliente cliente) : this(id, nome)
          {
               Email = email;
               Telefone = telefone;
               CPF = cpf;
               CNH = cnh;
               DataValidade = dataValidade;
               Cliente = cliente;
          }

          public string Nome { get; set; }
          public string Email { get; set; }
          public string Telefone { get; set; }
          public string CPF { get; set; }
          public string CNH { get; set; }
          public DateTime DataValidade { get; set; }
          public Cliente Cliente { get; set; }

          public override string ToString()
          {
               return Nome;
          }

          public override void Atualizar(Condutor condutor)
          {
               Nome = condutor.Nome;
               Email = condutor.Email;
               Telefone = condutor.Telefone;
               CPF = condutor.CPF;
               CNH = condutor.CNH;
               DataValidade = condutor.DataValidade;
               Cliente = condutor.Cliente;
          }

          public override int GetHashCode()
          {
               return HashCode.Combine(Id, Nome, Email, Telefone, CPF, CNH, DataValidade, Cliente);
          }
          public override bool Equals(object? obj)
          {
               return obj is Condutor condutor &&
                      Id.Equals(condutor.Id) &&
                      Nome == condutor.Nome &&
                      Email == condutor.Email &&
                      Telefone == condutor.Telefone &&
                      CPF == condutor.CPF &&
                      CNH == condutor.CNH &&
                      DataValidade == condutor.DataValidade &&
                      EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente);
          }
     }
}
