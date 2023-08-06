namespace LocadoraAutomoveis.WinApp.ModuloPlanoCobranca
{
    partial class TabelaPlanoCobrancaControl
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
            gridPlanoCobranca = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)gridPlanoCobranca).BeginInit();
            SuspendLayout();
            // 
            // gridPlanoCobranca
            // 
            gridPlanoCobranca.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridPlanoCobranca.Dock = DockStyle.Fill;
            gridPlanoCobranca.Location = new Point(0, 0);
            gridPlanoCobranca.Name = "gridPlanoCobranca";
            gridPlanoCobranca.RowHeadersWidth = 51;
            gridPlanoCobranca.RowTemplate.Height = 29;
            gridPlanoCobranca.Size = new Size(556, 486);
            gridPlanoCobranca.TabIndex = 0;
            // 
            // TabelaPlanoCobrancaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(gridPlanoCobranca);
            Name = "TabelaPlanoCobrancaControl";
            Size = new Size(556, 486);
            ((System.ComponentModel.ISupportInitialize)gridPlanoCobranca).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridPlanoCobranca;
    }
}
