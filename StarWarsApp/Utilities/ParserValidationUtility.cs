using StarWarsApp.Models;
using System;
using System.Text.RegularExpressions;

namespace StarWarsApp.Utilities
{
   /// <summary>
   /// Responsible for parsing and validating Starship data
   /// </summary>
   public class ParserValidationUtility
   {
      private const string DAY = "day";
      private const string WEEK = "week";
      private const string MONTH = "month";
      private const string YEAR = "year";

      /// <summary>
      /// Validates User Input and returns boolean result
      /// </summary>
      public bool IsUserInputValid(string input)
      {
         uint distance;
         var isValid = uint.TryParse(input, out distance);

         // distance entered should not be negative
         return distance < 0 ? false : isValid;
      }

      /// <summary>
      /// Calculate number of days (roughly) from consumables
      /// Assuming only one number and one time period (e.g. week, month) present
      /// 1. Parse number from string
      /// 2. Parse time period from string
      /// 3. adjust number according depending on detected time period.
      /// Leave number unaltered if time period is days
      /// </summary>
      /// <param name="consumables"></param>
      /// <returns>Number of days</returns>
      public int ParseNumberOfDays(string consumables)
      {
         var resultString = Regex.Match(consumables, @"\d+").Value;
         int resultInteger = int.Parse(resultString);
         if (consumables.Contains(WEEK))
         {
            resultInteger = resultInteger * 7;
         }
         else if (consumables.Contains(MONTH))
         {
            resultInteger = resultInteger * 30;
         }
         else if (consumables.Contains(YEAR))
         {
            resultInteger = resultInteger * 365;
         }

         // if it doesn't contain week, month or year assume days
         return resultInteger;
      }

      /// <summary>
      /// Checks if consumables contains valid time period
      /// </summary>
      /// <param name="consumables"></param>
      /// <returns>isValid boolean result</returns>
      public bool IsConsumablesValid(string consumables)
      {
         var resultString = Regex.Match(consumables, @"\d+").Value;
         int resultInteger;
         var isInteger = int.TryParse(resultString, out resultInteger);
         var isTimePeriodValid = consumables.Contains(DAY) || consumables.Contains(WEEK)
            || consumables.Contains(MONTH) || consumables.Contains(YEAR);
         // Journey Time before resupply needed should not be negative
         if (isInteger && resultInteger < 0)
         {
            Console.WriteLine("Journey Time before Resupply needed should not be negative");
            return false;
         }

         return isInteger && isTimePeriodValid;
      }

      /// <summary>
      /// Checks if starship speed is Valid
      /// </summary>
      /// <returns>isSpeedValid: boolean result</returns>
      public bool IsSpeedValid(Starship starship)
      {
         int speed;
         bool isSpeedValid = int.TryParse(starship.MGLT, out speed);
         if (!isSpeedValid || speed <= 0)
         {
            isSpeedValid = false;
            // Number of stops would be infinite
            Console.WriteLine($"{starship.Name} has no valid speed: {starship.MGLT}.\n");
         }

         return isSpeedValid;
      }
   }
}
