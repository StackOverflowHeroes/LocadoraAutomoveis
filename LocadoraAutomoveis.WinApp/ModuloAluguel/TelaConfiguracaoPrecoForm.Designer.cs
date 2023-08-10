namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaConfiguracaoPrecoForm
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
            label3 = new Label();
            valorGasolina = new NumericUpDown();
            valorGas = new NumericUpDown();
            valorDiesel = new NumericUpDown();
            valorAlcool = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            btnCancelar = new Button();
            btnGravar = new Button();
            ((System.ComponentModel.ISupportInitialize)valorGasolina).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valorGas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valorDiesel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valorAlcool).BeginInit();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(37, 41);
            label3.Name = "label3";
            label3.Size = new Size(53, 16);
            label3.TabIndex = 7;
            label3.Text = "Gasolina";
            // 
            // valorGasolina
            // 
            valorGasolina.DecimalPlaces = 2;
            valorGasolina.Location = new Point(37, 59);
            valorGasolina.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            valorGasolina.Name = "valorGasolina";
            valorGasolina.Size = new Size(323, 23);
            valorGasolina.TabIndex = 19;
            // 
            // valorGas
            // 
            valorGas.DecimalPlaces = 2;
            valorGas.Location = new Point(37, 123);
            valorGas.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            valorGas.Name = "valorGas";
            valorGas.Size = new Size(323, 23);
            valorGas.TabIndex = 20;
            // 
            // valorDiesel
            // 
            valorDiesel.DecimalPlaces = 2;
            valorDiesel.Location = new Point(37, 184);
            valorDiesel.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            valorDiesel.Name = "valorDiesel";
            valorDiesel.Size = new Size(323, 23);
            valorDiesel.TabIndex = 21;
            // 
            // valorAlcool
            // 
            valorAlcool.DecimalPlaces = 2;
            valorAlcool.Location = new Point(37, 249);
            valorAlcool.Maximum = new decimal(new int[] { -1, -1, -1, 0 });
            valorAlcool.Name = "valorAlcool";
            valorAlcool.Size = new Size(323, 23);
            valorAlcool.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(37, 105);
            label1.Name = "label1";
            label1.Size = new Size(28, 16);
            label1.TabIndex = 23;
            label1.Text = "Gás";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(37, 231);
            label2.Name = "label2";
            label2.Size = new Size(40, 16);
            label2.TabIndex = 24;
            label2.Text = "Álcool";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(37, 166);
            label4.Name = "label4";
            label4.Size = new Size(42, 16);
            label4.TabIndex = 25;
            label4.Text = "Diesel";
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnCancelar.Location = new Point(285, 314);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 45);
            btnCancelar.TabIndex = 27;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGravar
            // 
            btnGravar.DialogResult = DialogResult.OK;
            btnGravar.FlatStyle = FlatStyle.Popup;
            btnGravar.Font = new Font("Comic Sans MS", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnGravar.Location = new Point(204, 314);
            btnGravar.Name = "btnGravar";
            btnGravar.Size = new Size(75, 45);
            btnGravar.TabIndex = 26;
            btnGravar.Text = "Gravar";
            btnGravar.UseVisualStyleBackColor = true;
            btnGravar.Click += btnGravar_Click;
            // 
            // TelaConfiguracaoPrecoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 371);
            Controls.Add(btnCancelar);
            Controls.Add(btnGravar);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(valorAlcool);
            Controls.Add(valorDiesel);
            Controls.Add(valorGas);
            Controls.Add(valorGasolina);
            Controls.Add(label3);
            Name = "TelaConfiguracaoPrecoForm";
            Text = "Configurar Preços";
            ((System.ComponentModel.ISupportInitialize)valorGasolina).EndInit();
            ((System.ComponentModel.ISupportInitialize)valorGas).EndInit();
            ((System.ComponentModel.ISupportInitialize)valorDiesel).EndInit();
            ((System.ComponentModel.ISupportInitialize)valorAlcool).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private NumericUpDown valorGasolina;
        private NumericUpDown valorGas;
        private NumericUpDown valorDiesel;
        private NumericUpDown valorAlcool;
        private Label label1;
        private Label label2;
        private Label label4;
        private Button btnCancelar;
        private Button btnGravar;
    }
}