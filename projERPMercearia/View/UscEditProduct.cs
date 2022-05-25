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
    public partial class UscEditProduct : UserControl
    {
        Product Product;
        public UscEditProduct(Product product)
        {
            Product = product;
            InitializeComponent();
            PopulateValues();
        }

        private void PopulateValues()
        {
            dgvMovimentation.Rows.Clear();
            txtEAN.Text = Product.EAN;
            txtName.Text = Product.Name;
            txtPrice.Text = DoubleFormatter.ConvertDoubleToString(Product.Price);
            txtDescription.Text = Product.Description;
            dgvMovimentation = DatabaseController.SelectProductChangesDataGridView(dgvMovimentation, Product.ID);
        }

        private void OnBtnSearchClicked(object sender, EventArgs e)
        {
            if (UserControlController.ProductFinded()) Product = UserControlController.productTemp;
            txtEAN.Text = Product.EAN;
        }

        private void OnBtnSaveClicked(object sender, EventArgs e)
        {
            if (CheckRequirementsAreComplete())
            {
                var save = MessageBox.Show
                (
                    "Deseja editar esse produto?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (save == DialogResult.Yes)
                {
                    if(DoubleFormatter.ConvertStringToDouble(txtPrice.Text) != Product.Price)
                    {
                        DatabaseController.Add
                        (
                            "PRICE_CHANGES",
                            "ID_PRODUCT, PRICE, CHANGE_DATE",
                            $"{Product.ID}, '{txtPrice.Text}', {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                        );
                    }

                    DatabaseController.Add
                    (
                        "PRODUCT_CHANGES",
                        "ID_PRODUCT, CHANGE, CHANGE_DATE",
                        $"{Product.ID}, '{ReturnChanges(out Product)}', {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                    );

                    DatabaseController.Update
                    (
                        "PRODUCT",
                        $"NAME = '{Product.Name}', DESCRIPTION = '{Product.Description}', PRICE = '{txtPrice.Text}'",
                        $"ID = {Product.ID}"
                    );

                    MessageBox.Show
                    (
                        "Produtos editado com sucesso!",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    PopulateValues();
                }
            }
        }

        private bool CheckRequirementsAreComplete()
        {
            bool complete = true;
            bool inputFilled = txtName.Text != string.Empty && txtPrice.Text != string.Empty && txtDescription.Text != string.Empty;

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
            else if (CheckIfDontHaveChanges())
            {
                complete = false;
                MessageBox.Show
                (
                    "Não houve mudanças.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return complete;
        }

        private bool CheckIfDontHaveChanges()
        {
            return txtName.Text == Product.Name && txtPrice.Text == DoubleFormatter.ConvertDoubleToString(Product.Price) && 
                txtDescription.Text == Product.Description;
        }

        private string ReturnChanges(out Product product)
        {
            string changes = "";
            Product temp = Product;

            if (txtName.Text != Product.Name)
            {
                changes += $"Mudou o nome de {Product.Name} para {txtName.Text};{Environment.NewLine}";
                temp.Name = txtName.Text;
            }
            if(DoubleFormatter.ConvertStringToDouble(txtPrice.Text) != Product.Price)
            {
                changes += $"Mudou o preço de R${Product.Price:N2} para R${txtPrice.Text};{Environment.NewLine}";
                temp.Price = DoubleFormatter.ConvertStringToDouble(txtPrice.Text);
            }
            if(txtDescription.Text != Product.Description)
            {
                changes += $"Mudou a descrição de \"{Product.Description}\" para \"{txtDescription.Text}\";{Environment.NewLine}";
                temp.Description = txtDescription.Text;
            }

            product = temp;
            return changes;
        }

        private void OnTxtPriceKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }
    }
}
