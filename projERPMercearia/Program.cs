using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using projERPMercearia.View;
using projERPMercearia.Controller;

namespace projERPMercearia
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DatabaseController.InitiateDatabase();

            //SQLiteHelper.RunQuery("delete from SECTION_PROFITS");
            //SQLiteHelper.RunQuery("drop table SECTION_PROFITS");
            //SQLiteHelper.RunQuery("DROP TABLE PDV_INFO");

            //SQLiteHelper.RunQuery("CREATE TABLE SECTION_PROFITS(PDV_ID INT, PROFIT_DATE STRING, SECTION_ID INT, GROSS_VALUE DOUBLE, NET_VALUE DOUBLE)");
            //SQLiteHelper.RunQuery("CREATE TABLE PDV_INFO(ID INT, PDV_DATE DATE, CLIENTS_NUMB INT, GROSS_VALUE DOUBLE, NET_VALUE DOUBLE)");

            Application.Run(new FrmMain());
        }
    }
}
