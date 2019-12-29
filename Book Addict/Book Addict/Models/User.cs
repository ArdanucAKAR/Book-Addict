using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Web;
using HttpCookie = System.Web.HttpCookie;

namespace Book_Addict
{
    public class User
    {
        public string ID { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Boş Geçilemez")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Ad Soyad Boş Geçilemez")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Mail Boş Geçilemez")]
        public string Mail { get; set; }
        public string Token { get; set; }

        public User Login()
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/login", Method.POST);

            request.AddParameter("username", Username);
            request.AddParameter("password", Password);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Singleton.GetInstance().User = JsonConvert.DeserializeObject<User>(response.Content);

                HttpCookie Cookie = null;
                if (HttpContext.Current.Response.Cookies["User"] != null)
                    Cookie = HttpContext.Current.Response.Cookies["User"];
                else
                    Cookie = new HttpCookie("User");

                Cookie.Expires = DateTime.Now.AddDays(3);
                Cookie["ID"] = Singleton.GetInstance().User.ID;
                Cookie["Token"] = Singleton.GetInstance().User.Token;

                HttpContext.Current.Response.Cookies.Add(Cookie);
                return Singleton.GetInstance().User;
            }
            else
                return null;
        }

        public object Add()
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/users/add", Method.POST);

            request.AddParameter("username", Username);
            request.AddParameter("password", Password);
            request.AddParameter("fullname", Fullname);
            request.AddParameter("mail", Mail);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var user = JsonConvert.DeserializeObject<User>(response.Content);

                HttpCookie Cookie = null;
                if (HttpContext.Current.Response.Cookies["User"] != null)
                    Cookie = HttpContext.Current.Response.Cookies["User"];
                else
                    Cookie = new HttpCookie("User");

                Cookie.Expires = DateTime.Now.AddDays(3);
                Cookie["ID"] = user.ID;
                Cookie["Token"] = user.Token;

                HttpContext.Current.Response.Cookies.Add(Cookie);
                return user;
            }
            else
                return null;
        }

        public void AddFavouriteAuthor(Author author)
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/users/" + ID + "/addFavoriteAuthor", Method.POST);

            request.AddParameter("authorid", author.ID);

            IRestResponse response = client.Execute(request);

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    var user = JsonConvert.DeserializeObject<User>(response.Content);

            //    HttpCookie Cookie = null;
            //    if (HttpContext.Current.Response.Cookies["User"] != null)
            //        Cookie = HttpContext.Current.Response.Cookies["User"];
            //    else
            //        Cookie = new HttpCookie("User");

            //    Cookie.Expires = DateTime.Now.AddDays(3);
            //    Cookie["Token"] = user.Token;

            //    HttpContext.Current.Response.Cookies.Add(Cookie);
            //    return user;
            //}
            //else
            //    return null;

        }

        public void AddFavouriteBook()
        {

        }

        public void AddFavouriteBookCategory()
        {

        }
    }
}