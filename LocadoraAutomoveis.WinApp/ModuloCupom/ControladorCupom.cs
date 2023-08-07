
using LocadoraAutomoveis.Aplicacao.ModuloCupom;
using LocadoraAutomoveis.Aplicacao.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.WinApp.ModuloPlanoCobranca;

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

            telaCupom.onGravarRegistro += servicoCupom.Inserir;
            DialogResult resultado = telaCupom.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarRegistros();
            }
        }

        public override void Excluir()
        {
        }

        public override void Editar()
        {
        }

        public override void CarregarRegistros()
        {
            List<Cupom> cupons = repositorioCupom.SelecionarTodos();

            tabelaCupom.AtualizarRegistros(cupons);

            mensagemRodape = string.Format("Visualizando {0} cupons", cupons.Count);

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
