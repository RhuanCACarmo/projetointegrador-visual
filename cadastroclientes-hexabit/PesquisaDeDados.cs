using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using MySqlX.XDevAPI.Relational;
using Mysqlx.Resultset;

namespace cadastroclientes_hexabit
{
    public partial class frmPesquisar : Form
    {
        public int? idcliente { get; private set; }
        public int? idestoque { get; private set; }
        public int? idpagamento { get; private set; }

        public frmPesquisar()
        {
            InitializeComponent();
        }

        public static class FormManager
        {
            // Versão sem parâmetros
            public static void ShowForm<T>() where T : Form, new()
            {
                ShowForm<T>(null);
            }

            // Versão com parâmetros
            public static void ShowForm<T>(params object[] args) where T : Form
            {
                // Verifica se o formulário já está aberto
                var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();
                if (existingForm != null)
                {
                    existingForm.BringToFront();
                    existingForm.WindowState = FormWindowState.Normal; // Restaura se minimizado
                    return;
                }

                // Cria nova instância
                T form;
                try
                {
                    form = args == null || args.Length == 0
                        ? Activator.CreateInstance<T>()
                        : (T)Activator.CreateInstance(typeof(T), args);

                    form.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir o formulário: {ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public static void CloseAllForms()
            {
                // Fecha todos os forms exceto o principal
                for (int i = Application.OpenForms.Count - 1; i >= 1; i--)
                {
                    Application.OpenForms[i].Close();
                }
            }
        }

        // Implementação dos métodos de clique nos itens de menu
        private void btnFecharPrograma_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair do sistema?", "Confirmação",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormManager.CloseAllForms();
                Application.Exit();
            }
        }

        private void tsmPesquisar_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmPesquisar>();
        }

        private void tsmCadastroCliente_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroClientes>(idcliente);
        }

        private void tsmVisualizarCliente_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarClientes>();
        }

        private void tsmCadastrarEstoque_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastrarEstoque>(idestoque);
        }

        private void tsmVisualizarEstoque_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarEstoque>();
        }
        private void tsmVisualizarPagamentos_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarPagamentos>();
        }
        private void tsmGerarPagamento_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroPagamento>(idpagamento);
        }
    }
}