using InfoTec.Classes;
using InfoTec.Forms;
using System.Data.SQLite;
using InfoTec.Bancos;


namespace InfoTec
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaCliente formTelaCliente = new TelaCliente();
            formTelaCliente.MdiParent = this;
            formTelaCliente.Show();
            
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaProduto formTelaProduto = new TelaProduto();
            formTelaProduto.MdiParent = this;
            formTelaProduto.Show();
            
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaUsuario formTelaUsuario = new TelaUsuario();
            formTelaUsuario.MdiParent = this;
            formTelaUsuario.Show();
        }

        private void realizarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaVenda formTelaVenda = new TelaVenda();
            formTelaVenda.MdiParent = this;
            formTelaVenda.Show();

        }

        private void consultarVendaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TelaConsultVendas FormTelaConsultVendas = new TelaConsultVendas();
            FormTelaConsultVendas.MdiParent = this;
            FormTelaConsultVendas.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }
    }
}