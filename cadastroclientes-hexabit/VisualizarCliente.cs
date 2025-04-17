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

            lstClientes.Columns.Add("ID CLIENTE", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("CPF/CNPJ", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("NOME", 300, HorizontalAlignment.Left);
            lstClientes.Columns.Add("EMAIL", 300, HorizontalAlignment.Left);
            lstClientes.Columns.Add("TELEFONE", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("ENDEREÇO", 400, HorizontalAlignment.Left);



            //Carrega os dados dos clientes na interface
            carregar_clientes();


        }
        private void carregar_clientes_com_query(string query)
        {
            try
            {
                conexao = new MySqlConnection(data_source);
                conexao.Open();


                //Executa a consulta SQL fornecida

                MySqlCommand cmd = new MySqlCommand(query, conexao);

                //Se a consulta contém o parâmetro @q, adiciona o valor da caixa de pesquisa
                if (query.Contains("@q"))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + txtBuscarCliente.Text + "%");
                }

                //Executa o comando e obtém os resultados
                MySqlDataReader reader = cmd.ExecuteReader();


                //Limpar os itens existentes no ListView
                lstClientes.Items.Clear();


                //Preenche o ListView com os dados dos clientes
                while (reader.Read())
                {
                    string[] row =
                    {
                        Convert.ToString(reader.GetInt64(0)),
                        Convert.ToString(reader.GetInt64(1)),
                        reader.GetString(2),
                        reader.GetString(3),
                        reader.GetString(4),
                        reader.GetString(7)
                    };

                    lstClientes.Items.Add(new ListViewItem(row));

                }


            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Erro" + ex.Number + "ocorreu:" + ex.Message,
                     "Erro",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu:" + ex.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            finally
            {
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
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
    }
}