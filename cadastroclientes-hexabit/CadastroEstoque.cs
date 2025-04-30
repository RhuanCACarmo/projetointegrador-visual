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
    public partial class frmCadastrarEstoque : Form
    {
        public int? idcliente { get; private set; }
       
        public int? idpagamento { get; private set; }

        private readonly string connectionString = "datasource=localhost;username=root;password=;database=hexabits";

        private int? _idestoque = null;

        public frmCadastrarEstoque(int? idestoque = null)
        {
            InitializeComponent();
            _idestoque = idestoque;

            if (_idestoque.HasValue)
            {
                this.Text = "Editar Produto";
                CarregarProduto(_idestoque.Value);
            }
            else
            {
                this.Text = "Novo Produto";
            }
        }

        private void CarregarProduto(int idestoque)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT * FROM estoque WHERE idestoque = @id", conexao);
                    cmd.Parameters.AddWithValue("@id", idestoque);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtNomeProduto.Text = reader["nomedoproduto"].ToString();
                            txtPrecoCompra.Text = reader["precodecompra"].ToString();
                            txtPrecoVenda.Text = reader["precodevenda"].ToString();
                            txtMarca.Text = reader["marca"].ToString();
                            txtQuantidade.Text = reader["quantidade"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}");
            }
        }

        private bool ValidarCampos()
        {
            // Validação do Nome do Produto
            if (string.IsNullOrWhiteSpace(txtNomeProduto.Text))
            {
                MessageBox.Show("Por favor, digite o nome do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeProduto.Focus();
                return false;
            }

            // Validação do Preço de Compra
            if (!decimal.TryParse(txtPrecoCompra.Text, out decimal precoCompra) || precoCompra <= 0)
            {
                MessageBox.Show("Por favor, digite um preço de compra válido (maior que zero).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecoCompra.Focus();
                return false;
            }

            // Validação do Preço de Venda
            if (!decimal.TryParse(txtPrecoVenda.Text, out decimal precoVenda) || precoVenda <= 0)
            {
                MessageBox.Show("Por favor, digite um preço de venda válido (maior que zero).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecoVenda.Focus();
                return false;
            }

            // Validação se preço de venda é maior que preço de compra
            if (precoVenda < precoCompra)
            {
                MessageBox.Show("O preço de venda deve ser maior ou igual ao preço de compra.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecoVenda.Focus();
                return false;
            }

            // Validação da Marca
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Por favor, digite a marca do produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMarca.Focus();
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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    using (var cmd = new MySqlCommand { Connection = conexao })
                    {
                        if (_idestoque.HasValue)
                        {
                            // UPDATE
                            cmd.CommandText = @"UPDATE estoque SET 
                                        nomedoproduto = @nome,
                                        precodecompra = @precoCompra,
                                        precodevenda = @precoVenda,
                                        marca = @marca,
                                        quantidade = @quantidade
                                        WHERE idestoque = @id";

                            cmd.Parameters.AddWithValue("@id", _idestoque.Value);
                        }
                        else
                        {
                            // INSERT
                            cmd.CommandText = @"INSERT INTO estoque(
                                        nomedoproduto, precodecompra, precodevenda, 
                                        marca, quantidade) 
                                        VALUES (
                                        @nome, @precoCompra, @precoVenda, 
                                        @marca, @quantidade)";
                        }

                        // Parâmetros comuns
                        cmd.Parameters.AddWithValue("@nome", txtNomeProduto.Text.Trim());
                        cmd.Parameters.AddWithValue("@precoCompra", decimal.Parse(txtPrecoCompra.Text));
                        cmd.Parameters.AddWithValue("@precoVenda", decimal.Parse(txtPrecoVenda.Text));
                        cmd.Parameters.AddWithValue("@marca", txtMarca.Text.Trim());
                        cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text));

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show(_idestoque.HasValue
                                ? "Produto atualizado com sucesso!"
                                : "Produto cadastrado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close();
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

        private void txtPrecoCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números, vírgula e backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Permite apenas uma vírgula
            if (e.KeyChar == ',' && (sender as TextBox).Text.IndexOf(',') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPrecoCompra_KeyPress(sender, e); // Reutiliza a mesma validação
        }

        private void txtQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       

        private void btnFecharPrograma_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPrecoCompra_TextChanged(object sender, EventArgs e)
        {
            // Calcula o preço de venda automaticamente quando o preço de compra é alterado
            if (decimal.TryParse(txtPrecoCompra.Text, out decimal precoCompra) && precoCompra > 0)
            {
                decimal precoVenda = precoCompra * 1.32m; // Aplica 32% de lucro
                txtPrecoVenda.Text = precoVenda.ToString("N2"); // Formata com 2 casas decimais
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

        private void pesquisarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmPesquisar>();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroClientes>(idcliente);
        }

        private void visualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            FormManager.ShowForm<frmVisualizarClientes>();
        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastrarEstoque>();

        }

        private void visualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarEstoque>(); FormManager.ShowForm<frmVisualizarEstoque>();
        }

        private void gerarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroPagamento>(idpagamento);

        }

        private void visualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarPagamentos>();
        }
    }
}