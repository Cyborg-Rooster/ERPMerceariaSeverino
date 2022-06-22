
namespace projERPMercearia.View
{
    partial class FrmMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Cadastrar Produtos");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Mostrar Produtos");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Entrada de Estoque");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Movimentar Estoque");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Editar Produto");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Códigos de Barra");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Imprimir Etiqueta");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Controle de Estoque", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Abrir Caixa");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Fechar Caixa");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("PDV", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Relatórios de Lucro");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Relatórios de Valor por Setor");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Produtos Próximos à Zerar");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Relatórios", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.pnlLeftMenuBar = new System.Windows.Forms.Panel();
            this.trvOptions = new System.Windows.Forms.TreeView();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlLeftMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlLeftMenuBar);
            this.pnlMain.Controls.Add(this.splitter1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1058, 576);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.splitter3);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(320, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(738, 572);
            this.pnlContent.TabIndex = 0;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter3.Location = new System.Drawing.Point(0, 0);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(738, 4);
            this.splitter3.TabIndex = 0;
            this.splitter3.TabStop = false;
            // 
            // pnlLeftMenuBar
            // 
            this.pnlLeftMenuBar.Controls.Add(this.trvOptions);
            this.pnlLeftMenuBar.Controls.Add(this.splitter2);
            this.pnlLeftMenuBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeftMenuBar.Location = new System.Drawing.Point(0, 0);
            this.pnlLeftMenuBar.Name = "pnlLeftMenuBar";
            this.pnlLeftMenuBar.Size = new System.Drawing.Size(320, 572);
            this.pnlLeftMenuBar.TabIndex = 1;
            // 
            // trvOptions
            // 
            this.trvOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.trvOptions.Cursor = System.Windows.Forms.Cursors.Default;
            this.trvOptions.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.trvOptions.Location = new System.Drawing.Point(12, 12);
            this.trvOptions.Name = "trvOptions";
            treeNode1.Name = "nodAddProducts";
            treeNode1.Text = "Cadastrar Produtos";
            treeNode2.Name = "nodShowProducts";
            treeNode2.Text = "Mostrar Produtos";
            treeNode3.Name = "nodAdd";
            treeNode3.Text = "Entrada de Estoque";
            treeNode4.Name = "nodMoveInventory";
            treeNode4.Text = "Movimentar Estoque";
            treeNode5.Name = "nodChange";
            treeNode5.Text = "Editar Produto";
            treeNode6.Name = "nodEAN";
            treeNode6.Text = "Códigos de Barra";
            treeNode7.Name = "nodProductPlate";
            treeNode7.Text = "Imprimir Etiqueta";
            treeNode8.Name = "nodInventoryControl";
            treeNode8.Text = "Controle de Estoque";
            treeNode9.Name = "nodOpenPDV";
            treeNode9.Text = "Abrir Caixa";
            treeNode10.Name = "nodClosePDV";
            treeNode10.Text = "Fechar Caixa";
            treeNode11.Name = "nodPDV";
            treeNode11.Text = "PDV";
            treeNode12.Name = "nodReports";
            treeNode12.Text = "Relatórios de Lucro";
            treeNode13.Name = "nodSectorValue";
            treeNode13.Text = "Relatórios de Valor por Setor";
            treeNode14.Name = "nodShoppingList";
            treeNode14.Text = "Produtos Próximos à Zerar";
            treeNode15.Name = "nodReport";
            treeNode15.Text = "Relatórios";
            this.trvOptions.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode11,
            treeNode15});
            this.trvOptions.Size = new System.Drawing.Size(298, 552);
            this.trvOptions.TabIndex = 0;
            this.trvOptions.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.OnSelectedOptionList);
            this.trvOptions.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.AfterSelectedOptionList);
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(4, 572);
            this.splitter2.TabIndex = 0;
            this.splitter2.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 572);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1058, 4);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 576);
            this.Controls.Add(this.pnlMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP Mercearia";
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlLeftMenuBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel pnlLeftMenuBar;
        private System.Windows.Forms.TreeView trvOptions;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Splitter splitter1;
    }
}