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
    public partial class UscAddProductQuantity : UserControl
    {
        Product Product;
        public UscAddProductQuantity(Product product)
        {
            Product = product;
            InitializeComponent();
            SetProductValues();
        }

        private void OnButtonSearchClicked(object sender, EventArgs e)
        {
            if (UserControlController.ProductFinded()) Product = UserControlController.productTemp;
            SetProductValues();
        }

        private void SetProductValues()
        {
            txtEAN.Text = Product.EAN;
            txtProductPrice.Text = Product.Price.ToString("N2").Replace(',', '.');
        }

        private void OnButtonClearClicked(object sender, EventArgs e)
        {
            txtQuantity.Text = string.Empty;
            txtPricePaid.Text = string.Empty;
        }

        private bool CheckRequirementsAreComplete()
        {
            bool complete = true;
            bool inputFilled = txtEAN.Text != string.Empty && txtPricePaid.Text != string.Empty &&
                txtProductPrice.Text != string.Empty && txtQuantity.Text != string.Empty;

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

            else if (!double.TryParse(txtPricePaid.Text, out double doubled))
            {
                complete = false;
                MessageBox.Show
                (
                    "Preço pago inválido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if (!double.TryParse(txtProductPrice.Text, out double otherDoubled))
            {
                complete = false;
                MessageBox.Show
                (
                    "Preço novo inválido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if (double.Parse(txtQuantity.Text) < 1)
            {
                complete = false;
                MessageBox.Show
                (
                    "Adicione uma quantidade válida.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return complete;
        }

        private void OnTxtQuantityKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if (!Product.Unity && (e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void OnTxtPriceKeyPressed(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            if (CheckRequirementsAreComplete())
            {
                var save = MessageBox.Show
                (
                    "Deseja dar entrada nesse produto?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if(save == DialogResult.Yes)
                {
                    Product.Quantity += DoubleFormatter.ConvertStringToDouble(txtQuantity.Text);
                    string profit = DoubleFormatter.ConvertDoubleToString
                    ( 
                        DoubleFormatter.ConvertStringToDouble(txtProductPrice.Text) - 
                        DoubleFormatter.ConvertStringToDouble(txtPricePaid.Text)
                    );

                    ProductMovement movement = new ProductMovement()
                    {
                        ID = DatabaseController.SelectCount("PRODUCT_MOVEMENTS", "ID") + 1,
                        ProductID = Product.ID,
                        MovedQuantity = DoubleFormatter.ConvertStringToDouble(txtQuantity.Text),
                        FinalQuantity = Product.Quantity,
                        DateHour = CommonQuery.ReturnDateTimeFormat(DateTime.Now),
                        Type = '+',
                        Why = CommonQuery.AddProductWhyCommon
                    };

                    DatabaseController.Update
                    (
                        "PRODUCT",
                        $"QUANTITY = '{DoubleFormatter.ConvertDoubleToString(Product.Quantity)}', PRICE = '{txtProductPrice.Text}', PROFIT = '{profit}'",
                        $"ID = {Product.ID}"
                    );

                    if (Product.Price != Convert.ToDouble(txtProductPrice.Text))
                    {
                        DatabaseController.Add
                        (
                            "PRODUCT_CHANGES",
                            "ID_PRODUCT, CHANGE, CHANGE_DATE",
                            $"{Product.ID}, 'Mudou o preço de R${Product.Price:N2} para R${txtProductPrice.Text};{ Environment.NewLine}'," +
                            $" {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                        );

                        Product.Price = DoubleFormatter.ConvertStringToDouble(txtProductPrice.Text);

                        DatabaseController.Add
                        (
                            "PRICE_CHANGES",
                            "ID_PRODUCT, PRICE, CHANGE_DATE",
                            $"{Product.ID}, '{Product.Price}', {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                        );
                    }

                    DatabaseController.Add
                    (
                        "PRODUCT_MOVEMENTS",
                        "ID, ID_PRODUCT, MOVEMENTS_DATE, MOVEMENT_TYPE, MOVED_QUANTITY, FINAL_QUANTITY, WHY",
                        $"{movement.ID}, {movement.ProductID}, {movement.DateHour}, '{movement.Type}', " +
                        $"'{DoubleFormatter.ConvertDoubleToString(movement.MovedQuantity)}', '{DoubleFormatter.ConvertDoubleToString(movement.FinalQuantity)}', '{movement.Why}'"
                    );

                    MessageBox.Show
                    (
                        "Produtos adicionados com sucesso!",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    OnButtonClearClicked(null, null);
                }
            }
        }
    }
}
