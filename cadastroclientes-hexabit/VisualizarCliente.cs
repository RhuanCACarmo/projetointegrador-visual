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

    public partial class frmVisualizarClientes : Form
    {
        public int? idestoque { get; private set; }
        public int? idpagamento { get; private set; }


        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";

        private int? idcliente = null;

        public frmVisualizarClientes()
        {
            InitializeComponent();

            // Configuração inicial da ListView para a exibição dos dados
            lstClientes.View = View.Details;
            lstClientes.LabelEdit = true;
            lstClientes.AllowColumnReorder = true;
            lstClientes.FullRowSelect = true;
            lstClientes.GridLines = true;


            //Definição das colunas da ListView

            lstClientes.Columns.Add("ID CLIENTE", 100, HorizontalAlignment.Left);
            lstClientes.Columns.Add("CPF/CNPJ", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("NOME", 300, HorizontalAlignment.Left);
            lstClientes.Columns.Add("EMAIL", 300, HorizontalAlignment.Left);
            lstClientes.Columns.Add("TELEFONE", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("ENDEREÇO", 200, HorizontalAlignment.Left);



            //Carrega os dados dos clientes na interface
            carregar_clientes();


        }
        private void carregar_clientes_com_query(string query, MySqlParameter parameter = null)
        {
            try
            {
                using (conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    // Adiciona o parâmetro se existir
                    if (parameter != null)
                    {
                        cmd.Parameters.Add(parameter);
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        lstClientes.Items.Clear();

                        while (reader.Read())
                        {
                            string[] row =
                            {
                        reader.GetInt64(0).ToString(),
                        reader.GetInt64(1).ToString(),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(7) // Assumindo que endereço está na posição 7
                    };
                            lstClientes.Items.Add(new ListViewItem(row));
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

        private void carregar_clientes()
        {
            string query = "SELECT * FROM cliente  ORDER BY cpf_cnpj DESC ";
            carregar_clientes_com_query(query);

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            conexao = new MySqlConnection(data_source);
            conexao.Open();

            //MessageBox.Show("Conexão aberta com sucesso.");

            //Comando SQL para inserir um novo cliente no banco de dados
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = conexao
            };

            cmd.Prepare();

            {
                try
                {
                    // Verifica se há itens selecionados
                    if (lstClientes.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Selecione um cliente primeiro!", "Aviso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Pega o primeiro item selecionado
                    ListViewItem itemSelecionado = lstClientes.SelectedItems[0];

                    // Verifica se há subitens suficientes
                    if (itemSelecionado.SubItems.Count < 1)
                    {
                        MessageBox.Show("Dados do cliente incompletos!", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Conversão segura do ID do cliente
                    if (!int.TryParse(itemSelecionado.SubItems[0].Text, out int idcliente))
                    {
                        MessageBox.Show("ID do cliente inválido!", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Agora você pode usar o idCliente com segurança
                    var formCadastro = new frmCadastroClientes(idcliente);
                    formCadastro.ShowDialog();

                    // Atualiza a lista após edição
                    carregar_clientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao editar cliente: {ex.Message}", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnDeletarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Verifica se há itens selecionados
                if (lstClientes.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um cliente primeiro!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Pega o primeiro item selecionado
                ListViewItem itemSelecionado = lstClientes.SelectedItems[0];

                // Verifica se há subitens suficientes
                if (itemSelecionado.SubItems.Count < 1)
                {
                    MessageBox.Show("Dados do cliente incompletos!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Conversão segura do ID do cliente
                if (!int.TryParse(itemSelecionado.SubItems[0].Text, out int idcliente))
                {
                    MessageBox.Show("ID do cliente inválido!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Confirmação do usuário
                DialogResult confirmacao = MessageBox.Show(
                    $"Tem certeza que deseja excluir o cliente {itemSelecionado.SubItems[2].Text}?",
                    "Confirmar Exclusão",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmacao == DialogResult.Yes)
                {
                    using (var conexao = new MySqlConnection(data_source))
                    {
                        conexao.Open();

                        // Comando SQL para deletar o cliente
                        using (var cmd = new MySqlCommand(
                            "DELETE FROM cliente WHERE idcliente = @id",
                            conexao))
                        {
                            cmd.Parameters.AddWithValue("@id", idcliente);
                            int linhasAfetadas = cmd.ExecuteNonQuery();

                            if (linhasAfetadas > 0)
                            {
                                MessageBox.Show("Cliente excluído com sucesso!", "Sucesso",
                                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                                carregar_clientes(); // Atualiza a lista
                            }
                            else
                            {
                                MessageBox.Show("Nenhum cliente foi excluído.", "Aviso",
                                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                string mensagem = ex.Number == 1451 // Código de erro para violação de chave estrangeira
                    ? "Este cliente não pode ser excluído porque possui registros vinculados."
                    : $"Erro MySQL ({ex.Number}): {ex.Message}";

                MessageBox.Show(mensagem, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir cliente: {ex.Message}", "Erro",
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
            FormManager.ShowForm<frmVisualizarEstoque>();
        }

        private void gerarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmCadastroPagamento>(idpagamento);
        }

        private void visualizarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmVisualizarPagamentos>();
        }

        private void btnFecharPrograma_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
{
    try
    {
        string termoBusca = txtBuscarCliente.Text.Trim();
        
        // Se o campo estiver vazio, carrega todos os clientes
        if (string.IsNullOrEmpty(termoBusca))
        {
            carregar_clientes();
            return;
        }

        // Conexão com o banco de dados
        using (MySqlConnection conexao = new MySqlConnection(data_source))
        {
            conexao.Open();
            
            // Query SQL para buscar por nome ou CPF/CNPJ
            string query = @"SELECT * FROM cliente 
                           WHERE nome LIKE @termo OR 
                                 cpf_cnpj LIKE @termo OR
                                 email LIKE @termo OR
                                telefone LIKE @termo OR
                                rua LIKE @termo
                           ORDER BY nome ASC";
            
            MySqlCommand cmd = new MySqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("@termo", "%" + termoBusca + "%");

            // Executa a consulta
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                lstClientes.Items.Clear();
                
                // Preenche o ListView com os resultados
                while (reader.Read())
                {
                    string[] row =
                    {
                        reader["idcliente"].ToString(),
                        reader["cpf_cnpj"].ToString(),
                        reader["nome"].ToString(),
                        reader["email"].ToString(),
                        reader["telefone"].ToString(),
                        reader["rua"].ToString()
                    };
                    lstClientes.Items.Add(new ListViewItem(row));
                }
            }
        }
    }
    catch (MySqlException ex)
    {
        MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro", 
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Erro: {ex.Message}", "Erro",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
    }
}


      