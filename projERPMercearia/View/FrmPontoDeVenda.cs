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
    public partial class FrmPontoDeVenda : Form
    {

        public int ClientsNumber = 0;
        public int PDVId;

        Form FormParent;
        List<Product> ShoppingCart = new List<Product>();
        Product LastProduct;

        double Price = 0;
        bool Finish;

        public FrmPontoDeVenda(Form parent)
        {
            InitializeComponent();

            PDVId = DatabaseController.SelectCount("PDV_INFO", "*") + 1;

            FormParent = parent;
            lblClientsCount.Text = "Contagem de clientes: " + ClientsNumber;

            Timer timer = new Timer();
            timer.Tick += new EventHandler(TimerEventProcessor);
            timer.Interval = 1000;
            timer.Start();
        }

        private void TimerEventProcessor(Object Object, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        public void OnTxtProductEnterKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Finish)
                {
                    if (CheckInputsRequirements())
                    {
                        SetProduct(DatabaseController.SelectProduct
                        (
                            long.Parse(txtProduct.Text)
                        ));
                    }
                }
                else
                {
                    MessageBox.Show
                    (
                        "A compra está finalizada. Se você deseja adicionar mais produtos, cancele a mesma.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape && Finish)
            {
                ClientsNumber++;

                SubtractShoppingCartProducts();

                lblClientsCount.Text = "Contagem de clientes: " + ClientsNumber;
                Clear();
            }
            else if (keyData == Keys.F1)
            {
                FormParent.WindowState = FormWindowState.Normal;
                return true;
            }
            else if (keyData == Keys.F2)
            {
                GetProductManually();
                return true;
            }
            else if (keyData == Keys.F3)
            {
                if (LastProduct != null) MultiplyLastProduct();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return true;
            }
            else if (keyData == Keys.F4)
            {
                if (LastProduct != null) DeleteLastProduct();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return true;
            }
            else if (keyData == Keys.F5)
            {
                if (LastProduct != null) CancelPurchase();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return true;
            }
            else if (keyData == Keys.F6)
            {
                if (LastProduct != null) FinishPurchase();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetProduct(Product product)
        {
            LastProduct = product;

            ShoppingCart.Add(product);

            dgvShoppingCart.Rows.Add(new object[]{
                LastProduct.EAN,
                LastProduct.Name,
                1,
                $"R${LastProduct.Price:N2}"
            });

            Price += LastProduct.Price;

            dgvShoppingCart.Rows[dgvShoppingCart.Rows.Count - 1].
                DefaultCellStyle = ReturnDataGridViewRow();

            txtFinalPrice.Text = $"R${Price:N2}";
            txtProduct.Text = string.Empty;
            txtProduct.Focus();
        }

        private void CancelPurchase()
        {
            var cancel = MessageBox.Show
            (
                "Tem certeza que gostaria de cancelar a compra?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (cancel == DialogResult.Yes) Clear();
        }

        private void FinishPurchase()
        {
            var finish = MessageBox.Show
            (
                "Tem certeza que gostaria de finalizar a compra?",
                "Aviso",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (finish == DialogResult.Yes)
            {
                double value, cashback;
                FrmCashback frmCashback = new FrmCashback("Confirme o Valor", "Digite o valor pago:");
                if (frmCashback.ShowDialog() == DialogResult.OK)
                {
                    value = frmCashback.Value;
                    if (CheckIfValueIsValid(value, out cashback))
                    {
                        Finish = true;
                        txtCashback.Text = $"R${cashback:N2}";
                    }
                    else
                    {
                        MessageBox.Show
                        (
                            "Valor menor que o da compra.",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }

                frmCashback.Dispose();
            }
        }

        private void MultiplyLastProduct()
        {
            FrmCashback frmCashback = new FrmCashback("Multiplique o Produto", "Digite a quantidade para se multiplicar:");
            if (frmCashback.ShowDialog() == DialogResult.OK)
            {
                if (CheckIfValueIsValid(frmCashback.Value, frmCashback.isDouble))
                {
                    double currentAmount = double.Parse(dgvShoppingCart.Rows[dgvShoppingCart.Rows.Count - 1].Cells[2].Value.ToString());

                    if (frmCashback.Value < currentAmount) Price -= (LastProduct.Price * currentAmount) - LastProduct.Price;

                    dgvShoppingCart.Rows[dgvShoppingCart.Rows.Count - 1].Cells[2].Value = frmCashback.Value;
                    dgvShoppingCart.Rows[dgvShoppingCart.Rows.Count - 1].Cells[3].Value = $"R${LastProduct.Price * frmCashback.Value:N2}";

                    Price += (LastProduct.Price * frmCashback.Value) - LastProduct.Price;
                    txtFinalPrice.Text = $"R${Price:N2}";
                }
            }
            frmCashback.Dispose();
        }

        private void DeleteLastProduct()
        {
            Price -= ShoppingCart.Last().Price * double.Parse(dgvShoppingCart.Rows[dgvShoppingCart.Rows.Count - 1].Cells[2].Value.ToString());
            dgvShoppingCart.Rows.Remove(dgvShoppingCart.Rows[dgvShoppingCart.Rows.Count - 1]);
            ShoppingCart.Remove(ShoppingCart.Last());

            if (ShoppingCart.Count < 1) LastProduct = null;
            else LastProduct = ShoppingCart.Last();

            txtFinalPrice.Text = $"R${Price:N2}";
            txtProduct.Text = string.Empty;
            txtProduct.Focus();
        }

        private void GetProductManually()
        {
            if (UserControlController.ProductFinded())
            {
                SetProduct(UserControlController.productTemp);
                UserControlController.productTemp = null;
            }
        }

        private void Clear()
        {
            Finish = false;
            txtProduct.Text = string.Empty;
            dgvShoppingCart.Rows.Clear();
            Price = 0;
            ShoppingCart.Clear();

            txtFinalPrice.Text = $"R${Price:N2}";
            txtCashback.Text = $"R${0:N2}";
            LastProduct = null;
            txtProduct.Focus();
        }

        private void SubtractShoppingCartProducts()
        {
            for (int i = 0; i < ShoppingCart.Count; i++)
            {
                double quantitySold = GetProductQuantityFromList(i);
                ShoppingCart[i].Quantity -= quantitySold;

                ProductMovement movement = new ProductMovement()
                {
                    ID = DatabaseController.SelectCount("PRODUCT_MOVEMENTS", "ID") + 1,
                    ProductID = ShoppingCart[i].ID,
                    MovedQuantity = quantitySold,
                    FinalQuantity = ShoppingCart[i].Quantity,
                    DateHour = CommonQuery.ReturnDateTimeFormat(DateTime.Now),
                    Type = '-',
                    Why = CommonQuery.SubstractProductWhyCommon
                };

                #region "Atualiza a quantidade do produto da lista"
                DatabaseController.Update
                (
                    "PRODUCT",
                    $"QUANTITY = '{DoubleFormatter.ConvertDoubleToString(ShoppingCart[i].Quantity)}'",
                    $"ID = {ShoppingCart[i].ID}"
                );
                #endregion

                #region "Adiciona o relatorio de saida do produto"
                DatabaseController.Add
                (
                    "PRODUCT_MOVEMENTS",
                    "ID, ID_PRODUCT, MOVEMENTS_DATE, MOVEMENT_TYPE, MOVED_QUANTITY, FINAL_QUANTITY, WHY",
                    $"{movement.ID}, {movement.ProductID}, {movement.DateHour}, '{movement.Type}', " +
                    $"'{DoubleFormatter.ConvertDoubleToString(movement.MovedQuantity)}', '{DoubleFormatter.ConvertDoubleToString(movement.FinalQuantity)}', '{movement.Why}'"
                );
                #endregion

                if (DatabaseController.CheckIfExist("SECTION_PROFITS", "PROFIT_DATE", $"PDV_ID = {PDVId} AND SECTION_ID = {ShoppingCart[i].Section.ID}"))
                {
                    double actualProfit = DoubleFormatter.ConvertStringToDouble
                    (
                        DatabaseController.Select
                        (
                            "SECTION_PROFITS",
                            "NET_VALUE",
                            $"PROFIT_DATE = {CommonQuery.ReturnDateFormat(DateTime.Now)} " +
                            $"AND SECTION_ID = {ShoppingCart[i].Section.ID}"
                        )
                    );

                    double actualGrossValue = DoubleFormatter.ConvertStringToDouble
                    (
                        DatabaseController.Select
                        (
                            "SECTION_PROFITS",
                            "GROSS_VALUE",
                            $"PROFIT_DATE = {CommonQuery.ReturnDateFormat(DateTime.Now)} " +
                            $"AND SECTION_ID = {ShoppingCart[i].Section.ID}"
                        )
                    );

                    actualProfit += quantitySold * ShoppingCart[i].Profit;
                    actualGrossValue += quantitySold * ShoppingCart[i].Price;

                    DatabaseController.Update
                    (
                        "SECTION_PROFITS",
                        $"NET_VALUE = {DoubleFormatter.ConvertDoubleToString(actualProfit)}," +
                        $"GROSS_VALUE = {DoubleFormatter.ConvertDoubleToString(actualGrossValue)}",
                        $"PDV_ID = {PDVId} " +
                        $"AND SECTION_ID = { ShoppingCart[i].Section.ID}"
                    );
                }
                else
                {
                    DatabaseController.Add
                    (
                        "SECTION_PROFITS",
                        "PDV_ID, PROFIT_DATE, SECTION_ID, GROSS_VALUE, NET_VALUE",
                        $"{PDVId}, " +
                        $"{CommonQuery.ReturnDateFormat(DateTime.Now)}, " +
                        $"{ShoppingCart[i].Section.ID}, " +
                        $"{DoubleFormatter.ConvertDoubleToString(quantitySold * ShoppingCart[i].Price)}," +
                        $"{DoubleFormatter.ConvertDoubleToString(quantitySold * ShoppingCart[i].Profit)}"
                    );
                }
            }
        }

        private bool CheckIfValueIsValid(double value, out double cashback)
        {
            cashback = value - Price;
            return value >= Price;
        }

        private bool CheckIfValueIsValid(double value, bool isDouble)
        {
            if (LastProduct.Unity)
            {
                if (isDouble)
                {
                    MessageBox.Show
                    (
                        "Não é possível multiplicar produtos em unidade por decimal.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
            }
            else if (value < 0)
            {
                MessageBox.Show
                (
                    "Valor inválido.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false;
            }
            return true;
        }

        DataGridViewCellStyle ReturnDataGridViewRow()
        {
            DataGridViewRow row = new DataGridViewRow();

            if (dgvShoppingCart.Rows.Count % 2 == 0)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(240, 182, 199);
                row.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 182, 199);
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.White;
            }

            row.DefaultCellStyle.SelectionForeColor = Color.Black;
            row.DefaultCellStyle.Font = new Font("Segoe UI", 24f, GraphicsUnit.Pixel);

            return row.DefaultCellStyle;
        }

        bool CheckInputsRequirements()
        {
            bool result = true;

            if (txtProduct.Text == null || txtProduct.Text == "")
            {
                result = false;
                MessageBox.Show
                (
                    "Não há código EAN.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            else if (!DatabaseController.ReturnIfExistElementInArray("EAN", "EAN_CODES", txtProduct.Text))
            {
                result = false;
                MessageBox.Show
                (
                    "EAN não foi cadastrado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            return result;
        }

        double GetProductQuantityFromList(int position)
        {
            return double.Parse(dgvShoppingCart.Rows[position].Cells[2].Value.ToString());
        }

        private void OnSubtitleKeyClicked(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Name == "F1") 
            {
                if (FormParent.WindowState == FormWindowState.Minimized)
                    FormParent.WindowState = FormWindowState.Normal;
                else FormParent.WindowState = FormWindowState.Minimized;
            }
            if (((PictureBox)sender).Name == "F2") GetProductManually();
            if (((PictureBox)sender).Name == "F3")
            {
                if (LastProduct != null) MultiplyLastProduct();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            if (((PictureBox)sender).Name == "F4")
            {
                if (LastProduct != null) DeleteLastProduct();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            if (((PictureBox)sender).Name == "F5")
            {
                if (LastProduct != null) CancelPurchase();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            if (((PictureBox)sender).Name == "F6")
            {
                if (LastProduct != null) FinishPurchase();
                else
                {
                    MessageBox.Show
                    (
                        "A compra está vazia.",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        public void OnFormTryClose(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
