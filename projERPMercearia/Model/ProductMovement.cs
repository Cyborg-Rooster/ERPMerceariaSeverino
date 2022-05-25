using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projERPMercearia.Model
{
    class ProductMovement
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public double MovedQuantity { get; set; }
        public double FinalQuantity { get; set; }
        public string DateHour { get; set; }
        public string Why { get; set; }
        public char Type { get; set; }
    }
}
