
using LocadoraAutomoveis.Aplicacao.ModuloAutomovel;
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloCupom;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase
    {
        public TabelaAutomovelControl tabelaAutomovel;
        public IRepositorioAutomovel repositorioAutomovel;
        public IRepositorioGrupoAutomovel repositorioGrupoAutomovel;
        public ServicoAutomovel servicoAutomovel;

        public ControladorAutomovel(IRepositorioAutomovel repositorioAutomovel, IRepositorioGrupoAutomovel repositorioGrupoAutomovel, ServicoAutomovel servicoAutomovel)
        {
            this.repositorioAutomovel = repositorioAutomovel;
            this.repositorioGrupoAutomovel = repositorioGrupoAutomovel;
            this.servicoAutomovel = servicoAutomovel;
        }

        public override void Inserir()
        {
            TelaAutomovelForm telaAutomovel = new TelaAutomovelForm();
            telaAutomovel.PopularComboBox(repositorioGrupoAutomovel.SelecionarTodos());
            telaAutomovel.ConfigurarTelaAutomovel(new Automovel());

            telaAutomovel.Text = "Cadastro de automóveis";
            telaAutomovel.onGravarRegistro += servicoAutomovel.Inserir;
            DialogResult resultado = telaAutomovel.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaAutomovel.ObtemIdSelecionado();
            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro.",
                "Edição de automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaAutomovelForm telaAutomovel = new TelaAutomovelForm();

            telaAutomovel.Text = "Editar um automóvel";
            telaAutomovel.onGravarRegistro += servicoAutomovel.Editar;

            telaAutomovel.PopularComboBox(repositorioGrupoAutomovel.SelecionarTodos());
            telaAutomovel.ConfigurarTelaAutomovel(automovelSelecionado);
            telaAutomovel.PopularPictureBox();


            DialogResult resultado = telaAutomovel.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaAutomovel.ObtemIdSelecionado();

            Automovel automovelSelecionado = repositorioAutomovel.SelecionarPorId(id);

            if (automovelSelecionado == null)
            {
                MessageBox.Show("Selecione um automóvel primeiro.",
                "Exclusão de automóveis", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o automóvel?",
               "Exclusão de automóveis", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoAutomovel.Excluir(automovelSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de automóveis",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }

        public override void CarregarRegistros()
        {
            List<Automovel> automoveis = repositorioAutomovel.SelecionarTodos(true);

            tabelaAutomovel.AtualizarRegistros(automoveis);

            mensagemRodape = string.Format("Visualizando {0} {1}", automoveis.Count, automoveis.Count > 1 ? "automóveis" : "automóvel");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }

        public override void Filtrar()
        {
            MessageBox.Show("Filtrado");
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxAutomovel();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaAutomovel == null)
                tabelaAutomovel = new TabelaAutomovelControl();

            CarregarRegistros();

            return tabelaAutomovel;
        }
    }
}
