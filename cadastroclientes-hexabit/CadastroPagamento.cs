using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using MySqlX.XDevAPI.Relational;
using Mysqlx.Resultset;


namespace cadastroclientes_hexabit
{
    public partial class frmGerarPagamento : Form
    {
        MySqlConnection Conexao;
        string data_source = "datasource =localhost; username=root;password=;database=hexabits";

        public frmGerarPagamento()
        {
            InitializeComponent();
        }

        private void btnGerarPagamento_Click(object sender, EventArgs e)
        {
            try
            {

                if 
                   (string.IsNullOrEmpty(txtPrecodeCompra.Text.Trim()) ||
                   string.IsNullOrEmpty(txtQuantidade.Text.Trim())) 
                  
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos.", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCpfCnpj.Text))
                {
                    MessageBox.Show("Por favor, digite o CPF ou CNPJ.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpfCnpj.Focus();
                    return;
                }

                string cpfCnpjNumerico = new string(txtCpfCnpj.Text.Where(char.IsDigit).ToArray());
                if (cpfCnpjNumerico.Length != 11 && cpfCnpjNumerico.Length != 14)
                {
                    MessageBox.Show("CPF deve ter 11 dígitos ou CNPJ deve ter 14 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCpfCnpj.Focus();
                    return;
                }
                txtCpfCnpj.Text = cpfCnpjNumerico;

                Conexao = new MySqlConnection(data_source);
                Conexao.Open();

                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = Conexao
                };

                cmd.Prepare();

                cmd.CommandText = "INSERT INTO pagamento(cpf_cnpj,precodecompra,quantidade)" +
                    "VALUES (@cpf_cnpj,@precodecompra,@quantidade)";

                cmd.Parameters.AddWithValue("@cpf_cnpj", txtCpfCnpj.Text.Trim());
             
                cmd.Parameters.AddWithValue("@precodecompra", txtPrecodeCompra.Text.Trim());
                cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text.Trim());
              

                cmd.ExecuteNonQuery();

                MessageBox.Show("Pagamento gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Erro" + ex.Number + "Ocorreu:" + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (Conexao != null && Conexao.State == ConnectionState.Open)
                {
                    Conexao.Close();
                }

            }
        }
    }
}
    
