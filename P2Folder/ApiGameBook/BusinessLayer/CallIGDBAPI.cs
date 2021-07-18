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
            //	search "vegas"; fields name; limit 500;
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

        public string[] SearchGameById(int gameId)
        {
            var client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; where id = "+ gameId + ";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            List<string> gamesList = new List<string>();

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            if (myObject != null && myObject.Count != 0)
            {
                return myObject[0];
            }
            return null;
        }

        public List<string> SearchGamesByGenre(string genreName)
        {
            //put genre search here
            return null;
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
