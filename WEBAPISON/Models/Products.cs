using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPISON.Models
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public Boolean Discontinued { get; set; }
       



    }
}