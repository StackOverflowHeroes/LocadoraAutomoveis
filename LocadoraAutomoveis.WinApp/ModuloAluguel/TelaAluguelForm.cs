﻿using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutor;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;
using LocadoraAutomoveis.Dominio.ModuloPlanoCobranca;
using LocadoraAutomoveis.Dominio.ModuloTaxaServico;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public partial class TelaAluguelForm : Form
    {
        private Aluguel aluguel;
        public event GravarRegistroDelegate<Aluguel> onGravarRegistro;
        private List<Automovel> automoveis;
        private List<Condutor> condutores;
        public TelaAluguelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
            aluguel = new Aluguel();
            txtKmAutomovel.Controls[0].Visible = false;
        }
        public void PopularComboBox(List<Funcionario> funcionarios, List<Cliente> clientes,
            List<GrupoAutomovel> grupos, List<PlanoCobranca> planos, List<Condutor> condutores,
            List<Automovel> automoveis, List<TaxaServico> taxaServicos)
        {
            cboxFuncionario.DataSource = funcionarios;
            cboxFuncionario.DisplayMember = "Nome";
            cboxFuncionario.ValueMember = "Id";
            cboxCliente.DataSource = clientes;
            cboxCliente.DisplayMember = "Name";
            cboxCliente.ValueMember = "Id";
            cboxGrupoAutomoveis.DataSource = grupos;
            cboxGrupoAutomoveis.DisplayMember = "Nome";
            cboxGrupoAutomoveis.ValueMember = "Id";
            cmbPlanoCobranca.DataSource = planos;
            cmbPlanoCobranca.DisplayMember = "Nome";
            cmbPlanoCobranca.ValueMember = "Id";
            cboxCondutor.DataSource = condutores;
            cboxAutomovel.DataSource = automoveis;
            listTaxas.DataSource = taxaServicos;
            listTaxas.DisplayMember = "Nome";
            listTaxas.ValueMember = "Id";

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
            aluguel.ValorTotal = Convert.ToDecimal(lbValorTotal.Text);
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
            cboxGrupoAutomoveis.SelectedIndex = -1;
            if (cboxGrupoAutomoveis.SelectedItem is GrupoAutomovel grupoEscolhido)
                cboxAutomovel.DataSource = automoveis.FindAll(x => x.GrupoAutomovel.Id == grupoEscolhido.Id);
            cboxAutomovel.DisplayMember = "Placa";
            cboxAutomovel.ValueMember = "Id";
        }

        private void cboxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboxCondutor.SelectedIndex = -1;

            if (cboxCliente.SelectedItem is Cliente clienteEscolhido)
                cboxCondutor.DataSource = condutores.FindAll(x => x.Cliente.Id == clienteEscolhido.Id);
            cboxCondutor.DisplayMember = "Nome";
            cboxCondutor.ValueMember = "ID";
        }

        private void TelaAluguelForm_Load(object sender, EventArgs e)
        {
            cboxAutomovel.SelectedIndexChanged += cboxAutomovel_SelectedIndexChanged;
            cboxCliente.SelectedIndexChanged += cboxCliente_SelectedIndexChanged;
            cboxGrupoAutomoveis.SelectedIndexChanged += cboxGrupoAutomoveis_SelectedIndexChanged;
        }
    }
}
