using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InfoTec.Bancos;
using InfoTec.Classes;
using InfoTec.Forms;



namespace InfoTec.Forms
{
    public partial class CadUsuario : Form
    {
        public Usuario usuario = new Usuario();

        public CadUsuario()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            string login, senha;

            TelaUsuario formTelaUsuario = new TelaUsuario();

            if (usuario.Id > 0)
            {
                if (tbLogin.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Preencha o campo Login");
                }
                else
                {
                    login = tbLogin.Text;
                    if (tbSenha.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Preencha o campo Senha");
                    }
                    else
                    {
                        senha = tbSenha.Text;

                        Usuario objUsuario = new Usuario(usuario.Id, login, senha);

                        ConexaoSQLite.EditarUsuario(objUsuario);

                        DialogResult confirmarAlteracao = MessageBox.Show("Deseja alterar os dados do Usuario?", "Confirmar alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                        if (confirmarAlteracao == DialogResult.Yes)
                        {
                            ConexaoSQLite.EditarUsuario(objUsuario);
                            MessageBox.Show("Usuario alterado com sucesso!");

                            limparCampos();

                        }
                    }

                }
            }
            else
            {
                if (tbLogin.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Preencha o campo Login");
                }
                else
                {
                    login = tbLogin.Text;
                    if (tbSenha.Text.Equals(string.Empty))
                    {
                        MessageBox.Show("Preencha o campo Senha");
                    }
                    else
                    {
                        senha = tbSenha.Text;

                        int id = formTelaUsuario.getMaxId() + 1;
                        Usuario objUsuario = new Usuario(id, login, senha);

                        ConexaoSQLite.CadastrarUsuario(objUsuario);
                        MessageBox.Show("Usuário cadastrado com sucesso!");
                        limparCampos();
                    }
                }
            }
        }

        private void CadUsuario_Load(object sender, EventArgs e)
        {
            tbLogin.Text = usuario.Login;
            tbSenha.Text = usuario.Senha;
           
        }

        public void limparCampos()
        {
            tbLogin.Clear();
            tbSenha.Clear();
        }
    }
}
