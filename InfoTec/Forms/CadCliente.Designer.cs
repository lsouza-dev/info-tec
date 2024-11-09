namespace InfoTec.Forms
{
    partial class CadCliente
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
            this.tbId = new System.Windows.Forms.TextBox();
            this.lbId = new System.Windows.Forms.Label();
            this.tbSalvar = new System.Windows.Forms.Button();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbCpf = new System.Windows.Forms.TextBox();
            this.tbTelefone = new System.Windows.Forms.TextBox();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbCpf = new System.Windows.Forms.Label();
            this.lbTelefone = new System.Windows.Forms.Label();
            this.lbNome = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbId
            // 
            this.tbId.Enabled = false;
            this.tbId.Location = new System.Drawing.Point(50, 47);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(76, 23);
            this.tbId.TabIndex = 60;
            // 
            // lbId
            // 
            this.lbId.AutoSize = true;
            this.lbId.Location = new System.Drawing.Point(29, 50);
            this.lbId.Name = "lbId";
            this.lbId.Size = new System.Drawing.Size(20, 15);
            this.lbId.TabIndex = 59;
            this.lbId.Text = "Id:";
            // 
            // tbSalvar
            // 
            this.tbSalvar.Location = new System.Drawing.Point(267, 153);
            this.tbSalvar.Name = "tbSalvar";
            this.tbSalvar.Size = new System.Drawing.Size(75, 23);
            this.tbSalvar.TabIndex = 58;
            this.tbSalvar.Text = "Salvar";
            this.tbSalvar.UseVisualStyleBackColor = true;
            this.tbSalvar.Click += new System.EventHandler(this.tbSalvar_Click);
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(54, 153);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(156, 23);
            this.tbEmail.TabIndex = 57;
            // 
            // tbCpf
            // 
            this.tbCpf.Location = new System.Drawing.Point(54, 98);
            this.tbCpf.Name = "tbCpf";
            this.tbCpf.Size = new System.Drawing.Size(107, 23);
            this.tbCpf.TabIndex = 53;
            // 
            // tbTelefone
            // 
            this.tbTelefone.Location = new System.Drawing.Point(222, 98);
            this.tbTelefone.Name = "tbTelefone";
            this.tbTelefone.Size = new System.Drawing.Size(120, 23);
            this.tbTelefone.TabIndex = 55;
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(186, 47);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(156, 23);
            this.tbNome.TabIndex = 51;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(14, 156);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(39, 15);
            this.lbEmail.TabIndex = 56;
            this.lbEmail.Text = "Email:";
            // 
            // lbCpf
            // 
            this.lbCpf.AutoSize = true;
            this.lbCpf.Location = new System.Drawing.Point(22, 101);
            this.lbCpf.Name = "lbCpf";
            this.lbCpf.Size = new System.Drawing.Size(31, 15);
            this.lbCpf.TabIndex = 54;
            this.lbCpf.Text = "CPF:";
            // 
            // lbTelefone
            // 
            this.lbTelefone.AutoSize = true;
            this.lbTelefone.Location = new System.Drawing.Point(167, 101);
            this.lbTelefone.Name = "lbTelefone";
            this.lbTelefone.Size = new System.Drawing.Size(54, 15);
            this.lbTelefone.TabIndex = 52;
            this.lbTelefone.Text = "Telefone:";
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Location = new System.Drawing.Point(142, 50);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(43, 15);
            this.lbNome.TabIndex = 50;
            this.lbNome.Text = "Nome:";
            // 
            // CadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 214);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.lbId);
            this.Controls.Add(this.tbSalvar);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.tbCpf);
            this.Controls.Add(this.tbTelefone);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbCpf);
            this.Controls.Add(this.lbTelefone);
            this.Controls.Add(this.lbNome);
            this.Name = "CadCliente";
            this.Text = "CadCliente";
            this.Load += new System.EventHandler(this.CadCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbId;
        private Label lbId;
        private Button tbSalvar;
        private TextBox tbEmail;
        private TextBox tbCpf;
        private TextBox tbTelefone;
        private TextBox tbNome;
        private Label lbEmail;
        private Label lbCpf;
        private Label lbTelefone;
        private Label lbNome;
    }
}