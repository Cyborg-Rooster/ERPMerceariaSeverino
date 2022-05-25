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
            List<Product> products;

            dgvReport.Rows.Clear();

            if (cbbSections.Text == string.Empty) cbbSections.SelectedItem = cbbSections.Items[0];
            if (cbbProducts.Text == string.Empty) cbbProducts.SelectedItem = cbbProducts.Items[0];

            if (cbbSections.SelectedIndex != 0)
            {
                
                if (cbbProducts.SelectedIndex == 0) 
                { 
                    products = DatabaseController.SelectProductsListBySector($"PRODUCT.ID_SECTION = {cbbSections.SelectedIndex}");
                    for(int i = 0; i < products.Count; i++)
                    {
                        dgvReport.Rows.Add(new object[]
                        {
                            products[i].Name,
                            products[i].Quantity,
                            $"R${products[i].Profit * products[i].Quantity:N2}",
                            $"R${products[i].Price * products[i].Quantity:N2}"
                        });
                    }
                }
                else 
                {
                    products = DatabaseController.SelectProductsListBySector($"PRODUCT.ID_SECTION = {cbbSections.SelectedIndex} AND PRODUCT.NAME = '{cbbProducts.Text}'");
                    dgvReport.Rows.Add(new object[]
                    {
                        products[0].Name,
                        products[0].Quantity,
                        $"R${products[0].Profit * products[0].Quantity:N2}",
                        $"R${products[0].Price * products[0].Quantity:N2}"
                    });
                }
            }
            else 
            { 
                products = DatabaseController.SelectProductsListBySector("PRODUCT.ID_SECTION = PRODUCT.ID_SECTION");
                for (int i = 0; i < products.Count; i++)
                {
                    dgvReport.Rows.Add(new object[]
                    {
                        products[i].Name,
                        products[i].Quantity,
                        $"R${products[i].Profit * products[i].Quantity:N2}",
                        $"R${products[i].Price * products[i].Quantity:N2}"
                    });
                }
            }
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
    }
}
