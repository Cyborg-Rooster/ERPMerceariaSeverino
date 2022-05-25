
namespace projERPMercearia.View
{
    partial class FrmPDV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPDV));
            this.gbxPDV = new System.Windows.Forms.GroupBox();
            this.lblreturn = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.dgvShoppingCart = new System.Windows.Forms.DataGridView();
            this.clmEAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCashback = new System.Windows.Forms.TextBox();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.gbxCaption = new System.Windows.Forms.GroupBox();
            this.lblDelete = new System.Windows.Forms.Label();
            this.F6 = new System.Windows.Forms.PictureBox();
            this.lblFinish = new System.Windows.Forms.Label();
            this.lblCancel = new System.Windows.Forms.Label();
            this.lblMultiply = new System.Windows.Forms.Label();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblOpenERP = new System.Windows.Forms.Label();
            this.F5 = new System.Windows.Forms.PictureBox();
            this.F4 = new System.Windows.Forms.PictureBox();
            this.F3 = new System.Windows.Forms.PictureBox();
            this.F2 = new System.Windows.Forms.PictureBox();
            this.F1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblClientsCount = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.gbxPDV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingCart)).BeginInit();
            this.gbxCaption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.F5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.F4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.F3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.F2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.F1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxPDV
            // 
            this.gbxPDV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxPDV.Controls.Add(this.lblreturn);
            this.gbxPDV.Controls.Add(this.lblTotal);
            this.gbxPDV.Controls.Add(this.dgvShoppingCart);
            this.gbxPDV.Controls.Add(this.txtCashback);
            this.gbxPDV.Controls.Add(this.txtFinalPrice);
            this.gbxPDV.Controls.Add(this.txtProduct);
            this.gbxPDV.Controls.Add(this.lblTitle);
            this.gbxPDV.Location = new System.Drawing.Point(739, 49);
            this.gbxPDV.Name = "gbxPDV";
            this.gbxPDV.Size = new System.Drawing.Size(1151, 964);
            this.gbxPDV.TabIndex = 0;
            this.gbxPDV.TabStop = false;
            this.gbxPDV.Text = "Caixa";
            // 
            // lblreturn
            // 
            this.lblreturn.Font = new System.Drawing.Font("Berlin Sans FB", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblreturn.ForeColor = System.Drawing.Color.Red;
            this.lblreturn.Location = new System.Drawing.Point(23, 831);
            this.lblreturn.Name = "lblreturn";
            this.lblreturn.Size = new System.Drawing.Size(312, 107);
            this.lblreturn.TabIndex = 12;
            this.lblreturn.Text = "TROCO:";
            this.lblreturn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Berlin Sans FB", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTotal.ForeColor = System.Drawing.Color.Red;
            this.lblTotal.Location = new System.Drawing.Point(23, 707);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(295, 107);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "TOTAL:";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvShoppingCart
            // 
            this.dgvShoppingCart.AllowUserToAddRows = false;
            this.dgvShoppingCart.AllowUserToDeleteRows = false;
            this.dgvShoppingCart.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShoppingCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShoppingCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShoppingCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmEAN,
            this.clmName,
            this.clmQuantity,
            this.clmPrice});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShoppingCart.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShoppingCart.GridColor = System.Drawing.SystemColors.Window;
            this.dgvShoppingCart.Location = new System.Drawing.Point(23, 323);
            this.dgvShoppingCart.Name = "dgvShoppingCart";
            this.dgvShoppingCart.ReadOnly = true;
            this.dgvShoppingCart.RowHeadersWidth = 51;
            this.dgvShoppingCart.RowTemplate.Height = 29;
            this.dgvShoppingCart.Size = new System.Drawing.Size(1109, 363);
            this.dgvShoppingCart.TabIndex = 10;
            // 
            // clmEAN
            // 
            this.clmEAN.HeaderText = "EAN";
            this.clmEAN.MinimumWidth = 15;
            this.clmEAN.Name = "clmEAN";
            this.clmEAN.ReadOnly = true;
            this.clmEAN.Width = 200;
            // 
            // clmName
            // 
            this.clmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmName.HeaderText = "Produto";
            this.clmName.MinimumWidth = 6;
            this.clmName.Name = "clmName";
            this.clmName.ReadOnly = true;
            // 
            // clmQuantity
            // 
            this.clmQuantity.HeaderText = "Quantidade";
            this.clmQuantity.MinimumWidth = 6;
            this.clmQuantity.Name = "clmQuantity";
            this.clmQuantity.ReadOnly = true;
            this.clmQuantity.Width = 200;
            // 
            // clmPrice
            // 
            this.clmPrice.HeaderText = "Preço";
            this.clmPrice.MinimumWidth = 6;
            this.clmPrice.Name = "clmPrice";
            this.clmPrice.ReadOnly = true;
            this.clmPrice.Width = 200;
            // 
            // txtCashback
            // 
            this.txtCashback.BackColor = System.Drawing.SystemColors.Window;
            this.txtCashback.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtCashback.Location = new System.Drawing.Point(341, 831);
            this.txtCashback.Name = "txtCashback";
            this.txtCashback.ReadOnly = true;
            this.txtCashback.Size = new System.Drawing.Size(791, 107);
            this.txtCashback.TabIndex = 8;
            this.txtCashback.Text = "R$0.00";
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtFinalPrice.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtFinalPrice.Location = new System.Drawing.Point(341, 707);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.ReadOnly = true;
            this.txtFinalPrice.Size = new System.Drawing.Size(791, 107);
            this.txtFinalPrice.TabIndex = 7;
            this.txtFinalPrice.Text = "R$0.00";
            // 
            // txtProduct
            // 
            this.txtProduct.Font = new System.Drawing.Font("Segoe UI", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtProduct.Location = new System.Drawing.Point(23, 198);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(1109, 107);
            this.txtProduct.TabIndex = 6;
            this.txtProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTxtProductEnterKeyPressed);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Berlin Sans FB", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(210, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(728, 157);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "CAIXA";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTime.Location = new System.Drawing.Point(1637, 15);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(216, 31);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "00/00/0000 00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbxCaption
            // 
            this.gbxCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxCaption.Controls.Add(this.lblDelete);
            this.gbxCaption.Controls.Add(this.F6);
            this.gbxCaption.Controls.Add(this.lblFinish);
            this.gbxCaption.Controls.Add(this.lblCancel);
            this.gbxCaption.Controls.Add(this.lblMultiply);
            this.gbxCaption.Controls.Add(this.lblSelect);
            this.gbxCaption.Controls.Add(this.lblOpenERP);
            this.gbxCaption.Controls.Add(this.F5);
            this.gbxCaption.Controls.Add(this.F4);
            this.gbxCaption.Controls.Add(this.F3);
            this.gbxCaption.Controls.Add(this.F2);
            this.gbxCaption.Controls.Add(this.F1);
            this.gbxCaption.Location = new System.Drawing.Point(46, 372);
            this.gbxCaption.Name = "gbxCaption";
            this.gbxCaption.Size = new System.Drawing.Size(655, 641);
            this.gbxCaption.TabIndex = 3;
            this.gbxCaption.TabStop = false;
            this.gbxCaption.Text = "Legenda";
            // 
            // lblDelete
            // 
            this.lblDelete.AutoSize = true;
            this.lblDelete.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDelete.Location = new System.Drawing.Point(140, 344);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(218, 41);
            this.lblDelete.TabIndex = 11;
            this.lblDelete.Text = "Excluir Produto";
            // 
            // F6
            // 
            this.F6.Image = ((System.Drawing.Image)(resources.GetObject("F6.Image")));
            this.F6.Location = new System.Drawing.Point(38, 522);
            this.F6.Name = "F6";
            this.F6.Size = new System.Drawing.Size(75, 75);
            this.F6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F6.TabIndex = 10;
            this.F6.TabStop = false;
            this.F6.Click += new System.EventHandler(this.OnSubtitleKeyClicked);
            // 
            // lblFinish
            // 
            this.lblFinish.AutoSize = true;
            this.lblFinish.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFinish.Location = new System.Drawing.Point(140, 534);
            this.lblFinish.Name = "lblFinish";
            this.lblFinish.Size = new System.Drawing.Size(239, 41);
            this.lblFinish.TabIndex = 9;
            this.lblFinish.Text = "Finalizar Compra";
            // 
            // lblCancel
            // 
            this.lblCancel.AutoSize = true;
            this.lblCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCancel.Location = new System.Drawing.Point(140, 441);
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(245, 41);
            this.lblCancel.TabIndex = 8;
            this.lblCancel.Text = "Cancelar Compra";
            // 
            // lblMultiply
            // 
            this.lblMultiply.AutoSize = true;
            this.lblMultiply.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMultiply.Location = new System.Drawing.Point(140, 248);
            this.lblMultiply.Name = "lblMultiply";
            this.lblMultiply.Size = new System.Drawing.Size(273, 41);
            this.lblMultiply.TabIndex = 7;
            this.lblMultiply.Text = "Multiplicar Produto";
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelect.Location = new System.Drawing.Point(140, 152);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(461, 41);
            this.lblSelect.TabIndex = 6;
            this.lblSelect.Text = "Selecionar Produto Manualmente";
            // 
            // lblOpenERP
            // 
            this.lblOpenERP.AutoSize = true;
            this.lblOpenERP.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOpenERP.Location = new System.Drawing.Point(140, 61);
            this.lblOpenERP.Name = "lblOpenERP";
            this.lblOpenERP.Size = new System.Drawing.Size(193, 41);
            this.lblOpenERP.TabIndex = 5;
            this.lblOpenERP.Text = "Abrir Sistema";
            // 
            // F5
            // 
            this.F5.Image = ((System.Drawing.Image)(resources.GetObject("F5.Image")));
            this.F5.Location = new System.Drawing.Point(38, 424);
            this.F5.Name = "F5";
            this.F5.Size = new System.Drawing.Size(75, 75);
            this.F5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F5.TabIndex = 4;
            this.F5.TabStop = false;
            this.F5.Click += new System.EventHandler(this.OnSubtitleKeyClicked);
            // 
            // F4
            // 
            this.F4.Image = ((System.Drawing.Image)(resources.GetObject("F4.Image")));
            this.F4.Location = new System.Drawing.Point(38, 327);
            this.F4.Name = "F4";
            this.F4.Size = new System.Drawing.Size(75, 75);
            this.F4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F4.TabIndex = 3;
            this.F4.TabStop = false;
            this.F4.Click += new System.EventHandler(this.OnSubtitleKeyClicked);
            // 
            // F3
            // 
            this.F3.Image = ((System.Drawing.Image)(resources.GetObject("F3.Image")));
            this.F3.Location = new System.Drawing.Point(38, 232);
            this.F3.Name = "F3";
            this.F3.Size = new System.Drawing.Size(75, 75);
            this.F3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F3.TabIndex = 2;
            this.F3.TabStop = false;
            this.F3.Click += new System.EventHandler(this.OnSubtitleKeyClicked);
            // 
            // F2
            // 
            this.F2.Image = ((System.Drawing.Image)(resources.GetObject("F2.Image")));
            this.F2.Location = new System.Drawing.Point(38, 138);
            this.F2.Name = "F2";
            this.F2.Size = new System.Drawing.Size(75, 75);
            this.F2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F2.TabIndex = 1;
            this.F2.TabStop = false;
            this.F2.Click += new System.EventHandler(this.OnSubtitleKeyClicked);
            // 
            // F1
            // 
            this.F1.Image = ((System.Drawing.Image)(resources.GetObject("F1.Image")));
            this.F1.Location = new System.Drawing.Point(38, 44);
            this.F1.Name = "F1";
            this.F1.Size = new System.Drawing.Size(75, 75);
            this.F1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.F1.TabIndex = 0;
            this.F1.TabStop = false;
            this.F1.Click += new System.EventHandler(this.OnSubtitleKeyClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(1602, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "|";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblClientsCount
            // 
            this.lblClientsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClientsCount.AutoSize = true;
            this.lblClientsCount.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClientsCount.Location = new System.Drawing.Point(1332, 15);
            this.lblClientsCount.Name = "lblClientsCount";
            this.lblClientsCount.Size = new System.Drawing.Size(247, 31);
            this.lblClientsCount.TabIndex = 5;
            this.lblClientsCount.Text = "Contagem de clientes: ";
            this.lblClientsCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::projERPMercearia.Properties.Resources.logo;
            this.pictureBox6.Location = new System.Drawing.Point(46, 106);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(655, 207);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 6;
            this.pictureBox6.TabStop = false;
            // 
            // FrmPDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1902, 1080);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.lblClientsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbxCaption);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.gbxPDV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FrmPDV";
            this.Text = "frmPDV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbxPDV.ResumeLayout(false);
            this.gbxPDV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShoppingCart)).EndInit();
            this.gbxCaption.ResumeLayout(false);
            this.gbxCaption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.F6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.F5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.F4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.F3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.F2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.F1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxPDV;
        private System.Windows.Forms.TextBox txtCashback;
        private System.Windows.Forms.TextBox txtFinalPrice;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox gbxCaption;
        private System.Windows.Forms.PictureBox F1;
        private System.Windows.Forms.PictureBox F5;
        private System.Windows.Forms.PictureBox F4;
        private System.Windows.Forms.PictureBox F3;
        private System.Windows.Forms.PictureBox F2;
        private System.Windows.Forms.Label lblFinish;
        private System.Windows.Forms.Label lblCancel;
        private System.Windows.Forms.Label lblMultiply;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblOpenERP;
        private System.Windows.Forms.DataGridView dgvShoppingCart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblClientsCount;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Label lblreturn;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmEAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPrice;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.PictureBox F6;
    }
}