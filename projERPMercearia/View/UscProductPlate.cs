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
    public partial class UscProductPlate : UserControl
    {
        List<Product> products = new List<Product>();
        public UscProductPlate()
        {
            InitializeComponent();
        }

        private void OnReturnClickedOnTxtEAN(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OnBtnSubmmitClicked(null, null);
        }

        private void OnBtnSubmmitClicked(object sender, EventArgs e)
        {
            if(CheckIfInputIsValid())
            {
                Product product = DatabaseController.SelectProduct(long.Parse(txtEAN.Text));
                AddProductOnList(product);
            }
        }

        private void AddProductOnList(Product product)
        {
            dgvProductList.Rows.Add(new object[4]{
                    product.EAN,
                    product.Name,
                    $"R${product.Price:N2}",
                    product.Unity ? "UNI" : "KG"
            });
            txtEAN.Text = string.Empty;
            products.Add(product);
        }

        private bool CheckIfInputIsValid()
        {
            bool valid = true;
            if(txtEAN.Text == string.Empty)
            {
                valid = false;
                MessageBox.Show
                (
                    "Adicione um código EAN ou procure manualmente um produto com o botão \"Procurar\"",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            else if (!DatabaseController.ReturnIfExistElementInArray("EAN", "EAN_CODES", txtEAN.Text))
            {
                valid = false;
                MessageBox.Show
                (
                    "EAN existente",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return valid;
        }

        private void OnBtnSearchClicked(object sender, EventArgs e)
        {
            if (UserControlController.ProductFinded())
            {
                AddProductOnList(UserControlController.productTemp);
                UserControlController.productTemp = null;
            }
        }

        private void OnBtnClearClicked(object sender, EventArgs e)
        {
            dgvProductList.Rows.Clear();
            products.Clear();
        }

        private void OnBtnCreateClicked(object sender, EventArgs e)
        {
            PlateController.CreatePlate(products);
            OnBtnClearClicked(null, null);
        }
    }
}
