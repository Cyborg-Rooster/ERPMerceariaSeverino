using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projERPMercearia.Controller
{
    class Configuration
    {
        public static bool PDVopen = false;

        public static bool CheckIfPDVIsOpen()
        {
            if (!PDVopen) return false;
            else
            {
                MessageBox.Show
                (
                    "O caixa está aberto. Feche o caixa para poder acessar essa parte do sistema.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return true;
            }
        }

        public static bool CheckIfUserWantClosePDV()
        {
            if (!PDVopen) 
            {
                MessageBox.Show
                (
                    "O caixa está fechado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return false; 
            }
            else
            {
                var close = MessageBox.Show
                (
                    "Deseja fechar o caixa?",
                    "Atenção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (close == DialogResult.Yes) return true;
                else return false;
            }
        }
    }
}
