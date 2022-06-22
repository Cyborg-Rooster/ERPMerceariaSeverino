using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projERPMercearia.Model;
using System.Windows.Forms;

namespace projERPMercearia.Controller
{
    public static class BackupController
    {
        public static void CheckForBackups()
        {
            if (DatabaseController.SelectCount("PDV_INFO", "COUNT(ID)", "ID = (SELECT MAX(PDV_ID) FROM SECTION_PROFITS)") == 0)
                ReturnLastBackup();
        }

        static void ReturnLastBackup()
        {
            string[] PDVInfo = DatabaseController.SelectInArray("*", "SECTION_PROFITS", "PDV_ID = PDV_ID ORDER BY PDV_ID DESC LIMIT 1");
            int PDVId = int.Parse(PDVInfo[0]);
            string PDVDate = PDVInfo[1];

            string grossStringValue = DatabaseController.Select
            (
                "SECTION_PROFITS",
                "SUM(GROSS_VALUE)",
                $"PDV_ID = {PDVId}"
            );

            string netStringValue = DatabaseController.Select
            (
                "SECTION_PROFITS",
                "SUM(NET_VALUE)",
                $"PDV_ID = {PDVId}"
            );

            if (!DoubleFormatter.TryParse(grossStringValue, out double grossValue))
                grossValue = Convert.ToInt32(grossStringValue);

            if (!DoubleFormatter.TryParse(netStringValue, out double netValue))
                netValue = Convert.ToInt32(netStringValue);

            DatabaseController.Add
            (
                "PDV_INFO",
                "ID, PDV_DATE, CLIENTS_NUMB, GROSS_VALUE, NET_VALUE",
                $"{PDVId}, " +
                $"'{PDVDate}', " +
                $"{0}, " +
                $"{DoubleFormatter.ConvertDoubleToString(grossValue)}," +
                $"{DoubleFormatter.ConvertDoubleToString(netValue)}"
            );

            MessageBox.Show
            (
                "Foi encontrado um caixa que não foi fechado corretamente. " +
                "As informações de quantidade de clientes foi perdida.",
                "Aviso",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );
        }
    }
}
