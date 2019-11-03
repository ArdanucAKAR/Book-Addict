using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Book_Addict.Models;

namespace Book_Addict.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "https://book-addict-api.herokuapp.com/";
        public ActionResult Index()
        {
            user EmpInfo = new user();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = client.GetAsync("api/v1/users/1").Result;

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    EmpInfo = JsonConvert.DeserializeObject<user>(EmpResponse);
                }
                return View(EmpInfo);
            }
        }
    }
}