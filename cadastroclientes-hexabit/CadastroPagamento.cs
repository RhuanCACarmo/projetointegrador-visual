using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using MySql.Data.MySqlClient;

namespace cadastroclientes_hexabit
{
    public partial class frmCadastroPagamento : Form
    {
        public int? idcliente { get; private set; }
        public int? idestoque { get; private set; }
      

        private readonly string connectionString = "datasource=localhost;username=root;password=;database=hexabits";

        private int? _idpagamento = null;

        public frmCadastroPagamento(int? idpagamento = null)
        {
            InitializeComponent();
            _idpagamento = idpagamento;

            if (_idpagamento.HasValue)
            {
                this.Text = "Editar Pagamento";
                CarregarPagamento(_idpagamento.Value);
            }
            else
            {
                this.Text = "Novo Pagamento";
            }
        }

        private void CarregarPagamento(int idpagamento)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT * FROM pagamento WHERE idpagamento = @id", conexao); // Corrigido para idpagamento
                    cmd.Parameters.AddWithValue("@id", idpagamento);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIdCliente.Text = reader["idcliente"].ToString();
                            txtCpfCnpj.Text = reader["cpf_cnpj"].ToString();
                            txtIdEstoque.Text = reader["idestoque"].ToString();
                            txtPrecoDeCompra.Text = reader["precodecompra"].ToString();
                            txtQuantidade.Text = reader["quantidade"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pagamento: {ex.Message}");
            }
        }
        private bool ValidarPagamentos()
        {
            // Validação do Nome do Pagamento
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                MessageBox.Show("Por favor, digite o ID do Cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdCliente.Focus();
                return false;
            }

            // Validação do Preço de Compra
            if (!decimal.TryParse(txtPrecoDeCompra.Text, out decimal precoCompra) || precoCompra <= 0)
            {
                MessageBox.Show("Por favor, digite um preço da compra válido (maior que zero).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecoDeCompra.Focus();
                return false;
            }

            // Validação do Preço de Venda
            if (!decimal.TryParse(txtPrecoDeCompra.Text, out decimal precoVenda) || precoVenda <= 0)
            {
                MessageBox.Show("Por favor, digite um preço da venda válido (maior que zero).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecoDeCompra.Focus();
                return false;
            }

            // Validação da Marca
            if (string.IsNullOrWhiteSpace(txtIdEstoque.Text))
            {
                MessageBox.Show("Por favor, digite o ID do Estoque.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdEstoque.Focus();
                return false;
            }

            // Validação da Quantidade
            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade < 0)
            {
                MessageBox.Show("Por favor, digite uma quantidade válida (número inteiro positivo).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantidade.Focus();
                return false;
            }

            return true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarPagamentos())
                return;

            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    using (var cmd = new MySqlCommand { Connection = conexao })
                    {
                        if (_idpagamento.HasValue)
                        {
                            // UPDATE
                            cmd.CommandText = @"UPDATE pagamento SET 
                                idcliente = @idcliente,
                                cpf_cnpj = @cpf_cnpj,
                                idestoque = @idestoque,
                                precodecompra = @precodecompra,
                                quantidade = @quantidade
                                WHERE idpagamento = @id";

                            cmd.Parameters.AddWithValue("@id", _idpagamento.Value);
                        }
                        else
                        {
                            // INSERT
                            cmd.CommandText = @"INSERT INTO pagamento(
                                idcliente, cpf_cnpj, idestoque, 
                                precodecompra, quantidade) 
                                VALUES (
                                @idcliente, @cpf_cnpj, @idestoque, 
                                @precodecompra, @quantidade)";
                        }

                        // Parâmetros comuns - CORRIGIDOS
                        cmd.Parameters.AddWithValue("@idcliente", int.Parse(txtIdCliente.Text.Trim()));
                        cmd.Parameters.AddWithValue("@cpf_cnpj", txtCpfCnpj.Text.Trim()); // Mantido como string
                        cmd.Parameters.AddWithValue("@idestoque", int.Parse(txtIdEstoque.Text.Trim()));
                        cmd.Parameters.AddWithValue("@precodecompra", decimal.Parse(txtPrecoDeCompra.Text));
                        cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text.Trim()));

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show(_idpagamento.HasValue
                                ? "Pagamento atualizado com sucesso!"
                                : "Pagamento cadastrado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum registro foi atualizado. Verifique se o ID existe.",
                                          "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro MySQL ({ex.Number}): {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class FormManager
        {
            // Versão sem parâmetros (para formulários que não precisam de argumentos)
            public static void ShowForm<T>() where T : Form, new()
            {
                ShowForm<T>(null);
            }

            // Versão com parâmetros (para formulários que precisam de argumentos)
            public static void ShowForm<T>(params object[] args) where T : Form
            {
                // Verifica se o formulário já está aberto
                var existingForm = Application.OpenForms.OfType<T>().FirstOrDefault();
                if (existingForm != null)
                {
                    existingForm.BringToFront();
                    return;
                }

                // Cria nova instância com ou sem parâmetros
                T form;
                if (args == null || args.Length == 0)
                {
                    form = Activator.CreateInstance<T>();
                }
                else
                {
                    form = (T)Activator.CreateInstance(typeof(T), args);
                }

                form.Show();
            }

            public static void CloseAllForms()
            {
                foreach (Form form in Application.OpenForms)
                {
                    form.Close();
                }

            }

        }

        private void pESQUISARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmPesquisar>();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroClientes>(idcliente);
        }

        private void visualisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarClientes>();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastrarEstoque>(idestoque);
        }

        private void visualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FormManager.ShowForm<frmVisualizarEstoque>(); FormManager.ShowForm<frmVisualizarEstoque>();
        }

        private void pAGAMENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroPagamento>();
        }

        private void visualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarPagamentos>();
        }
    }
}
        
