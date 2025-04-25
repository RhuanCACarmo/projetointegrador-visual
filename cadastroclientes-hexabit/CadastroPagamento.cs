using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace cadastroclientes_hexabit
{
    public partial class frmCadastroPagamento : Form
    {
        private readonly string connectionString = "datasource=localhost;username=root;password=;database=hexabits";
        private int? _idPagamento = null;
        private MySqlConnection conexao;

        public frmCadastroPagamento(int? idPagamento = null)
        {
            InitializeComponent();
            _idPagamento = idPagamento;

            if (_idPagamento.HasValue)
            {
                this.Text = "Editar Pagamento";
                CarregarPagamento(_idPagamento.Value);
            }
            else
            {
                this.Text = "Novo Pagamento";
            }
        }

        private void CarregarPagamento(int idPagamento)
        {
            try
            {
                using (conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    string query = @"SELECT p.*, c.nome as nome_cliente, e.nomedoproduto 
                                   FROM pagamento p
                                   JOIN cliente c ON p.idcliente = c.idcliente
                                   JOIN estoque e ON p.idestoque = e.idestoque
                                   WHERE p.idpedido = @id";

                    var cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@id", idPagamento);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtIdCliente.Text = reader["idcliente"].ToString();
                            txtCpfCnpj.Text = reader["cpf_cnpj"].ToString();
                            txtIdEstoque.Text = reader["idestoque"].ToString();
                            txtPrecoDeCompra.Text = reader["precodecompra"].ToString();
                            txtQuantidade.Text = reader["quantidade"].ToString();
                            cmbFormaPagamento.SelectedItem = reader["formadepagamento"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pagamento: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validações básicas
                if (string.IsNullOrWhiteSpace(txtIdCliente.Text) || !int.TryParse(txtIdCliente.Text, out int idCliente))
                {
                    MessageBox.Show("ID do cliente inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCpfCnpj.Text))
                {
                    MessageBox.Show("CPF/CNPJ é obrigatório.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtIdEstoque.Text) || !int.TryParse(txtIdEstoque.Text, out int idEstoque))
                {
                    MessageBox.Show("ID do estoque inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPrecoDeCompra.Text) || !decimal.TryParse(txtPrecoDeCompra.Text, out decimal preco))
                {
                    MessageBox.Show("Preço de compra inválido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantidade.Text) || !int.TryParse(txtQuantidade.Text, out int quantidade))
                {
                    MessageBox.Show("Quantidade inválida.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cmbFormaPagamento.SelectedItem == null)
                {
                    MessageBox.Show("Selecione a forma de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                using (conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();

                    // Verifica se o cliente existe
                    if (!ClienteExiste(idCliente))
                    {
                        MessageBox.Show("Cliente não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Verifica se o item do estoque existe
                    if (!EstoqueExiste(idEstoque))
                    {
                        MessageBox.Show("Item do estoque não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Comando principal (INSERT ou UPDATE)
                    using (var cmd = new MySqlCommand { Connection = conexao })
                    {
                        if (_idPagamento.HasValue)
                        {
                            // UPDATE
                            cmd.CommandText = @"UPDATE pagamento SET 
                                        idcliente = @idcliente,
                                        cpf_cnpj = @cpf_cnpj,
                                        idestoque = @idestoque,
                                        precodecompra = @precodecompra,
                                        quantidade = @quantidade,
                                        formadepagamento = @formadepagamento,
                                        situacao = @situacao
                                        WHERE idpedido = @id";

                            cmd.Parameters.AddWithValue("@id", _idPagamento.Value);
                        }
                        else
                        {
                            // INSERT
                            cmd.CommandText = @"INSERT INTO pagamento(
                                        idcliente, cpf_cnpj, idestoque, precodecompra, 
                                        quantidade, formadepagamento, situacao) 
                                        VALUES (
                                        @idcliente, @cpf_cnpj, @idestoque, @precodecompra, 
                                        @quantidade, @formadepagamento, @situacao)";
                        }

                        // Parâmetros comuns
                        cmd.Parameters.AddWithValue("@idcliente", idCliente);
                        cmd.Parameters.AddWithValue("@cpf_cnpj", txtCpfCnpj.Text.Trim());
                        cmd.Parameters.AddWithValue("@idestoque", idEstoque);
                        cmd.Parameters.AddWithValue("@precodecompra", preco);
                        cmd.Parameters.AddWithValue("@quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@formadepagamento", cmbFormaPagamento.SelectedItem.ToString());

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show(_idPagamento.HasValue
                                ? "Pagamento atualizado com sucesso!"
                                : "Pagamento cadastrado com sucesso!",
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

        private bool ClienteExiste(int idCliente)
        {
            string query = "SELECT COUNT(*) FROM cliente WHERE idcliente = @id";
            var cmd = new MySqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("@id", idCliente);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private bool EstoqueExiste(int idEstoque)
        {
            string query = "SELECT COUNT(*) FROM estoque WHERE idestoque = @id";
            var cmd = new MySqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("@id", idEstoque);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            var formBusca = new frmVisualizarClientes();
            if (formBusca.ShowDialog() == DialogResult.OK)
            {
                txtIdCliente.Text = formBusca.ClienteSelecionado.Id.ToString();
                txtCpfCnpj.Text = formBusca.ClienteSelecionado.CpfCnpj;
            }
        }

        private void btnBuscarProduto_Click(object sender, EventArgs e)
        {
            var formBusca = new frmVisualizarClientes();
            if (formBusca.ShowDialog() == DialogResult.OK)
            {
                txtIdEstoque.Text = formBusca.ProdutoSelecionado.Id.ToString();
                txtPrecoDeCompra.Text = formBusca.ProdutoSelecionado.PrecoVenda.ToString();
            }
        }
    }
}