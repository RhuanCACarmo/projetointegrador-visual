namespace cadastroclientes_hexabit
{
    partial class frmPesquisar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPesquisar));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVisualizarCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.estoqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCadastrarEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVisualizarEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGerarPagamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGerarPagamento = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVisualizarPagamentos = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnFecharPrograma = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAcessar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmLogin,
            this.clientesToolStripMenuItem,
            this.estoqueToolStripMenuItem,
            this.tsmGerarPagamentos});
            this.menuStrip1.Location = new System.Drawing.Point(214, 33);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1111, 47);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // tsmLogin
            // 
            this.tsmLogin.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmLogin.Name = "tsmLogin";
            this.tsmLogin.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.tsmLogin.Size = new System.Drawing.Size(244, 43);
            this.tsmLogin.Text = "LOGIN";
            this.tsmLogin.Click += new System.EventHandler(this.tsmPesquisar_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCadastroCliente,
            this.tsmVisualizarCliente});
            this.clientesToolStripMenuItem.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.clientesToolStripMenuItem.Text = "CLIENTES";
            // 
            // tsmCadastroCliente
            // 
            this.tsmCadastroCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.tsmCadastroCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmCadastroCliente.Name = "tsmCadastroCliente";
            this.tsmCadastroCliente.Size = new System.Drawing.Size(196, 44);
            this.tsmCadastroCliente.Text = "Cadastrar ";
            this.tsmCadastroCliente.Click += new System.EventHandler(this.tsmCadastroCliente_Click);
            // 
            // tsmVisualizarCliente
            // 
            this.tsmVisualizarCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.tsmVisualizarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmVisualizarCliente.Name = "tsmVisualizarCliente";
            this.tsmVisualizarCliente.Size = new System.Drawing.Size(196, 44);
            this.tsmVisualizarCliente.Text = "Visualizar";
            this.tsmVisualizarCliente.Click += new System.EventHandler(this.tsmVisualizarCliente_Click);
            // 
            // estoqueToolStripMenuItem
            // 
            this.estoqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCadastrarEstoque,
            this.tsmVisualizarEstoque});
            this.estoqueToolStripMenuItem.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.estoqueToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.estoqueToolStripMenuItem.Name = "estoqueToolStripMenuItem";
            this.estoqueToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.estoqueToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.estoqueToolStripMenuItem.Text = "ESTOQUE";
            // 
            // tsmCadastrarEstoque
            // 
            this.tsmCadastrarEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.tsmCadastrarEstoque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmCadastrarEstoque.Name = "tsmCadastrarEstoque";
            this.tsmCadastrarEstoque.Size = new System.Drawing.Size(191, 44);
            this.tsmCadastrarEstoque.Text = "Cadastrar";
            this.tsmCadastrarEstoque.Click += new System.EventHandler(this.tsmCadastrarEstoque_Click);
            // 
            // tsmVisualizarEstoque
            // 
            this.tsmVisualizarEstoque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.tsmVisualizarEstoque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmVisualizarEstoque.Name = "tsmVisualizarEstoque";
            this.tsmVisualizarEstoque.Size = new System.Drawing.Size(191, 44);
            this.tsmVisualizarEstoque.Text = "Visualizar";
            this.tsmVisualizarEstoque.Click += new System.EventHandler(this.tsmVisualizarEstoque_Click);
            // 
            // tsmGerarPagamentos
            // 
            this.tsmGerarPagamentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGerarPagamento,
            this.tsmVisualizarPagamentos});
            this.tsmGerarPagamentos.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmGerarPagamentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmGerarPagamentos.Name = "tsmGerarPagamentos";
            this.tsmGerarPagamentos.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.tsmGerarPagamentos.Size = new System.Drawing.Size(319, 43);
            this.tsmGerarPagamentos.Text = "PAGAMENTOS";
            // 
            // tsmGerarPagamento
            // 
            this.tsmGerarPagamento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.tsmGerarPagamento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmGerarPagamento.Name = "tsmGerarPagamento";
            this.tsmGerarPagamento.Size = new System.Drawing.Size(269, 44);
            this.tsmGerarPagamento.Text = "Gerar Pagamento";
            this.tsmGerarPagamento.Click += new System.EventHandler(this.tsmGerarPagamento_Click);
            // 
            // tsmVisualizarPagamentos
            // 
            this.tsmVisualizarPagamentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.tsmVisualizarPagamentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.tsmVisualizarPagamentos.Name = "tsmVisualizarPagamentos";
            this.tsmVisualizarPagamentos.Size = new System.Drawing.Size(269, 44);
            this.tsmVisualizarPagamentos.Text = "Visualizar";
            this.tsmVisualizarPagamentos.Click += new System.EventHandler(this.tsmVisualizarPagamentos_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(424, 166);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(754, 342);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(764, 535);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(71, 35);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "LOGIN";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Black;
            this.txtPesquisa.Location = new System.Drawing.Point(635, 586);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(329, 33);
            this.txtPesquisa.TabIndex = 4;
            this.txtPesquisa.Text = "Usuário";
            this.txtPesquisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFecharPrograma
            // 
            this.btnFecharPrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharPrograma.BackColor = System.Drawing.Color.DarkRed;
            this.btnFecharPrograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFecharPrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharPrograma.ForeColor = System.Drawing.Color.White;
            this.btnFecharPrograma.Location = new System.Drawing.Point(1558, 12);
            this.btnFecharPrograma.Name = "btnFecharPrograma";
            this.btnFecharPrograma.Size = new System.Drawing.Size(30, 12);
            this.btnFecharPrograma.TabIndex = 5;
            this.btnFecharPrograma.Text = "X";
            this.btnFecharPrograma.UseVisualStyleBackColor = false;
            this.btnFecharPrograma.Click += new System.EventHandler(this.btnFecharPrograma_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Orange;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(1486, 12);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 12);
            this.btnMinimizar.TabIndex = 7;
            this.btnMinimizar.Text = "X";
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaximizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximizar.ForeColor = System.Drawing.Color.White;
            this.btnMaximizar.Location = new System.Drawing.Point(1522, 12);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(30, 12);
            this.btnMaximizar.TabIndex = 8;
            this.btnMaximizar.Text = "X";
            this.btnMaximizar.UseVisualStyleBackColor = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(635, 625);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(329, 33);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Senha";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnAcessar
            // 
            this.btnAcessar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAcessar.BackColor = System.Drawing.Color.DimGray;
            this.btnAcessar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAcessar.Font = new System.Drawing.Font("Open Sans Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcessar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAcessar.Location = new System.Drawing.Point(701, 676);
            this.btnAcessar.Name = "btnAcessar";
            this.btnAcessar.Size = new System.Drawing.Size(192, 44);
            this.btnAcessar.TabIndex = 31;
            this.btnAcessar.Text = "ACESSAR";
            this.btnAcessar.UseVisualStyleBackColor = false;
            // 
            // frmPesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.btnAcessar);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnMaximizar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnFecharPrograma);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPesquisar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pesquisar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmLogin;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem tsmVisualizarCliente;
        private System.Windows.Forms.ToolStripMenuItem estoqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmCadastrarEstoque;
        private System.Windows.Forms.ToolStripMenuItem tsmVisualizarEstoque;
        private System.Windows.Forms.ToolStripMenuItem tsmGerarPagamentos;
        private System.Windows.Forms.ToolStripMenuItem tsmGerarPagamento;
        private System.Windows.Forms.ToolStripMenuItem tsmVisualizarPagamentos;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnFecharPrograma;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAcessar;
    }
}