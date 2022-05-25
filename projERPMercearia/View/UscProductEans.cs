using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projERPMercearia.Model;
using projERPMercearia.Controller;

namespace projERPMercearia.View
{
    public partial class UscProductEans : UserControl
    {
        Product Product;
        public UscProductEans(Product product)
        {
            Product = product;
            InitializeComponent();
            PopulateValues();
        }

        private void OnBtnSearchClicked(object sender, EventArgs e)
        {
            if (UserControlController.ProductFinded()) Product = UserControlController.productTemp;
            PopulateValues();
        }

        private void PopulateValues()
        {
            txtEAN.Text = Product.EAN;
            dgvEan.Rows.Clear();
            dgvEan = DatabaseController.SelectProductEansDataGridView(dgvEan, Product.ID);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmEan ean = new FrmEan(Product);
            if (ean.ShowDialog() == DialogResult.OK) 
            { 
                Product = ean.Product;
                PopulateValues();
            }
            ean.Dispose();
        }
    }
}
