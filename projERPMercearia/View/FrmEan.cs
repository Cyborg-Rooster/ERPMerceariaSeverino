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
    public partial class FrmEan : Form
    {
        public Product Product;
        public FrmEan(Product product)
        {
            Product = product;
            InitializeComponent();
            PopulateData();
        }

        private void PopulateData()
        {
            txtName.Text = Product.Name;
            txtOldEan.Text = Product.EAN;
        }

        private void OnTxtNewEanKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) e.Handled = true;
        }

        private bool CheckRequirementsAreComplete()
        {
            bool complete = true;
            bool inputFilled = txtNewEan.Text != string.Empty;

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

            else if (DatabaseController.ReturnIfExistElementInArray("EAN", "EAN_CODES", txtNewEan.Text))
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

            return complete;
        }

        private void OnBtnOkClicked(object sender, EventArgs e)
        {
            if (CheckRequirementsAreComplete())
            {
                var save = MessageBox.Show
                (
                    "Deseja salvar este EAN?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if(save == DialogResult.Yes)
                {
                    Product.EAN = txtNewEan.Text;

                    DatabaseController.Add
                    (
                        "EAN_CODES",
                        "EAN, ID_PRODUCT, ADD_DATE",
                        $"{Product.EAN}, {Product.ID}, {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}"
                    );

                    DatabaseController.Add
                    (
                        "EAN_CHANGES",
                        "EAN_CODE, EAN_CHANGES_DATE, WHY",
                        $"{Product.EAN}, {CommonQuery.ReturnDateTimeFormat(DateTime.Now)}, '{CommonQuery.EanChangesWhyUpdate}'"
                    );

                    MessageBox.Show
                    (
                        "EAN adicionado com sucesso!",
                        "Atenção",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
