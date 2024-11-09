using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoTec.Classes;
using InfoTec.Forms;
using InfoTec.Bancos;

namespace InfoTec.Forms
{
    public partial class CadProduto : Form
    {
        public Produtos produto = new Produtos();

        public CadProduto()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            int id;
            decimal valorProduto;
            string descricao;

            if (produto.Id > 0)
            {
                if (Decimal.TryParse(tbValor.Text, out valorProduto))
                {
                    valorProduto = Convert.ToDecimal(tbValor.Text);

                    if (tbDescricao.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Produto sem descrição.");
                    }
                    else
                    {
                        descricao = tbDescricao.Text;

                        Produtos objProduto = new Produtos(produto.Id, descricao, valorProduto);

                        DialogResult confirmarAlteracao = MessageBox.Show("Deseja alterar os dados do Produto?", "Confirmar alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (confirmarAlteracao == DialogResult.Yes)
                        {
                            ConexaoSQLite.EditarProduto(objProduto);
                            MessageBox.Show("Produto alterado com sucesso!");

                            limparCampos();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("O valor apenar pode conter números.");
                }
            }
            else
            {

                TelaProduto formProduto = new TelaProduto();
                int idObj = formProduto.getMaxId() + 1;

                if (tbValor.Text.Equals(string.Empty))
                {
                    MessageBox.Show("O campo VALOR não pode estar vazio");
                }
                else
                {
                    if (Decimal.TryParse(tbValor.Text, out valorProduto))
                    {
                        valorProduto = Convert.ToDecimal(tbValor.Text);

                        if (tbDescricao.Text.Equals(string.Empty))
                        {
                            MessageBox.Show("Produto sem descrição.");
                        }
                        else
                        {
                            descricao = tbDescricao.Text;

                            Produtos objProduto = new Produtos(idObj, descricao, valorProduto);

                            MessageBox.Show("Produto cadastrado com sucesso!");
                            ConexaoSQLite.CadastrarProdutos(objProduto);
                            limparCampos();


                            id = formProduto.getMaxId() + 1;
                            tbId.Text = id.ToString();
                        }
                    }
                    else
                    {
                        MessageBox.Show("O valor apenar pode conter números.");
                    }
                }

            }
            
        }
        public void limparCampos()
        {
            tbId.Clear();
            tbValor.Clear();
            tbDescricao.Clear();
            
        }

        private void CadProduto_Load(object sender, EventArgs e)
        {
            if (produto.Id == 0)
            {
                TelaProduto formProduto = new TelaProduto();
                int id = formProduto.getMaxId() + 1;
                tbId.Text = id.ToString();
            }
            else
            {


                tbId.Text = produto.Id.ToString();
                tbDescricao.Text = produto.Descricao;
                tbValor.Text = produto.ValorProduto.ToString();
            }
        }
    }
}
