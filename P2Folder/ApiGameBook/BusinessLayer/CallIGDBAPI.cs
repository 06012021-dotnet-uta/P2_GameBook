using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RepositoryLayer;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CallIGDBAPI
    {
        private gamebookdbContext _context;
        private readonly ILogger<GameRatingMethods> _logger;

        public CallIGDBAPI(gamebookdbContext context)
        {
            _context = context;
        }
        public CallIGDBAPI(ILogger<GameRatingMethods> logger, gamebookdbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public CallIGDBAPI()
        {
        }

        public List<string> GamesList(int page)
        {
            var client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; limit 500;";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            List<string> gamesList = new List<string>();

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            foreach (var i in myObject)
            {
                string str = i.name.ToString();
                gamesList.Add(str);
            }
            return gamesList;
        }

        public List<string> SearchByWordsInTitle(string wordToSearch)
        {
         
            var client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; search """ + wordToSearch + @"""; limit 500;";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            List<string> gamesList = new List<string>();

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            foreach (var i in myObject)
            {
                string str = i.name.ToString();
                gamesList.Add(str);
            }
            return gamesList;
        }

        public string SearchGameById(int gameId)
        {
            var client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; where id = " + gameId + ";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);


            if (myObject != null && myObject.Count != 0)
            {
                var array = myObject[0];
                string game = array.name;
                return game;
               
            }
            return null;
        }

        public List<string> SearchGamesByGenre(string genreName)
        {
            //search genre table
            int genreId = 0;
            var client = new RestClient("https://api.igdb.com/v4/genres");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; where name = """ + genreName + @""";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            if (myObject != null && myObject.Count != 0)
            {
                var array = myObject[0];
                genreId = array.id;
            }

            client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            body = @"fields name, genres; where genres = ("+ genreId + "); limit 500;";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            response = client.Execute(request);

            dynamic myObject2 = JsonConvert.DeserializeObject(response.Content);
            List<string> gamesList = new List<string>();
            foreach (var i in myObject2)
            {
                string str = i.name.ToString();
                gamesList.Add(str);
            }
            return gamesList;
        }

        public List<string> SearchGamesByCollection(string genreName)
        {
            //put collection search here
            return null;
        }

        public List<string> SearchGamesByKeyword(string genreName)
        {
            //put keyword search here
            return null;
        }
    }

}
