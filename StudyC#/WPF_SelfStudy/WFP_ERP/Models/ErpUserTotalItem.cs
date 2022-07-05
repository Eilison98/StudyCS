using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_ERP.Models
{
    class ErpUserTotalItem
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Department { get; set; }
        public string Rank { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string YearOfEntry { get; set; }

        public ErpUserTotalItem(string name, string age, string department, string rank,
                                string address, string dateofbirth, string yearofentry)
        {
            Name = name;
            Age = age;
            Department = department;
            Rank = rank;
            Address = address;
            DateOfBirth = dateofbirth;
            YearOfEntry = yearofentry;
        }
    }
}
