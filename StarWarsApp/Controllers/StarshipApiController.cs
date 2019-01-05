using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace StarWarsApp.Controllers
{
   /// <summary>
   /// Controller responsible for retrieving Starship data from Star Wars API
   /// </summary>
   public class StarshipApiController
   {
      private const string URL_PARAMETER = "starships";

      private HttpClient _client;

      public StarshipApiController(HttpClient client)
      {
         _client = client;
      }

      /// <summary>
      /// Get Result for all Starships request
      /// </summary>
      /// <returns></returns>
      public StarshipsApiResult GetStarshipsApiResult()
      {
         // List data response.
         StarshipsApiResult starshipsApiResult = null;
         var response = _client.GetAsync(URL_PARAMETER).Result;
         if (response.IsSuccessStatusCode)
         {
            // Parse the response body.
            try
            {
               starshipsApiResult = response.Content.ReadAsAsync<StarshipsApiResult>().Result;
            }
            catch(Exception e)
            {
               // Might indicate the schema has been changed and Models need to be revisited
               Console.WriteLine(e.Message);
            }
         }
         else
         {
            Console.WriteLine($"{(int)response.StatusCode}, {response.ReasonPhrase}. Please try again.");
         }

         return starshipsApiResult;
      }

      /// <summary>
      /// Get All Starships
      /// </summary>
      /// <param name="starshipsApiResult"></param>
      /// <returns>Starships</returns>
      public IEnumerable<Starship> GetStarships(StarshipsApiResult starshipsApiResult)
      {
         return starshipsApiResult?.Results;
      }
   }
}