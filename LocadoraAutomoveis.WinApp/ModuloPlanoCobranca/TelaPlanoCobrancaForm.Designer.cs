namespace LocadoraAutomoveis.WinApp.ModuloPlanoCobranca
{
    partial class TelaPlanoCobrancaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            groupBox1 = new GroupBox();
            label5 = new Label();
            NumericInputKmDisponiveis = new NumericUpDown();
            label4 = new Label();
            NumericInputPrecoKM = new NumericUpDown();
            label3 = new Label();
            NumericInputPrecoDiaria = new NumericUpDown();
            label2 = new Label();
            ComboBoxTipoPlano = new ComboBox();
            ComboBoxGrupoAutomoveis = new ComboBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumericInputKmDisponiveis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoKM).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoDiaria).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 56);
            label1.Name = "label1";
            label1.Size = new Size(152, 20);
            label1.TabIndex = 0;
            label1.Text = "Grupo de automóveis";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(NumericInputKmDisponiveis);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(NumericInputPrecoKM);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(NumericInputPrecoDiaria);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ComboBoxTipoPlano);
            groupBox1.Location = new Point(42, 123);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(412, 306);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Configuração de planos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(50, 226);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 10;
            label5.Text = "KM disponíveis";
            // 
            // NumericInputKmDisponiveis
            // 
            NumericInputKmDisponiveis.Enabled = false;
            NumericInputKmDisponiveis.Location = new Point(50, 249);
            NumericInputKmDisponiveis.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericInputKmDisponiveis.Name = "NumericInputKmDisponiveis";
            NumericInputKmDisponiveis.Size = new Size(312, 27);
            NumericInputKmDisponiveis.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(50, 161);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 8;
            label4.Text = "Preço por KM";
            // 
            // NumericInputPrecoKM
            // 
            NumericInputPrecoKM.DecimalPlaces = 2;
            NumericInputPrecoKM.Enabled = false;
            NumericInputPrecoKM.Location = new Point(50, 184);
            NumericInputPrecoKM.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericInputPrecoKM.Name = "NumericInputPrecoKM";
            NumericInputPrecoKM.Size = new Size(312, 27);
            NumericInputPrecoKM.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 97);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 6;
            label3.Text = "Preço diária";
            // 
            // NumericInputPrecoDiaria
            // 
            NumericInputPrecoDiaria.DecimalPlaces = 2;
            NumericInputPrecoDiaria.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            NumericInputPrecoDiaria.Location = new Point(50, 120);
            NumericInputPrecoDiaria.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            NumericInputPrecoDiaria.Name = "NumericInputPrecoDiaria";
            NumericInputPrecoDiaria.Size = new Size(312, 27);
            NumericInputPrecoDiaria.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 35);
            label2.Name = "label2";
            label2.Size = new Size(102, 20);
            label2.TabIndex = 4;
            label2.Text = "Tipo de plano";
            // 
            // ComboBoxTipoPlano
            // 
            ComboBoxTipoPlano.DisplayMember = "Nome";
            ComboBoxTipoPlano.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxTipoPlano.FormattingEnabled = true;
            ComboBoxTipoPlano.Location = new Point(50, 58);
            ComboBoxTipoPlano.Name = "ComboBoxTipoPlano";
            ComboBoxTipoPlano.Size = new Size(312, 28);
            ComboBoxTipoPlano.TabIndex = 3;
            ComboBoxTipoPlano.SelectedIndexChanged += ComboBoxTipoPlano_SelectedIndexChanged;
            // 
            // ComboBoxGrupoAutomoveis
            // 
            ComboBoxGrupoAutomoveis.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxGrupoAutomoveis.FormattingEnabled = true;
            ComboBoxGrupoAutomoveis.Location = new Point(42, 79);
            ComboBoxGrupoAutomoveis.Name = "ComboBoxGrupoAutomoveis";
            ComboBoxGrupoAutomoveis.Size = new Size(412, 28);
            ComboBoxGrupoAutomoveis.TabIndex = 2;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(366, 456);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 60);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Location = new Point(273, 456);
            btnGravar.Margin = new Padding(3, 4, 3, 4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(86, 60);
            btnGravar.TabIndex = 11;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaPlanoCobrancaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(502, 529);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(ComboBoxGrupoAutomoveis);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Name = "TelaPlanoCobrancaForm";
            Text = "TelaPlanoCobrancaForm";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumericInputKmDisponiveis).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoKM).EndInit();
            ((System.ComponentModel.ISupportInitialize)NumericInputPrecoDiaria).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private ComboBox ComboBoxGrupoAutomoveis;
        private Button btnCancelar;
        private Button btnGravar;
        private Label label2;
        private ComboBox ComboBoxTipoPlano;
        private Label label3;
        private NumericUpDown NumericInputPrecoDiaria;
        private Label label5;
        private NumericUpDown NumericInputKmDisponiveis;
        private Label label4;
        private NumericUpDown NumericInputPrecoKM;
    }
}