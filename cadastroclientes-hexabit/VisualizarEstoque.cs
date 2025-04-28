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

            lstProdutos.Columns.Add("NOME DO PRODUTO", 400, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("PREÇO DE COMPRA", 200, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("PREÇO DE VENDA", 200, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("MARCA", 200, HorizontalAlignment.Left);
            lstProdutos.Columns.Add("QUANTIDADE", 100, HorizontalAlignment.Left);



            //Carrega os dados dos clientes na interface
            carregar_produtos();
        }
        private void carregar_produtos_com_query(string query)
        {
            try
            {
                lstProdutos.Items.Clear();

                using (conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conexao);

                    if (query.Contains("@q"))
                    {
                        cmd.Parameters.AddWithValue("@q", "%" + txtBuscarProduto.Text + "%");
                    }

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Armazena o ID como Tag do item (não visível)
                            ListViewItem item = new ListViewItem(reader["nomedoproduto"].ToString());
                            item.SubItems.Add(reader["precodecompra"].ToString());
                            item.SubItems.Add(reader["precodevenda"].ToString());
                            item.SubItems.Add(reader["marca"].ToString());
                            item.SubItems.Add(reader["quantidade"].ToString());
                            item.Tag = reader["idestoque"]; // Armazena o ID

                            lstProdutos.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}");
            }
        }
        private void carregar_produtos()
        {
            string query = "SELECT * FROM estoque ORDER BY idestoque DESC ";
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
            try
            {
                using (var conexao = new MySqlConnection(data_source))
                {
                    conexao.Open();

                    // Busca o ID do produto baseado no nome (ou outros campos únicos)
                    string query = "SELECT idestoque FROM estoque WHERE nomedoproduto = @nome LIMIT 1";
                    MySqlCommand cmd = new MySqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@nome", item.SubItems[0].Text);

                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
            catch
            {
                return -1;
            }
        }

    }
}