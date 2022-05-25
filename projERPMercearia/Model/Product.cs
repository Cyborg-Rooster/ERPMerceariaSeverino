using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projERPMercearia.Model
{
    public class Product
    {
        public int ID { get; set; }
        public string EAN { get; set; }
        public string DateEAN { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }
        public bool Unity { get; set; }
        public double Price { get; set; }
        public double Profit { get; set; }
        public string DatePrice { get; set; }
        public double Quantity { get; set; }
    }
}
