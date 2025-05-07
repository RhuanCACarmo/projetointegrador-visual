
namespace cadastroclientes_hexabit
{
    partial class frmVisualizarEstoque
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarEstoque));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eSTOQUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pAGAMENTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarPagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.lstProdutos = new System.Windows.Forms.ListView();
            this.txtBuscarProduto = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnDeletarCliente = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMaximizar = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnFecharPrograma = new System.Windows.Forms.Button();
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
            this.menuStrip1.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cLIENTESToolStripMenuItem,
            this.eSTOQUEToolStripMenuItem,
            this.pAGAMENTOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(400, 33);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 47);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.visualizarToolStripMenuItem1});
            this.cLIENTESToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cLIENTESToolStripMenuItem.Name = "cLIENTESToolStripMenuItem";
            this.cLIENTESToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.cLIENTESToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.cLIENTESToolStripMenuItem.Text = "CLIENTES";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cadastrarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(191, 44);
            this.cadastrarToolStripMenuItem.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem.Click += new System.EventHandler(this.cadastrarToolStripMenuItem_Click);
            // 
            // visualizarToolStripMenuItem1
            // 
            this.visualizarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.visualizarToolStripMenuItem1.Name = "visualizarToolStripMenuItem1";
            this.visualizarToolStripMenuItem1.Size = new System.Drawing.Size(191, 44);
            this.visualizarToolStripMenuItem1.Text = "Visualizar";
            this.visualizarToolStripMenuItem1.Click += new System.EventHandler(this.visualizarToolStripMenuItem1_Click);
            // 
            // eSTOQUEToolStripMenuItem
            // 
            this.eSTOQUEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem1,
            this.visualizarToolStripMenuItem2});
            this.eSTOQUEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eSTOQUEToolStripMenuItem.Name = "eSTOQUEToolStripMenuItem";
            this.eSTOQUEToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.eSTOQUEToolStripMenuItem.Size = new System.Drawing.Size(270, 43);
            this.eSTOQUEToolStripMenuItem.Text = "ESTOQUE";
            // 
            // cadastrarToolStripMenuItem1
            // 
            this.cadastrarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.cadastrarToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.cadastrarToolStripMenuItem1.Name = "cadastrarToolStripMenuItem1";
            this.cadastrarToolStripMenuItem1.Size = new System.Drawing.Size(191, 44);
            this.cadastrarToolStripMenuItem1.Text = "Cadastrar";
            this.cadastrarToolStripMenuItem1.Click += new System.EventHandler(this.cadastrarToolStripMenuItem1_Click);
            // 
            // visualizarToolStripMenuItem2
            // 
            this.visualizarToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.visualizarToolStripMenuItem2.Name = "visualizarToolStripMenuItem2";
            this.visualizarToolStripMenuItem2.Size = new System.Drawing.Size(191, 44);
            this.visualizarToolStripMenuItem2.Text = "Visualizar";
            this.visualizarToolStripMenuItem2.Click += new System.EventHandler(this.visualizarToolStripMenuItem2_Click);
            // 
            // pAGAMENTOToolStripMenuItem
            // 
            this.pAGAMENTOToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gerarPagamentoToolStripMenuItem,
            this.visualizarToolStripMenuItem3});
            this.pAGAMENTOToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pAGAMENTOToolStripMenuItem.Name = "pAGAMENTOToolStripMenuItem";
            this.pAGAMENTOToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.pAGAMENTOToolStripMenuItem.Size = new System.Drawing.Size(319, 43);
            this.pAGAMENTOToolStripMenuItem.Text = "PAGAMENTOS";
            // 
            // gerarPagamentoToolStripMenuItem
            // 
            this.gerarPagamentoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.gerarPagamentoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.gerarPagamentoToolStripMenuItem.Name = "gerarPagamentoToolStripMenuItem";
            this.gerarPagamentoToolStripMenuItem.Size = new System.Drawing.Size(269, 44);
            this.gerarPagamentoToolStripMenuItem.Text = "Gerar Pagamento";
            this.gerarPagamentoToolStripMenuItem.Click += new System.EventHandler(this.gerarPagamentoToolStripMenuItem_Click);
            // 
            // visualizarToolStripMenuItem3
            // 
            this.visualizarToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.visualizarToolStripMenuItem3.Name = "visualizarToolStripMenuItem3";
            this.visualizarToolStripMenuItem3.Size = new System.Drawing.Size(269, 44);
            this.visualizarToolStripMenuItem3.Text = "Visualizar";
            this.visualizarToolStripMenuItem3.Click += new System.EventHandler(this.visualizarToolStripMenuItem3_Click);
            // 
            // lstProdutos
            // 
            this.lstProdutos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstProdutos.AutoArrange = false;
            this.lstProdutos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.lstProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstProdutos.Font = new System.Drawing.Font("Open Sans Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstProdutos.ForeColor = System.Drawing.Color.White;
            this.lstProdutos.HideSelection = false;
            this.lstProdutos.Location = new System.Drawing.Point(122, 238);
            this.lstProdutos.Name = "lstProdutos";
            this.lstProdutos.Size = new System.Drawing.Size(1140, 492);
            this.lstProdutos.TabIndex = 19;
            this.lstProdutos.UseCompatibleStateImageBehavior = false;
            // 
            // txtBuscarProduto
            // 
            this.txtBuscarProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarProduto.Font = new System.Drawing.Font("Open Sans Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarProduto.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarProduto.Location = new System.Drawing.Point(417, 169);
            this.txtBuscarProduto.Name = "txtBuscarProduto";
            this.txtBuscarProduto.Size = new System.Drawing.Size(659, 33);
            this.txtBuscarProduto.TabIndex = 20;
            this.txtBuscarProduto.Text = "Digite um nome ou CPF/CNPJ";
            this.txtBuscarProduto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBuscarProduto.Click += new System.EventHandler(this.txtBuscarProduto_Click);
            this.txtBuscarProduto.TextChanged += new System.EventHandler(this.txtBuscarProduto_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(20, 768);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(88)))), ((int)(((byte)(123)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizar.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAtualizar.Location = new System.Drawing.Point(1321, 816);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(224, 54);
            this.btnAtualizar.TabIndex = 22;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnDeletarCliente
            // 
            this.btnDeletarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeletarCliente.BackColor = System.Drawing.Color.DimGray;
            this.btnDeletarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeletarCliente.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnDeletarCliente.Location = new System.Drawing.Point(1091, 816);
            this.btnDeletarCliente.Name = "btnDeletarCliente";
            this.btnDeletarCliente.Size = new System.Drawing.Size(224, 54);
            this.btnDeletarCliente.TabIndex = 30;
            this.btnDeletarCliente.Text = "DELETAR";
            this.btnDeletarCliente.UseVisualStyleBackColor = false;
            this.btnDeletarCliente.Click += new System.EventHandler(this.btnDeletarCliente_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnMaximizar);
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnFecharPrograma);
            this.panel1.Controls.Add(this.btnDeletarCliente);
            this.panel1.Controls.Add(this.btnAtualizar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtBuscarProduto);
            this.panel1.Controls.Add(this.lstProdutos);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 900);
            this.panel1.TabIndex = 0;
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
            this.btnMaximizar.TabIndex = 45;
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
            this.btnMinimizar.TabIndex = 44;
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
            this.btnFecharPrograma.TabIndex = 43;
            this.btnFecharPrograma.Text = "X";
            this.btnFecharPrograma.UseVisualStyleBackColor = false;
            this.btnFecharPrograma.Click += new System.EventHandler(this.btnFecharPrograma_Click);
            // 
            // frmVisualizarEstoque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Name = "frmVisualizarEstoque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualizarEstoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eSTOQUEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pAGAMENTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarPagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem3;
        private System.Windows.Forms.ListView lstProdutos;
        private System.Windows.Forms.TextBox txtBuscarProduto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnDeletarCliente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMaximizar;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnFecharPrograma;
    }
}