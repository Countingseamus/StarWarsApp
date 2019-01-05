using StarWarsApp.Controllers;
using StarWarsApp.Utilities;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StarWarsApp
{
   /// <summary>
   /// A Specific Program that runs Starship calculations based on user input and data from Star Wars API
   /// Informs User, given their specified input distance, how many resupply stops are required for each Starship
   /// </summary>
   public class LogisticsProgram
   {
      private const string BASE_URL = "https://swapi.co/api/";
      private const string CONTENT_TYPE = "application/json";

      /// <summary>
      /// Singleton to be shared between requests
      /// </summary>
      private readonly static HttpClient _client = new HttpClient();

      static void Main(string[] args)
      {
         // Obtain All Starships Data
         SetupClient();
         var starshipController = new StarshipApiController(_client);

         var starshipsApiResult = starshipController.GetStarshipsApiResult();
         // If API call was successful, available and served expected result
         if (starshipsApiResult != null)
         {
            var starships = starshipController.GetStarships(starshipsApiResult);

            // Perform Parsing of Data
            var parserUtility = new ParserValidationUtility();
            int distance = GetValidUserInput(parserUtility);
            int speed;

            var starshipLogisticsCalculator = new StarshipLogisticsCalculator();
            foreach (var starship in starships)
            {
               if (parserUtility.IsSpeedValid(starship))
               {
                  speed = int.Parse(starship.MGLT);
                  if (parserUtility.IsConsumablesValid(starship.Consumables))
                  {
                     int daysBeforeResupply = parserUtility.ParseNumberOfDays(starship.Consumables);
                     //Perform Calculations
                     var journeyTimeWithoutStops = starshipLogisticsCalculator.CalculateETAWithoutResupply(distance, speed);
                     var numberOfStops = starshipLogisticsCalculator.CalculateNumberOfStops(journeyTimeWithoutStops, daysBeforeResupply);
                     Console.WriteLine($"{starship.Name}: {numberOfStops}\n");
                  }
                  else
                  {
                     Console.WriteLine($"{starship.Name}'s Consumables are not valid: {starship.Consumables}.\n");
                  }
               }
            }
         }

         Console.ReadLine();
      }

      /// <summary>
      /// Returns valid User Input i.e. an Integer
      /// </summary>
      /// <returns></returns>
      private static int GetValidUserInput(ParserValidationUtility parserUtility)
      {
         Console.Write("Please enter a distance (whole number) in mega lights (MGLT): ");
         // Slight Overkill here but trying to adhere to Single Responsibility Principle
         bool isValid = false;
         string input = string.Empty;
         while (!isValid)
         {
            input = Console.ReadLine();
            isValid = parserUtility.IsUserInputValid(input);
            if (isValid)
            {
               break;
            }
            // Can change to uint or long to support larger entries but int will be sufficient
            Console.WriteLine("Invalid Input: Please enter a valid positive numerical value 1-2147483647!");
            Console.Write("Please enter a distance (whole number) in mega lights (MGLT): ");
         }

         return int.Parse(input);
      }

      private static void SetupClient()
      {
         _client.BaseAddress = new Uri(BASE_URL);
         // Add an Accept header for JSON format.
         _client.DefaultRequestHeaders.Accept.Add(
         new MediaTypeWithQualityHeaderValue(CONTENT_TYPE));
      }
   }
}
