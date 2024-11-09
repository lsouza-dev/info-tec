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
using InfoTec.Bancos;

namespace InfoTec.Forms
{
    public partial class CadCliente : Form
    {
        public Cliente cliente = new Cliente();

        public CadCliente()
        {
            InitializeComponent();
        }

        private void tbSalvar_Click(object sender, EventArgs e)
        {
            setCliente();
        }

        private void setCliente()
        {
            TelaCliente formCliente = new TelaCliente();
            
            string nome, cpf, telefone, email;
            int id;

            Cliente clienteEdit = new Cliente();
            clienteEdit = cliente;
            
            if (clienteEdit.Id > 0)
            {
                

                if (tbNome.Text.Equals(string.Empty))
                {
                    MessageBox.Show("O campo NOME não pode estar vazio");
                }
                else
                {
                    nome = tbNome.Text;
                    if (tbNome.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("O campo NOME não pode estar vazio");
                    }
                    else
                    {
                        nome = tbNome.Text;
                        if (tbCpf.Text.Equals(string.Empty))
                        {
                            MessageBox.Show("O campo CPF não pode estar vazio");
                        }
                        else
                        {
                            cpf = tbCpf.Text;
                            if (tbTelefone.Text.Equals(string.Empty))
                            {
                                MessageBox.Show("O campo TELEFONE não pode estar vazio");
                            }
                            else
                            {
                                telefone = tbTelefone.Text;
                                if (tbEmail.Text.Equals(string.Empty))
                                {
                                    MessageBox.Show("O campo EMAIL não pode estar vazio");
                                }
                                else
                                {
                                    email = tbEmail.Text;

                                    Cliente objCliente = new Cliente(cliente.Id, nome, cpf, telefone, email);

                                    DialogResult confirmarAlteracao = MessageBox.Show("Deseja alterar os dados do Cliente?", "Confirmar alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                                    if (confirmarAlteracao == DialogResult.Yes)
                                    {
                                        ConexaoSQLite.EditarCliente(objCliente);
                                        MessageBox.Show("Cliente alterado com sucesso!");

                                        limparCampos();
                                        
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                id = formCliente.getMaxId() + 1; // Usar o método de leitura do banco e retornar o maxID

                if (tbNome.Text.Equals(string.Empty))
                {
                    MessageBox.Show("O campo NOME não pode estar vazio");
                }
                else
                {
                    nome = tbNome.Text;
                    if (tbNome.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("O campo NOME não pode estar vazio");
                    }
                    else
                    {
                        nome = tbNome.Text;
                        if (tbCpf.Text.Equals(string.Empty))
                        {
                            MessageBox.Show("O campo CPF não pode estar vazio");
                        }
                        else
                        {
                            cpf = tbCpf.Text;
                            if (tbTelefone.Text.Equals(string.Empty))
                            {
                                MessageBox.Show("O campo TELEFONE não pode estar vazio");
                            }
                            else
                            {
                                telefone = tbTelefone.Text;
                                if (tbEmail.Text.Equals(string.Empty))
                                {
                                    MessageBox.Show("O campo EMAIL não pode estar vazio");
                                }
                                else
                                {
                                    email = tbEmail.Text;

                                    Cliente objCliente = new Cliente(id, nome, cpf, telefone, email);
                                    ConexaoSQLite.CadastrarCliente(objCliente);


                                    MessageBox.Show("Cliente Cadastrado com sucesso!");
                                    limparCampos();

                                    id= formCliente.getMaxId() + 1;
                                    tbId.Text = id.ToString();

                                }
                            }
                        }
                    }
                }
            }
            
        }

        public void limparCampos()
        {
            tbNome.Clear();
            tbCpf.Clear();
            tbTelefone.Clear();
            tbEmail.Clear();
            
        }

        private void CadCliente_Load(object sender, EventArgs e)
        {
            if (cliente.Id == 0 )
            {
                TelaCliente formCliente = new TelaCliente();
                int id = formCliente.getMaxId() + 1;
                tbId.Text = id.ToString();
            }
            else
            {
                

                tbId.Text = cliente.Id.ToString();
                tbNome.Text = cliente.Nome;
                tbCpf.Text = cliente.Cpf;
                tbTelefone.Text = cliente.Telefone;
                tbEmail.Text = cliente.Email;
            }
        }
    }
}
