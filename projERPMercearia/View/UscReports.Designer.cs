
namespace projERPMercearia.View
{
    partial class UscReports
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
            this.dtpSince = new System.Windows.Forms.DateTimePicker();
            this.lblSince = new System.Windows.Forms.Label();
            this.lblUntil = new System.Windows.Forms.Label();
            this.dtpUntil = new System.Windows.Forms.DateTimePicker();
            this.cbxFilter = new System.Windows.Forms.CheckBox();
            this.cbbSections = new System.Windows.Forms.ComboBox();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.clnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnClientsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnGross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clnNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(52, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(148, 37);
            this.lblTitle.TabIndex = 13;
            this.lblTitle.Text = "Relatórios";
            // 
            // dtpSince
            // 
            this.dtpSince.Location = new System.Drawing.Point(52, 109);
            this.dtpSince.Name = "dtpSince";
            this.dtpSince.Size = new System.Drawing.Size(195, 27);
            this.dtpSince.TabIndex = 14;
            // 
            // lblSince
            // 
            this.lblSince.AutoSize = true;
            this.lblSince.Location = new System.Drawing.Point(52, 79);
            this.lblSince.Name = "lblSince";
            this.lblSince.Size = new System.Drawing.Size(54, 20);
            this.lblSince.TabIndex = 15;
            this.lblSince.Text = "Desde:";
            // 
            // lblUntil
            // 
            this.lblUntil.AutoSize = true;
            this.lblUntil.Location = new System.Drawing.Point(290, 79);
            this.lblUntil.Name = "lblUntil";
            this.lblUntil.Size = new System.Drawing.Size(35, 20);
            this.lblUntil.TabIndex = 17;
            this.lblUntil.Text = "Até:";
            // 
            // dtpUntil
            // 
            this.dtpUntil.Location = new System.Drawing.Point(290, 109);
            this.dtpUntil.Name = "dtpUntil";
            this.dtpUntil.Size = new System.Drawing.Size(195, 27);
            this.dtpUntil.TabIndex = 16;
            // 
            // cbxFilter
            // 
            this.cbxFilter.AutoSize = true;
            this.cbxFilter.Location = new System.Drawing.Point(52, 152);
            this.cbxFilter.Name = "cbxFilter";
            this.cbxFilter.Size = new System.Drawing.Size(138, 24);
            this.cbxFilter.TabIndex = 18;
            this.cbxFilter.Text = "Filtrar por Setor:";
            this.cbxFilter.UseVisualStyleBackColor = true;
            this.cbxFilter.CheckedChanged += new System.EventHandler(this.OnCbxFilterCheckedChanged);
            // 
            // cbbSections
            // 
            this.cbbSections.Enabled = false;
            this.cbbSections.FormattingEnabled = true;
            this.cbbSections.Location = new System.Drawing.Point(290, 148);
            this.cbbSections.Name = "cbbSections";
            this.cbbSections.Size = new System.Drawing.Size(195, 28);
            this.cbbSections.TabIndex = 19;
            // 
            // dgvReport
            // 
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnDate,
            this.clnClientsNumber,
            this.clnGross,
            this.clnNet});
            this.dgvReport.Location = new System.Drawing.Point(52, 195);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 29;
            this.dgvReport.Size = new System.Drawing.Size(433, 199);
            this.dgvReport.TabIndex = 20;
            // 
            // clnDate
            // 
            this.clnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnDate.HeaderText = "Data";
            this.clnDate.MinimumWidth = 6;
            this.clnDate.Name = "clnDate";
            this.clnDate.ReadOnly = true;
            // 
            // clnClientsNumber
            // 
            this.clnClientsNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnClientsNumber.HeaderText = "Contagem de Clientes";
            this.clnClientsNumber.MinimumWidth = 6;
            this.clnClientsNumber.Name = "clnClientsNumber";
            this.clnClientsNumber.ReadOnly = true;
            // 
            // clnGross
            // 
            this.clnGross.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnGross.HeaderText = "Valor Bruto";
            this.clnGross.MinimumWidth = 6;
            this.clnGross.Name = "clnGross";
            this.clnGross.ReadOnly = true;
            // 
            // clnNet
            // 
            this.clnNet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clnNet.HeaderText = "Valor Liquído";
            this.clnNet.MinimumWidth = 6;
            this.clnNet.Name = "clnNet";
            this.clnNet.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(391, 400);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Procurar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.OnBtnSearchClicked);
            // 
            // UscReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.cbbSections);
            this.Controls.Add(this.cbxFilter);
            this.Controls.Add(this.lblUntil);
            this.Controls.Add(this.dtpUntil);
            this.Controls.Add(this.lblSince);
            this.Controls.Add(this.dtpSince);
            this.Controls.Add(this.lblTitle);
            this.Name = "UscReports";
            this.Size = new System.Drawing.Size(543, 443);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpSince;
        private System.Windows.Forms.Label lblSince;
        private System.Windows.Forms.Label lblUntil;
        private System.Windows.Forms.DateTimePicker dtpUntil;
        private System.Windows.Forms.CheckBox cbxFilter;
        private System.Windows.Forms.ComboBox cbbSections;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnClientsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnNet;
    }
}
