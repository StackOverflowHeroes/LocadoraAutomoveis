namespace LocadoraAutomoveis.Infra.Arquivos
{
    [Serializable]
    public class GeradorTesteJsonContext : IContextoPersistencia
    {
        private readonly ISerializador serializador;

        public GeradorTesteJsonContext()
        {
            //Parceiros = new List<Parceiro>();

            //Materias = new List<Materia>();

            //Testes = new List<Teste>();

            //Questoes = new List<Questao>();
        }


        public GeradorTesteJsonContext(ISerializador serializador) : this()
        {
            this.serializador = serializador;

            CarregarDados();
        }

        //public List<Materia> Materias { get; set; }

        //public List<Parceiro> Parceiros { get; set; }

        //public List<Teste> Testes { get; set; }

        //public List<Questao> Questoes { get; set; }

        public void DesfazerAlteracoes()
        {
            CarregarDados();
        }

        public void GravarDados()
        {
            serializador.GravarDadosEmArquivo(this);
        }

        private void CarregarDados()
        {
            var ctx = serializador.CarregarDadosDoArquivo();

            //if (ctx.Parceiros.Any())
            //    this.Parceiros.AddRange(ctx.Parceiros);

            //if (ctx.Materias.Any())
            //    this.Materias.AddRange(ctx.Materias);

            //if (ctx.Questoes.Any())
            //    this.Questoes.AddRange(ctx.Questoes);

            //if (ctx.Testes.Any())
            //    this.Testes.AddRange(ctx.Testes);
        }
    }
}
