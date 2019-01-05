using System.Collections.Generic;

namespace StarWarsApp.Models
{
   /// <summary>
   /// Wrapper class that contains result from api call to get all the starship resources
   /// </summary>
   public class StarshipsApiResult
   {
      public int Count { get; set; }
      public string Next { get; set; }
      public string Previous { get; set; }

      /// <summary>
      /// List of Starships
      /// </summary>
      public IEnumerable<Starship> Results { get; set; }
   }
}