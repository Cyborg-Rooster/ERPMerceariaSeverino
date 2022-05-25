using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projERPMercearia.View;
using projERPMercearia.Model;

namespace projERPMercearia.Controller
{
    class UserControlController
    {
        public static Product productTemp; 
        public static void SpawnAddProductControl(Panel parent)
        {
            UserControlHelper.AddControl(parent, new UscAddProduct());
        }

        public static void SpawnProductViewerControl(Panel parent)
        {
            UserControlHelper.AddControl(parent, new UscProductViewer(productTemp));
            productTemp = null;
        }

        public static void SpawnAddProductQuantityControl(Panel parent, Product product)
        {
            UserControlHelper.AddControl(parent, new UscAddProductQuantity(product));
            productTemp = null;
        }

        public static void SpawnAdjustProductQuantityControl(Panel parent, Product product)
        {
            UserControlHelper.AddControl(parent, new UscAdjustProduct(product));
            productTemp = null;
        }

        public static void SpawnProductEanViewerControl(Panel parent, Product product)
        {
            UserControlHelper.AddControl(parent, new UscProductEans(product));
            productTemp = null;
        }

        public static void SpawnProductEditControl(Panel parent, Product product)
        {
            UserControlHelper.AddControl(parent, new UscEditProduct(product));
            productTemp = null;
        }

        public static void SpawnProductPlateControl(Panel parent)
        {
            UserControlHelper.AddControl(parent, new UscProductPlate());
        }

        public static void SpawnReportsControl(Panel parent)
        {
            UserControlHelper.AddControl(parent, new UscReports());
        }

        public static void SpawnSectionReports(Panel parent)
        {
            UserControlHelper.AddControl(parent, new UscSectorReports());
        }

        public static void SpawnShoppingList(Panel parent)
        {
            UserControlHelper.AddControl(parent, new UscShoppingList());
        }

        public static bool ProductFinded()
        {
            bool finded = true;
            FrmSearch search = new FrmSearch();

            if (search.ShowDialog() == DialogResult.OK) productTemp = search.productTemp;
            else finded = false;

            search.Dispose();
            return finded;
        }
    }
}
