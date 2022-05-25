using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using projERPMercearia.Controller;
using projERPMercearia.Model;

namespace projERPMercearia.View
{
    public partial class UscAddProduct : UserControl
    {
        public UscAddProduct()
        {
            InitializeComponent();
            PopulateComboBox();
        }

        private void OnButtonClearClicked(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtEan.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            cbbSections.Text = string.Empty;
        }

        private void OnButtonEditClicked(object sender, EventArgs e)
        {
            FrmSection section = new FrmSection();
            section.ShowDialog();
            if (section.DialogResult == DialogResult.OK || section.DialogResult == DialogResult.Cancel) PopulateComboBox();
            section.Dispose();
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

        private void OnButtonSaveClicked(object sender, EventArgs e)
        {
            if(CheckRequirementsAreComplete())
            {
                var save = MessageBox.Show
                (
                    "Deseja criar o produto com esses dados?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (save == DialogResult.Yes)
                {
                    Product product = new Product()
                    {
                        ID = DatabaseController.SelectCount("PRODUCT", "ID") + 1,
                        EAN = txtEan.Text,
                        Name = txtName.Text,
                        Description = txtDescription.Text,
                        Section = new Section()
                        {
                            ID = cbbSections.SelectedIndex + 1,
                            Name = cbbSections.Text
                        },
                        Price = DoubleFormatter.ConvertStringToDouble(txtPrice.Text),
                        Profit = 0,
                        Unity = rbtUnity.Checked,
                        Quantity = 0
                    };

                    DatabaseController.Add
                    (
                        "EAN_CODES", 
                        "EAN, ID_PRODUCT, ADD_DATE", 
                        $"{product.EAN}, {product.ID}, {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                    );

                    DatabaseController.Add
                    (
                        "EAN_CHANGES",
                        "EAN_CODE, EAN_CHANGES_DATE, WHY",
                        $"{product.EAN}, {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}, '{CommonQuery.EanChangesWhyCommon}'"
                    );

                    DatabaseController.Add
                    (
                        "PRICE_CHANGES",
                        "ID_PRODUCT, PRICE, CHANGE_DATE",
                        $"{product.ID}, '{DoubleFormatter.ConvertDoubleToString(product.Price)}', {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                    );

                    DatabaseController.Add
                    (
                        "PRODUCT",
                        "ID, NAME, DESCRIPTION, ID_SECTION, PRICE, PROFIT, QUANTITY, UNITY",
                        $"'{product.ID}', '{product.Name}', '{product.Description}', '{product.Section.ID}', '{DoubleFormatter.ConvertDoubleToString(product.Price)}','{DoubleFormatter.ConvertDoubleToString(product.Profit)}', '{DoubleFormatter.ConvertDoubleToString(product.Quantity)}', {(product.Unity ? 1 : 0)}"
                    );

                    MessageBox.Show
                    (
                        "Produto criado com sucesso!",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    OnButtonClearClicked(null, null);
                }
            }
        }

        private void OnTxtPriceKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void OnTxtEanKeyPressed(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private bool CheckRequirementsAreComplete()
        {
            bool complete = true;
            bool inputFilled = txtDescription.Text != string.Empty && txtEan.Text != string.Empty &&
                txtName.Text != string.Empty && txtPrice.Text != string.Empty && cbbSections.Text != string.Empty;

            if (!inputFilled)
            {
                complete = false;
                MessageBox.Show
                (
                    "Preencha todos os campos.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if(!double.TryParse(txtPrice.Text, out double doubled))
            {
                complete = false;
                MessageBox.Show
                (
                    "Preço inválido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if (DatabaseController.ReturnIfExistElementInArray("EAN", "EAN_CODES", txtEan.Text))
            {
                complete = false;
                MessageBox.Show
                (
                    "EAN existente",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if (!DatabaseController.ReturnIfExistElementInArray("NAME", "SECTION", cbbSections.Text))
            {
                complete = false;
                MessageBox.Show
                (
                    "Setor inexistente",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if(Configuration.CheckIfPDVIsOpen()) complete = false;

            return complete;
        }
    }
}
