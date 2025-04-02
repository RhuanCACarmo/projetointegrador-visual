using System;
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

namespace cadastroclientes_hexabit
{
    public partial class frmCadastroClientes : Form
    {
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
        public frmCadastroClientes()
        {

            InitializeComponent();
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
        private void btnCadastar_Click(object sender, EventArgs e)
        {
            // Validação do Nome Completo
            if (string.IsNullOrWhiteSpace(txtNomeCompleto.Text))
            {
                MessageBox.Show("Por favor, digite o nome completo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNomeCompleto.Focus();
                return; 
            }

            // Validação do CPF/CNPJ (apenas se não está vazio)
            if (string.IsNullOrWhiteSpace(txtCpfCnpj.Text))
            {
                MessageBox.Show("Por favor, digite o CPF ou CNPJ.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCnpj.Focus();
                return;
            }

            // Remove caracteres não numéricos (como pontos, traços, barras)
            string cpfCnpjNumerico = new string(txtCpfCnpj.Text.Where(char.IsDigit).ToArray());

            // Verifica se o texto resultante contém apenas números e tem tamanho válido
            if (cpfCnpjNumerico.Length != 11 && cpfCnpjNumerico.Length != 14) // CPF = 11 dígitos, CNPJ = 14
            {
                MessageBox.Show("CPF deve ter 11 dígitos ou CNPJ deve ter 14 dígitos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCpfCnpj.Focus();
                return;
            }

            // Atualiza o campo com os números puros (opcional)
            txtCpfCnpj.Text = cpfCnpjNumerico;

            // Validação do CEP
            if (string.IsNullOrWhiteSpace(txtCep.Text))
            {
                MessageBox.Show("Por favor, digite o CEP.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCep.Focus();
                return; 
            }

            // Validação do Número (e converte para double)
            if (string.IsNullOrWhiteSpace(txtNumero.Text) || !double.TryParse(txtNumero.Text, out double numero))
            {
                MessageBox.Show("Por favor, digite um número de endereço válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNumero.Focus();
                return; 
            }
            // Se todas as validações passarem:
            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
}


