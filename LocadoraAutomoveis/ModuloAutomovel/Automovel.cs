
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public class Automovel : EntidadeBase<Automovel>
    {
        public byte[] ImagemAutomovel { get; set; }
        public GrupoAutomovel GrupoAutomovel { get; set; } 
        public string Modelo { get; set; }  
        public string Marca { get; set; }   
        public int Ano { get; set; }
        public int Quilometragem { get; set; }
        public string Cor { get; set; }
        public string Placa { get; set; }
        public TipoCombustivelEnum Combustivel { get; set; }    
        public int CapacidadeLitros { get; set; }

        public Automovel()
        {
        }

        public Automovel(string modelo) : this()
        {
            Modelo = modelo;
        }

        public Automovel(Guid id, string modelo) : this(modelo)
        {
            Id = id;
        }

        public Automovel(Guid id, GrupoAutomovel grupoAutomovel, string modelo, string marca, string cor, TipoCombustivelEnum combustivel, int capacidadeLitros) : this(id, modelo)
        {
            GrupoAutomovel = grupoAutomovel;
            Modelo = modelo;
            Marca = marca;
            Cor = cor;
            Combustivel = combustivel;
            CapacidadeLitros = capacidadeLitros;
        }

        public override void Atualizar(Automovel registro)
        {
            GrupoAutomovel = registro.GrupoAutomovel;
            Modelo = registro.Modelo;
            Marca = registro.Marca;
            Cor = registro.Cor;
            Combustivel= registro.Combustivel;
            CapacidadeLitros = registro.CapacidadeLitros;
        }


        public override string? ToString()
        {
            return Modelo;
        }

        public override bool Equals(object? obj)
        {
            return obj is Automovel automovel &&
                   Id.Equals(automovel.Id) &&
                   EqualityComparer<GrupoAutomovel>.Default.Equals(GrupoAutomovel, automovel.GrupoAutomovel) &&
                   Modelo == automovel.Modelo &&
                   Marca == automovel.Marca &&
                   Cor == automovel.Cor &&
                   Combustivel == automovel.Combustivel &&
                   CapacidadeLitros == automovel.CapacidadeLitros;
        }
    }
}
