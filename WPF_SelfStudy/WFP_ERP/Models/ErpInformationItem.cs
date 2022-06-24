using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFP_ERP.Models
{
    public class ErpInformationItem
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
        public string SubTitle { get; set; }
        public string PubDate { get; set; }
        public string Director { get; set; }
        public string Actor { get; set; }
        public string UserRating { get; set; }
    }
}
