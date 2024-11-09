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
using System.Data.SQLite;


namespace InfoTec.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {

            string usuario;
            string senha;

            if (tbUsuario.Text.Equals(string.Empty))
            {
                MessageBox.Show($"O campo USUÁRIO não pode estar vazio.", "Erro de preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                usuario = tbUsuario.Text;

                if (tbSenha.Text.Equals(string.Empty))
                {
                    MessageBox.Show($"O campo SENHA não pode estar vazio.", "Erro de preenchimento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    senha = tbSenha.Text;

                    Usuario objUsuario = new Usuario(usuario, senha);

                    if (ConexaoSQLite.ValidarUsuario(objUsuario))
                    {
                        MessageBox.Show($"Bem vindo(a) {usuario}!\nSeu login foi efetuado com sucesso!", "Usuário Existente", MessageBoxButtons.OK, MessageBoxIcon.None);
                        Principal formPrincipal = new Principal();
                        this.Hide();

                        formPrincipal.ShowDialog();

                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show($"Usuário inexistente\nNão foi possível efetuar seu login!", "Usuário Inexistente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            //   Criando o usuario adm para entrar pela primeira vez no sistema


            ConexaoSQLite.CriarBanco();
            ConexaoSQLite.CriarTabelas();

            string loginAdm = "Admin";
            string senhaAdm = "admin123";
            Usuario userAdm = new Usuario(1, loginAdm, senhaAdm);

            ConexaoSQLite.CadastrarUsuario(userAdm);

            // Comentar após primeiro uso
        }
    }
}
