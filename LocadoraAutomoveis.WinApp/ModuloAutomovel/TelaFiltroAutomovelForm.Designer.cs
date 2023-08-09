namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    partial class TelaFiltroAutomovelForm
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
            groupBox1 = new GroupBox();
            btnCancelar = new Button();
            btnGravar = new Button();
            ComboBoxGrupoAutomovel = new ComboBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(ComboBoxGrupoAutomovel);
            groupBox1.Location = new Point(56, 26);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(433, 117);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Grupo de automóveis";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Location = new Point(403, 172);
            btnCancelar.Margin = new Padding(3, 4, 3, 4);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(86, 60);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Location = new Point(310, 172);
            btnGravar.Margin = new Padding(3, 4, 3, 4);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(86, 60);
            btnGravar.TabIndex = 16;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // ComboBoxGrupoAutomovel
            // 
            ComboBoxGrupoAutomovel.DisplayMember = "Nome";
            ComboBoxGrupoAutomovel.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxGrupoAutomovel.FormattingEnabled = true;
            ComboBoxGrupoAutomovel.Location = new Point(20, 56);
            ComboBoxGrupoAutomovel.Name = "ComboBoxGrupoAutomovel";
            ComboBoxGrupoAutomovel.Size = new Size(394, 28);
            ComboBoxGrupoAutomovel.TabIndex = 0;
            // 
            // TelaFiltroAutomovelForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 265);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(groupBox1);
            Name = "TelaFiltroAutomovelForm";
            Text = "Filtrar automóveis";
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnCancelar;
        private Button btnGravar;
        private ComboBox ComboBoxGrupoAutomovel;
    }
}