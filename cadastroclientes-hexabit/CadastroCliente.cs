﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text.Json;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Cryptography;
using System.CodeDom;

namespace cadastroclientes_hexabit
{
    public partial class frmCadastroClientes : Form
    {
        MySqlConnection conexao;
        private readonly string connectionString = "datasource=localhost;username=root;password=;database=hexabits";
        private int? _idcliente = null;

        public class EnderecoViaCEP
        {
            public string cep { get; set; }
            public string logradouro { get; set; }    // Rua
            public string complemento { get; set; }
            public string bairro { get; set; }
            public string localidade { get; set; }    // Cidade
            public string uf { get; set; }            // Estado (sigla)
            public string erro { get; set; }          // Indica se o CEP é inválido
        }
        public frmCadastroClientes(int? idcliente = null)
        {
            InitializeComponent();
            _idcliente = idcliente;

            if (_idcliente.HasValue)
            {
                carregar_cliente(_idcliente.Value);
                this.Text = "Editar Cliente"; // Altera título do form
            }
            else
            {
                this.Text = "Novo Cliente";
            }
        }

        private void carregar_cliente(int idcliente)
        {
            try
            {
                using (var conexao = new MySqlConnection(connectionString))
                {
                    conexao.Open();
                    var cmd = new MySqlCommand("SELECT * FROM cliente WHERE idcliente = @id", conexao);
                    cmd.Parameters.AddWithValue("@id", idcliente);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Preenche os campos com os dados do banco
                            txtNomeCompleto.Text = reader["nome"].ToString();
                            txtEmail.Text = reader["email"].ToString();
                            txtCpfCnpj.Text = reader["CPF/CNPJ"].ToString();

                            // ... outros campos
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}");
            }
        }

