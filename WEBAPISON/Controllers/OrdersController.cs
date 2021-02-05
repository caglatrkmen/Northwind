using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using WEBAPISON.Models;
using Newtonsoft.Json;
using System.Text;

namespace WEBAPISON.Controllers
{
    public class OrdersController : ApiController
    {
        [HttpGet]
        public List<Orders> GetApiData()
        {

            var apiUrl = "https://northwind.now.sh/api/orders";

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Orders> jsonList = ser.Deserialize<List<Orders>>(json);
            //END

            return jsonList;
        }
        [HttpGet]
        public Orders GetApiData(int id)
        {

            var apiUrl = "https://northwind.now.sh/api/orders/"+id;

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Orders jsonList = ser.Deserialize<Orders>(json);
            //END

            return jsonList;
        }
        [HttpPost]
        public HttpResponseMessage PostOrders([FromBody]Orders ord)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            // prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            var jsonString = JsonConvert.SerializeObject(ord);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/orders", content).Result;
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutOrders([FromBody]Orders ord, int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(ord);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/orders/" +ID, content).Result;
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteOrders(int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/orders/" + ID).Result;
            return result;
        }
    }

}