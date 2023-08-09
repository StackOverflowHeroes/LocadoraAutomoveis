
using System.Windows.Forms;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloGrupoAutomovel;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public partial class TelaAutomovelForm : Form
    {
        private Automovel Automovel { get; set; }

        public event GravarRegistroDelegate<Automovel> onGravarRegistro;
        public event ManipularImagemDelegate onTransformToByte;
        public TelaAutomovelForm()
        {
            InitializeComponent();
            this.ConfigurarDialog();
        }

        public void ConfigurarTelaAutomovel(Automovel automovel)
        {
            this.Automovel = automovel;

            ComboBoxGrupoAutomovel.SelectedItem = automovel.GrupoAutomovel;
            TextBoxModelo.Text = automovel.Modelo;
            TextBoxMarca.Text = automovel.Marca;
            NumericInputAno.Value = automovel.Ano;
            NumericInputQuilometragem.Value = automovel.Quilometragem;
            TextBoxCor.Text = automovel.Cor;
            TextBoxPlaca.Text = automovel.Placa;
            ComboBoxTipoCombustivel.SelectedItem = automovel.Combustivel;
            NumericInputCapacidadeLitros.Value = automovel.CapacidadeLitros;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Automovel automovel = ObterAutomovel();

            Result resultado = onGravarRegistro(automovel);

            if (resultado.IsFailed)
            {
                string erro = resultado.Errors[0].Message;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro, TipoStatusEnum.Erro);

                DialogResult = DialogResult.None;
            }
        }

        private Automovel ObterAutomovel()
        {
            Automovel.GrupoAutomovel = ComboBoxGrupoAutomovel.SelectedItem as GrupoAutomovel;
            Automovel.Modelo = TextBoxModelo.Text;
            Automovel.Marca = TextBoxMarca.Text;
            Automovel.Cor = TextBoxCor.Text;
            Automovel.Ano = Convert.ToInt32(Math.Round(NumericInputAno.Value, 0));
            Automovel.Quilometragem = Convert.ToInt32(Math.Round(NumericInputQuilometragem.Value, 0));
            Automovel.Placa = TextBoxPlaca.Text;
            Automovel.Combustivel = (TipoCombustivelEnum)ComboBoxTipoCombustivel.SelectedItem;
            Automovel.CapacidadeLitros = Convert.ToInt32(Math.Round(NumericInputCapacidadeLitros.Value, 0));

            return Automovel;
        }

        public void PopularComboBox(List<GrupoAutomovel> gruposAutomoveis)
        {
            gruposAutomoveis.ForEach(grupo => ComboBoxGrupoAutomovel.Items.Add(grupo));

            var tiposCombustiveis = Enum.GetValues(typeof(TipoCombustivelEnum));

            foreach (var tipo in tiposCombustiveis)
            {
                ComboBoxTipoCombustivel.Items.Add(tipo);
            }
        }

        public void PopularPictureBox()
        {
            using (MemoryStream memoryStream = new MemoryStream(Automovel.ImagemAutomovel))
            {
                Image selectedImage = Image.FromStream(memoryStream);
                PictureBoxCarro.Image = selectedImage;
            }
        }

        private void BotaoBuscarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                string imagePath = openFileDialog1.FileName;
                Image selectedImage = Image.FromFile(imagePath);
                PictureBoxCarro.Image = selectedImage;

                byte[] imageBytes;
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    selectedImage.Save(memoryStream, selectedImage.RawFormat);
                    imageBytes = memoryStream.ToArray();
                }

                Automovel.ImagemAutomovel = imageBytes;
            }
            else return;

        }
    }
}
