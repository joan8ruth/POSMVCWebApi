using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POSMVCWebAPIClient.Models
{
    public class Item
    {
        public string ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Index { get; set; }


    }
}