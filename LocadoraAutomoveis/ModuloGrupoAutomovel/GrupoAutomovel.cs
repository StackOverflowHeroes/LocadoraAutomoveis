
namespace LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel
{
    public class GrupoAutomovel : EntidadeBase<GrupoAutomovel>
    {
        public string Nome { get; set; }

        public GrupoAutomovel()
        {

        }

        public GrupoAutomovel(string nome) : this()
        {
            Nome = nome;
        }
        public GrupoAutomovel(Guid id, string nome) : this(nome)
        {
            Id = id;
        }


        public override void Atualizar(GrupoAutomovel registro)
        {
            Nome = registro.Nome;
        }
        

        public override string? ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is GrupoAutomovel automovel &&
                   Id.Equals(automovel.Id) &&
                   Nome == automovel.Nome;
        }
    }
}
