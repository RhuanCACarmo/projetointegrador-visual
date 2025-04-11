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
    public partial class frmVisualizarClientes: Form
    {
        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";


        public frmVisualizarClientes()
        {
            InitializeComponent();

            // Configuração inicial da ListView para a exib~ição dos dados
            lstClientes.View = View.Details;
            lstClientes.LabelEdit = true;
            lstClientes.AllowColumnReorder = true;
            lstClientes.FullRowSelect = true;
            lstClientes.GridLines = true;


            //Definição das colunas da ListView

            lstClientes.Columns.Add("CPF/CNPJ", 100, HorizontalAlignment.Left);
            lstClientes.Columns.Add("NOME", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("TELEFONE", 200, HorizontalAlignment.Left);
            lstClientes.Columns.Add("EMAIL", 200, HorizontalAlignment.Left);


            //Carrega os dados dos clientes na interface
            carregar_clientes();


        }
        private void carregar_clientes_com_query (string query)
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
                        Convert.ToString(reader.GetInt32(0)),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)
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
            string query = "SELECT * FROM cadastroclientes ORDER BY cpf/cnpj DESC";
            carregar_clientes_com_query(query);
        }




        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM cadastroclientes WHERE nome LIKE @q OR email LIKE @q ORDER BY cpf/cnpj DESC ";
            carregar_clientes_com_query(query);
        }
    }
}
