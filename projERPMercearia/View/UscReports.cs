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
using System.Globalization;

namespace projERPMercearia.View
{
    public partial class UscReports : UserControl
    {
        DataGridView Reference;
        public UscReports()
        {
            InitializeComponent();
            Reference = dgvReport;
        }

        private void OnCbxFilterCheckedChanged(object sender, EventArgs e)
        {
            if (cbxFilter.Checked) OnCbxFilterIsChecked();
            else cbbSections.Enabled = false;
        }

        private void OnCbxFilterIsChecked()
        {
            cbbSections.Enabled = true;
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            cbbSections.Items.Clear();
            var itens = DatabaseController.SelectInArray("NAME", "SECTION");
            foreach (string item in itens)
            {
                cbbSections.Items.Add(item);
            }
        }

        private void OnBtnSearchClicked(object sender, EventArgs e)
        {
            dgvReport.Rows.Clear();

            if (!cbxFilter.Checked)
            {
                if (dgvReport.Columns.Count == 3) 
                { 
                    dgvReport.Columns.Clear();
                    dgvReport.Columns.AddRange(new DataGridViewColumn[]
                    {
                        clnDate, clnClientsNumber, clnGross, clnNet
                    });
                }

                dgvReport = DatabaseController.SelectValuesDataGridView
                (
                    dgvReport,
                    "PDV_DATE, CLIENTS_NUMB, GROSS_VALUE, NET_VALUE",
                    "PDV_INFO",
                    $"PDV_DATE >= '{dtpSince.Value.ToString("yyyy-M-d", CultureInfo.InvariantCulture)}' AND " +
                    $"PDV_DATE <= '{dtpUntil.Value.ToString("yyyy-M-d", CultureInfo.InvariantCulture)}'"
                );
            }
            else
            {
                if (dgvReport.Columns.Count == 4) dgvReport.Columns.Remove(dgvReport.Columns[1]);

                dgvReport = DatabaseController.SelectValuesDataGridView
                (
                    dgvReport,
                    "PROFIT_DATE, SECTION_ID, GROSS_VALUE, NET_VALUE",
                    "SECTION_PROFITS",
                    $"PROFIT_DATE >= '{dtpSince.Value.ToString("yyyy-M-d", CultureInfo.InvariantCulture)}' AND " +
                    $"PROFIT_DATE <= '{dtpUntil.Value.ToString("yyyy-M-d", CultureInfo.InvariantCulture)}' AND " +
                    $"SECTION_ID = {cbbSections.SelectedIndex + 1}"
                );
            }
        }
    }
}
