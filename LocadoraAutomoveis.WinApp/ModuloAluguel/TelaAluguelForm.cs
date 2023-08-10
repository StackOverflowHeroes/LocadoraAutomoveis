using iText.Kernel.XMP.Impl;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;
using System.Runtime.InteropServices;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private Aluguel aluguel;
        IRepositorioCupom cupom;
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;
        public event GravarRegistroDelegate<Aluguel> onCalcularAluguel;
        private List<Automovel> automoveis;
        private List<Condutor> condutores;
        private List<PlanoCobranca> planoCobranca;
        private List<TaxaServico> taxas;
        private List<Cupom> cupons;
        private decimal ValorTotal = 0;
        bool cupomAplicado = false;
        bool configurado = false;

        public TelaAluguelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            aluguel = new Aluguel();
            txtKmAutomovel.Controls[0].Visible = false;
        }
        public void PopularComboBox(List<Funcionario> funcionarios, List<Cliente> clientes,
            List<GrupoAutomovel> grupos, List<PlanoCobranca> planos, List<Condutor> condutores,
            List<Automovel> automoveis, List<TaxaServico> taxaServicos, List<Cupom> cupons)
        {
            funcionarios.ForEach(funcionario => cboxFuncionario.Items.Add(funcionario));
            cboxFuncionario.ValueMember = "Id";

            clientes.ForEach(cliente => cboxCliente.Items.Add(cliente));
            cboxCliente.ValueMember = "Id";

            grupos.ForEach(grupo => cboxGrupoAutomoveis.Items.Add(grupo));
            cboxGrupoAutomoveis.ValueMember = "Id";


            planos.ForEach(plano => cmbPlanoCobranca.Items.Add(plano));
            cmbPlanoCobranca.DisplayMember = "Plano";

            condutores.ForEach(condutor => cboxCondutor.Items.Add(condutor));


            taxaServicos.ForEach(taxa => listTaxas.Items.Add(taxa));
            listTaxas.ValueMember = "Nome";

            this.condutores = new List<Condutor>(condutores);
            this.automoveis = new List<Automovel>(automoveis);


            if (cboxGrupoAutomoveis.SelectedItem is GrupoAutomovel categoriaEscolhida)
                cboxAutomovel.DataSource = automoveis.FindAll(x => x.GrupoAutomovel.Id == categoriaEscolhida.Id);
            cboxAutomovel.DisplayMember = "Placa";
            cboxAutomovel.ValueMember = "Id";

            if (cboxCliente.SelectedItem is Cliente clienteEscolhido)
                cboxCondutor.DataSource = condutores.FindAll(x => x.Cliente.Id == clienteEscolhido.Id);
            cboxCondutor.DisplayMember = "Nome";
            cboxCondutor.ValueMember = "Id";

            if (cboxAutomovel.SelectedItem is Automovel automovelEscolhido)
                txtKmAutomovel.Value = automovelEscolhido.Quilometragem;
            this.cupons = cupons;

        }
        private Aluguel ObterAluguel()
        {
            aluguel.Funcionario = cboxFuncionario.SelectedItem as Funcionario;
            aluguel.Cliente = cboxCliente.SelectedItem as Cliente;
            aluguel.GrupoAutomovel = cboxGrupoAutomoveis.SelectedItem as GrupoAutomovel;
            aluguel.PlanoCobranca = cmbPlanoCobranca.SelectedItem as PlanoCobranca;
            aluguel.Condutor = cboxCondutor.SelectedItem as Condutor;
            aluguel.Automovel = cboxAutomovel.SelectedItem as Automovel;
            aluguel.DataLocacao = dateLocacao.Value;
            aluguel.DataDevolucao = dateDevolucao.Value;
            aluguel.Automovel.Quilometragem = Convert.ToInt32(Math.Round(txtKmAutomovel.Value, 0));
            aluguel.Cupom = txtCupom.Text == "" ? null : new Cupom() { Nome = txtCupom.Text };
            aluguel.ValorTotal = Convert.ToDecimal(lbValor.Text);
            aluguel.Concluido = false;

            return aluguel;

        }
        public void ConfigurarTelaAluguel(Aluguel aluguel)
        {
            this.aluguel = aluguel;
            cboxFuncionario.SelectedItem = aluguel.Funcionario;
            cboxCliente.SelectedItem = aluguel.Cliente;
            cboxGrupoAutomoveis.SelectedItem = aluguel.GrupoAutomovel;
            cmbPlanoCobranca.SelectedItem = aluguel.PlanoCobranca;
            cboxCondutor.SelectedItem = aluguel.Condutor;
            cboxAutomovel.SelectedItem = aluguel.Automovel;
            listTaxas.SelectedItem = aluguel.TaxaServicos;
            dateLocacao.Value = aluguel.DataLocacao;
            dateDevolucao.Value = (DateTime)aluguel.DataPrevisaoRetorno;
            txtCupom.Text = aluguel?.Cupom?.Nome;
        }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = ObterAluguel();

            Result resultado = onGravarRegistro(aluguel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }

        private void cboxAutomovel_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKmAutomovel.Value = 0;
            if (cboxAutomovel.SelectedItem is Automovel automovelEscolhido)
                txtKmAutomovel.Value = automovelEscolhido.Quilometragem;
        }

        private void cboxGrupoAutomoveis_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxAutomovel.SelectedIndex = -1;
            cboxAutomovel.Items.Clear();

            GrupoAutomovel grupoAutomovel = cboxGrupoAutomoveis.SelectedItem as GrupoAutomovel;
            grupoAutomovel.Automoveis.ForEach(x => cboxAutomovel.Items.Add(x));


        }

        private void cboxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxCondutor.SelectedIndex = -1;
            cboxCondutor.Items.Clear();
            Cliente cliente = cboxCliente.SelectedItem as Cliente;
            cliente.Condutores.ForEach(x => cboxCondutor.Items.Add(x));
        }

        private void TelaAluguelForm_Load(object sender, EventArgs e)
        {
            cboxAutomovel.SelectedIndexChanged += cboxAutomovel_SelectedIndexChanged;
            cboxCliente.SelectedIndexChanged += cboxCliente_SelectedIndexChanged;
            cboxGrupoAutomoveis.SelectedIndexChanged += cboxGrupoAutomoveis_SelectedIndexChanged;
        }

        private void btnCupom_Click(object sender, EventArgs e)
        {
            if (!cupomAplicado)
            {
                Cupom cupom = cupons.FirstOrDefault(x => x.Nome == txtCupom.Text);

                if (cupom != null)
                {
                    ValorTotal -= cupom.Valor;
                    cupomAplicado = true;
                    txtCupom.ReadOnly = true;
                    lbValor.Text = ValorTotal.ToString();
                }

            }

        }
        private void CalcularValorTotalPrevisto()
        {

        }

        private void cmbPlanoCobranca_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularValorTotalPrevisto();
        }

        private void dateDevolucao_ValueChanged(object sender, EventArgs e)
        {
            CalcularValorTotalPrevisto();
        }

        private void listTaxas_MouseUp(object sender, MouseEventArgs e)
        {
            TaxaServico sa = null;

            if (listTaxas.CheckedItems.Contains(listTaxas.SelectedItem))
            {
                sa = listTaxas.SelectedItem as TaxaServico;
                ValorTotal += sa.Preco;
            }
            else if (listTaxas.CheckedItems.Contains(listTaxas.SelectedItem) == false)
            {
                sa = listTaxas.SelectedItem as TaxaServico;
                ValorTotal -= sa.Preco;
            }

            if (sa != null)
                lbValor.Text = ValorTotal.ToString();
        }
    }
}
