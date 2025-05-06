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

        public frmCadastroPagamento() : this(null)
        {
        }

        public frmCadastroPagamento(int? idpagamento)
        {
            InitializeComponent();
            _idpagamento = idpagamento;
            cmbFormaPagamento.DropDownStyle = ComboBoxStyle.DropDownList;
            CarregarFormasPagamento();
            txtIdCliente.Enter += txtIdCliente_Enter;
            txtIdEstoque.Enter += txtIdEstoque_Enter;

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
        private void BuscarInfoEstoquePorId(int idEstoque)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT quantidade, precodecompra FROM estoque WHERE idestoque = @id", conexao);
                    cmd.Parameters.AddWithValue("@id", idEstoque);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Atualiza o preço de compra automaticamente
                            txtPrecoDeCompra.Text = reader["precodecompra"].ToString();

                            // Armazena a quantidade disponível para validação posterior
                            // Você pode mostrar essa informação em um label se quiser
                            int quantidadeDisponivel = Convert.ToInt32(reader["quantidade"]);
                            // Exemplo: lblQuantidadeDisponivel.Text = $"Disponível: {quantidadeDisponivel}";
                        }
                        else
                        {
                            txtPrecoDeCompra.Text = string.Empty;
                            MessageBox.Show("Estoque não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar estoque: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrecoDeCompra.Text = string.Empty;
            }
        }
        private int ObterQuantidadeDisponivelEstoque(int idEstoque)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT quantidade FROM estoque WHERE idestoque = @id", conexao);
                    cmd.Parameters.AddWithValue("@id", idEstoque);

                    var result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        private void BuscarCpfCnpjPorIdCliente(int idCliente)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT cpf_cnpj FROM cliente WHERE idcliente = @id", conexao);
                    cmd.Parameters.AddWithValue("@id", idCliente);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        txtCpfCnpj.Text = result.ToString();
                    }
                    else
                    {
                        txtCpfCnpj.Text = string.Empty;
                        MessageBox.Show("Cliente não encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar cliente: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCnpj.Text = string.Empty;
            }
        }
        private void CarregarFormasPagamento()
        {
            try
            {
                cmbFormaPagamento.Items.Clear();

                // Lista padrão de formas de pagamento
                var formasPadrao = new List<string> { "DINHEIRO", "CRÉDITO", "DÉBITO", "PIX" };

                // Adiciona as formas padrão
                cmbFormaPagamento.Items.AddRange(formasPadrao.ToArray());

                // Seleciona o primeiro item por padrão
                if (cmbFormaPagamento.Items.Count > 0)
                    cmbFormaPagamento.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formas de pagamento: {ex.Message}");
            }
        }

        private void CarregarPagamento(int idpagamento)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT * FROM pagamento WHERE idpagamento = @id", conexao);
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
                            string formaPagamento = reader["formadepagamento"].ToString();
                            if (!cmbFormaPagamento.Items.Contains(formaPagamento))
                            {
                                cmbFormaPagamento.Items.Add(formaPagamento);
                            }
                            cmbFormaPagamento.SelectedItem = formaPagamento;
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

            if (cmbFormaPagamento.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma forma de pagamento.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbFormaPagamento.Focus();
                return false;
            }

            // Validação do ID do Cliente
            if (string.IsNullOrWhiteSpace(txtIdCliente.Text) || !int.TryParse(txtIdCliente.Text, out _))
            {
                MessageBox.Show("Por favor, digite um ID de cliente válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdCliente.Focus();
                return false;
            }

            // Validação do CPF/CNPJ
            if (string.IsNullOrWhiteSpace(txtCpfCnpj.Text))
            {
                MessageBox.Show("Não foi possível encontrar o CPF/CNPJ do cliente. Verifique o ID.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdCliente.Focus();
                return false;
            }

            // Validação do ID do Estoque
            if (string.IsNullOrWhiteSpace(txtIdEstoque.Text) || !int.TryParse(txtIdEstoque.Text, out int idEstoque))
            {
                MessageBox.Show("Por favor, digite um ID de estoque válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIdEstoque.Focus();
                return false;
            }

            // Validação da Quantidade vs Estoque
            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Por favor, digite uma quantidade válida (número inteiro positivo).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantidade.Focus();
                return false;
            }

            int quantidadeDisponivel = ObterQuantidadeDisponivelEstoque(idEstoque);
            if (quantidade > quantidadeDisponivel)
            {
                MessageBox.Show($"Quantidade solicitada ({quantidade}) maior que disponível no estoque ({quantidadeDisponivel}).",
                              "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantidade.Focus();
                return false;
            }

            return true;
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarPagamentos())
                return;

            MySqlTransaction transaction = null;

            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    transaction = conexao.BeginTransaction();

                    using (var cmd = new MySqlCommand { Connection = conexao, Transaction = transaction })
                    {
                        int idEstoque = int.Parse(txtIdEstoque.Text);
                        int quantidade = int.Parse(txtQuantidade.Text);

                        if (_idpagamento.HasValue)
                        {
                            // UPDATE
                            cmd.CommandText = @"UPDATE pagamento SET 
                        idcliente = @idcliente,
                        cpf_cnpj = @cpf_cnpj,
                        idestoque = @idestoque,
                        precodecompra = @precodecompra,
                        quantidade = @quantidade,
                        formadepagamento = @formadepagamento
                        WHERE idpagamento = @id";

                            cmd.Parameters.AddWithValue("@id", _idpagamento.Value);
                        }
                        else
                        {
                            // INSERT do pagamento
                            cmd.CommandText = @"INSERT INTO pagamento(
                        idcliente, cpf_cnpj, idestoque, 
                        precodecompra, quantidade, formadepagamento) 
                        VALUES (
                        @idcliente, @cpf_cnpj, @idestoque, 
                        @precodecompra, @quantidade, @formadepagamento)";

                            // Parâmetros comuns
                            cmd.Parameters.AddWithValue("@idcliente", int.Parse(txtIdCliente.Text.Trim()));
                            cmd.Parameters.AddWithValue("@cpf_cnpj", txtCpfCnpj.Text.Trim());
                            cmd.Parameters.AddWithValue("@idestoque", int.Parse(txtIdEstoque.Text.Trim()));
                            cmd.Parameters.AddWithValue("@precodecompra", decimal.Parse(txtPrecoDeCompra.Text));
                            cmd.Parameters.AddWithValue("@quantidade", int.Parse(txtQuantidade.Text.Trim()));
                            cmd.Parameters.AddWithValue("@formadepagamento", cmbFormaPagamento.SelectedItem.ToString());

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
                            cmd.CommandText = "UPDATE estoque SET quantidade = quantidade - @quantidade WHERE idestoque = @idestoque";
                            cmd.Parameters.Clear();
                            cmd.Parameters.AddWithValue("@quantidade", quantidade);
                            cmd.Parameters.AddWithValue("@idestoque", idEstoque);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();

                        MessageBox.Show(_idpagamento.HasValue
                            ? "Pagamento atualizado e estoque ajustado com sucesso!"
                            : "Pagamento cadastrado e estoque atualizado com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
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
                transaction?.Rollback();
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class FormManager
        {
            private static List<Form> openForms = new List<Form>();

            public static void ShowForm<T>(params object[] args) where T : Form
            {
                var existingForm = openForms.FirstOrDefault(f => f is T);
                if (existingForm != null)
                {
                    existingForm.BringToFront();
                    return;
                }

                Form form;
                if (args == null || args.Length == 0)
                {
                    form = Activator.CreateInstance<T>();
                }
                else
                {
                    form = (T)Activator.CreateInstance(typeof(T), args);
                }

                form.FormClosed += (s, e) => openForms.Remove(form);
                openForms.Add(form);
                form.Show();
            }

            public static void CloseAllForms()
            {
                // Fecha na ordem inversa (filhos primeiro)
                for (int i = openForms.Count - 1; i >= 0; i--)
                {
                    var form = openForms[i];
                    if (!form.IsDisposed)
                    {
                        form.Close();
                        form.Dispose();
                    }
                }
                openForms.Clear();
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            _idpagamento = null;

            txtIdCliente.Text = string.Empty;
            txtCpfCnpj.Text = string.Empty;
            txtIdEstoque.Text = string.Empty;
            txtPrecoDeCompra.Text = string.Empty;
            txtQuantidade.Text = string.Empty;

            // Reseta o ComboBox
            if (cmbFormaPagamento.Items.Count > 0)
                cmbFormaPagamento.SelectedIndex = 0;

            txtIdCliente.Focus();
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

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                // Se já estiver maximizado, volta ao tamanho normal
                this.WindowState = FormWindowState.Normal;

                // Opcional: Altera o ícone para o de maximizar
                btnMaximizar.Text = "🗖"; // Ou altere a imagem se for um PictureBox
            }
            else
            {
                // Maximiza a janela
                this.WindowState = FormWindowState.Maximized;

                // Opcional: Altera o ícone para o de restaurar
                btnMaximizar.Text = "🗗"; // Ou altere a imagem se for um PictureBox
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            // Minimiza a janela para a barra de tarefas
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtIdCliente_Enter(object sender, EventArgs e)
        {
            {
                if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
                {
                    if (int.TryParse(txtIdCliente.Text, out int idCliente))
                    {
                        BuscarCpfCnpjPorIdCliente(idCliente);
                    }
                    else
                    {
                        txtCpfCnpj.Text = string.Empty;
                    }
                }
                else
                {
                    txtCpfCnpj.Text = string.Empty;
                }
            }
        }

        private void txtIdEstoque_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdEstoque.Text))
            {
                if (int.TryParse(txtIdEstoque.Text, out int idEstoque))
                {
                    BuscarInfoEstoquePorId(idEstoque);
                }
                else
                {
                    txtPrecoDeCompra.Text = string.Empty;
                }
            }
            else
            {
                txtPrecoDeCompra.Text = string.Empty;
            }
        }

        private void txtIdEstoque_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdEstoque.Text))
            {
                if (int.TryParse(txtIdEstoque.Text, out int idEstoque))
                {
                    BuscarInfoEstoquePorId(idEstoque);
                }
                else
                {
                    txtPrecoDeCompra.Text = string.Empty;
                }
            }
            else
            {
                txtPrecoDeCompra.Text = string.Empty;
            }
        }

        private void txtIdCliente_Leave(object sender, EventArgs e)
        {
            {
                if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
                {
                    if (int.TryParse(txtIdCliente.Text, out int idCliente))
                    {
                        BuscarCpfCnpjPorIdCliente(idCliente);
                    }
                    else
                    {
                        txtCpfCnpj.Text = string.Empty;
                    }
                }
                else
                {
                    txtCpfCnpj.Text = string.Empty;
                }
            }
        }
    }
}

