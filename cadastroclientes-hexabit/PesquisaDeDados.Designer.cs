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
            this.pESQUISARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vizualisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eSTOQUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pAGAMENTOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarPagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.btnFecharPrograma = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
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
            this.pESQUISARToolStripMenuItem,
            this.cLIENTESToolStripMenuItem,
            this.eSTOQUEToolStripMenuItem,
            this.pAGAMENTOSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(131, 22);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1162, 47);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.UseWaitCursor = true;
            // 
            // pESQUISARToolStripMenuItem
            // 
            this.pESQUISARToolStripMenuItem.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pESQUISARToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pESQUISARToolStripMenuItem.Name = "pESQUISARToolStripMenuItem";
            this.pESQUISARToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.pESQUISARToolStripMenuItem.Size = new System.Drawing.Size(295, 43);
            this.pESQUISARToolStripMenuItem.Text = "PESQUISAR ";
            // 
            // cLIENTESToolStripMenuItem
            // 
            this.cLIENTESToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.vizualisarToolStripMenuItem});
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
            // vizualisarToolStripMenuItem
            // 
            this.vizualisarToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.vizualisarToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.vizualisarToolStripMenuItem.Name = "vizualisarToolStripMenuItem";
            this.vizualisarToolStripMenuItem.Size = new System.Drawing.Size(196, 44);
            this.vizualisarToolStripMenuItem.Text = "Visualizar";
            this.vizualisarToolStripMenuItem.Click += new System.EventHandler(this.vizualisarToolStripMenuItem_Click);
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
            // 
            // gerarPagamentoToolStripMenuItem
            // 
            this.gerarPagamentoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.gerarPagamentoToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gerarPagamentoToolStripMenuItem.Name = "gerarPagamentoToolStripMenuItem";
            this.gerarPagamentoToolStripMenuItem.Size = new System.Drawing.Size(269, 44);
            this.gerarPagamentoToolStripMenuItem.Text = "Gerar Pagamento";
            this.gerarPagamentoToolStripMenuItem.Click += new System.EventHandler(this.gerarPagamentoToolStripMenuItem_Click);
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
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(544, 145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(326, 282);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblBanco
            // 
            this.lblBanco.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanco.Location = new System.Drawing.Point(617, 459);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(189, 35);
            this.lblBanco.TabIndex = 3;
            this.lblBanco.Text = "BANCO DE CLIENTES";
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisa.ForeColor = System.Drawing.Color.Black;
            this.txtPesquisa.Location = new System.Drawing.Point(454, 572);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(548, 33);
            this.txtPesquisa.TabIndex = 4;
            this.txtPesquisa.Text = "Digite um nome ou CPF";
            this.txtPesquisa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnFecharPrograma
            // 
            this.btnFecharPrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecharPrograma.BackColor = System.Drawing.Color.Red;
            this.btnFecharPrograma.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFecharPrograma.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecharPrograma.ForeColor = System.Drawing.Color.White;
            this.btnFecharPrograma.Location = new System.Drawing.Point(1344, 12);
            this.btnFecharPrograma.Name = "btnFecharPrograma";
            this.btnFecharPrograma.Size = new System.Drawing.Size(49, 51);
            this.btnFecharPrograma.TabIndex = 5;
            this.btnFecharPrograma.Text = "X";
            this.btnFecharPrograma.UseVisualStyleBackColor = false;
            this.btnFecharPrograma.Click += new System.EventHandler(this.btnFecharPrograma_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(1024, 572);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(42, 33);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "button1";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // frmPesquisar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.btnFecharPrograma);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.lblBanco);
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
        private System.Windows.Forms.ToolStripMenuItem pESQUISARToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vizualisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eSTOQUEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pAGAMENTOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarPagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Button btnFecharPrograma;
        private System.Windows.Forms.Button btnPesquisar;
    }
}