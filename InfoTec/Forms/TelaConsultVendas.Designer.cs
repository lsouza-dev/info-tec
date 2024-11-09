namespace InfoTec.Forms
{
    partial class TelaConsultVendas
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
            this.dgVendas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVendas
            // 
            this.dgVendas.AllowUserToAddRows = false;
            this.dgVendas.AllowUserToDeleteRows = false;
            this.dgVendas.AllowUserToOrderColumns = true;
            this.dgVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVendas.Location = new System.Drawing.Point(28, 42);
            this.dgVendas.Name = "dgVendas";
            this.dgVendas.ReadOnly = true;
            this.dgVendas.RowTemplate.Height = 25;
            this.dgVendas.Size = new System.Drawing.Size(453, 297);
            this.dgVendas.TabIndex = 0;
            this.dgVendas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgVendas_CellDoubleClick);
            // 
            // TelaConsultVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 376);
            this.Controls.Add(this.dgVendas);
            this.Name = "TelaConsultVendas";
            this.Text = "TelaConsultVendas";
            this.Load += new System.EventHandler(this.TelaConsultVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgVendas;
    }
}