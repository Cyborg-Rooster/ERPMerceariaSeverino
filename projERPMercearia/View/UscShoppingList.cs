using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projERPMercearia.Controller;

namespace projERPMercearia.View
{
    public partial class UscShoppingList : UserControl
    {
        public UscShoppingList()
        {
            InitializeComponent();
        }

        private void OnBtnSearchClicked(object sender, EventArgs e)
        {
            if (txtFilter.Text == string.Empty) txtFilter.Text = 1.ToString();
            dgvProducts.Rows.Clear();
            dgvProducts = DatabaseController.SelectProductsWithQuantityLessThen10(dgvProducts, int.Parse(txtFilter.Text));
        }

        private void OnTxtFilterTextChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private void OnBtnPrintClicked(object sender, EventArgs e)
        {
            if (dgvProducts.Rows.Count > 0)
            {
                string[,] values = new string[dgvProducts.Rows.Count, 3];
                for (int i = 0; i < dgvProducts.Rows.Count; i++)
                {
                    values[i, 0] = dgvProducts.Rows[i].Cells[0].Value.ToString();
                    values[i, 1] = dgvProducts.Rows[i].Cells[1].Value.ToString();
                    values[i, 2] = dgvProducts.Rows[i].Cells[2].Value.ToString();
                }
                PlateController.CreateList(values, dgvProducts.Rows.Count);
                MessageBox.Show
                (
                    "Lista criada.",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show
                (
                    "Faça uma pesquisa antes de criar o documento.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
