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
using MySql.Data.MySqlClient;

namespace cadastroclientes_hexabit
{
    public partial class frmVisualizarPagamentos : Form
    {
        public int? idcliente { get; private set; }
        public int? idestoque { get; private set; }

        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";

        public frmVisualizarPagamentos()
        {
            InitializeComponent();


            // Configuração inicial da ListView
            lstPagamentos.View = View.Details;
            lstPagamentos.LabelEdit = true;
            lstPagamentos.AllowColumnReorder = true;
            lstPagamentos.FullRowSelect = true;
            lstPagamentos.GridLines = true;


            //Definição das colunas da ListView

            // Definição das colunas atualizadas
            lstPagamentos.Columns.Add("ID PAGAMENTO", 150, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("CLIENTE", 250, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("CPF/CNPJ", 150, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("PRODUTO", 250, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("PREÇO TOTAL", 150, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("QUANTIDADE", 100, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("FORMA PAGTO", 120, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("STATUS", 100, HorizontalAlignment.Left);


            //Carrega os dados dos clientes na interface
            carregar_pagamentos();
        }
        private void carregar_pagamentos_com_query(string query)
        {
            try
            {
                lstPagamentos.Items.Clear();

                using (conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    if (query.Contains("@q"))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + txtBuscarPagamento.Text + "%");
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["idpagamento"].ToString());
                            item.SubItems.Add(reader["nome_cliente"].ToString());
                            item.SubItems.Add(reader["cpf_cnpj"].ToString());
                            item.SubItems.Add(reader["nomedoproduto"].ToString());
                            item.SubItems.Add(reader["precodecompra"].ToString()); // Formato monetário
                            item.SubItems.Add(reader["quantidade"].ToString());
                            item.SubItems.Add(reader["formadepagamento"].ToString());
                            item.SubItems.Add(reader["situacao"].ToString());
                            item.Tag = reader["idpagamento"]; // Armazena o ID

                            lstPagamentos.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar pagamentos: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void carregar_pagamentos()
        {
            string query = @"SELECT p.idpagamento, 
                           c.nome AS nome_cliente, 
                           c.cpf_cnpj, 
                           e.nomedoproduto, 
                           p.precodecompra, 
                           p.quantidade,
                           p.formadepagamento,
                           p.situacao
                    FROM pagamento p
                    JOIN cliente c ON p.idcliente = c.idcliente
                    JOIN estoque e ON p.idestoque = e.idestoque
                    ORDER BY p.idpagamento DESC";

            carregar_pagamentos_com_query(query);
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {

            try
            {
                // Verifica se há itens selecionados
                if (lstPagamentos.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um produto primeiro!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pega o primeiro item selecionado
                ListViewItem itemSelecionado = lstPagamentos.SelectedItems[0];

                // Precisamos obter o ID do produto - precisamos modificcar o carregar_produtos para incluir o ID
                // Primeiro, precisamos buscar o ID do produto selecionado
                int idpagamento = ObterIdPagamentoSelecionado(itemSelecionado);

                if (idpagamento <= 0)
                {
                    MessageBox.Show("Não foi possível identificar o pagamento selecionado!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idestoque = ObterIdPagamentoSelecionado(itemSelecionado);

                if (idestoque <= 0)
                {
                    MessageBox.Show("Não foi possível identificar o produto selecionado!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abre o formulário de edição correto
                var formEdicao = new frmCadastroPagamento(idestoque);
                formEdicao.ShowDialog();
                formEdicao.ShowDialog();

                // Atualiza a lista após edição
                carregar_pagamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar pagamento: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObterIdPagamentoSelecionado(ListViewItem item)
        {
            if (item == null || item.Tag == null)
                return -1;

            return Convert.ToInt32(item.Tag);
        }

        private void btnDeletarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há itens selecionados
                if (lstPagamentos.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um pagamento primeiro!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pega o primeiro item selecionado
                ListViewItem itemSelecionado = lstPagamentos.SelectedItems[0];

                // Obtém o ID do pagamento a partir do Tag (que foi armazenado durante o carregamento)
                if (itemSelecionado.Tag == null || !int.TryParse(itemSelecionado.Tag.ToString(), out int idPagamento))
                {
                    MessageBox.Show("Não foi possível identificar o pagamento selecionado!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtém informações para exibir na confirmação
                string idCliente = itemSelecionado.SubItems[0].Text;
                string valorCompra = itemSelecionado.SubItems[3].Text;

                // Confirmação do usuário
                DialogResult confirmacao = MessageBox.Show(
                    $"Tem certeza que deseja excluir o pagamento do cliente {idCliente} no valor de {valorCompra}?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2); // Default no "Não" para prevenir exclusões acidentais

                if (confirmacao == DialogResult.Yes)
                {
                    using (var conexao = new MySqlConnection(data_source))
                    {
                        conexao.Open();

                        using (var transaction = conexao.BeginTransaction())
                        {
                            try
                            {
                                // Comando SQL para deletar o pagamento
                                using (var cmd = new MySqlCommand(
                                    "DELETE FROM pagamento WHERE idpagamento = @id",
                                    conexao, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@id", idPagamento);
                                    int linhasAfetadas = cmd.ExecuteNonQuery();

                                    if (linhasAfetadas > 0)
                                    {
                                        transaction.Commit();
                                        MessageBox.Show("Pagamento excluído com sucesso!", "Sucesso",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        carregar_pagamentos(); // Atualiza a lista
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Nenhum pagamento foi excluído.", "Aviso",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch
                            {
                                transaction.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                string mensagem = ex.Number == 1451 // Código de erro para violação de chave estrangeira
                    ? "Este pagamento não pode ser excluído porque possui registros vinculados."
                    : $"Erro MySQL ({ex.Number}): {ex.Message}";

                MessageBox.Show(mensagem, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir pagamento: {ex.Message}", "Erro",
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
            FormManager.ShowForm<frmCadastrarEstoque>(idestoque);
        }

        private void visualizarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarEstoque>(); FormManager.ShowForm<frmVisualizarEstoque>();
        }

        private void gerarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroPagamento>(idestoque);
        }

        private void visualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarPagamentos>();
        }

        private void txtBuscarPagamento_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string termoBusca = txtBuscarPagamento.Text.Trim();

                if (string.IsNullOrEmpty(termoBusca))
                {
                    carregar_pagamentos();
                    return;
                }

                string query = @"SELECT p.idpagamento, 
                               c.nome AS nome_cliente, 
                               c.cpf_cnpj, 
                               e.nomedoproduto, 
                               p.precodecompra, 
                               p.quantidade,
                               p.formadepagamento,
                               p.situacao
                        FROM pagamento p
                        JOIN cliente c ON p.idcliente = c.idcliente
                        JOIN estoque e ON p.idestoque = e.idestoque
                        WHERE c.nome LIKE @termo OR 
                              c.cpf_cnpj LIKE @termo OR
                              e.nomedoproduto LIKE @termo OR
                              p.idpagamento LIKE @termo
                        ORDER BY p.idpagamento DESC";

                carregar_pagamentos_com_query(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na busca: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}