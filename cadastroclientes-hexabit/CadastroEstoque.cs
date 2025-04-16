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
    public partial class frmCadastrarEstoque : Form
    {
        MySqlConnection conexao;
        string data_source = "datasource=localhost; username=root; password=; database=hexabits";


        public frmCadastrarEstoque()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string nomeProduto;
                double precoCompra;
                double precoVenda;
                string marca;
                int quantidade;


                if (string.IsNullOrWhiteSpace(txtNomeProduto.Text))
                {
                    MessageBox.Show("Por favor, preencha o nome do produto.", "Nome do Produto");
                    return;
                }

                if (!double.TryParse(txtPrecoCompra.Text, out double txtprecoCompra))
                {
                    MessageBox.Show("Por favor, insira o preço de compra.", "Preço de Compra");
                    return;
                }
                if (!double.TryParse(txtPrecoVenda.Text, out double txtprecoVenda))
                {
                    MessageBox.Show("Por favor, insira o preço de venda.", "Preço de Venda");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtMarca.Text))
                {
                    MessageBox.Show("Por favor, insira a marca do produto.", "Marca");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
                {
                    MessageBox.Show("Por favor, insira a quantidade do produto.", "Quantidade");
                    return;
                }

                //Continuação da validação

                nomeProduto = txtNomeProduto.Text;
                precoCompra = Convert.ToDouble(txtPrecoCompra.Text);
                precoVenda = Convert.ToDouble(txtPrecoVenda.Text);
                marca = txtMarca.Text;
                quantidade = Convert.ToInt32(txtQuantidade.Text);


               



                //Conexão com o banco de dados
                conexao = new MySqlConnection(data_source);
                conexao.Open();

                //Comando SQL para inserir um novo cliente no banco de dados 
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = conexao
                };
                cmd.Prepare();

                cmd.CommandText = "INSERT INTO estoque(nomedoproduto, precodecompra, precodevenda, quantidade,marca) " +
                    "VALUES (@nomedoproduto, @precodecompra, @precodevenda, @quantidade, @marca) ";


                cmd.Parameters.AddWithValue("@nomedoproduto", txtNomeProduto.Text.Trim());
                cmd.Parameters.AddWithValue("@precodecompra", txtPrecoCompra.Text.Trim());
                cmd.Parameters.AddWithValue("@precodevenda", txtPrecoVenda.Text.Trim());
                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text.Trim());
                cmd.Parameters.AddWithValue("@marca", txtMarca.Text.Trim());

                cmd.ExecuteNonQuery();


                MessageBox.Show("Produto cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro" + ex.Number + "Ocorreu:" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            finally
            {
                if (conexao != null && conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }

            }
        }

     
    






private void gerarPagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        { 
             
            frmGerarPagamento form3 = new frmGerarPagamento();
            form3.Show();
        }
    }
    
}
