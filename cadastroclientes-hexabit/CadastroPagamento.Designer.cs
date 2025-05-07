namespace cadastroclientes_hexabit
{
    partial class frmCadastroPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroPagamento));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSTOQUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pAGAMENTOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarPagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.lblCpf_Cnpj = new System.Windows.Forms.Label();
            this.lblPrecodeCompra = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtCpfCnpj = new System.Windows.Forms.TextBox();
            this.txtIdEstoque = new System.Windows.Forms.TextBox();
            this.txtQuantidade = new System.Windows.Forms.TextBox();
            this.txtPrecoDeCompra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnFecharPrograma = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCadastroPagamentos = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem,
            this.eSTOQUEToolStripMenuItem,
            this.pAGAMENTOSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(400, 33);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(987, 47);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.visualisarToolStripMenuItem});
            this.cLIENTESToolStripMenuItem.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cLIENTESToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            this.cLIENTESToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.cLIENTESToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.cLIENTESToolStripMenuItem.Text = "CLIENTES";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cadastrarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(196, 44);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar ";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // visualisarToolStripMenuItem
            // 
            this.visualisarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualisarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.visualisarToolStripMenuItem.Name = "visualisarToolStripMenuItem";
            this.visualisarToolStripMenuItem.Size = new System.Drawing.Size(196, 44);
            this.visualisarToolStripMenuItem.Text = "Visualizar";
            this.visualisarToolStripMenuItem.Click += new System.EventHandler(this.visualisarToolStripMenuItem_Click);
            // 
            // eSTOQUEToolStripMenuItem
            // 
            this.eSTOQUEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem1,
            this.visualizarToolStripMenuItem});
            this.eSTOQUEToolStripMenuItem.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSTOQUEToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.eSTOQUEToolStripMenuItem.Name = "eSTOQUEToolStripMenuItem";
            this.eSTOQUEToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.eSTOQUEToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.eSTOQUEToolStripMenuItem.Text = "ESTOQUE";
            // 
            // cadastrarToolStripMenuItem1
            // 
            this.cadastrarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cadastrarToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cadastrarToolStripMenuItem1.Name = "cadastrarToolStripMenuItem1";
            this.cadastrarToolStripMenuItem1.Size = new System.Drawing.Size(191, 44);
            this.cadastrarToolStripMenuItem1.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem1.Click += new System.EventHandler(this.cadastrarToolStripMenuItem1_Click);
            // 
            // visualizarToolStripMenuItem
            // 
            this.visualizarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.visualizarToolStripMenuItem.Name = "visualizarToolStripMenuItem";
            this.visualizarToolStripMenuItem.Size = new System.Drawing.Size(191, 44);
            this.visualizarToolStripMenuItem.Text = "Visualizar";
            this.visualizarToolStripMenuItem.Click += new System.EventHandler(this.visualizarToolStripMenuItem_Click);
            // 
            // pAGAMENTOSToolStripMenuItem
            // 
            this.pAGAMENTOSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarPagamentoToolStripMenuItem,
            this.visualizarToolStripMenuItem1});
            this.pAGAMENTOSToolStripMenuItem.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pAGAMENTOSToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pAGAMENTOSToolStripMenuItem.Name = "pAGAMENTOSToolStripMenuItem";
            this.pAGAMENTOSToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.pAGAMENTOSToolStripMenuItem.Size = new System.Drawing.Size(319, 43);
            this.pAGAMENTOSToolStripMenuItem.Text = "PAGAMENTOS";
            this.pAGAMENTOSToolStripMenuItem.Click += new System.EventHandler(this.pAGAMENTOSToolStripMenuItem_Click);
            // 
            // gerarPagamentoToolStripMenuItem
            // 
            this.gerarPagamentoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.gerarPagamentoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gerarPagamentoToolStripMenuItem.Name = "gerarPagamentoToolStripMenuItem";
            this.gerarPagamentoToolStripMenuItem.Size = new System.Drawing.Size(269, 44);
            this.gerarPagamentoToolStripMenuItem.Text = "Gerar Pagamento";
            // 
            // visualizarToolStripMenuItem1
            // 
            this.visualizarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.visualizarToolStripMenuItem1.Name = "visualizarToolStripMenuItem1";
            this.visualizarToolStripMenuItem1.Size = new System.Drawing.Size(269, 44);
            this.visualizarToolStripMenuItem1.Text = "Visualizar";
            this.visualizarToolStripMenuItem1.Click += new System.EventHandler(this.visualizarToolStripMenuItem1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 768);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(88)))), ((int)(((byte)(123)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizar.Font = new System.Drawing.Font("Open Sans Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAtualizar.Location = new System.Drawing.Point(1321, 816);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(224, 54);
            this.btnAtualizar.TabIndex = 14;
            this.btnAtualizar.Text = "GERAR PAGAMENTO";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // lblCpf_Cnpj
            // 
            this.lblCpf_Cnpj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCpf_Cnpj.AutoSize = true;
            this.lblCpf_Cnpj.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpf_Cnpj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblCpf_Cnpj.Location = new System.Drawing.Point(73, 31);
            this.lblCpf_Cnpj.Name = "lblCpf_Cnpj";
            this.lblCpf_Cnpj.Size = new System.Drawing.Size(95, 31);
            this.lblCpf_Cnpj.TabIndex = 2;
            this.lblCpf_Cnpj.Text = "ID CLIENTE";
            // 
            // lblPrecodeCompra
            // 
            this.lblPrecodeCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPrecodeCompra.AutoSize = true;
            this.lblPrecodeCompra.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecodeCompra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblPrecodeCompra.Location = new System.Drawing.Point(73, 90);
            this.lblPrecodeCompra.Name = "lblPrecodeCompra";
            this.lblPrecodeCompra.Size = new System.Drawing.Size(87, 31);
            this.lblPrecodeCompra.TabIndex = 4;
            this.lblPrecodeCompra.Text = "CPF/CNPJ\r\n";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.lblQuantidade.Location = new System.Drawing.Point(56, 145);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(104, 31);
            this.lblQuantidade.TabIndex = 5;
            this.lblQuantidade.Text = "ID ESTOQUE\r\n";
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.txtIdCliente.Location = new System.Drawing.Point(174, 25);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(214, 40);
            this.txtIdCliente.TabIndex = 8;
            this.txtIdCliente.Enter += new System.EventHandler(this.txtIdCliente_Enter);
            this.txtIdCliente.Leave += new System.EventHandler(this.txtIdCliente_Leave);
            // 
            // txtCpfCnpj
            // 
            this.txtCpfCnpj.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.txtCpfCnpj.Location = new System.Drawing.Point(174, 81);
            this.txtCpfCnpj.Name = "txtCpfCnpj";
            this.txtCpfCnpj.Size = new System.Drawing.Size(214, 40);
            this.txtCpfCnpj.TabIndex = 10;
            // 
            // txtIdEstoque
            // 
            this.txtIdEstoque.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.txtIdEstoque.Location = new System.Drawing.Point(174, 136);
            this.txtIdEstoque.Name = "txtIdEstoque";
            this.txtIdEstoque.Size = new System.Drawing.Size(214, 40);
            this.txtIdEstoque.TabIndex = 11;
            this.txtIdEstoque.Enter += new System.EventHandler(this.txtIdEstoque_Enter);
            this.txtIdEstoque.Leave += new System.EventHandler(this.txtIdEstoque_Leave);
            // 
            // txtQuantidade
            // 
            this.txtQuantidade.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.txtQuantidade.Location = new System.Drawing.Point(174, 249);
            this.txtQuantidade.Name = "txtQuantidade";
            this.txtQuantidade.Size = new System.Drawing.Size(214, 40);
            this.txtQuantidade.TabIndex = 19;
            // 
            // txtPrecoDeCompra
            // 
            this.txtPrecoDeCompra.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.txtPrecoDeCompra.Location = new System.Drawing.Point(174, 193);
            this.txtPrecoDeCompra.Name = "txtPrecoDeCompra";
            this.txtPrecoDeCompra.Size = new System.Drawing.Size(214, 40);
            this.txtPrecoDeCompra.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(47, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 62);
            this.label2.TabIndex = 16;
            this.label2.Text = "QUANTIDADE\r\n\r\n";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Location = new System.Drawing.Point(7, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "PREÇO DA COMPRA";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(449, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 31);
            this.label1.TabIndex = 20;
            this.label1.Text = "FORMA DE PAGAMENTO";
            // 
            // cmbFormaPagamento
            // 
            this.cmbFormaPagamento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFormaPagamento.FormattingEnabled = true;
            this.cmbFormaPagamento.Items.AddRange(new object[] {
            "Crédito",
            "Débito",
            "Pix"});
            this.cmbFormaPagamento.Location = new System.Drawing.Point(441, 54);
            this.cmbFormaPagamento.Name = "cmbFormaPagamento";
            this.cmbFormaPagamento.Size = new System.Drawing.Size(214, 21);
            this.cmbFormaPagamento.TabIndex = 22;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpar.BackColor = System.Drawing.Color.DimGray;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpar.Font = new System.Drawing.Font("Open Sans Condensed", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnLimpar.Location = new System.Drawing.Point(1091, 816);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(224, 54);
            this.btnLimpar.TabIndex = 32;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnMaximizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMaximizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximizar.ForeColor = System.Drawing.Color.White;
            this.btnMaximizar.Location = new System.Drawing.Point(1515, 12);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(30, 12);
            this.btnMaximizar.TabIndex = 39;
            this.btnMaximizar.Text = "X";
            this.btnMaximizar.UseVisualStyleBackColor = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Orange;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinimizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Location = new System.Drawing.Point(1479, 12);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 12);
            this.btnMinimizar.TabIndex = 38;
            this.btnMinimizar.Text = "X";
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnFecharPrograma
            // 
            this.btnFecharPrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharPrograma.BackColor = System.Drawing.Color.DarkRed;
            this.btnFecharPrograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFecharPrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharPrograma.ForeColor = System.Drawing.Color.White;
            this.btnFecharPrograma.Location = new System.Drawing.Point(1551, 12);
            this.btnFecharPrograma.Name = "btnFecharPrograma";
            this.btnFecharPrograma.Size = new System.Drawing.Size(30, 12);
            this.btnFecharPrograma.TabIndex = 37;
            this.btnFecharPrograma.Text = "X";
            this.btnFecharPrograma.UseVisualStyleBackColor = false;
            this.btnFecharPrograma.Click += new System.EventHandler(this.btnFecharPrograma_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblQuantidade);
            this.panel1.Controls.Add(this.lblPrecodeCompra);
            this.panel1.Controls.Add(this.cmbFormaPagamento);
            this.panel1.Controls.Add(this.txtQuantidade);
            this.panel1.Controls.Add(this.lblCpf_Cnpj);
            this.panel1.Controls.Add(this.txtPrecoDeCompra);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtIdCliente);
            this.panel1.Controls.Add(this.txtCpfCnpj);
            this.panel1.Controls.Add(this.txtIdEstoque);
            this.panel1.Location = new System.Drawing.Point(395, 341);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 316);
            this.panel1.TabIndex = 40;
            // 
            // lblCadastroPagamentos
            // 
            this.lblCadastroPagamentos.AutoSize = true;
            this.lblCadastroPagamentos.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCadastroPagamentos.ForeColor = System.Drawing.Color.White;
            this.lblCadastroPagamentos.Location = new System.Drawing.Point(410, 292);
            this.lblCadastroPagamentos.Name = "lblCadastroPagamentos";
            this.lblCadastroPagamentos.Size = new System.Drawing.Size(308, 46);
            this.lblCadastroPagamentos.TabIndex = 36;
            this.lblCadastroPagamentos.Text = "Cadastro de Pagamentos";
            // 
            // frmCadastroPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.lblCadastroPagamentos);
            this.Controls.Add(this.btnMaximizar);
            this.Controls.Add(this.btnMinimizar);
            this.Controls.Add(this.btnFecharPrograma);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCadastroPagamento";
            this.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerar Pagamentos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSTOQUEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pAGAMENTOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarPagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Label lblCpf_Cnpj;
        private System.Windows.Forms.Label lblPrecodeCompra;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtCpfCnpj;
        private System.Windows.Forms.TextBox txtIdEstoque;
        private System.Windows.Forms.TextBox txtQuantidade;
        private System.Windows.Forms.TextBox txtPrecoDeCompra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFormaPagamento;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnFecharPrograma;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCadastroPagamentos;
    }
}