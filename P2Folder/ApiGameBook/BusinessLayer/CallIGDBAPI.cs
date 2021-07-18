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
	class CallIGDBAPI
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
        public void searchByWordsInTitle(string wordToSearch)
			{
            //	search "vegas"; fields name; limit 500;

            for (int i = 2000; i < 5000; i++)
            {
                var client = new RestClient("https://api.igdb.com/v4/games");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
                request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
                request.AddHeader("Content-Type", "text/plain");
                var body = @"Search " + wordToSearch + "fields name; limit 500";
                request.AddParameter("text/plain", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                dynamic myObject = JsonConvert.DeserializeObject(response.Content);
                if (myObject != null && myObject.Count != 0)
                {
                    var array = myObject[0];
                    int id = array.id;
                    string name = array.name;
                    Game temp = _context.Games.Where(x => x.GameId == id).FirstOrDefault();
                    if (temp == null)
                    {
                      
                    }
                    else
                    {
                        
                    }
                }
            }
            Console.WriteLine("Seed complete");
        }
    }
		
	}
}
