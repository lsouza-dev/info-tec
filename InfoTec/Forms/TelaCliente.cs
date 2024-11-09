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
using InfoTec.Classes;
using InfoTec.Bancos;
using InfoTec.Forms;


namespace InfoTec.Forms
{
    public partial class TelaCliente : Form
    {
        public Cliente clienteEdit = new Cliente();

        public TelaCliente()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, EventArgs e)
        {
            CadCliente formCadastro = new CadCliente();
            formCadastro.ShowDialog();
            getClientes();
        }

        public void getClientes()
        {
            List<Cliente> listaDeClientes = new List<Cliente>();

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Cliente";
                using (SQLiteCommand command = new SQLiteCommand(sql,connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        
                        while (reader.Read())
                        {
                            Cliente objCliente = new Cliente();
                            objCliente.Id = Convert.ToInt32(reader["Id"]);
                            objCliente.Nome = reader["Nome"].ToString();
                            objCliente.Cpf = reader["CPF"].ToString();
                            objCliente.Telefone = reader["Telefone"].ToString();
                            objCliente.Email = reader["Email"].ToString();

                            listaDeClientes.Add(objCliente);

                        }
                    }
                }
                connection.Close();
                dgClientes.DataSource = listaDeClientes;
            }

        }

        public int getMaxId()
        {
            List<Cliente> listaDeClientes = new List<Cliente>();

            string connectionstring = "Data Source = c:\\dados\\Cadastro.sqlite;Version = 3";
            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();
                string sql = "SELECT * FROM Cliente";
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cliente objCliente = new Cliente();
                            objCliente.Id = Convert.ToInt32(reader["Id"]);
                            objCliente.Nome = reader["Nome"].ToString();
                            objCliente.Cpf = reader["CPF"].ToString();
                            objCliente.Telefone = reader["Telefone"].ToString();
                            objCliente.Email = reader["Email"].ToString();

                            listaDeClientes.Add(objCliente);
                        }
                    }
                }
                connection.Close();
                int maxId = 0;
                if (listaDeClientes.Count > 0)
                {
                    maxId = listaDeClientes.Max(x => x.Id);
                    
                }

                return maxId;
            }

        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {
            getClientes();
            DataGridViewButtonColumn buttonExcluir = new DataGridViewButtonColumn();
            buttonExcluir.Name = "Excluir";
            buttonExcluir.Text = "Excluir";
            buttonExcluir.UseColumnTextForButtonValue = true;
            dgClientes.Columns.Add(buttonExcluir);
        }

        private void dgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente objCliente = new Cliente();
            objCliente.Id = Convert.ToInt32(dgClientes.Rows[e.RowIndex].Cells["Id"].Value);
            objCliente.Nome = dgClientes.Rows[e.RowIndex].Cells["Nome"].Value.ToString();
            objCliente.Cpf = dgClientes.Rows[e.RowIndex].Cells["Cpf"].Value.ToString();
            objCliente.Telefone = dgClientes.Rows[e.RowIndex].Cells["Telefone"].Value.ToString();
            objCliente.Email = dgClientes.Rows[e.RowIndex].Cells["Email"].Value.ToString();

            clienteEdit = objCliente;
        }

        private void dgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex == dgClientes.Columns["Excluir"].Index)
            {
                DialogResult confirmarExclusao = MessageBox.Show($"Deseja excluir permanentemente os dados do cliente:\nId: {clienteEdit.Id}\nNome: {clienteEdit.Nome}\nCpf: {clienteEdit.Cpf}","Confirmar exclusão",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (confirmarExclusao == DialogResult.Yes)
                {
                    ConexaoSQLite.RemoverCliente(clienteEdit.Id);
                    MessageBox.Show("Cliente excluido com sucesso!");
                    getClientes();
                }
            }

        }


        private void btEditar_Click(object sender, EventArgs e)
        {
            CadCliente formCadastro = new CadCliente();
            formCadastro.cliente = clienteEdit;
            formCadastro.ShowDialog();
            getClientes();
        }
    }
}
