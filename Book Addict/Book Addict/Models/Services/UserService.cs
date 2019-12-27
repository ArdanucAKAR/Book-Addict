using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using HttpCookie = System.Web.HttpCookie;

namespace Book_Addict
{
    public static class UserService
    {
        public static HttpCookie CheckToken()
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/checkToken", Method.POST);

            if (HttpContext.Current.Request.Cookies["User"] != null)
            {
                request.AddHeader("Authorization", HttpContext.Current.Request.Cookies["User"]["Token"]);
                IRestResponse response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                    return HttpContext.Current.Request.Cookies["User"];
                else
                    return null;
            }
            else
                return null;
        }

        public static User GetUser(User user)
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/Users/" + user.ID, Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                user = JsonConvert.DeserializeObject<User>(response.Content);
                return user;
            }
            else
                return null;
        }
    }
}