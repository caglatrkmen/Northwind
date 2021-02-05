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

[assembly: log4net.Config.XmlConfigurator(Watch=true)]
namespace WEBAPISON.Controllers
{
    
    public class CategoriesController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public List<Categories> GetApiData()
        {

            var apiUrl = "https://northwind.now.sh/api/categories";

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Categories> jsonList = ser.Deserialize<List<Categories>>(json);
            //END

            return jsonList;
        }
        [HttpGet]
        public Categories GetApiData(int id)
        {

            var apiUrl = "https://northwind.now.sh/api/categories/"+id;

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;
            
            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Categories jsonList = ser.Deserialize<Categories>(json);
            //END

            return jsonList;
        }
        [HttpPost]
        public HttpResponseMessage PostCategories([FromBody]Categories cat)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            // prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            var jsonString = JsonConvert.SerializeObject(cat);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/categories", content).Result;
            var response = result.StatusCode;
            log.Info("" + response);
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutCategories([FromBody]Categories cat, int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            // prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            var jsonString = JsonConvert.SerializeObject(cat);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/categories/" +ID, content).Result;
            var response = result.StatusCode;
            log.Info("" + response);
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteCategories(int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/categories/" + ID).Result;
            var response = result.StatusCode;
            log.Error(""+response);
            return result;
        }
    }


}