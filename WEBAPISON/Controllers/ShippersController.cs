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
    public class ShippersController : ApiController
    {
        [HttpGet]
        public List<Shippers> GetApiData()
        {

            var apiUrl = "https://northwind.now.sh/api/shippers";

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END
            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Shippers> jsonList = ser.Deserialize<List<Shippers>>(json);
            //END

            return jsonList;
        }
        [HttpGet]
        public Shippers GetApiData(int id)
        {

            var apiUrl = "https://northwind.now.sh/api/shippers/"+id;

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Shippers jsonList = ser.Deserialize<Shippers>(json);
            //END

            return jsonList;
        }
        [HttpPost]
        public HttpResponseMessage PostShippers([FromBody]Shippers ship)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(ship);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/shippers", content).Result;
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutShippers([FromBody]Shippers ship, int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(ship);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PutAsync("api/shippers/" +ID, content).Result;
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteShippers(int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/shippers/" + ID).Result;
            return result;
        }
    }


}