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

        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";

        public frmVisualizarPagamentos()
        {
            InitializeComponent();


            // Configuração inicial da ListView para a exibição dos dados
            lstPagamentos.View = View.Details;
            lstPagamentos.LabelEdit = true;
            lstPagamentos.AllowColumnReorder = true;
            lstPagamentos.FullRowSelect = true;
            lstPagamentos.GridLines = true;


            //Definição das colunas da ListView

            lstPagamentos.Columns.Add("ID DE CLIENTE", 400, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("CPF/CNPJ", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("ID DE ESTOQUE", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("PREÇO DA COMPRA", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("QUANTIDADE", 100, HorizontalAlignment.Left);



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
                            // Armazena o ID como Tag do item (não visível)
                            ListViewItem item = new ListViewItem(reader["idcliente"].ToString());
                            item.SubItems.Add(reader["cpf_cnpj"].ToString());
                            item.SubItems.Add(reader["idestoque"].ToString());
                            item.SubItems.Add(reader["precodecompra"].ToString());
                            item.SubItems.Add(reader["quantidade"].ToString());
                            item.Tag = reader["idpagamento"]; // Armazena o ID

                            lstPagamentos.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
        private void carregar_pagamentos()
        {
            string query = "SELECT * FROM pagamento ORDER BY idpagamento DESC ";
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
            try
            {
                using (var conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    // Busca o ID do pagamento baseado no CPF/CNPJ (ou outros campos únicos)
                    string query = "SELECT idpagamento FROM pagamento WHERE idcliente = @idcliente LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@idcliente", item.SubItems[0].Text);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
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
    }
}
