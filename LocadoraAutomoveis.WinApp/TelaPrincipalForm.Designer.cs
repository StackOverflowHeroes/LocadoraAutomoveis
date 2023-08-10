namespace LocadoraAutomoveis.WinApp
{
    partial class TelaPrincipalForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            temporizador = new System.Windows.Forms.Timer(components);
            sRodape = new StatusStrip();
            textoRodape = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            btnInserir = new ToolStripButton();
            btnEditar = new ToolStripButton();
            btnExcluir = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BtnFiltrar = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            btnDevolucao = new ToolStripButton();
            btnGerarPDF = new ToolStripButton();
            btnConfigurarPreco = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            textoTipoCadastro = new ToolStripLabel();
            menuStrip1 = new MenuStrip();
            cadastrosMenuItem = new ToolStripMenuItem();
            parceirosMenuItem = new ToolStripMenuItem();
            cuponsMenuItem = new ToolStripMenuItem();
            gruposMenuItem = new ToolStripMenuItem();
            taxaServicoMenuItem = new ToolStripMenuItem();
            planosMenuItem = new ToolStripMenuItem();
            funcionariosMenuItem = new ToolStripMenuItem();
            clientesMenuItem = new ToolStripMenuItem();
            alugueisMenuItem = new ToolStripMenuItem();
            automoveisMenuItem = new ToolStripMenuItem();
            condutoresMenuItem = new ToolStripMenuItem();
            painelRegistros = new Panel();
            sRodape.SuspendLayout();
            toolStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // sRodape
            // 
            sRodape.ImageScalingSize = new Size(20, 20);
            sRodape.Items.AddRange(new ToolStripItem[] { textoRodape });
            sRodape.Location = new Point(0, 389);
            sRodape.Name = "sRodape";
            sRodape.Size = new Size(834, 22);
            sRodape.TabIndex = 0;
            sRodape.Text = "statusStrip1";
            // 
            // textoRodape
            // 
            textoRodape.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textoRodape.Name = "textoRodape";
            textoRodape.Size = new Size(42, 17);
            textoRodape.Text = "Status";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator1, BtnFiltrar, toolStripSeparator3, btnDevolucao, btnGerarPDF, btnConfigurarPreco, toolStripSeparator2, textoTipoCadastro });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(834, 41);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnInserir
            // 
            btnInserir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInserir.Enabled = false;
            btnInserir.Image = Properties.Resources.add;
            btnInserir.ImageScaling = ToolStripItemImageScaling.None;
            btnInserir.ImageTransparentColor = Color.Magenta;
            btnInserir.Name = "btnInserir";
            btnInserir.Padding = new Padding(5);
            btnInserir.Size = new Size(38, 38);
            btnInserir.Text = "toolStripButton1";
            btnInserir.ToolTipText = "Inserir";
            btnInserir.Click += btnInserir_Click;
            // 
            // btnEditar
            // 
            btnEditar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnEditar.Enabled = false;
            btnEditar.Image = Properties.Resources.edit;
            btnEditar.ImageScaling = ToolStripItemImageScaling.None;
            btnEditar.ImageTransparentColor = Color.Magenta;
            btnEditar.Name = "btnEditar";
            btnEditar.Padding = new Padding(5);
            btnEditar.Size = new Size(38, 38);
            btnEditar.Text = "toolStripButton2";
            btnEditar.ToolTipText = "Editar";
            btnEditar.Click += btnEditar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnExcluir.Enabled = false;
            btnExcluir.Image = Properties.Resources.delete;
            btnExcluir.ImageScaling = ToolStripItemImageScaling.None;
            btnExcluir.ImageTransparentColor = Color.Magenta;
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Padding = new Padding(5);
            btnExcluir.Size = new Size(38, 38);
            btnExcluir.Text = "toolStripButton3";
            btnExcluir.ToolTipText = "Excluir";
            btnExcluir.Click += btnExcluir_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // BtnFiltrar
            // 
            BtnFiltrar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BtnFiltrar.Enabled = false;
            BtnFiltrar.Image = Properties.Resources.filter;
            BtnFiltrar.ImageTransparentColor = Color.Magenta;
            BtnFiltrar.Name = "BtnFiltrar";
            BtnFiltrar.Size = new Size(24, 38);
            BtnFiltrar.Text = "Filtrar";
            BtnFiltrar.Click += BtnFiltrar_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 41);
            // 
            // btnDevolucao
            // 
            btnDevolucao.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnDevolucao.Enabled = false;
            btnDevolucao.Image = Properties.Resources.devolution;
            btnDevolucao.ImageScaling = ToolStripItemImageScaling.None;
            btnDevolucao.ImageTransparentColor = Color.Magenta;
            btnDevolucao.Name = "btnDevolucao";
            btnDevolucao.Padding = new Padding(5);
            btnDevolucao.Size = new Size(38, 38);
            btnDevolucao.Text = "Devolução de Aluguel";
            btnDevolucao.ToolTipText = "Devolução de Aluguel";
            btnDevolucao.Click += btnDevolucao_Click;
            // 
            // btnGerarPDF
            // 
            btnGerarPDF.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnGerarPDF.Enabled = false;
            btnGerarPDF.Image = Properties.Resources.pdf;
            btnGerarPDF.ImageScaling = ToolStripItemImageScaling.None;
            btnGerarPDF.ImageTransparentColor = Color.Magenta;
            btnGerarPDF.Name = "btnGerarPDF";
            btnGerarPDF.Padding = new Padding(5);
            btnGerarPDF.Size = new Size(38, 38);
            btnGerarPDF.Text = "Gerar PDF";
            btnGerarPDF.ToolTipText = "Gerar PDF";
            btnGerarPDF.Click += btnGerarPDF_Click;
            // 
            // btnConfigurarPreco
            // 
            btnConfigurarPreco.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnConfigurarPreco.Enabled = false;
            btnConfigurarPreco.Image = Properties.Resources.priceconfig;
            btnConfigurarPreco.ImageScaling = ToolStripItemImageScaling.None;
            btnConfigurarPreco.ImageTransparentColor = Color.Magenta;
            btnConfigurarPreco.Name = "btnConfigurarPreco";
            btnConfigurarPreco.Padding = new Padding(5);
            btnConfigurarPreco.Size = new Size(38, 38);
            btnConfigurarPreco.Text = "Configurar Preço";
            btnConfigurarPreco.ToolTipText = "Excluir";
            btnConfigurarPreco.Click += btnConfigurarPreco_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 41);
            // 
            // textoTipoCadastro
            // 
            textoTipoCadastro.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textoTipoCadastro.Name = "textoTipoCadastro";
            textoTipoCadastro.Size = new Size(87, 38);
            textoTipoCadastro.Text = "Tipo Cadastro";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(834, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosMenuItem
            // 
            cadastrosMenuItem.DropDownItems.AddRange(new ToolStripItem[] { parceirosMenuItem, gruposMenuItem, taxaServicoMenuItem, planosMenuItem, funcionariosMenuItem, clientesMenuItem, alugueisMenuItem, automoveisMenuItem, condutoresMenuItem });
            cadastrosMenuItem.Name = "cadastrosMenuItem";
            cadastrosMenuItem.Size = new Size(71, 20);
            cadastrosMenuItem.Text = "Cadastros";
            // 
            // parceirosMenuItem
            // 
            parceirosMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cuponsMenuItem });
            parceirosMenuItem.Name = "parceirosMenuItem";
            parceirosMenuItem.Size = new Size(193, 22);
            parceirosMenuItem.Text = "Parceiros";
            parceirosMenuItem.Click += parceirosMenuItem_Click;
            // 
            // cuponsMenuItem
            // 
            cuponsMenuItem.Name = "cuponsMenuItem";
            cuponsMenuItem.Size = new Size(115, 22);
            cuponsMenuItem.Text = "Cupons";
            cuponsMenuItem.Click += cuponsMenuItem_Click;
            // 
            // gruposMenuItem
            // 
            gruposMenuItem.Name = "gruposMenuItem";
            gruposMenuItem.Size = new Size(193, 22);
            gruposMenuItem.Text = "Grupos de automóveis";
            gruposMenuItem.Click += gruposMenuItem_Click;
            // 
            // taxaServicoMenuItem
            // 
            taxaServicoMenuItem.Name = "taxaServicoMenuItem";
            taxaServicoMenuItem.Size = new Size(193, 22);
            taxaServicoMenuItem.Text = "Taxas ou serviços";
            taxaServicoMenuItem.Click += taxaServicoMenuItem_Click;
            // 
            // planosMenuItem
            // 
            planosMenuItem.Name = "planosMenuItem";
            planosMenuItem.Size = new Size(193, 22);
            planosMenuItem.Text = "Planos de cobrança";
            planosMenuItem.Click += planosMenuItem_Click;
            // 
            // funcionariosMenuItem
            // 
            funcionariosMenuItem.Name = "funcionariosMenuItem";
            funcionariosMenuItem.Size = new Size(193, 22);
            funcionariosMenuItem.Text = "Funcionários";
            funcionariosMenuItem.Click += funcionariosMenuItem_Click;
            // 
            // clientesMenuItem
            // 
            clientesMenuItem.Name = "clientesMenuItem";
            clientesMenuItem.Size = new Size(193, 22);
            clientesMenuItem.Text = "Clientes";
            clientesMenuItem.Click += clientesMenuItem_Click;
            // 
            // alugueisMenuItem
            // 
            alugueisMenuItem.Name = "alugueisMenuItem";
            alugueisMenuItem.Size = new Size(193, 22);
            alugueisMenuItem.Text = "Aluguéis";
            alugueisMenuItem.Click += alugueisMenuItem_Click;
            // 
            // automoveisMenuItem
            // 
            automoveisMenuItem.Name = "automoveisMenuItem";
            automoveisMenuItem.Size = new Size(193, 22);
            automoveisMenuItem.Text = "Automóveis";
            automoveisMenuItem.Click += automoveisMenuItem_Click;
            // 
            // condutoresMenuItem
            // 
            condutoresMenuItem.Name = "condutoresMenuItem";
            condutoresMenuItem.Size = new Size(193, 22);
            condutoresMenuItem.Text = "Condutores";
            condutoresMenuItem.Click += condutoresMenuItem_Click;
            // 
            // painelRegistros
            // 
            painelRegistros.Dock = DockStyle.Fill;
            painelRegistros.Location = new Point(0, 65);
            painelRegistros.Name = "painelRegistros";
            painelRegistros.Size = new Size(834, 324);
            painelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 411);
            Controls.Add(painelRegistros);
            Controls.Add(toolStrip1);
            Controls.Add(sRodape);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "TelaPrincipalForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Locadora Automóveis";
            sRodape.ResumeLayout(false);
            sRodape.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer temporizador;
        private StatusStrip sRodape;
        private ToolStrip toolStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastrosMenuItem;
        private Panel painelRegistros;
        private ToolStripStatusLabel textoRodape;
        private ToolStripLabel textoTipoCadastro;
        private ToolStripButton btnInserir;
        private ToolStripButton btnEditar;
        private ToolStripButton btnExcluir;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem parceirosMenuItem;
        private ToolStripMenuItem gruposMenuItem;
        private ToolStripMenuItem taxaServicoMenuItem;
        private ToolStripMenuItem planosMenuItem;
        private ToolStripMenuItem funcionariosMenuItem;
        private ToolStripMenuItem clientesMenuItem;
        private ToolStripMenuItem cuponsMenuItem;
        private ToolStripMenuItem alugueisMenuItem;
        private ToolStripMenuItem automoveisMenuItem;
        private ToolStripMenuItem condutoresMenuItem;
        private ToolStripButton btnConfigurarPreco;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton btnDevolucao;
        private ToolStripButton btnGerarPDF;
        private ToolStripButton BtnFiltrar;
        private ToolStripSeparator toolStripSeparator3;
    }
}