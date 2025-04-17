namespace cadastroclientes_hexabit
{
    partial class frmVisualizarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVisualizarClientes));
            this.lstClientes = new System.Windows.Forms.ListView();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pesquisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLIENTESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eSTOQUEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pAGAMENTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gerarPagamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstClientes
            // 
            this.lstClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstClientes.AutoArrange = false;
            this.lstClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.lstClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstClientes.Font = new System.Drawing.Font("Open Sans Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClientes.ForeColor = System.Drawing.Color.White;
            this.lstClientes.HideSelection = false;
            this.lstClientes.Location = new System.Drawing.Point(122, 238);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(1378, 492);
            this.lstClientes.TabIndex = 2;
            this.lstClientes.UseCompatibleStateImageBehavior = false;
            // 
            // txtBuscarCliente
            // 
            this.txtBuscarCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBuscarCliente.Font = new System.Drawing.Font("Open Sans Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCliente.ForeColor = System.Drawing.Color.Black;
            this.txtBuscarCliente.Location = new System.Drawing.Point(417, 169);
            this.txtBuscarCliente.Name = "txtBuscarCliente";
            this.txtBuscarCliente.Size = new System.Drawing.Size(608, 33);
            this.txtBuscarCliente.TabIndex = 3;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(88)))), ((int)(((byte)(123)))));
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAtualizar.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnAtualizar.Location = new System.Drawing.Point(1365, 794);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(224, 54);
            this.btnAtualizar.TabIndex = 16;
            this.btnAtualizar.Text = "ATUALIZAR";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 764);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Open Sans Condensed SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pesquisarToolStripMenuItem,
            this.cLIENTESToolStripMenuItem,
            this.eSTOQUEToolStripMenuItem,
            this.pAGAMENTOToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(118, 22);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1157, 47);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pesquisarToolStripMenuItem
            // 
            this.pesquisarToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            this.pesquisarToolStripMenuItem.Padding = new System.Windows.Forms.Padding(80, 0, 80, 0);
            this.pesquisarToolStripMenuItem.Size = new System.Drawing.Size(290, 43);
            this.pesquisarToolStripMenuItem.Text = "PESQUISAR";
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
            // 
            // visualizarToolStripMenuItem1
            // 
            this.visualizarToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.visualizarToolStripMenuItem1.Name = "visualizarToolStripMenuItem1";
            this.visualizarToolStripMenuItem1.Size = new System.Drawing.Size(191, 44);
            this.visualizarToolStripMenuItem1.Text = "Visualizar";
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
            // 
            // visualizarToolStripMenuItem2
            // 
            this.visualizarToolStripMenuItem2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem2.ForeColor = System.Drawing.Color.White;
            this.visualizarToolStripMenuItem2.Name = "visualizarToolStripMenuItem2";
            this.visualizarToolStripMenuItem2.Size = new System.Drawing.Size(191, 44);
            this.visualizarToolStripMenuItem2.Text = "Visualizar";
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
            // 
            // visualizarToolStripMenuItem3
            // 
            this.visualizarToolStripMenuItem3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.visualizarToolStripMenuItem3.ForeColor = System.Drawing.Color.White;
            this.visualizarToolStripMenuItem3.Name = "visualizarToolStripMenuItem3";
            this.visualizarToolStripMenuItem3.Size = new System.Drawing.Size(269, 44);
            this.visualizarToolStripMenuItem3.Text = "Visualizar";
            // 
            // frmVisualizarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(44)))), ((int)(((byte)(69)))));
            this.ClientSize = new System.Drawing.Size(1620, 920);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBuscarCliente);
            this.Controls.Add(this.lstClientes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVisualizarClientes";
            this.Text = "Visualizar Clientes";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstClientes;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLIENTESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem eSTOQUEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pAGAMENTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gerarPagamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarToolStripMenuItem3;
    }
}