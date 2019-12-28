using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Book_Addict
{
    public static class BookService
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

        public static List<Book> GetBooksByCategory(Category category)
        {
            List<Book> Books = new List<Book>();
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/Books/findByCategory" + category.ID, Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Books = JsonConvert.DeserializeObject<List<Book>>(response.Content);
                return Books;
            }
            else
                return null;
        }
    }
}