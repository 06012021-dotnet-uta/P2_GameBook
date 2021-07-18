using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RepositoryLayer;
using RestSharp;

namespace BusinessLayer
{
    public class PopulateDBRealQuickMethod
    {
        //private gamebookdbContext _context;

        //public PopulateDBRealQuickMethod(gamebookdbContext context)
        //{
        //    _context = context;
        //}

        //public void SeedGames()
        //{
        //    for (int i = 2000; i < 5000; i++)
        //    {
        //        var client = new RestClient("https://api.igdb.com/v4/games");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
        //        request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
        //        request.AddHeader("Content-Type", "text/plain");
        //        var body = @"fields name;" + "\n" + @"where id = " + i + ";";
        //        request.AddParameter("text/plain", body, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);

        //        dynamic myObject = JsonConvert.DeserializeObject(response.Content);
        //        if (myObject != null && myObject.Count != 0)
        //        {
        //            var array = myObject[0];
        //            int id = array.id;
        //            string name = array.name;
        //            Game temp = _context.Games.Where(x => x.GameId == id).FirstOrDefault();
        //            if (temp == null)
        //            {
        //                Game game = new Game()
        //                {
        //                    GameId = id,
        //                    Name = name
        //                };
        //                _context.Games.Add(game);
        //                _context.SaveChanges();
        //                Console.WriteLine($"Success game added: {name}");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"Game already exists: {name}");
        //            }
        //        }
        //    }
        //    Console.WriteLine("Seed complete");
        //}

        //public void SeedKeywords()
        //{
        //    for (int i = 501; i < 1000; i++)
        //    {
        //        var client = new RestClient("https://api.igdb.com/v4/keywords");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("Client-ID", "q17vg91zyii02i7r72jjohbf0d6ggc");
        //        request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
        //        request.AddHeader("Content-Type", "text/plain");
        //        var body = @"fields name;" + "\n" + @"where id = " + i + ";";
        //        request.AddParameter("text/plain", body, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);

        //        dynamic myObject = JsonConvert.DeserializeObject(response.Content);
        //        if (myObject != null && myObject.Count != 0)
        //        {
        //            var array = myObject[0];
        //            int id = array.id;
        //            string name = array.name;
        //            Keyword temp = _context.Keywords.Where(x => x.KeywordId == id).FirstOrDefault();
        //            if (temp == null)
        //            {
        //                Keyword keyword = new Keyword()
        //                {
        //                    KeywordId = id,
        //                    Name = name
        //                };
        //                _context.Keywords.Add(keyword);
        //                _context.SaveChanges();
        //                Console.WriteLine("Success");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"{name} Keyword already exists");
        //            }
        //        }
        //    }
        //    Console.WriteLine("Seed complete");
        //}

        //public void PopulateThatDb()
        //{
        //    //int seed = 500;
        //    //for (int i = 1; i < 280; i++)
        //    {
        //        //seed = seed*=1;
        //        var client = new RestClient("https://api.igdb.com/v4/games");
        //        client.Timeout = -1;
        //        var request = new RestRequest(Method.POST);
        //        request.AddHeader("Client-ID", " q17vg91zyii02i7r72jjohbf0d6ggc");
        //        request.AddHeader("Authorization", "Bearer b313017ewuy4acht8jascuje10i1sc");
        //        request.AddHeader("Content-Type", "text/plain");
        //        var body = @"fields id, name; limit 300 ; sort rating desc; where rating > 90 & rating < 100  ;";
        //        request.AddParameter("text/plain", body, ParameterType.RequestBody);
        //        IRestResponse response = client.Execute(request);
        //        //Console.WriteLine(response.Content);
        //        //Console.WriteLine(response.Content.GetType());
        //        string doSomething = response.Content;
        //        //Console.WriteLine(doSomething);
        //        string bracketsGoneDoSomething = doSomething.Replace("[", "");
        //        string startBracketsGoneDoSomething = bracketsGoneDoSomething.Replace("{", "");
        //        string endBracketsGoneDoSomething = startBracketsGoneDoSomething.Replace("}", "");
        //        string racketsGoneDoSomething = endBracketsGoneDoSomething.Replace("]", "");
        //        string finalreplace = racketsGoneDoSomething.Replace("\"", "");
        //        var arrayString = finalreplace.Split(",");

        //        int gameID = 0;

        //        for (var i = 0; i < arrayString.Length; i++)
        //        {
        //            var temp = arrayString[i].Trim();


        //            if (i % 2 == 0)
        //            {
        //                Console.WriteLine(temp);
        //                string temp1 = temp.Remove(0, 4);
        //                //Console.WriteLine(temp1);
        //                gameID = Int32.Parse(temp1);
        //            }
        //            else
        //            {
        //                Console.WriteLine(temp);
        //                string temp1 = temp.Remove(0, 6);
        //                Console.WriteLine(temp1);
        //                Console.WriteLine(gameID);

        //                try
        //                {
        //                    //Game temp2 = null;
        //                    // Search game table for game with matching name, returns null if not found
        //                    Game temp2 = _context.Games.Where(x => x.Name == temp1).FirstOrDefault();
        //                    if (temp2 == null)
        //                    {
        //                        //create game
        //                        Game game = new Game();
        //                        game.Name = temp1;
        //                        game.GameId = gameID;
        //                        // add game to db 
        //                        _context.Games.Add(game);
        //                        _context.SaveChanges();
        //                        Console.WriteLine("Success");
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine("Error, that game already exists");
        //                    }
        //                }
        //                catch (Exception e)
        //                {
        //                    Console.WriteLine("*******something bad happened******");
        //                    Console.WriteLine(e.InnerException.Message);
        //                    Console.WriteLine(temp1 + "** **" + gameID);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
