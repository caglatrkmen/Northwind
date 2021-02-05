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
    public class EmployessController : ApiController
    {
        [HttpGet]
        public List<Employess> GetApiData()
        {

            var apiUrl = "https://northwind.now.sh/api/employess";

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Employess> jsonList = ser.Deserialize<List<Employess>>(json);
            //END

            return jsonList;
        }
        [HttpGet]
        public Employess GetApiData(int id)
        {

            var apiUrl = "https://northwind.now.sh/api/employess/"+id;

            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Employess jsonList = ser.Deserialize<Employess>(json);
            //END

            return jsonList;
        }
        [HttpPost]
        public HttpResponseMessage PostEmployess([FromBody]Employess emp)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(emp);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PostAsync("api/employess", content).Result;
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutEmployess([FromBody]Employess emp, int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var jsonString = JsonConvert.SerializeObject(emp);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PutAsync("api/employess/" +ID, content).Result;
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteEmployess(int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/employess/" + ID).Result;
            return result;
        }
    }


}