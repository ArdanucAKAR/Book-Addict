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
        public static List<Book> GetBooks()
        {
            List<Book> Books = new List<Book>();
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/Books", Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Books = JsonConvert.DeserializeObject<List<Book>>(response.Content);
                return Books;
            }
            else
                return null;
        }

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

        public static List<Author> GetAuthors()
        {
            List<Author> Authors = new List<Author>();
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/Authors", Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Authors = JsonConvert.DeserializeObject<List<Author>>(response.Content);
                return Authors;
            }
            else
                return null;
        }

        public static Book GetBook(Book book)
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/Books/" + book.ID, Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                book = JsonConvert.DeserializeObject<Book>(response.Content);
                return book;
            }
            else
                return null;
        }
    }
}