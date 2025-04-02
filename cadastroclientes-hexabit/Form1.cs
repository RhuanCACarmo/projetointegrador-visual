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
            if(string.IsNullOrEmpty(txtBairro.Text))
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

            // Se todas as validações passarem:
            MessageBox.Show("Cliente cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Aqui você pode adicionar a lógica para salvar no banco de dados
        }

        private void eSTOQUEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show(); // Não modal
            // form2.ShowDialog(); // Modal
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


