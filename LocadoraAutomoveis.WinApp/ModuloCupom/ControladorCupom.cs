
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.WinApp.ModuloCupom
{
    public class ControladorCupom : ControladorBase
    {

        public TabelaCupomControl tabelaCupom;
        public IRepositorioCupom repositorioCupom;
        public IRepositorioParceiro repositorioParceiro;
        public ServicoCupom servicoCupom;

        public ControladorCupom(IRepositorioCupom repositorioCupom, IRepositorioParceiro repositorioParceiro, ServicoCupom servicoCupom)
        {
            this.repositorioCupom = repositorioCupom;
            this.repositorioParceiro = repositorioParceiro;
            this.servicoCupom = servicoCupom;
        }

        public override void Inserir()
        {
            TelaCupomForm telaCupom = new TelaCupomForm();
            telaCupom.PopularComboBox(repositorioParceiro.SelecionarTodos());
            telaCupom.ConfigurarTelaCupom(new Cupom());

            telaCupom.Text = "Cadastro de cupom";
            telaCupom.onGravarRegistro += servicoCupom.Inserir;
            DialogResult resultado = telaCupom.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }

        public override void Editar()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();
            Cupom cupomSelecionado = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionado == null)
            {
                MessageBox.Show("Selecione um cupom primeiro.",
                "Edição de cupom", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCupomForm telaCupom = new TelaCupomForm();

            telaCupom.PopularComboBox(repositorioParceiro.SelecionarTodos());

            telaCupom.Text = "Editar um cupom";
            telaCupom.onGravarRegistro += servicoCupom.Editar;

            telaCupom.ConfigurarTelaCupom(cupomSelecionado);

            DialogResult resultado = telaCupom.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }

        public override void Excluir()
        {
            Guid id = tabelaCupom.ObtemIdSelecionado();

            Cupom cupomSelecionado = repositorioCupom.SelecionarPorId(id);

            if (cupomSelecionado == null)
            {
                MessageBox.Show("Selecione um cupom primeiro primeiro.",
                "Exclusão de cupom", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult opcaoEscolhida = MessageBox.Show("Deseja realmente excluir o cupom?",
               "Exclusão de cupom", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (opcaoEscolhida == DialogResult.OK)
            {
                Result resultado = servicoCupom.Excluir(cupomSelecionado);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors[0].Message, "Exclusão de cupom",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                CarregarRegistros();
            }
        }


        public override void CarregarRegistros()
        {
            List<Cupom> cupons = repositorioCupom.SelecionarTodos();

            tabelaCupom.AtualizarRegistros(cupons);

            mensagemRodape = string.Format("Visualizando {0} {1}", cupons.Count, cupons.Count > 1 ? "cupons" : "cupom");

            TelaPrincipalForm.Instancia.AtualizarRodape(mensagemRodape, TipoStatusEnum.Visualizando);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxCupom();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaCupom == null)
                tabelaCupom = new TabelaCupomControl();

            CarregarRegistros();

            return tabelaCupom;
        }
    }
}
