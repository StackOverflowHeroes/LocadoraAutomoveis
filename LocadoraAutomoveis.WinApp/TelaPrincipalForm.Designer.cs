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
               menuStrip1 = new MenuStrip();
               cadastrosMenuItem = new ToolStripMenuItem();
               painelRegistros = new Panel();
               sRodape.SuspendLayout();
               menuStrip1.SuspendLayout();
               SuspendLayout();
               // 
               // sRodape
               // 
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
               toolStrip1.Location = new Point(0, 24);
               toolStrip1.Name = "toolStrip1";
               toolStrip1.Size = new Size(834, 25);
               toolStrip1.TabIndex = 1;
               toolStrip1.Text = "toolStrip1";
               // 
               // menuStrip1
               // 
               menuStrip1.Items.AddRange(new ToolStripItem[] { cadastrosMenuItem });
               menuStrip1.Location = new Point(0, 0);
               menuStrip1.Name = "menuStrip1";
               menuStrip1.Size = new Size(834, 24);
               menuStrip1.TabIndex = 2;
               menuStrip1.Text = "menuStrip1";
               // 
               // cadastrosMenuItem
               // 
               cadastrosMenuItem.Name = "cadastrosMenuItem";
               cadastrosMenuItem.Size = new Size(71, 20);
               cadastrosMenuItem.Text = "Cadastros";
               // 
               // painelRegistros
               // 
               painelRegistros.Dock = DockStyle.Fill;
               painelRegistros.Location = new Point(0, 49);
               painelRegistros.Name = "painelRegistros";
               painelRegistros.Size = new Size(834, 340);
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
     }
}