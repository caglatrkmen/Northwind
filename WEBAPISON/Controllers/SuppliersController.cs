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

//[assembly:log4net.Config.XmlConfigurator(Watch =true)]

namespace WEBAPISON.Controllers
{
    public class SuppliersController : ApiController
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        [HttpGet]
        public List<Suppliers> GetApiData()
        {

            var apiUrl = "https://northwind.now.sh/api/suppliers";

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Suppliers> jsonList = ser.Deserialize<List<Suppliers>>(json);
            //END
            

            return jsonList;
        }
        [HttpGet]
        public Suppliers GetApiData(int id)
        {

            var apiUrl = "https://northwind.now.sh/api/suppliers/"+id;

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Suppliers jsonList = ser.Deserialize<Suppliers>(json);
            //END

            return jsonList;
        }
        [HttpPost]
        public HttpResponseMessage PostSuppliers([FromBody]Suppliers sup)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(sup);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/suppliers", content).Result;
            var response = result.StatusCode;
            log.Info("" + response);
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutSuppliers([FromBody]Suppliers sup, int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(sup);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PutAsync("api/suppliers/" +ID, content).Result;
            var response = result.StatusCode;
            log.Info("" + response);
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteSuppliers(int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/suppliers/" + ID).Result;
            var response = result.StatusCode;
            log.Error("" + response);
            return result;
        }
    }


}