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
    public partial class FrmMain : Form
    {
        string title = "ERP Mercearia Severino : ";
        //FrmPDV frmPDV;
        FrmPontoDeVenda frmPontoDeVenda;
        public FrmMain()
        {
            InitializeComponent();
            trvOptions.SelectedNode = trvOptions.Nodes[0].Nodes[0];
        }

        private void OnSelectedOptionList(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Name == "nodAddProducts" && !Configuration.CheckIfPDVIsOpen()) 
            {
                Text = title + "Cadastrar Produto";
                UserControlController.SpawnAddProductControl(pnlContent); 
            }

            else if (e.Node.Name == "nodShowProducts")
            {
                if (UserControlController.ProductFinded()) 
                {
                    Text = title + "Mostrar Produto";
                    UserControlController.SpawnProductViewerControl(pnlContent); 
                }
                else e.Cancel = true;
            }
            else if (e.Node.Name == "nodAdd" && !Configuration.CheckIfPDVIsOpen())
            {
                if (UserControlController.ProductFinded())
                {
                    Text = title + "Entrada de Estoque";
                    UserControlController.SpawnAddProductQuantityControl(pnlContent, UserControlController.productTemp); 
                }
                else e.Cancel = true;
            }
            else if (e.Node.Name == "nodMoveInventory" && !Configuration.CheckIfPDVIsOpen())
            {
                if (UserControlController.ProductFinded())
                {
                    Text = title + "Ajuste de Estoque";
                    UserControlController.SpawnAdjustProductQuantityControl(pnlContent, UserControlController.productTemp); 
                }
                else e.Cancel = true;
            }
            else if (e.Node.Name == "nodEAN" && !Configuration.CheckIfPDVIsOpen())
            {
                if (UserControlController.ProductFinded())
                {
                    Text = title + "Códigos de Barra";
                    UserControlController.SpawnProductEanViewerControl(pnlContent, UserControlController.productTemp);
                }
                else e.Cancel = true;
            }
            else if (e.Node.Name == "nodChange" && !Configuration.CheckIfPDVIsOpen())
            {
                if (UserControlController.ProductFinded())
                {
                    Text = title + "Editar Produto";
                    UserControlController.SpawnProductEditControl(pnlContent, UserControlController.productTemp);
                }
                else e.Cancel = true;
            }
            else if (e.Node.Name == "nodProductPlate")
            {
                Text = title + "Imprimir Etiqueta";
                UserControlController.SpawnProductPlateControl(pnlContent);
            }
            else if (e.Node.Name == "nodShoppingList")
            {
                Text = title + "Produtos Próximos à Zerar";
                UserControlController.SpawnShoppingList(pnlContent);
            }
            else if (e.Node.Name == "nodOpenPDV")
            {
                if (!Configuration.CheckIfPDVIsOpen())
                {
                    var open = MessageBox.Show
                    (
                        "Tem certeza que gostaria de abrir o caixa? Com o caixa aberto será impossível fazer alguns procedimentos no sistema.",
                        "Atenção",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (open == DialogResult.Yes)
                    {
                        Configuration.PDVopen = true;
                        /*frmPDV = new FrmPDV(this);
                        frmPDV.Show();*/
                        frmPontoDeVenda = new FrmPontoDeVenda(this);
                        frmPontoDeVenda.Show();
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
            }
            else if (e.Node.Name == "nodClosePDV")
            {
                if (Configuration.CheckIfUserWantClosePDV())
                {
                    string grossStringValue = DatabaseController.Select
                    (
                        "SECTION_PROFITS",
                        "SUM(GROSS_VALUE)",
                        $"PDV_ID = {frmPontoDeVenda.PDVId}"
                    );

                    string netStringValue = DatabaseController.Select
                    (
                        "SECTION_PROFITS",
                        "SUM(NET_VALUE)",
                        $"PDV_ID = {frmPontoDeVenda.PDVId}"
                    );

                    if (!DoubleFormatter.TryParse(grossStringValue, out double grossValue))
                        grossValue = Convert.ToInt32(grossStringValue);

                    if (!DoubleFormatter.TryParse(netStringValue, out double netValue))
                        netValue = Convert.ToInt32(netStringValue);

                    DatabaseController.Add
                    (
                        "PDV_INFO",
                        "ID, PDV_DATE, CLIENTS_NUMB, GROSS_VALUE, NET_VALUE",
                        $"{frmPontoDeVenda.PDVId}," +
                        $"{CommonQuery.ReturnDateFormat(DateTime.Now)}, " +
                        $"{frmPontoDeVenda.ClientsNumber}, " +
                        $"{DoubleFormatter.ConvertDoubleToString(grossValue)}," +
                        $"{DoubleFormatter.ConvertDoubleToString(netValue)}"
                    );

                    frmPontoDeVenda.FormClosing -= new FormClosingEventHandler(frmPontoDeVenda.OnFormTryClose);
                    frmPontoDeVenda.Close();

                    Configuration.PDVopen = false;
                }
            }
            else if (e.Node.Name == "nodReports" && !Configuration.CheckIfPDVIsOpen())
            {
                Text = title + "Relatórios";
                UserControlController.SpawnReportsControl(pnlContent);
            }
            else if (e.Node.Name == "nodSectorValue" && !Configuration.CheckIfPDVIsOpen())
            {
                Text = title + "Relatórios de Valor por Setor";
                UserControlController.SpawnSectionReports(pnlContent);
            }
        }

        private void AfterSelectedOptionList(object sender, TreeViewEventArgs e)
        {
            trvOptions.SelectedNode = trvOptions.Nodes[0];
        }
    }
}
