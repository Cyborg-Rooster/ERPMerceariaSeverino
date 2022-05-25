using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projERPMercearia.Controller
{
    class UserControlHelper
    {
        public static void AddControl(Panel parent, UserControl control)
        {
            parent.Controls.Clear();
            parent.Controls.Add(ReturnFilledUserControl(control));
        }

        private static UserControl ReturnFilledUserControl(UserControl control)
        {
            control.Dock = DockStyle.Fill;
            return control;
        }
    }
}
