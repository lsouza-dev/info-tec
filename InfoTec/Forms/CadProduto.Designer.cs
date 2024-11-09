namespace InfoTec.Forms
{
    partial class CadProduto
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
            this.lbId = new System.Windows.Forms.Label();
            this.lbValor = new System.Windows.Forms.Label();
            this.lbDescricao = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbDescricao = new System.Windows.Forms.TextBox();
            this.tbValor = new System.Windows.Forms.TextBox();
            this.btSalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(43, 42);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(20, 15);
            this.lbId.TabIndex = 0;
            this.lbId.Text = "Id:";
            // 
            // lbValor
            // 
            this.lbValor.AutoSize = true;
            this.lbValor.Location = new System.Drawing.Point(27, 86);
            this.lbValor.Name = "lbValor";
            this.lbValor.Size = new System.Drawing.Size(36, 15);
            this.lbValor.TabIndex = 1;
            this.lbValor.Text = "Valor:";
            // 
            // lbDescricao
            // 
            this.lbDescricao.AutoSize = true;
            this.lbDescricao.Location = new System.Drawing.Point(208, 39);
            this.lbDescricao.Name = "lbDescricao";
            this.lbDescricao.Size = new System.Drawing.Size(61, 15);
            this.lbDescricao.TabIndex = 2;
            this.lbDescricao.Text = "Descrição:";
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(66, 39);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(100, 23);
            this.tbId.TabIndex = 3;
            // 
            // tbDescricao
            // 
            this.tbDescricao.Location = new System.Drawing.Point(272, 36);
            this.tbDescricao.Multiline = true;
            this.tbDescricao.Name = "tbDescricao";
            this.tbDescricao.Size = new System.Drawing.Size(169, 70);
            this.tbDescricao.TabIndex = 4;
            // 
            // tbValor
            // 
            this.tbValor.Location = new System.Drawing.Point(66, 83);
            this.tbValor.Name = "tbValor";
            this.tbValor.Size = new System.Drawing.Size(100, 23);
            this.tbValor.TabIndex = 5;
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(366, 126);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 23);
            this.btSalvar.TabIndex = 6;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // CadProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 174);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.tbValor);
            this.Controls.Add(this.tbDescricao);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbDescricao);
            this.Controls.Add(this.lbValor);
            this.Controls.Add(this.lbId);
            this.Name = "CadProduto";
            this.Text = "CadProduto";
            this.Load += new System.EventHandler(this.CadProduto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbId;
        private Label lbValor;
        private Label lbDescricao;
        private TextBox tbId;
        private TextBox tbDescricao;
        private TextBox tbValor;
        private Button btSalvar;
    }
}