namespace projERPMercearia.View
{
    partial class UscAddProduct
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
            this.lblEan = new System.Windows.Forms.Label();
            this.txtEan = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSection = new System.Windows.Forms.Label();
            this.cbbSections = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.rbtUnity = new System.Windows.Forms.RadioButton();
            this.rbtKg = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(46, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(254, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cadastrar Produto";
            // 
            // lblEan
            // 
            this.lblEan.AutoSize = true;
            this.lblEan.Location = new System.Drawing.Point(53, 136);
            this.lblEan.Name = "lblEan";
            this.lblEan.Size = new System.Drawing.Size(94, 20);
            this.lblEan.TabIndex = 1;
            this.lblEan.Text = "Código EAN:";
            // 
            // txtEan
            // 
            this.txtEan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEan.Location = new System.Drawing.Point(53, 159);
            this.txtEan.Name = "txtEan";
            this.txtEan.Size = new System.Drawing.Size(219, 27);
            this.txtEan.TabIndex = 1;
            this.txtEan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTxtEanKeyPressed);
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(53, 99);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(419, 27);
            this.txtName.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(53, 76);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(53, 20);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Nome:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(53, 314);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(419, 67);
            this.txtDescription.TabIndex = 5;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(53, 291);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(77, 20);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "Descrição:";
            // 
            // lblSection
            // 
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new System.Drawing.Point(53, 189);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new System.Drawing.Size(47, 20);
            this.lblSection.TabIndex = 7;
            this.lblSection.Text = "Setor:";
            // 
            // cbbSections
            // 
            this.cbbSections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbSections.FormattingEnabled = true;
            this.cbbSections.Location = new System.Drawing.Point(53, 213);
            this.cbbSections.Name = "cbbSections";
            this.cbbSections.Size = new System.Drawing.Size(219, 28);
            this.cbbSections.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(378, 397);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Salvar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.OnButtonSaveClicked);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(278, 397);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(94, 29);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Limpar";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(278, 213);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Novo";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.OnButtonEditClicked);
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrice.Location = new System.Drawing.Point(278, 159);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(194, 27);
            this.txtPrice.TabIndex = 2;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTxtPriceKeyPressed);
            // 
            // lblPreco
            // 
            this.lblPreco.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(278, 136);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(106, 20);
            this.lblPreco.TabIndex = 13;
            this.lblPreco.Text = "Preço Unitário:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(53, 260);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(134, 20);
            this.lblType.TabIndex = 14;
            this.lblType.Text = "Tipo de venda por:";
            // 
            // rbtUnity
            // 
            this.rbtUnity.AutoSize = true;
            this.rbtUnity.Checked = true;
            this.rbtUnity.Location = new System.Drawing.Point(194, 260);
            this.rbtUnity.Name = "rbtUnity";
            this.rbtUnity.Size = new System.Drawing.Size(86, 24);
            this.rbtUnity.TabIndex = 15;
            this.rbtUnity.TabStop = true;
            this.rbtUnity.Text = "Unidade";
            this.rbtUnity.UseVisualStyleBackColor = true;
            // 
            // rbtKg
            // 
            this.rbtKg.AutoSize = true;
            this.rbtKg.Location = new System.Drawing.Point(278, 260);
            this.rbtKg.Name = "rbtKg";
            this.rbtKg.Size = new System.Drawing.Size(66, 24);
            this.rbtKg.TabIndex = 16;
            this.rbtKg.Text = "Quilo";
            this.rbtKg.UseVisualStyleBackColor = true;
            // 
            // UscAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbtKg);
            this.Controls.Add(this.rbtUnity);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbbSections);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtEan);
            this.Controls.Add(this.lblEan);
            this.Controls.Add(this.lblTitle);
            this.Name = "UscAddProduct";
            this.Size = new System.Drawing.Size(543, 443);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEan;
        private System.Windows.Forms.TextBox txtEan;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSection;
        private System.Windows.Forms.ComboBox cbbSections;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rbtUnity;
        private System.Windows.Forms.RadioButton rbtKg;
    }
}
