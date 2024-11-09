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
    public partial class TelaUsuario : Form
    {
        public Usuario usuarioEdit = new Usuario();

        public TelaUsuario()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            CadUsuario formCadUsuario = new CadUsuario();
            formCadUsuario.ShowDialog();
            getUsuarios();
        }

        private void TelaUsuario_Load(object sender, EventArgs e)
        {
            getUsuarios();
            DataGridViewButtonColumn buttonExcluir = new DataGridViewButtonColumn();
            buttonExcluir.Name = "Excluir";
            buttonExcluir.Text = "Excluir";
            buttonExcluir.UseColumnTextForButtonValue = true;
            dgUsuarios.Columns.Add(buttonExcluir);
        }

        public void getUsuarios()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Usuario";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Usuario objUsuario= new Usuario();
                            objUsuario.Id = Convert.ToInt32(reader["Id"]);
                            objUsuario.Login = reader["Login"].ToString();
                            objUsuario.Senha = reader["Senha"].ToString();
                            

                            listaDeUsuarios.Add(objUsuario);

                        }
                    }
                }
                connection.Close();
                dgUsuarios.DataSource = listaDeUsuarios;
            }

        }


        public int getMaxId()
        {
            List<Usuario> listaDeUsuarios = new List<Usuario>();

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Usuario";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Usuario objUsuario = new Usuario();
                            objUsuario.Id = Convert.ToInt32(reader["Id"]);
                            objUsuario.Login = reader["Login"].ToString();
                            objUsuario.Senha = reader["Senha"].ToString();


                            listaDeUsuarios.Add(objUsuario);

                        }
                    }
                }
                connection.Close();
                int maxId = 0;
                if (listaDeUsuarios.Count > 0)
                {
                    maxId = listaDeUsuarios.Max(x => x.Id);
                }

                return maxId;
            }

        }

        private void dgUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario objUsuario = new Usuario();
            objUsuario.Id = Convert.ToInt32(dgUsuarios.Rows[e.RowIndex].Cells["Id"].Value);
            objUsuario.Login = dgUsuarios.Rows[e.RowIndex].Cells["Login"].Value.ToString();
            objUsuario.Senha = dgUsuarios.Rows[e.RowIndex].Cells["Senha"].Value.ToString();
            

            usuarioEdit = objUsuario;
        }

        private void dgUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgUsuarios.Columns["Excluir"].Index)
            {
                DialogResult confirmarExclusao = MessageBox.Show($"Deseja excluir permanentemente os dados do cliente:\nId: {usuarioEdit.Id}\nLogin: {usuarioEdit.Login}\nSenha: {usuarioEdit.Senha}", "Confirmar exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmarExclusao == DialogResult.Yes)
                {
                    ConexaoSQLite.RemoverUsuario(usuarioEdit.Id);
                    MessageBox.Show("Usuario excluido com sucesso!");
                    getUsuarios();
                }
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            CadUsuario formCadastro = new CadUsuario();
            formCadastro.usuario = usuarioEdit;
            formCadastro.ShowDialog();
            getUsuarios();
        }
    }
}
