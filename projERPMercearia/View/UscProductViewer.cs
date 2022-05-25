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
    public partial class UscProductViewer : UserControl
    {
        Product Product;
        public UscProductViewer(Product _product)
        {
            InitializeComponent();
            Product = _product;
            PopulateData(Product);
        }

        public void PopulateData(Product product)
        {
            txtProductValues.Text = $"Nome: {product.Name}{Environment.NewLine}" +
                                    $"Setor: {product.Section.Name}{Environment.NewLine}" +
                                    $"Descrição: {product.Description}{Environment.NewLine}" +
                                    $"-------------------------------------------------------------------------{Environment.NewLine}" +
                                    $"EAN: {product.EAN}{Environment.NewLine}" +
                                    $"Data da última alteração de código EAN: {product.DateEAN}{Environment.NewLine}" +
                                    $"-------------------------------------------------------------------------{Environment.NewLine}" +
                                    $"Preço: R${product.Price:N2}{Environment.NewLine}" +
                                    $"Data da última alteração de preço: {product.DatePrice}{Environment.NewLine}" +
                                    $"-------------------------------------------------------------------------{Environment.NewLine}" +
                                    $"Quantidade atual: {product.Quantity:N2} {(product.Unity ? "uni" : "kg")}";

            dgvMovimentation = DatabaseController.SelectMovementDataGridView(dgvMovimentation, product.ID);
        }

        private void OnBtnAddClicked(object sender, EventArgs e)
        {
            if(!Configuration.CheckIfPDVIsOpen()) UserControlController.SpawnAddProductQuantityControl((Panel)Parent, Product);
        }

        private void OnBtnAdjustClicked(object sender, EventArgs e)
        {
            if (!Configuration.CheckIfPDVIsOpen()) UserControlController.SpawnAdjustProductQuantityControl((Panel)Parent, Product);
        }

        private void OnBtnEanClicked(object sender, EventArgs e)
        {
            if (!Configuration.CheckIfPDVIsOpen()) UserControlController.SpawnProductEanViewerControl((Panel)Parent, Product);
        }

        private void OnBtnEditClicked(object sender, EventArgs e)
        {
            if (!Configuration.CheckIfPDVIsOpen()) UserControlController.SpawnProductEditControl((Panel)Parent, Product);
        }
    }
}
