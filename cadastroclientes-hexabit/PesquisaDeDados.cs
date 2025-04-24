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
    public partial class frmPesquisar: Form
    {
        private DatabaseManager dbManager;
        public class DatabaseManager
        {
            private string connectionString = "Server=localhost;Database=hexabits;Uid=root;Pwd=;";

            public DataTable ExecuteQuery(string query)
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        connection.Open();
                        MySqlCommand command = new MySqlCommand(query, connection);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao conectar ao banco: " + ex.Message);
                    }
                    return dataTable;
                }
            }
        }

        public frmPesquisar()
        {
            InitializeComponent();
            dbManager = new DatabaseManager();
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
        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizarEstoque form5 = new frmVisualizarEstoque();
            form5.Show();
        }

        private void visualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVisualizarPagamentos form6 = new frmVisualizarPagamentos();
            form6.Show();
        }

        private void btnFecharPrograma_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
                string termoPesquisa = txtPesquisa.Text.Trim();

                if (string.IsNullOrEmpty(termoPesquisa))
                {
                    MessageBox.Show("Digite um nome ou CPF/CNPJ para pesquisar");
                    return;
                }

                PesquisarCliente(termoPesquisa);
            }

        private void PesquisarCliente(string termoPesquisa)
        {

            // Query para buscar cliente
            string queryCliente = $@"
            SELECT * FROM cliente 
            WHERE nome LIKE '%{termoPesquisa}%' 
            OR cpf_cnpj LIKE '%{termoPesquisa}%'";

            DataTable clientes = dbManager.ExecuteQuery(queryCliente);

            if (clientes.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum cliente encontrado");
                return;
            }

            // Mostrar dados do cliente
            DataRow cliente = clientes.Rows[0];
            PreencherDadosCliente(cliente);

            // Buscar pagamentos do cliente
            string idCliente = cliente["idcliente"].ToString();
            PesquisarPagamentos(idCliente);
        }

            private void PreencherDadosCliente(DataRow cliente)
                {
                    txtNome.Text = cliente["nome"].ToString();
                    txtCPF.Text = cliente["cpf_cnpj"].ToString();
                    txtEmail.Text = cliente["email"].ToString();
                    txtTelefone.Text = cliente["telefone"].ToString();
                    txtEndereco.Text = $"{cliente["rua"]}, {cliente["numero"]} - {cliente["bairro"]}, {cliente["cidade"]}";
                }

            private void PesquisarPagamentos(string idCliente)
            {
                string queryPagamentos = $@"
                SELECT p.*, e.nomedoproduto 
                FROM pagamento p
                INNER JOIN estoque e ON p.idestoque = e.idestoque
                WHERE p.idcliente = {idCliente}
                ORDER BY p.datadacompra DESC";

                DataTable pagamentos = dbManager.ExecuteQuery(queryPagamentos);
                dgvPagamentos.DataSource = pagamentos;

                // Configurar a DataGridView
                dgvPagamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvPagamentos.Columns["idpedido"].HeaderText = "Nº Pedido";
                dgvPagamentos.Columns["nomedoproduto"].HeaderText = "Produto";
                dgvPagamentos.Columns["precodecompra"].HeaderText = "Valor";
                dgvPagamentos.Columns["datadacompra"].HeaderText = "Data";
                dgvPagamentos.Columns["situacao"].HeaderText = "Status";
            }
        }
    }