        private async void ConsultarCEP(string cep)
        {
           try
            {
                // Remove caracteres não numéricos
                cep = new string(cep.Where(char.IsDigit).ToArray());

                if (cep.Length != 8)
                {
                    MessageBox.Show("CEP deve conter 8 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (HttpClient client = new HttpClient())
                {
                    // Faz a requisição para a API ViaCEP
                    string url = $"https://viacep.com.br/ws/{cep}/json/";
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        EnderecoViaCEP endereco = JsonSerializer.Deserialize<EnderecoViaCEP>(json);

                        if (endereco.erro == "true")
                        {
                            MessageBox.Show("CEP não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Preenche os campos do formulário
                        txtRua.Text = endereco.logradouro;
                        txtBairro.Text = endereco.bairro;
                        txtCidade.Text = endereco.localidade;
                        txtComplemento.Text = endereco.complemento;
                        // txtEstado.Text = endereco.uf; // Se tiver um campo para o estado
                    }
                    else
                    {
                        MessageBox.Show("Falha ao consultar CEP. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           }
        private void txtCep_Leave(object sender, EventArgs e)
        {
            ConsultarCEP(txtCep.Text);
        }
        private void btnSalvar_Click(object sender, EventArgs e)


        { 
            try
            {
                // Validação do Nome Completo (obrigatório)
                if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text))
                {
                    MessageBox.Show("Por favor, digite o nome completo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNomeCompleto.Focus();
                    return;
                }

                // Validação do CPF/CNPJ (obrigatório e formato numérico)
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

                // Validação do CEP (obrigatório e formato) - AGORA ANTES DO NÚMERO
                if (string.IsNullOrWhiteSpace(txtCep.Text))
                {
                    MessageBox.Show("Por favor, digite o CEP.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCep.Focus();
                    return;
                }

                // Verifica se o CEP tem 8 dígitos (validação adicional)
                string cepNumerico = new string(txtCep.Text.Where(char.IsDigit).ToArray());
                if (cepNumerico.Length != 8)
                {
                    MessageBox.Show("CEP deve conter 8 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCep.Focus();
                    return;
                }

                // Validação do Número (obrigatório e numérico)
                if (string.IsNullOrWhiteSpace(txtNumero.Text) || !double.TryParse(txtNumero.Text, out double numero))
                {
                    MessageBox.Show("Por favor, digite um número de endereço válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNumero.Focus();
                    return;
                }

                // Validação do E-mail
                if (!txtEmail.Text.Contains("@") || !txtEmail.Text.Contains("."))
                {
                    MessageBox.Show("Digite um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //Validação do número de Telefone
                if (txtTelefone.Text.Length != 11)
                {
                    MessageBox.Show("O número de telefone deve haver 11 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTelefone.Focus();
                    return;
                }

                // Verifica se o Telefone tem 11 dígitos (validação adicional)
                string telefoneNumerico = new string(txtTelefone.Text.Where(char.IsDigit).ToArray());
                if (telefoneNumerico.Length != 11)
                {
                    MessageBox.Show("O telefone deve conter 11 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCep.Focus();
                    return;
                }

                //Validaçãõ de Rua
                if (string.IsNullOrEmpty(txtRua.Text))
                {
                    MessageBox.Show("Por favor, preencha o nome da rua.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRua.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtBairro.Text))
                {
                    MessageBox.Show("Por favor, preencha o nome do bairro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBairro.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtCidade.Text))
                {
                    MessageBox.Show("Por favor, preencha o nome da cidade.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCidade.Focus();
                    return;
                }

                //Conexão com o banco de dados
                conexao = new MySqlConnection(connectionString);
                conexao.Open();

                //Comando SQL para inserir um novo cliente no banco de dados 
                MySqlCommand cmd = new MySqlCommand
                {
                    Connection = conexao
                };
                cmd.Prepare();


                cmd.CommandText = "INSERT INTO cliente(cpf_cnpj,nome,email,telefone,complemento,numero,rua,bairro,cidade,cep) " +
                    "VALUES (@cpf_cnpj, @nome, @email,@telefone, @complemento, @numero, @rua, @bairro, @cidade, @cep)";



                cmd.Parameters.AddWithValue("@cpf_cnpj", txtCpfCnpj.Text.Trim());
                cmd.Parameters.AddWithValue("@nome", txtNomeCompleto.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text.Trim());
                cmd.Parameters.AddWithValue("@complemento", txtComplemento.Text.Trim());
                cmd.Parameters.AddWithValue("@numero", txtNumero.Text.Trim());
                cmd.Parameters.AddWithValue("@rua", txtRua.Text.Trim());
                cmd.Parameters.AddWithValue("@bairro", txtBairro.Text.Trim());
                cmd.Parameters.AddWithValue("@cidade", txtCidade.Text.Trim());
                cmd.Parameters.AddWithValue("@cep", txtCep.Text.Trim());


                cmd.ExecuteNonQuery();




                // Se todas as validações passarem:
                MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void eSTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarEstoque form2 = new frmCadastrarEstoque();
            form2.Show(); // Não modal
            // form2.ShowDialog(); // Modal
        }

        private void vISUALIZARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVisualizarClientes form4 = new frmVisualizarClientes();
            form4.Show();
        }

        private void gERARPAGAMENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGerarPagamento form3 = new frmGerarPagamento();
            form3.Show();
        }
    }



    // Aqui você pode salvar os dados no banco de dados ou fazer outras operações
    // Exemplo:
    // var cliente = new Cliente
    // {
    //     Nome = txtNomeCompleto.Text,
    //     Email = txtEmail.Text,
    //     CpfCnpj = txtCpfCnpj.Text,
    //     Telefone = txtTelefone.Text,
    //     Endereco = new Endereco
    //     {
    //         Cep = txtCep.Text,
    //         Rua = txtRua.Text,
    //         Numero = numeroRua, // Já convertido para double
    //         Bairro = txtBairro.Text,
    //         Complemento = txtComplemento.Text,
    //         Cidade = txtCidade.Text
    //     }
    // };
    // _clienteService.Cadastrar(cliente);
}




