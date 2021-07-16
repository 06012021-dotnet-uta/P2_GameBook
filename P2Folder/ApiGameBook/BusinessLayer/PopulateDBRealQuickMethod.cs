using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RestSharp;

namespace BusinessLayer
{
	class PopulateDBRealQuickMethod
	{
		public void PopulateThatDb() 
		{
			var client = new RestClient("https://api.igdb.com/v4/games");
			client.Timeout = -1;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Client-ID", " q17vg91zyii02i7r72jjohbf0d6ggc");
			request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
			request.AddHeader("Content-Type", "text/plain");
			var body = @"fields id,name; limit 500; where id < " + 500 + " & id > " + 1 + ";";
			request.AddParameter("text/plain", body, ParameterType.RequestBody);
			IRestResponse response = client.Execute(request);
			Console.WriteLine(response.Content);

			
		}
	}
}
