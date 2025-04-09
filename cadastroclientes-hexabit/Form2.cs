using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cadastroclientes_hexabit
{
    public partial class frmCadastrarEstoque: Form
    {
        public frmCadastrarEstoque()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
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


            //Exibir a informações na MessageBox

            MessageBox.Show("Nome do Produto:" + nomeProduto);
            MessageBox.Show("Preço de Compra:" + precoCompra);
            MessageBox.Show("Preço de Venda:" + precoVenda);
            MessageBox.Show("Marca:" + marca);
            MessageBox.Show("Quantidade:" + quantidade);



        }
    }
}
