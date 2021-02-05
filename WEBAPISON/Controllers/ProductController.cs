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
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<Products> GetApiData()
        {
          var apiUrl = "https://northwind.now.sh/api/products"; 
            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Products> jsonList = ser.Deserialize<List<Products>>(json);

            //END

            return jsonList;
        }
        
        [HttpGet]
        public Products GetApiData(int id)
        {
            var apiUrl = "https://northwind.now.sh/api/products/"+id;
            //Connect API
            Uri url = new Uri(apiUrl);
            WebClient client = new WebClient();
            client.Encoding = System.Text.Encoding.UTF8;

            string json = client.DownloadString(url);
            //END

            //JSON Parse START
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Products jsonList = ser.Deserialize<Products>(json);

            //END

            return jsonList;
        }


        [HttpPost]
        public HttpResponseMessage PostProduct([FromBody]Products prod)
        {
            
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            // prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            var jsonString = JsonConvert.SerializeObject(prod);
            var content = new StringContent(jsonString, Encoding.UTF8,"application/json");
            var result = client.PostAsync("api/products", content).Result;
            return result;
        }
        [HttpPut]
        public HttpResponseMessage PutProduct([FromBody]Products prod, int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            // prod.SupplierID = Convert.ToInt32(txtsupplierid.Text);
            var jsonString = JsonConvert.SerializeObject(prod);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var result = client.PutAsync("api/products/"+ID, content).Result;
            return result;
        }
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(int ID)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("https://northwind.now.sh/");
            var result = client.DeleteAsync("api/products/" + ID).Result;
            return result;
        }
    }



    }

    

  
