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
using projERPMercearia.Model;

namespace projERPMercearia.View
{
    public partial class FrmSearch : Form
    {
        public Product productTemp;
        public FrmSearch()
        {
            InitializeComponent();
        }

        private void OnButtonSearch(object sender, EventArgs e)
        {
            if (txtProdName.Text != null)
            {
                dgvQuery.Rows.Clear();
                if (long.TryParse(txtProdName.Text, out long ean)) dgvQuery = DatabaseController.SelectProductDataGridView(dgvQuery, ean);
                else dgvQuery = DatabaseController.SelectProductDataGridView(dgvQuery, txtProdName.Text);
            }
        }

        private void OnAcceptButton(object sender, EventArgs e)
        {
            if (CheckIfCanReturnValue())
            {
                productTemp = DatabaseController.SelectProduct
                (
                    dgvQuery.Rows[dgvQuery.SelectedCells[0].RowIndex].Cells[0].Value.ToString()
                );
                DialogResult = DialogResult.OK;
            }
            else MessageBox.Show
            (
                "Selecione um valor válido.",
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }

        private bool CheckIfCanReturnValue()
        {
            return dgvQuery.SelectedCells.Cast<DataGridViewCell>().Select(c => c.RowIndex).Distinct().Count() > 0 && 
                !string.IsNullOrEmpty(dgvQuery.SelectedCells[0].Value?.ToString());
        }
    }
}
