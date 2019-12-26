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
        public static object Login(User user)
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/login", Method.POST);

            request.AddParameter("username", user.Username);
            request.AddParameter("password", user.Password);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JObject.Parse(response.Content);
                user.ID = jObject.GetValue("userID").ToString();
                user.Username = jObject.GetValue("userID").ToString();
                user.Password = jObject.GetValue("password").ToString();
                user.FullName = jObject.GetValue("userFullName").ToString();
                user.Mail = jObject.GetValue("mail").ToString();

                HttpCookie Cookie = null;
                if (HttpContext.Current.Response.Cookies["User"] != null)
                    Cookie = HttpContext.Current.Response.Cookies["User"];
                else
                    Cookie = new HttpCookie("User");

                Cookie.Expires = DateTime.Now.AddDays(3);
                Cookie["Token"] = jObject.GetValue("token").ToString();

                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
            else
                return null;

            return user;
        }

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

        public static User Register(User user)
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/users/add", Method.POST);

            request.AddParameter("username", user.Username);
            request.AddParameter("password", user.Password);
            request.AddParameter("fullName", user.FullName);
            request.AddParameter("mail", user.Mail);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var jObject = JObject.Parse(response.Content);
                user.ID = jObject.GetValue("userID").ToString();
                user.Username = jObject.GetValue("userID").ToString();
                user.Password = jObject.GetValue("password").ToString();
                user.FullName = jObject.GetValue("userFullName").ToString();
                user.Mail = jObject.GetValue("mail").ToString();

                HttpCookie Cookie = null;
                if (HttpContext.Current.Response.Cookies["User"] != null)
                    Cookie = HttpContext.Current.Response.Cookies["User"];
                else
                    Cookie = new HttpCookie("User");

                Cookie.Expires = DateTime.Now.AddDays(3);
                Cookie["Token"] = jObject.GetValue("token").ToString();

                HttpContext.Current.Response.Cookies.Add(Cookie);
            }
            else
                return null;

            return user;
        }
    }
}