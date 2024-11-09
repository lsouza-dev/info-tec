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

namespace InfoTec.Forms
{
    public partial class TelaConsultVendas : Form
    {

        List<Vendas> listaDeVendas = new List<Vendas>();
        int IdVenda { get; set; }
        public TelaConsultVendas()
        {
            InitializeComponent();
        }

        private void TelaConsultVendas_Load(object sender, EventArgs e)
        {
            getVendas();
        }

        public void getVendas()
        {
            List<Vendas> listVendas = new List<Vendas>();
            string connectionstring = "Data Source =c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Venda";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Vendas objVenda = new Vendas();
                            objVenda.IdVenda = Convert.ToInt32(reader["Id"]);
                            objVenda.Cliente = reader["Cliente"].ToString();
                            objVenda.ValorDesconto = Convert.ToDecimal(reader["ValorDesconto"]);
                            objVenda.Valorfinal = Convert.ToDecimal(Convert.ToDouble(reader["ValorFinal"]));

                            listVendas.Add(objVenda);

                        }
                    }
                }
                connection.Close();
                listaDeVendas.AddRange(listVendas);
                dgVendas.DataSource = listVendas;
            }
        }

        private void dgVendas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdVenda = Convert.ToInt32(dgVendas.Rows[e.RowIndex].Cells["IdVenda"].Value);
            MessageBox.Show(getProdutosVendas(IdVenda));
            
        }

        private string getProdutosVendas(int id)
        {
            List<ProdutoVenda> listaDeProdutos = new List<ProdutoVenda>();
            string connectionstring = "Data Source=c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM ProdutosVendas";
                using (SQLiteCommand command = new SQLiteCommand(sql,connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutoVenda produtoVenda = new ProdutoVenda();
                            produtoVenda.IdVenda = Convert.ToInt32(reader["IdVenda"]);
                            produtoVenda.IdProduto = Convert.ToInt32(reader["IdProduto"]);
                            produtoVenda.Qtd = Convert.ToInt32(reader["Quantidade"]);
                            produtoVenda.ValorTotal = Convert.ToDecimal(reader["ValorTotal"]);

                            if (produtoVenda.IdVenda == id)
                            {
                                listaDeProdutos.Add(produtoVenda);
                            }
                        }
                    }
                }
                connection.Close();
            }
            string texto = "";
            foreach (var item in listaDeProdutos)
            {
                texto += $"Id Produto: {item.IdProduto}\nQuantidade: {item.Qtd}\nValor: {item.ValorTotal}\n\n";
            }
            return texto;
        }
    }
}
