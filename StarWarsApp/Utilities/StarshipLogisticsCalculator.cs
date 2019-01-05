namespace StarWarsApp.Utilities
{
   public class StarshipLogisticsCalculator
   {
      private const int HOURS_IN_A_DAY = 24;

      /// <summary>
      /// Calculate number of stops needed for a journey
      /// </summary>
      /// <param name="journeyTimeWithoutStops">Number of days journey will take without stops</param>
      /// <param name="maxDistanceBeforeResupply">Number of days ship can travel for before resupply needed</param>
      /// <returns>Number of stops</returns>
      public int CalculateNumberOfStops(int journeyTimeWithoutStops, int daysBeforeResupply)
      {
         // Stop divide by zero exception occurring
         // if 0 stops provided assume ship can travel infinite distance without stopping, renewable resources on board :-)
         return daysBeforeResupply == 0 ? 0 : journeyTimeWithoutStops/daysBeforeResupply;
      }

      /// <summary>
      /// Calculate time taken, in days, for journey completion without stops to resupply
      /// </summary>
      /// <param name="distance">distance to be traveled</param>
      /// <param name="speed">average speed</param>
      /// <returns>Number of days journey will take without stops</returns>
      public int CalculateETAWithoutResupply(int distance, int speed)
      {
         return (distance/speed)/HOURS_IN_A_DAY;
      }
   }
}