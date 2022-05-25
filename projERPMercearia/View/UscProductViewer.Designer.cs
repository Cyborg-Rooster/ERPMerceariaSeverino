
namespace projERPMercearia.View
{
    partial class UscProductViewer
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtProductValues = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnEAN = new System.Windows.Forms.Button();
            this.dgvMovimentation = new System.Windows.Forms.DataGridView();
            this.clmDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmMovedQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmActualQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmWhy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentation)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(46, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Mostrar Produto";
            // 
            // txtProductValues
            // 
            this.txtProductValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductValues.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtProductValues.Location = new System.Drawing.Point(49, 60);
            this.txtProductValues.Multiline = true;
            this.txtProductValues.Name = "txtProductValues";
            this.txtProductValues.ReadOnly = true;
            this.txtProductValues.Size = new System.Drawing.Size(449, 151);
            this.txtProductValues.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(49, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.OnBtnAddClicked);
            // 
            // btnAdjust
            // 
            this.btnAdjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdjust.Location = new System.Drawing.Point(166, 188);
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.Size = new System.Drawing.Size(94, 29);
            this.btnAdjust.TabIndex = 2;
            this.btnAdjust.Text = "Ajustar";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.OnBtnAdjustClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(284, 188);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Editar";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.OnBtnEditClicked);
            // 
            // btnEAN
            // 
            this.btnEAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEAN.Location = new System.Drawing.Point(405, 188);
            this.btnEAN.Name = "btnEAN";
            this.btnEAN.Size = new System.Drawing.Size(94, 29);
            this.btnEAN.TabIndex = 4;
            this.btnEAN.Text = "EAN";
            this.btnEAN.UseVisualStyleBackColor = true;
            this.btnEAN.Click += new System.EventHandler(this.OnBtnEanClicked);
            // 
            // dgvMovimentation
            // 
            this.dgvMovimentation.AllowUserToAddRows = false;
            this.dgvMovimentation.AllowUserToDeleteRows = false;
            this.dgvMovimentation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMovimentation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmDate,
            this.clmType,
            this.clmMovedQuantity,
            this.clmActualQuantity,
            this.clmWhy});
            this.dgvMovimentation.Location = new System.Drawing.Point(49, 10);
            this.dgvMovimentation.Name = "dgvMovimentation";
            this.dgvMovimentation.ReadOnly = true;
            this.dgvMovimentation.RowHeadersWidth = 51;
            this.dgvMovimentation.RowTemplate.Height = 29;
            this.dgvMovimentation.Size = new System.Drawing.Size(449, 170);
            this.dgvMovimentation.TabIndex = 5;
            // 
            // clmDate
            // 
            this.clmDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmDate.HeaderText = "Data";
            this.clmDate.MinimumWidth = 6;
            this.clmDate.Name = "clmDate";
            this.clmDate.ReadOnly = true;
            // 
            // clmType
            // 
            this.clmType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmType.HeaderText = "Tipo";
            this.clmType.MinimumWidth = 6;
            this.clmType.Name = "clmType";
            this.clmType.ReadOnly = true;
            // 
            // clmMovedQuantity
            // 
            this.clmMovedQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmMovedQuantity.HeaderText = "Quantidade Movida";
            this.clmMovedQuantity.MinimumWidth = 6;
            this.clmMovedQuantity.Name = "clmMovedQuantity";
            this.clmMovedQuantity.ReadOnly = true;
            // 
            // clmActualQuantity
            // 
            this.clmActualQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmActualQuantity.HeaderText = "Quantidade Final";
            this.clmActualQuantity.MinimumWidth = 6;
            this.clmActualQuantity.Name = "clmActualQuantity";
            this.clmActualQuantity.ReadOnly = true;
            // 
            // clmWhy
            // 
            this.clmWhy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmWhy.HeaderText = "Motivo";
            this.clmWhy.MinimumWidth = 6;
            this.clmWhy.Name = "clmWhy";
            this.clmWhy.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtProductValues);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(543, 443);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.dgvMovimentation);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.btnAdjust);
            this.panel2.Controls.Add(this.btnEAN);
            this.panel2.Controls.Add(this.btnEdit);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(543, 226);
            this.panel2.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(543, 4);
            this.splitter1.TabIndex = 6;
            this.splitter1.TabStop = false;
            // 
            // UscProductViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "UscProductViewer";
            this.Size = new System.Drawing.Size(543, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnEAN;
        private System.Windows.Forms.DataGridView dgvMovimentation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtProductValues;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmType;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmMovedQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmActualQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmWhy;
    }
}
