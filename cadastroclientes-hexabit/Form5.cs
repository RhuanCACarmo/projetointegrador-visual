using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastroclientes_hexabit
{
    public partial class frmPesquisar: Form
    {
        public frmPesquisar()
        {
            InitializeComponent();
            
        }

        private void txtBuscarCPF_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroClientes form1 = new frmCadastroClientes();
            form1.Show();
        }

        private void vizualisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizarClientes form4 = new frmVisualizarClientes();
            form4.Show();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCadastrarEstoque form2 = new frmCadastrarEstoque();
            form2.Show();
        }

        private void gerarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerarPagamento form3 = new frmGerarPagamento();
            form3.Show();
        }
    }
}
