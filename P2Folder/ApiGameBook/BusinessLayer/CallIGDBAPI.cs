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
        private readonly ILogger<GameRatingMethods> _logger;

        public CallIGDBAPI(ILogger<GameRatingMethods> logger)
        {
            _logger = logger;
        }

        public CallIGDBAPI()
        {
        }

        public List<string> GamesList()
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
            body = @"fields name; where genres = ("+ genreId + "); limit 500;";
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

        public List<string> SearchGamesByCollection(string collectionName)
        {
            int collectionId = 0;
            var client = new RestClient("https://api.igdb.com/v4/collections");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; where name = """ + collectionName + @""";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            if (myObject != null && myObject.Count != 0)
            {
                var array = myObject[0];
                collectionId = array.id;
            }

            client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            body = @"fields name; where collection = " + collectionId + "; limit 500;";
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

        public List<string> SearchGamesByKeyword(string keywordName)
        {
            int keywordId = 0;
            var client = new RestClient("https://api.igdb.com/v4/keywords");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"fields name; where name = """ + keywordName + @""";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            if (myObject != null && myObject.Count != 0)
            {
                var array = myObject[0];
                keywordId = array.id;
            }

            client = new RestClient("https://api.igdb.com/v4/games");
            client.Timeout = -1;
            request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            body = @"fields name; where keywords = (" + keywordId + "); limit 500;";
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

        public string GameCoverArt(int gameID)
        {
            var client = new RestClient("https://api.igdb.com/v4/covers");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", " q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @" fields url; where game = " + gameID + ";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);
            if (myObject != null && myObject.Count != 0)
            {
                var array = myObject[0];
                string url = array.url;
                return url;
            }
            return null;
        }

        public List<string> GameScreenshots(int gameID)
        {
            var client = new RestClient("https://api.igdb.com/v4/screenshots");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", " q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @" fields * ; where game = " + gameID + ";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);

            List<string> picsList = new List<string>();

            if (myObject != null && myObject.Count != 0)
            {
                foreach (var i in myObject)
                {
                    string temp = i.url;
                    picsList.Add(temp);
                }
                return picsList;
            }

            return null;
        }

        public List<string> PicturesForTheGame(int gameID)
		{
            var client = new RestClient("https://api.igdb.com/v4/artworks");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", " q17vg91zyii02i7r72jjohbf0d6ggc");
            request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
            request.AddHeader("Content-Type", "text/plain");
            var body = @" fields * ; where game = " + gameID + @";";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic myObject = JsonConvert.DeserializeObject(response.Content);

            List<string> pixList = new List<string>();

            if (myObject != null && myObject.Count != 0)
            {
                foreach (var i in myObject) {
				//Console.WriteLine(i.url.typeOf());
                string temp = i.url;
                pixList.Add(temp);
                }
                return pixList;
            }

            return null;
        }
    }

}
