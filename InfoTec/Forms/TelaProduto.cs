using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using InfoTec.Bancos;
using InfoTec.Classes;
using InfoTec.Forms;

namespace InfoTec.Forms
{
    public partial class TelaProduto : Form
    {
        Produtos produtoPrincipal = new Produtos();

        public TelaProduto()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            CadProduto formCadastro = new CadProduto();
            formCadastro.ShowDialog();
            getProdutos();
        }

        private void TelaProduto_Load(object sender, EventArgs e)
        {
            getProdutos();
            DataGridViewButtonColumn buttonExcluir = new DataGridViewButtonColumn();
            buttonExcluir.Name = "Excluir";
            buttonExcluir.Text = "Excluir";
            buttonExcluir.UseColumnTextForButtonValue = true;
            dgProdutos.Columns.Add(buttonExcluir);
        }

        public void getProdutos()
        {
            List<Produtos> listaDeProdutos = new List<Produtos>();  

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Produto";
                using (SQLiteCommand command = new SQLiteCommand(sql,connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produtos objProduto = new Produtos();

                            objProduto.Id = Convert.ToInt32(reader["Id"]);
                            objProduto.Descricao = reader["Descricao"].ToString();
                            objProduto.ValorProduto = Convert.ToDecimal(reader["ValorProduto"]);

                            listaDeProdutos.Add(objProduto);

                        }
                    }
                }

                connection.Close();
                dgProdutos.DataSource = listaDeProdutos;
            }
        }

        public int getMaxId()
        {
            List<Produtos> listaDeProdutos = new List<Produtos>();

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Produto";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Produtos objProduto = new Produtos();

                            objProduto.Id = Convert.ToInt32(reader["Id"]);
                            objProduto.Descricao = reader["Descricao"].ToString();
                            objProduto.ValorProduto = Convert.ToDecimal(reader["ValorProduto"]);

                            listaDeProdutos.Add(objProduto);

                        }
                    }
                }

                connection.Close();

                int maxId = 0;
                if (listaDeProdutos.Count > 0)
                {
                    maxId = listaDeProdutos.Max(x=>x.Id);
                }
                return maxId;
            }
        }

        private void dgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Produtos objProduto = new Produtos();
            objProduto.Id = Convert.ToInt32(dgProdutos.Rows[e.RowIndex].Cells["Id"].Value);
            objProduto.Descricao = dgProdutos.Rows[e.RowIndex].Cells["Descricao"].Value.ToString();
            objProduto.ValorProduto = Convert.ToDecimal(dgProdutos.Rows[e.RowIndex].Cells["ValorProduto"].Value);
           
            produtoPrincipal = objProduto;
        }

        private void dgProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgProdutos.Columns["Excluir"].Index)
            {
                DialogResult confirmarExclusao = MessageBox.Show($"Deseja excluir permanentemente os dados do cliente:\nId: {produtoPrincipal.Id}\nDescrição: {produtoPrincipal.Descricao}\nValor: {produtoPrincipal.ValorProduto}", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmarExclusao == DialogResult.Yes)
                {
                    ConexaoSQLite.RemoverProduto(produtoPrincipal.Id);
                    MessageBox.Show("Produto excluido com sucesso!");
                    getProdutos();
                }
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            CadProduto formCadastro = new CadProduto();
            formCadastro.produto = produtoPrincipal;
            formCadastro.ShowDialog();
            getProdutos();
        }

        private void dgProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //int id = dgProdutos
        }
    }
}
