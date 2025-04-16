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

            lstPagamentos.Columns.Add("ID PEDIDO", 400, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("CPF/CNPJ", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("DATA", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("SITUAÇÃO", 200, HorizontalAlignment.Left);

            //Carrega os dados dos clientes na interface
            carregar_pagamentos();
        }
        private void carregar_pagamentos_com_query(string query)
        {
            try
            {
                conexao = new MySqlConnection(data_source);
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand(query, conexao);

                if (query.Contains("@q"))
                {
                    cmd.Parameters.AddWithValue("@q", "%" + txtBuscarPagamento.Text + "%");
                }

                MySqlDataReader reader = cmd.ExecuteReader();
                lstPagamentos.Items.Clear();

                while (reader.Read())
                {
                    // CORREÇÃO: Usar ToString() para converter os valores numéricos
                    string[] row =
                    {
                reader["ID PEDIDO"].ToString(),      
                reader["CPF/CNPJ"].ToString(),       
                reader["DATA"].ToString(),        
                reader["SITUAÇÂO"].ToString(),               
            };

                    lstPagamentos.Items.Add(new ListViewItem(row));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Erro {ex.Number} ocorreu: {ex.Message}",
                     "Erro",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu: {ex.Message}",
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
        private void carregar_pagamentos()
        {
            string query = "SELECT * FROM pagamento ORDER BY idpedido DESC ";
            carregar_pagamentos_com_query(query);

        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM estoque WHERE cpf_cnpj LIKE @q OR situação LIKE @q ORDER BY idpedido DESC ";
            carregar_pagamentos_com_query(query);
        }
    }
}