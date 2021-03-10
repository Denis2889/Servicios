namespace Servicios
{
    partial class frmBuscarEmpresa
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
            this.dgvEmpresa = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpresa
            // 
            this.dgvEmpresa.AllowUserToAddRows = false;
            this.dgvEmpresa.AllowUserToDeleteRows = false;
            this.dgvEmpresa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpresa.Location = new System.Drawing.Point(12, 22);
            this.dgvEmpresa.Name = "dgvEmpresa";
            this.dgvEmpresa.ReadOnly = true;
            this.dgvEmpresa.Size = new System.Drawing.Size(467, 196);
            this.dgvEmpresa.TabIndex = 0;
            this.dgvEmpresa.DoubleClick += new System.EventHandler(this.dgvEmpresa_DoubleClick);
            // 
            // frmBuscarEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 237);
            this.Controls.Add(this.dgvEmpresa);
            this.Name = "frmBuscarEmpresa";
            this.Text = "frmBuscarEmpresa";
            this.Load += new System.EventHandler(this.frmBuscarEmpresa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpresa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpresa;
    }
}