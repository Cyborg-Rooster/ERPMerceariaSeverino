using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projERPMercearia.View
{
    public partial class FrmCashback : Form
    {
        public double Value;
        public bool isDouble = false;
        public FrmCashback(string caption, string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        private void OnTxtValueKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void OnBtnOkClicked(object sender, EventArgs e)
        {
            if (CheckRequirements()) DialogResult = DialogResult.OK;
        }

        private void OnBtnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool CheckRequirements()
        {
            bool required = true;

            if (txtValue.Text == string.Empty)
            {
                MessageBox.Show
                (
                    "Adicione um valor válido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                required = false;
            }

            else if (!DoubleFormatter.TryParse(txtValue.Text, out double value))
            {
                MessageBox.Show
                (
                    "Adicione um valor válido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                required = false;
            }
            else 
            { 
                Value = value;
                if (txtValue.Text.Contains('.')) isDouble = true;
            }

            return required;
        }
    }
}
