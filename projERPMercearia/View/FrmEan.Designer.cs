
namespace projERPMercearia.View
{
    partial class FrmEan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEan));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtOldEan = new System.Windows.Forms.TextBox();
            this.txtNewEan = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblOldEan = new System.Windows.Forms.Label();
            this.lblNewEan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(412, 158);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(94, 29);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Concluído";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.OnBtnOkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(296, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Location = new System.Drawing.Point(28, 43);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(261, 27);
            this.txtName.TabIndex = 2;
            // 
            // txtOldEan
            // 
            this.txtOldEan.BackColor = System.Drawing.SystemColors.Window;
            this.txtOldEan.Location = new System.Drawing.Point(296, 43);
            this.txtOldEan.Name = "txtOldEan";
            this.txtOldEan.ReadOnly = true;
            this.txtOldEan.Size = new System.Drawing.Size(208, 27);
            this.txtOldEan.TabIndex = 3;
            // 
            // txtNewEan
            // 
            this.txtNewEan.Location = new System.Drawing.Point(28, 111);
            this.txtNewEan.Name = "txtNewEan";
            this.txtNewEan.Size = new System.Drawing.Size(476, 27);
            this.txtNewEan.TabIndex = 4;
            this.txtNewEan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTxtNewEanKeyPress);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(28, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(65, 20);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Produto:";
            // 
            // lblOldEan
            // 
            this.lblOldEan.AutoSize = true;
            this.lblOldEan.Location = new System.Drawing.Point(296, 15);
            this.lblOldEan.Name = "lblOldEan";
            this.lblOldEan.Size = new System.Drawing.Size(88, 20);
            this.lblOldEan.TabIndex = 6;
            this.lblOldEan.Text = "EAN antigo:";
            // 
            // lblNewEan
            // 
            this.lblNewEan.AutoSize = true;
            this.lblNewEan.Location = new System.Drawing.Point(28, 83);
            this.lblNewEan.Name = "lblNewEan";
            this.lblNewEan.Size = new System.Drawing.Size(78, 20);
            this.lblNewEan.TabIndex = 7;
            this.lblNewEan.Text = "EAN novo:";
            // 
            // FrmEan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(516, 200);
            this.Controls.Add(this.lblNewEan);
            this.Controls.Add(this.lblOldEan);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtNewEan);
            this.Controls.Add(this.txtOldEan);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(534, 247);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(534, 247);
            this.Name = "FrmEan";
            this.Text = "Adicionar novo EAN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtOldEan;
        private System.Windows.Forms.TextBox txtNewEan;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblOldEan;
        private System.Windows.Forms.Label lblNewEan;
    }
}