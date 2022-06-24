using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_ERP.Models
{
    internal class ErpIteml
    {
        public string Name { get; set; }
        public string Number { get; set; }
        public string Quantity { get; set; }
        public string EA { get; set; }
        public string Price { get; set; }
        public string Place { get; set; }
        public string CustomerName { get; set; }

        public ErpIteml(string name, string number, string quantity, string ea,
                       string price, string place, string customername)
        {
            Name = name;
            Number = number;
            Quantity = quantity;
            EA = ea;
            Price = price;
            Place = place;
            CustomerName = customername;
        }
    }
}
