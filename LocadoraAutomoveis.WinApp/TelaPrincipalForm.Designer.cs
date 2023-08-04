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
            textoTipoCadastro = new ToolStripLabel();
            menuStrip1 = new MenuStrip();
            cadastrosMenuItem = new ToolStripMenuItem();
            parceirosMenuItem = new ToolStripMenuItem();
            grupoToolStripMenuItem = new ToolStripMenuItem();
            taxasServicosMenuItem = new ToolStripMenuItem();
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
            sRodape.Location = new Point(0, 522);
            sRodape.Name = "sRodape";
            sRodape.Padding = new Padding(1, 0, 16, 0);
            sRodape.Size = new Size(953, 26);
            sRodape.TabIndex = 0;
            sRodape.Text = "statusStrip1";
            // 
            // textoRodape
            // 
            textoRodape.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textoRodape.Name = "textoRodape";
            textoRodape.Size = new Size(53, 20);
            textoRodape.Text = "Status";
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnInserir, btnEditar, btnExcluir, toolStripSeparator1, textoTipoCadastro });
            toolStrip1.Location = new Point(0, 30);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(953, 41);
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
            // textoTipoCadastro
            // 
            textoTipoCadastro.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            textoTipoCadastro.Name = "textoTipoCadastro";
            textoTipoCadastro.Size = new Size(110, 38);
            textoTipoCadastro.Text = "Tipo Cadastro";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(953, 30);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosMenuItem
            // 
            cadastrosMenuItem.DropDownItems.AddRange(new ToolStripItem[] { parceirosMenuItem, grupoToolStripMenuItem });
            cadastrosMenuItem.Name = "cadastrosMenuItem";
            cadastrosMenuItem.Size = new Size(88, 24);
            cadastrosMenuItem.Text = "Cadastros";
            // 
            // parceirosMenuItem
            // 
            parceirosMenuItem.Name = "parceirosMenuItem";
            parceirosMenuItem.Size = new Size(229, 26);
            parceirosMenuItem.Text = "Parceiros";
            parceirosMenuItem.Click += parceirosMenuItem_Click;
            // 
            // grupoToolStripMenuItem
            // 
            grupoToolStripMenuItem.Name = "grupoToolStripMenuItem";
            grupoToolStripMenuItem.Size = new Size(229, 26);
            grupoToolStripMenuItem.Text = "Grupo de automóvel";
            grupoToolStripMenuItem.Click += grupoToolStripMenuItem_Click;
            // 
            // taxasServicosMenuItem
            // 
            taxasServicosMenuItem.Name = "taxasServicosMenuItem";
            taxasServicosMenuItem.Size = new Size(180, 22);
            taxasServicosMenuItem.Text = "Taxa e Serviços";
            taxasServicosMenuItem.Click += taxasServicosMenuItem_Click;
            // 
            // painelRegistros
            // 
            painelRegistros.Dock = DockStyle.Fill;
            painelRegistros.Location = new Point(0, 71);
            painelRegistros.Margin = new Padding(3, 4, 3, 4);
            painelRegistros.Name = "painelRegistros";
            painelRegistros.Size = new Size(953, 451);
            painelRegistros.TabIndex = 3;
            // 
            // TelaPrincipalForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 548);
            Controls.Add(painelRegistros);
            Controls.Add(toolStrip1);
            Controls.Add(sRodape);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
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
        private ToolStripMenuItem grupoToolStripMenuItem;
        private ToolStripMenuItem taxasServicosMenuItem;
     }
}