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
    public partial class UscSectorReports : UserControl
    {
        double Profit, Price;
        List<Product> products;

        public UscSectorReports()
        {
            InitializeComponent();
            PopulateComboBox("NAME", "SECTION", cbbSections);
        }

        private void PopulateComboBox(string name, string section, ComboBox cbb)
        {
            var itens = DatabaseController.SelectInArray(name, section);
            foreach (string item in itens)
            {
                cbb.Items.Add(item);
            }
        }

        private void PopulateComboBox(string name, string section, string where, ComboBox cbb)
        {
            cbb.Items.Clear();
            cbb.Items.Add("TODOS OS PRODUTOS");

            var itens = DatabaseController.SelectInArray(name, section, where);
            foreach (string item in itens)
            {
                cbb.Items.Add(item);
            }
        }

        private void OnBtnSearchClicked(object sender, EventArgs e)
        {
            dgvReport.Rows.Clear();

            if (cbbSections.Text == string.Empty) cbbSections.SelectedItem = cbbSections.Items[0];
            if (cbbProducts.Text == string.Empty) cbbProducts.SelectedItem = cbbProducts.Items[0];

            if (cbbSections.SelectedIndex != 0)
            {
                if (cbbProducts.SelectedIndex == 0) FilterByProduct();
                else FilterProductBySector();
            }
            else FilterBySector();
        }

        private void OnCbbSectionsSelectIndexChanged(object sender, EventArgs e)
        {
            if (cbbSections.SelectedIndex == 0) cbbProducts.Enabled = false;
            else 
            {
                cbbProducts.Enabled = true;
                cbbProducts.Text = string.Empty;
                PopulateComboBox("NAME", "PRODUCT", $"ID_SECTION = {cbbSections.SelectedIndex}", cbbProducts); 
            }
        }

        private void FilterByProduct()
        {
            products = DatabaseController.SelectProductsListBySector($"PRODUCT.ID_SECTION = {cbbSections.SelectedIndex}");

            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Quantity > 0)
                {
                    Profit = products[i].Profit * products[i].Quantity;
                    Price = products[i].Price * products[i].Quantity;
                }
                else
                {
                    Profit = 0;
                    Price = 0;
                }

                dgvReport.Rows.Add(new object[]
                {
                    products[i].Name,
                    products[i].Quantity,
                    $"R${Profit:N2}",
                    $"R${Price:N2}"
                });
            }
        }

        private void FilterProductBySector()
        {
            products = DatabaseController.SelectProductsListBySector($"PRODUCT.ID_SECTION = {cbbSections.SelectedIndex} AND PRODUCT.NAME = '{cbbProducts.Text}'");

            if (products[0].Quantity > 0)
            {
                Profit = products[0].Profit * products[0].Quantity;
                Price = products[0].Price * products[0].Quantity;
            }
            else
            {
                Profit = 0;
                Price = 0;
            }

            dgvReport.Rows.Add(new object[]
            {
                products[0].Name,
                products[0].Quantity,
                $"R${Profit:N2}",
                $"R${Price:N2}"
            });
        }

        private void FilterBySector()
        {
            products = DatabaseController.SelectProductsListBySector("PRODUCT.ID_SECTION = PRODUCT.ID_SECTION");
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Quantity > 0)
                {
                    Profit = products[i].Profit * products[i].Quantity;
                    Price = products[i].Price * products[i].Quantity;
                }
                else
                {
                    Profit = 0;
                    Price = 0;
                }

                dgvReport.Rows.Add(new object[]
                {
                    products[i].Name,
                    products[i].Quantity,
                    $"R${Profit:N2}",
                    $"R${Price:N2}"
                });
            }
        }
    }
}
