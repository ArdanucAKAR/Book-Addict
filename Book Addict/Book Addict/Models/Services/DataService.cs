using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Book_Addict
{
    public static class DataService
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/categories", Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                categories = JsonConvert.DeserializeObject<List<Category>>(response.Content);
                return categories;
            }
            else
                return null;
        }
    }
}