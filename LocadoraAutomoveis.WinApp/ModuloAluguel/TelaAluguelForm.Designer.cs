namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    partial class TelaAluguelForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 21);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 0;
            label1.Text = "Funcionário";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(87, 70);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 1;
            label2.Text = "Cliente";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(87, 106);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 2;
            label3.Text = "Grupo de Automóveis";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(87, 147);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 3;
            label4.Text = "Plano de Cobrança";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(87, 179);
            label5.Name = "label5";
            label5.Size = new Size(78, 15);
            label5.TabIndex = 4;
            label5.Text = "Data Locação";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(87, 211);
            label6.Name = "label6";
            label6.Size = new Size(47, 15);
            label6.TabIndex = 5;
            label6.Text = "Cupom";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(546, 84);
            label7.Name = "label7";
            label7.Size = new Size(58, 15);
            label7.TabIndex = 6;
            label7.Text = "Condutor";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(543, 131);
            label8.Name = "label8";
            label8.Size = new Size(71, 15);
            label8.TabIndex = 7;
            label8.Text = "Automóveis";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(543, 167);
            label9.Name = "label9";
            label9.Size = new Size(104, 15);
            label9.TabIndex = 8;
            label9.Text = "KM do Automóvel";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(543, 199);
            label10.Name = "label10";
            label10.Size = new Size(107, 15);
            label10.TabIndex = 9;
            label10.Text = "Devolução Prevista";
            // 
            // TelaAluguelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TelaAluguelForm";
            Text = "Cadastro de Aluguel";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
    }
}