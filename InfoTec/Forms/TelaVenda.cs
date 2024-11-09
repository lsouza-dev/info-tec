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
    public partial class TelaVenda : Form
    {
        List<ProdutoVenda> listaDeProdutos = new List<ProdutoVenda>();
        List<int> maxId = new List<int>();
        ProdutoVenda objProdutoVenda = new ProdutoVenda();
        ProdutoVenda objProdutoCadastrado = new ProdutoVenda();
        decimal valTot { get; set; }
        decimal valDesconto { get; set; }

        public TelaVenda()
        {
            InitializeComponent();
        }

        private void TelaVenda_Load(object sender, EventArgs e)
        {
            getClientes();
            getProdutos();
            dgProdutosVenda.DataSource = listaDeProdutos;

            DataGridViewButtonColumn buttonExcluir = new DataGridViewButtonColumn();
            buttonExcluir.Name = "Excluir";
            buttonExcluir.Text = "Excluir";
            buttonExcluir.UseColumnTextForButtonValue = true;
            dgProdutosVenda.Columns.Add(buttonExcluir);

        }


        public void getClientes()
        {
            List<string> nomeDosClientes = new List<string>();


            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT Nome FROM Cliente";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Cliente objCliente = new Cliente();
                            objCliente.Nome = reader["Nome"].ToString();
                           
                            nomeDosClientes.Add(objCliente.Nome.ToString());

                        }
                    }
                }
                connection.Close();
                cbCliente.DataSource = nomeDosClientes;
            }

        }

        public void getProdutos()
        {
            List<Produtos> nomeDosProdutos = new List<Produtos>();
            

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
                            objProduto.Descricao = reader["Descricao"].ToString();
                            objProduto.Id = Convert.ToInt32(reader["Id"]);

                            nomeDosProdutos.Add(objProduto);

                        }
                    }
                }
                connection.Close();
                cbProduto.DisplayMember = "Descricao";
                cbProduto.ValueMember = "Id";
                cbProduto.DataSource = nomeDosProdutos;

            }

        }

        public void getProdutoVenda()
        {
            List<ProdutoVenda> listaProdutoVenda = new List<ProdutoVenda>();


            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM ProdutoVenda";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            ProdutoVenda objProdutoVenda = new ProdutoVenda();

                            objProdutoVenda.IdVenda = Convert.ToInt32(reader["IdVenda"]);
                            objProdutoVenda.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                            objProdutoVenda.Qtd = Convert.ToInt32(reader["Quantidade"]);
                            objProdutoVenda.ValorTotal = Convert.ToDecimal(reader["ValorTotal"]);

                            listaProdutoVenda.Add(objProdutoVenda);
                        }
                    }
                }
                connection.Close();
                dgProdutosVenda.DataSource = listaProdutoVenda;
            }

        }


        public int getMaxIdProdutoVenda()
        {
            List<ProdutoVenda> listaProdutoVenda = new List<ProdutoVenda>();


            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM ProdutosVendas";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            ProdutoVenda objProdutoVenda = new ProdutoVenda();

                            objProdutoVenda.IdVenda = Convert.ToInt32(reader["IdVenda"]);
                            objProdutoVenda.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                            objProdutoVenda.Qtd = Convert.ToInt32(reader["Quantidade"]);
                            objProdutoVenda.ValorTotal = Convert.ToDecimal(reader["ValorTotal"]);

                            listaProdutoVenda.Add(objProdutoVenda);
                        }
                    }
                }
                connection.Close();
                int maxId = 0;
                if (listaProdutoVenda.Count > 0)
                {
                    maxId = listaProdutoVenda.Max(x => x.IdVenda);
                }
                return maxId;
            }

        }

        private void btAdicionar_Click(object sender, EventArgs e)
        {
            Produtos produto = new Produtos();

            int idVenda = getIdVenda() + 1;
            int idProduto = cbProduto.SelectedIndex + 1;
            decimal qtd = nudQuantidade.Value;
            decimal valor = getValorProdutos(Convert.ToInt32(cbProduto.SelectedValue));
            decimal valorFinal = qtd * valor;

            ProdutoVenda objProdutoVenda = new ProdutoVenda(idVenda,idProduto,qtd,valorFinal);
            //ConexaoSQLite.CadastrarProdutosVenda(objProdutoVenda);

            listaDeProdutos.Add(objProdutoVenda);
            atualizarValTot();

            nudQuantidade.Value = 1;
        }

        public decimal getValorProdutos(int id)
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
                var produto = listaDeProdutos.Find(x => x.Id == id);
                return produto.ValorProduto;
            }
        }

        private void cbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dgProdutosVenda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var idProd = listaDeProdutos.Find(x => x.IdProduto == Convert.ToInt32(dgProdutosVenda.Rows[e.RowIndex].Cells["IdVenda"].Value ));
            if (e.RowIndex >= 0 && e.ColumnIndex == dgProdutosVenda.Columns["Excluir"].Index)
            {
                DialogResult confirmarExclusao = MessageBox.Show($"Deseja excluir o produto:\nId Venda: {objProdutoVenda.IdVenda}\nId Produto: {objProdutoVenda.IdProduto}\nQuantidade: {objProdutoVenda.Qtd}\nValor: {objProdutoVenda.ValorTotal}", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmarExclusao == DialogResult.Yes)
                {
                    listaDeProdutos.Remove(idProd);
                    dgProdutosVenda.DataSource = listaDeProdutos;

                    atualizarValTot();
                    //ConexaoSQLite.();
                    //MessageBox.Show("Cliente excluido com sucesso!");
                    //getClientes();
                }


            }
        }

        private void dgProdutosVenda_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdutoVenda objVenda = new ProdutoVenda();
            objVenda.IdVenda = Convert.ToInt32(dgProdutosVenda.Rows[e.RowIndex].Cells["IdVenda"].Value);
            objVenda.IdProduto = Convert.ToInt32(dgProdutosVenda.Rows[e.RowIndex].Cells["IdProduto"].Value);
            objVenda.Qtd = Convert.ToDecimal(dgProdutosVenda.Rows[e.RowIndex].Cells["Qtd"].Value.ToString());
            objVenda.ValorTotal = Convert.ToDecimal(dgProdutosVenda.Rows[e.RowIndex].Cells["ValorTotal"].Value.ToString());
            

            objProdutoVenda = objVenda;
        }

        public void atualizarValTot()
        {
            List<ProdutoVenda> listaProdutosCB = new List<ProdutoVenda>();
            listaProdutosCB.AddRange(listaDeProdutos);
            dgProdutosVenda.DataSource = listaProdutosCB;

            valTot = Convert.ToDecimal(listaProdutosCB.Sum(x => x.ValorTotal));
            valDesconto = nudDesconto.Value; 


            nudValorFinal.Value =  valTot - valDesconto;
        }

        public int getIdVenda()
        {
            int maxIdVenda = 0;

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT IdVenda FROM ProdutosVendas";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutoVenda objProduto = new ProdutoVenda();

                            objProduto.IdVenda = Convert.ToInt32(reader["IdVenda"]);
                            

                            maxId.Add(objProduto.IdVenda);

                        }
                    }
                }

                connection.Close();
                if (maxId.Count > 0)
                {
                    maxIdVenda = maxId.Max();
                }

                return maxIdVenda;
            }
        }

        private void nudDesconto_ValueChanged(object sender, EventArgs e)
        {

            if (nudDesconto.Value < nudValorFinal.Value)
            {
                valDesconto = nudDesconto.Value;
                nudValorFinal.Value = valTot - valDesconto;
                
            }
            else if (nudDesconto.Value == 0)
            {
                atualizarValTot();
            }
            else
            {
                MessageBox.Show("O valor de desconto não pode ser maior que o valor final.", "Desconto inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btRealizarVenda_Click(object sender, EventArgs e)
        {
            int idVenda = getIdVenda() + 1;
            
            Vendas objVenda = new Vendas(idVenda,cbCliente.Text,nudDesconto.Value,nudValorFinal.Value);

           ConexaoSQLite.CadastrarVenda(objVenda);

            foreach(var item in listaDeProdutos)
            {
                item.IdVenda = idVenda;
                ConexaoSQLite.CadastrarProdutosVenda(item);
            }

            MessageBox.Show("Venda realizada com sucesso.");
            this.Close();
        }
    }
}
