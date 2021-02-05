using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPISON.Models
{
    public class Orders
    {
        public int id { get; set; }
        public string customerid { get; set; }
        public int employeeid { get; set; }
        public string orderdate { get; set; }
        public string requireddate { get; set; }
        public string shippeddate { get; set; }
        public int shipvia { get; set; }
        public double freight { get; set; }
        public string shipname { get; set; }


    }
}