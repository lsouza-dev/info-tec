namespace InfoTec.Forms
{
    partial class TelaVenda
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
            this.lbCliente = new System.Windows.Forms.Label();
            this.lbQuantidade = new System.Windows.Forms.Label();
            this.lbProduto = new System.Windows.Forms.Label();
            this.lbProdutosVenda = new System.Windows.Forms.Label();
            this.lbValorFinal = new System.Windows.Forms.Label();
            this.lbDesconto = new System.Windows.Forms.Label();
            this.cbCliente = new System.Windows.Forms.ComboBox();
            this.cbProduto = new System.Windows.Forms.ComboBox();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.nudDesconto = new System.Windows.Forms.NumericUpDown();
            this.nudValorFinal = new System.Windows.Forms.NumericUpDown();
            this.btAdicionar = new System.Windows.Forms.Button();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.dgProdutosVenda = new System.Windows.Forms.DataGridView();
            this.btRealizarVenda = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesconto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorFinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutosVenda)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCliente
            // 
            this.lbCliente.AutoSize = true;
            this.lbCliente.Location = new System.Drawing.Point(32, 31);
            this.lbCliente.Name = "lbCliente";
            this.lbCliente.Size = new System.Drawing.Size(44, 15);
            this.lbCliente.TabIndex = 0;
            this.lbCliente.Text = "Cliente";
            // 
            // lbQuantidade
            // 
            this.lbQuantidade.AutoSize = true;
            this.lbQuantidade.Location = new System.Drawing.Point(302, 95);
            this.lbQuantidade.Name = "lbQuantidade";
            this.lbQuantidade.Size = new System.Drawing.Size(69, 15);
            this.lbQuantidade.TabIndex = 1;
            this.lbQuantidade.Text = "Quantidade";
            // 
            // lbProduto
            // 
            this.lbProduto.AutoSize = true;
            this.lbProduto.Location = new System.Drawing.Point(32, 95);
            this.lbProduto.Name = "lbProduto";
            this.lbProduto.Size = new System.Drawing.Size(50, 15);
            this.lbProduto.TabIndex = 2;
            this.lbProduto.Text = "Produto";
            // 
            // lbProdutosVenda
            // 
            this.lbProdutosVenda.AutoSize = true;
            this.lbProdutosVenda.Location = new System.Drawing.Point(32, 158);
            this.lbProdutosVenda.Name = "lbProdutosVenda";
            this.lbProdutosVenda.Size = new System.Drawing.Size(106, 15);
            this.lbProdutosVenda.TabIndex = 3;
            this.lbProdutosVenda.Text = "Produtos da Venda";
            // 
            // lbValorFinal
            // 
            this.lbValorFinal.AutoSize = true;
            this.lbValorFinal.Location = new System.Drawing.Point(302, 340);
            this.lbValorFinal.Name = "lbValorFinal";
            this.lbValorFinal.Size = new System.Drawing.Size(61, 15);
            this.lbValorFinal.TabIndex = 4;
            this.lbValorFinal.Text = "Valor Final";
            // 
            // lbDesconto
            // 
            this.lbDesconto.AutoSize = true;
            this.lbDesconto.Location = new System.Drawing.Point(32, 340);
            this.lbDesconto.Name = "lbDesconto";
            this.lbDesconto.Size = new System.Drawing.Size(57, 15);
            this.lbDesconto.TabIndex = 5;
            this.lbDesconto.Text = "Desconto";
            // 
            // cbCliente
            // 
            this.cbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCliente.FormattingEnabled = true;
            this.cbCliente.Location = new System.Drawing.Point(32, 49);
            this.cbCliente.Name = "cbCliente";
            this.cbCliente.Size = new System.Drawing.Size(390, 23);
            this.cbCliente.TabIndex = 1;
            // 
            // cbProduto
            // 
            this.cbProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProduto.FormattingEnabled = true;
            this.cbProduto.Location = new System.Drawing.Point(32, 113);
            this.cbProduto.Name = "cbProduto";
            this.cbProduto.Size = new System.Drawing.Size(215, 23);
            this.cbProduto.TabIndex = 2;
            this.cbProduto.SelectedIndexChanged += new System.EventHandler(this.cbProduto_SelectedIndexChanged);
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Location = new System.Drawing.Point(302, 114);
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 23);
            this.nudQuantidade.TabIndex = 6;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudDesconto
            // 
            this.nudDesconto.DecimalPlaces = 2;
            this.nudDesconto.Location = new System.Drawing.Point(32, 358);
            this.nudDesconto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDesconto.Name = "nudDesconto";
            this.nudDesconto.Size = new System.Drawing.Size(215, 23);
            this.nudDesconto.TabIndex = 7;
            this.nudDesconto.ValueChanged += new System.EventHandler(this.nudDesconto_ValueChanged);
            // 
            // nudValorFinal
            // 
            this.nudValorFinal.DecimalPlaces = 2;
            this.nudValorFinal.Enabled = false;
            this.nudValorFinal.Location = new System.Drawing.Point(302, 358);
            this.nudValorFinal.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudValorFinal.Name = "nudValorFinal";
            this.nudValorFinal.Size = new System.Drawing.Size(214, 23);
            this.nudValorFinal.TabIndex = 8;
            // 
            // btAdicionar
            // 
            this.btAdicionar.Location = new System.Drawing.Point(441, 114);
            this.btAdicionar.Name = "btAdicionar";
            this.btAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btAdicionar.TabIndex = 9;
            this.btAdicionar.Text = "Adicionar";
            this.btAdicionar.UseVisualStyleBackColor = true;
            this.btAdicionar.Click += new System.EventHandler(this.btAdicionar_Click);
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // dgProdutosVenda
            // 
            this.dgProdutosVenda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProdutosVenda.Location = new System.Drawing.Point(32, 176);
            this.dgProdutosVenda.Name = "dgProdutosVenda";
            this.dgProdutosVenda.RowTemplate.Height = 25;
            this.dgProdutosVenda.Size = new System.Drawing.Size(484, 150);
            this.dgProdutosVenda.TabIndex = 10;
            this.dgProdutosVenda.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutosVenda_CellClick);
            this.dgProdutosVenda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdutosVenda_CellContentClick);
            // 
            // btRealizarVenda
            // 
            this.btRealizarVenda.Location = new System.Drawing.Point(386, 407);
            this.btRealizarVenda.Name = "btRealizarVenda";
            this.btRealizarVenda.Size = new System.Drawing.Size(130, 39);
            this.btRealizarVenda.TabIndex = 11;
            this.btRealizarVenda.Text = "Realizar Venda";
            this.btRealizarVenda.UseVisualStyleBackColor = true;
            this.btRealizarVenda.Click += new System.EventHandler(this.btRealizarVenda_Click);
            // 
            // TelaVenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 458);
            this.Controls.Add(this.btRealizarVenda);
            this.Controls.Add(this.dgProdutosVenda);
            this.Controls.Add(this.btAdicionar);
            this.Controls.Add(this.nudValorFinal);
            this.Controls.Add(this.nudDesconto);
            this.Controls.Add(this.nudQuantidade);
            this.Controls.Add(this.cbProduto);
            this.Controls.Add(this.cbCliente);
            this.Controls.Add(this.lbDesconto);
            this.Controls.Add(this.lbValorFinal);
            this.Controls.Add(this.lbProdutosVenda);
            this.Controls.Add(this.lbProduto);
            this.Controls.Add(this.lbQuantidade);
            this.Controls.Add(this.lbCliente);
            this.Name = "TelaVenda";
            this.Text = "TelaVenda";
            this.Load += new System.EventHandler(this.TelaVenda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDesconto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudValorFinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdutosVenda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbCliente;
        private Label lbQuantidade;
        private Label lbProduto;
        private Label lbProdutosVenda;
        private Label lbValorFinal;
        private Label lbDesconto;
        private ComboBox cbCliente;
        private ComboBox cbProduto;
        private NumericUpDown nudQuantidade;
        private NumericUpDown nudDesconto;
        private NumericUpDown nudValorFinal;
        private Button btAdicionar;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private DataGridView dgProdutosVenda;
        private Button btRealizarVenda;
    }
}