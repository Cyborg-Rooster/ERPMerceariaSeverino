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
    public partial class UscAdjustProduct : UserControl
    {
        double input = 0;
        double MovedQuantity = 0;
        char Operation = '-';
        bool Checked = false;

        Product Product;
        public UscAdjustProduct(Product product)
        {
            Product = product;
            InitializeComponent();
            txtEAN.Text = Product.EAN;
        }

        private void OnTxtQuantityKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) e.Handled = true;
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) e.Handled = true;
        }

        private void OnBtnCheckPressed(object sender, EventArgs e)
        {
            Checked = true;
            if (!double.TryParse(txtQuantity.Text, out input)) txtQuantity.Text = DoubleFormatter.ConvertDoubleToString(input);
            else input = DoubleFormatter.ConvertStringToDouble(txtQuantity.Text);

            MovedQuantity = Product.Quantity - input;
            if (MovedQuantity < 0)
            {
                Operation = '+';
                MovedQuantity *= -1;
            }
            else Operation = '-';

            txtCheck.Text = $"Quantidade atual: {DoubleFormatter.ConvertDoubleToString(Product.Quantity)} | Quantidade conferida: {DoubleFormatter.ConvertDoubleToString(input)}{Environment.NewLine}" +
                            $"Quantidade alterada: {Operation} {MovedQuantity}";
        }

        private void OnButtonSearchClicked(object sender, EventArgs e)
        {
            if (UserControlController.ProductFinded()) Product = UserControlController.productTemp;
            txtEAN.Text = Product.EAN;
        }

        private void OnBtnClearPressed(object sender, EventArgs e)
        {
            txtQuantity.Text = string.Empty;
            txtWhy.Text = string.Empty;
            txtCheck.Text = string.Empty;
            Checked = false;
            Operation = '-';
            input = 0;
        }

        private void OnBtnSavePressed(object sender, EventArgs e)
        {
            if(CheckRequirementsAreComplete())
            {
                OnBtnCheckPressed(null, null);
                var save = MessageBox.Show
                (
                    $"Tem certeza que deseja modificar o estoque com essa quantidade? A quantidade final ficará {DoubleFormatter.ConvertDoubleToString(input)}.",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if(save == DialogResult.Yes)
                {
                    Product.Quantity = input;

                    ProductMovement movement = new ProductMovement()
                    {
                        ID = DatabaseController.SelectCount("PRODUCT_MOVEMENTS", "ID") + 1,
                        ProductID = Product.ID,
                        MovedQuantity = MovedQuantity,
                        FinalQuantity = Product.Quantity,
                        DateHour = CommonQuery.ReturnDateTimeFormat(DateTime.Now),
                        Type = Operation,
                        Why = $"Movimentação manual via ajuste de estoque: \"{txtWhy.Text}\"."
                    };

                    DatabaseController.Update
                    (
                        "PRODUCT",
                        $"QUANTITY = '{DoubleFormatter.ConvertDoubleToString(Product.Quantity)}'",
                        $"ID = {Product.ID}"
                    );

                    DatabaseController.Add
                    (
                        "PRODUCT_MOVEMENTS",
                        "ID, ID_PRODUCT, MOVEMENTS_DATE, MOVEMENT_TYPE, MOVED_QUANTITY, FINAL_QUANTITY, WHY",
                        $"{movement.ID}, {movement.ProductID}, {movement.DateHour}, '{movement.Type}', " +
                        $"'{DoubleFormatter.ConvertDoubleToString(movement.MovedQuantity)}', '{DoubleFormatter.ConvertDoubleToString(movement.FinalQuantity)}', '{movement.Why}'"
                    );

                    MessageBox.Show
                    (
                        "Produtos movimentados com sucesso!",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    OnBtnClearPressed(null, null);
                }
            }
        }

        private bool CheckRequirementsAreComplete()
        {
            bool complete = true;
            bool inputFilled = txtWhy.Text != string.Empty;

            if(!inputFilled)
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
            else if(!Checked)
            {
                complete = false;
                MessageBox.Show
                (
                    "Faça a conferência antes de continuar.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return complete;
        }
    }
}
