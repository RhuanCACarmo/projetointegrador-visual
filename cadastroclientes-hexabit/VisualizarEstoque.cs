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
    public partial class frmVisualizarEstoque : Form
    {
        public int? idcliente { get; private set; }

        public int? idpagamento { get; private set; }

        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";

        public frmVisualizarEstoque()
        {
            InitializeComponent();


            // Configuração inicial da ListView para a exibição dos dados
            lstProdutos.View = View.Details;
            lstProdutos.LabelEdit = true;
            lstProdutos.AllowColumnReorder = true;
            lstProdutos.FullRowSelect = true;
            lstProdutos.GridLines = true;


            //Definição das colunas da ListView

            lstProdutos.Columns.Add("ID ESTOQUE", 120, HorizontalAlignment.Left); // Adicionei coluna ID
            lstProdutos.Columns.Add("NOME DO PRODUTO", 300, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("PREÇO DE COMPRA", 150, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("PREÇO DE VENDA", 150, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("MARCA", 150, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("QUANTIDADE", 120, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("VALOR TOTAL", 150, HorizontalAlignment.Left); // NOVA COLUNA

            carregar_produtos();
        }

        private void carregar_produtos_com_query(string query, string termoBusca = null)
        {
            try
            {
                lstProdutos.Items.Clear();

                using (conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    if (termoBusca != null)
                    {
                        cmd.Parameters.AddWithValue("@termo", "%" + termoBusca + "%");
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Obter valores importantes
                            decimal precoVenda = reader["precodevenda"] != DBNull.Value ?
                                               Convert.ToDecimal(reader["precodevenda"]) : 0;
                            int quantidade = reader["quantidade"] != DBNull.Value ?
                                            Convert.ToInt32(reader["quantidade"]) : 0;
                            decimal valorTotal = precoVenda * quantidade;

                            ListViewItem item = new ListViewItem(reader["idestoque"].ToString()); // ID
                            item.SubItems.Add(reader["nomedoproduto"].ToString());
                            item.SubItems.Add(Convert.ToDecimal(reader["precodecompra"]).ToString("C"));
                            item.SubItems.Add(precoVenda.ToString("C"));
                            item.SubItems.Add(reader["marca"].ToString());
                            item.SubItems.Add(quantidade.ToString());
                            item.SubItems.Add(valorTotal.ToString("C")); // VALOR TOTAL
                            item.Tag = reader["idestoque"];

                            lstProdutos.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void carregar_produtos()
        {
            string query = "SELECT * FROM estoque ORDER BY idestoque DESC";
            carregar_produtos_com_query(query);
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há itens selecionados
                if (lstProdutos.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um produto primeiro!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pega o primeiro item selecionado
                ListViewItem itemSelecionado = lstProdutos.SelectedItems[0];

                // Precisamos obter o ID do produto - precisamos modificcar o carregar_produtos para incluir o ID
                // Primeiro, precisamos buscar o ID do produto selecionado
                int idProduto = ObterIdProdutoSelecionado(itemSelecionado);

                if (idProduto <= 0)
                {
                    MessageBox.Show("Não foi possível identificar o produto selecionado!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abre o formulário de edição correto
                var formEdicao = new frmCadastrarEstoque(idProduto);
                formEdicao.ShowDialog();

                // Atualiza a lista após edição
                carregar_produtos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar estoque: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int ObterIdProdutoSelecionado(ListViewItem item)
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
                if (lstProdutos.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um produto primeiro!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pega o primeiro item selecionado
                ListViewItem itemSelecionado = lstProdutos.SelectedItems[0];

                // Obtém o ID do produto a partir do Tag (que foi armazenado durante o carregamento)
                if (itemSelecionado.Tag == null || !int.TryParse(itemSelecionado.Tag.ToString(), out int idProduto))
                {
                    MessageBox.Show("Não foi possível identificar o produto selecionado!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtém informações para exibir na confirmação
                string nomeProduto = itemSelecionado.SubItems[0].Text;
                string marca = itemSelecionado.SubItems[3].Text;

                // Confirmação do usuário
                DialogResult confirmacao = MessageBox.Show(
                    $"Tem certeza que deseja excluir o produto:\n\n" +
                    $"Nome: {nomeProduto}\n" +
                    $"Marca: {marca}\n\n" +
                    "Esta ação não poderá ser desfeita!",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
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
                                // 1. Verifica se o produto está vinculado a algum pagamento
                                using (var cmdVerifica = new MySqlCommand(
                                    "SELECT COUNT(*) FROM pagamento WHERE idestoque = @id",
                                    conexao, transaction))
                                {
                                    cmdVerifica.Parameters.AddWithValue("@id", idProduto);
                                    int registrosVinculados = Convert.ToInt32(cmdVerifica.ExecuteScalar());

                                    if (registrosVinculados > 0)
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Este produto não pode ser excluído porque está vinculado a pagamentos existentes.",
                                                      "Erro",
                                                      MessageBoxButtons.OK,
                                                      MessageBoxIcon.Error);
                                        return;
                                    }
                                }

                                // 2. Comando SQL para deletar o produto
                                using (var cmdDeletar = new MySqlCommand(
                                    "DELETE FROM estoque WHERE idestoque = @id",
                                    conexao, transaction))
                                {
                                    cmdDeletar.Parameters.AddWithValue("@id", idProduto);
                                    int linhasAfetadas = cmdDeletar.ExecuteNonQuery();

                                    if (linhasAfetadas > 0)
                                    {
                                        transaction.Commit();
                                        MessageBox.Show("Produto excluído com sucesso!", "Sucesso",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        carregar_produtos(); // Atualiza a lista
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                        MessageBox.Show("Nenhum produto foi excluído.", "Aviso",
                                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Erro ao excluir produto: {ex.Message}", "Erro",
                                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtBuscarProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string termoBusca = txtBuscarProduto.Text.Trim();

                if (string.IsNullOrEmpty(termoBusca))
                {
                    carregar_produtos();
                    return;
                }

                string query = @"SELECT * FROM estoque 
                       WHERE nomedoproduto LIKE @termo OR
                             marca LIKE @termo OR
                             precodecompra LIKE @termo OR
                             precodevenda LIKE @termo
                       ORDER BY nomedoproduto ASC";

                carregar_produtos_com_query(query, termoBusca);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na busca: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarProduto_Click(object sender, EventArgs e)
        {
            txtBuscarProduto.Text = string.Empty;

            txtBuscarProduto.Focus();

            carregar_produtos();
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
    }
}