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
    public class CustomersController : ApiController
    {
        [HttpGet]
        public List<Customers> GetApiData()
        {

            var apiUrl = "https://northwind.now.sh/api/customers";

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Customers> jsonList = ser.Deserialize<List<Customers>>(json);
            //END

            return jsonList;
        }
        [HttpGet]
        public Customers GetApiData(string id)
        {

            var apiUrl = "https://northwind.now.sh/api/customers/"+id;

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Customers jsonList = ser.Deserialize<Customers>(json);
            //END

            return jsonList;
        }
        [HttpPost]
        public HttpResponseMessage PostCustomers([FromBody]Customers cus)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(cus);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/customers", content).Result;
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutCustomers([FromBody]Customers cus, string ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(cus);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PutAsync("api/customers/" +ID, content).Result;
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteCustomers(string ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/customers/" + ID).Result;
            return result;
        }
    }


}