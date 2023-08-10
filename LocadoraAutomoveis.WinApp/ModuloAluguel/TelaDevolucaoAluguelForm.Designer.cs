namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
     partial class TelaDevolucaoAluguelForm
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
               btnCancelar = new Button();
               btnGravar = new Button();
               lbValorTotal = new Label();
               label11 = new Label();
               label12 = new Label();
               tbControlTaxasAdicionadas = new TabControl();
               tbTaxas = new TabPage();
               listTaxas = new CheckedListBox();
               dateDevolucao = new DateTimePicker();
               label10 = new Label();
               valorKmPercorrido = new NumericUpDown();
               label9 = new Label();
               cboxNivelTanque = new ComboBox();
               label8 = new Label();
               btnCalcularValorTotal = new Button();
               tbControlTaxasAdicionadas.SuspendLayout();
               tbTaxas.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)valorKmPercorrido).BeginInit();
               SuspendLayout();
               // 
               // btnCancelar
               // 
               btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
               btnCancelar.DialogResult = DialogResult.Cancel;
               btnCancelar.Location = new Point(337, 349);
               btnCancelar.Name = "btnCancelar";
               btnCancelar.Size = new Size(85, 37);
               btnCancelar.TabIndex = 101;
               btnCancelar.Text = "Cancelar";
               btnCancelar.UseVisualStyleBackColor = true;
               // 
               // btnGravar
               // 
               btnGravar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
               btnGravar.DialogResult = DialogResult.OK;
               btnGravar.Location = new Point(246, 349);
               btnGravar.Name = "btnGravar";
               btnGravar.Size = new Size(85, 37);
               btnGravar.TabIndex = 100;
               btnGravar.Text = "Gravar";
               btnGravar.UseVisualStyleBackColor = true;
               btnGravar.Click += btnGravar_Click;
               // 
               // lbValorTotal
               // 
               lbValorTotal.AutoSize = true;
               lbValorTotal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
               lbValorTotal.ForeColor = Color.Green;
               lbValorTotal.Location = new Point(175, 347);
               lbValorTotal.Name = "lbValorTotal";
               lbValorTotal.Size = new Size(15, 17);
               lbValorTotal.TabIndex = 99;
               lbValorTotal.Text = "0";
               lbValorTotal.TextAlign = ContentAlignment.MiddleLeft;
               // 
               // label11
               // 
               label11.AutoSize = true;
               label11.Location = new Point(149, 349);
               label11.Name = "label11";
               label11.Size = new Size(20, 15);
               label11.TabIndex = 98;
               label11.Text = "R$";
               // 
               // label12
               // 
               label12.AutoSize = true;
               label12.Location = new Point(141, 37);
               label12.Name = "label12";
               label12.Size = new Size(109, 15);
               label12.TabIndex = 97;
               label12.Text = "Valor Total Previsto:";
               // 
               // tbControlTaxasAdicionadas
               // 
               tbControlTaxasAdicionadas.Controls.Add(tbTaxas);
               tbControlTaxasAdicionadas.Location = new Point(28, 139);
               tbControlTaxasAdicionadas.Name = "tbControlTaxasAdicionadas";
               tbControlTaxasAdicionadas.SelectedIndex = 0;
               tbControlTaxasAdicionadas.Size = new Size(398, 191);
               tbControlTaxasAdicionadas.TabIndex = 96;
               // 
               // tbTaxas
               // 
               tbTaxas.Controls.Add(listTaxas);
               tbTaxas.Location = new Point(4, 24);
               tbTaxas.Name = "tbTaxas";
               tbTaxas.Padding = new Padding(3);
               tbTaxas.Size = new Size(390, 163);
               tbTaxas.TabIndex = 0;
               tbTaxas.Text = "Taxas Adicionais";
               tbTaxas.UseVisualStyleBackColor = true;
               // 
               // listTaxas
               // 
               listTaxas.Dock = DockStyle.Fill;
               listTaxas.FormattingEnabled = true;
               listTaxas.Location = new Point(3, 3);
               listTaxas.Name = "listTaxas";
               listTaxas.Size = new Size(384, 157);
               listTaxas.TabIndex = 0;
               // 
               // dateDevolucao
               // 
               dateDevolucao.Format = DateTimePickerFormat.Short;
               dateDevolucao.Location = new Point(35, 95);
               dateDevolucao.Name = "dateDevolucao";
               dateDevolucao.Size = new Size(121, 23);
               dateDevolucao.TabIndex = 103;
               // 
               // label10
               // 
               label10.AutoSize = true;
               label10.Location = new Point(35, 77);
               label10.Name = "label10";
               label10.Size = new Size(90, 15);
               label10.TabIndex = 102;
               label10.Text = "Data Devolução";
               // 
               // valorKmPercorrido
               // 
               valorKmPercorrido.Enabled = false;
               valorKmPercorrido.Location = new Point(162, 95);
               valorKmPercorrido.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
               valorKmPercorrido.Name = "valorKmPercorrido";
               valorKmPercorrido.Size = new Size(121, 23);
               valorKmPercorrido.TabIndex = 105;
               // 
               // label9
               // 
               label9.AutoSize = true;
               label9.Location = new Point(162, 77);
               label9.Name = "label9";
               label9.Size = new Size(83, 15);
               label9.TabIndex = 104;
               label9.Text = "KM Percorrido";
               // 
               // cboxNivelTanque
               // 
               cboxNivelTanque.FormattingEnabled = true;
               cboxNivelTanque.Location = new Point(289, 95);
               cboxNivelTanque.Name = "cboxNivelTanque";
               cboxNivelTanque.Size = new Size(121, 23);
               cboxNivelTanque.TabIndex = 107;
               // 
               // label8
               // 
               label8.AutoSize = true;
               label8.Location = new Point(289, 77);
               label8.Name = "label8";
               label8.Size = new Size(92, 15);
               label8.TabIndex = 106;
               label8.Text = "Nível do Tanque";
               // 
               // btnCalcularValorTotal
               // 
               btnCalcularValorTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
               btnCalcularValorTotal.DialogResult = DialogResult.OK;
               btnCalcularValorTotal.Location = new Point(28, 345);
               btnCalcularValorTotal.Name = "btnCalcularValorTotal";
               btnCalcularValorTotal.Size = new Size(115, 22);
               btnCalcularValorTotal.TabIndex = 108;
               btnCalcularValorTotal.Text = "Calcular Total";
               btnCalcularValorTotal.UseVisualStyleBackColor = true;
               btnCalcularValorTotal.Click += btnCalcularValorTotal_Click;
               // 
               // TelaDevolucaoAluguelForm
               // 
               AutoScaleDimensions = new SizeF(7F, 15F);
               AutoScaleMode = AutoScaleMode.Font;
               ClientSize = new Size(445, 398);
               Controls.Add(btnCalcularValorTotal);
               Controls.Add(cboxNivelTanque);
               Controls.Add(label8);
               Controls.Add(valorKmPercorrido);
               Controls.Add(label9);
               Controls.Add(dateDevolucao);
               Controls.Add(label10);
               Controls.Add(btnCancelar);
               Controls.Add(btnGravar);
               Controls.Add(lbValorTotal);
               Controls.Add(label11);
               Controls.Add(label12);
               Controls.Add(tbControlTaxasAdicionadas);
               Name = "TelaDevolucaoAluguelForm";
               Text = "Registro de Devolução do Aluguel";
               tbControlTaxasAdicionadas.ResumeLayout(false);
               tbTaxas.ResumeLayout(false);
               ((System.ComponentModel.ISupportInitialize)valorKmPercorrido).EndInit();
               ResumeLayout(false);
               PerformLayout();
          }

          #endregion

          private Button btnCancelar;
          private Button btnGravar;
          private Label lbValorTotal;
          private Label label11;
          private Label label12;
          private TabControl tbControlTaxasAdicionadas;
          private TabPage tbTaxas;
          private CheckedListBox listTaxas;
          private DateTimePicker dateDevolucao;
          private Label label10;
          private NumericUpDown valorKmPercorrido;
          private Label label9;
          private ComboBox cboxNivelTanque;
          private Label label8;
          private Button btnCalcularValorTotal;
     }
}