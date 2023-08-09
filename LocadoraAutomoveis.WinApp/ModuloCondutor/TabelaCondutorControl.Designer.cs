namespace LocadoraAutomoveis.WinApp.ModuloCondutor
{
     partial class TabelaCondutorControl
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

          #region Component Designer generated code

          /// <summary> 
          /// Required method for Designer support - do not modify 
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
               gridCondutor = new DataGridView();
               ((System.ComponentModel.ISupportInitialize)gridCondutor).BeginInit();
               SuspendLayout();
               // 
               // gridCondutor
               // 
               gridCondutor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               gridCondutor.Dock = DockStyle.Fill;
               gridCondutor.Location = new Point(0, 0);
               gridCondutor.Margin = new Padding(3, 2, 3, 2);
               gridCondutor.Name = "gridCondutor";
               gridCondutor.RowHeadersWidth = 51;
               gridCondutor.RowTemplate.Height = 29;
               gridCondutor.Size = new Size(333, 276);
               gridCondutor.TabIndex = 1;
               // 
               // TabelaCondutorControl
               // 
               AutoScaleDimensions = new SizeF(7F, 15F);
               AutoScaleMode = AutoScaleMode.Font;
               Controls.Add(gridCondutor);
               Name = "TabelaCondutorControl";
               Size = new Size(333, 276);
               ((System.ComponentModel.ISupportInitialize)gridCondutor).EndInit();
               ResumeLayout(false);
          }

          #endregion

          private DataGridView gridCondutor;
     }
}
