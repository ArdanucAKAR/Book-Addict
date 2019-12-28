using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Book_Addict
{
    public static class AuthorService
    {
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

        public static Author GetAuthor(Author author)
        {
            var client = new RestClient(Base.URL);
            var request = new RestRequest("api/v1/Authors/" + author.ID, Method.GET);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                author = JsonConvert.DeserializeObject<Author>(response.Content);
                return author;
            }
            else
                return null;
        }

    }
}