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
        private int _idPagamento;

        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";

        public frmVisualizarPagamentos(int idPagamento)
        {
            InitializeComponent();
            _idPagamento = idPagamento;
            carregar_pagamentos();


            // Configuração inicial da ListView para a exibição dos dados
            lstPagamentos.View = View.Details;
            lstPagamentos.LabelEdit = true;
            lstPagamentos.AllowColumnReorder = true;
            lstPagamentos.FullRowSelect = true;
            lstPagamentos.GridLines = true;


            //Definição das colunas da ListView

            lstPagamentos.Columns.Add("ID PEDIDO", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("CPF/CNPJ", 300, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("ID ESTOQUE", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("PREÇO DE COMPRA", 200, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("QUANTIDADE", 100, HorizontalAlignment.Left);
            lstPagamentos.Columns.Add("FORMA DE PAGAMENTO", 200, HorizontalAlignment.Center);
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

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Armazena o ID como Tag do item (não visível)
                        ListViewItem item = new ListViewItem(reader["idpedido"].ToString());
                        item.SubItems.Add(reader["cpf_cnpj"].ToString());
                        item.SubItems.Add(reader["idestoque"].ToString());
                        item.SubItems.Add(reader["precodecompra"].ToString());
                        item.SubItems.Add(reader["quantidade"].ToString());
                        item.SubItems.Add(reader["formadepagamento"].ToString());
                        item.SubItems.Add(reader["situacao"].ToString());
                        item.Tag = reader["idpedido"]; // Armazena o ID

                        lstPagamentos.Items.Add(item);
                    }
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
            try
            {
                if (lstPagamentos.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Selecione um pagamento primeiro!", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ListViewItem itemSelecionado = lstPagamentos.SelectedItems[0];

                // Obtém o ID diretamente do Tag (que você já armazenou)
                if (itemSelecionado.Tag == null || !int.TryParse(itemSelecionado.Tag.ToString(), out int idPagamento))
                {
                    MessageBox.Show("ID do pagamento inválido!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Abre o formulário de edição
                var formEdicao = new frmCadastroPagamento(idPagamento);
                formEdicao.ShowDialog();

                // Atualiza a lista
                carregar_pagamentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar pagamento: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}