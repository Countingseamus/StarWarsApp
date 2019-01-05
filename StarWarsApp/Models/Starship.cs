using System.Collections.Generic;

namespace StarWarsApp.Models
{
   /// <summary>
   /// A Starship resource is a single transport craft that has hyperdrive capability
   /// </summary>
   public class Starship
   {
      /// <summary>
      /// The common name of this starship
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// The model or official name of this starship
      /// </summary>
      public string Model { get; set; }

      /// <summary>
      /// The manufacturer of this starship
      /// Comma separated if more than one
      /// </summary>
      public string Manufacturer { get; set; }

      /// <summary>
      /// The cost of this starship new, in galactic credits
      /// </summary>
      public string Cost_In_Credits { get; set; }

      /// <summary>
      /// The length of this starship in meters
      /// </summary>
      public string Length { get; set; }

      /// <summary>
      /// The maximum speed of this starship in the atmosphere.
      /// "N/A" if this starship is incapable of atmospheric flight
      /// </summary>
      public string Max_Atmosphering_Speed { get; set; }

      /// <summary>
      /// The number of personnel needed to run or pilot this starship
      /// </summary>
      public string Crew { get; set; }

      /// <summary>
      /// The number of non-essential people this starship can transport
      /// </summary>
      public string Passengers { get; set; }

      /// <summary>
      /// The maximum number of kilograms that this starship can transport
      /// </summary>
      public string Cargo_Capacity { get; set; }

      /// <summary>
      /// The maximum length of time that this starship can provide consumables for
      /// its entire crew without having to resupply
      /// </summary>
      public string Consumables { get; set; }

      /// <summary>
      /// The class of this starship's hyperdrive
      /// </summary>
      public string Hyperdrive_Rating { get; set; }

      /// <summary>
      /// The Maximum number of Megalights this starship can travel in a standard hour
      /// A "Megalight" is a standard unit of distance and has never been defined before
      /// within the Star Wars universe. This figure is only really useful for measuring
      /// the difference in speed of starships. We can assume it is similar to AU,
      /// the distance between our Sun (Sol) and Earth.
      /// </summary>
      public string MGLT { get; set; }

      /// <summary>
      /// The class of this starship
      /// </summary>
      public string Starship_Class { get; set; }

      /// <summary>
      /// An array of People URL Resources that this starship has been piloted by
      /// </summary>
      public IEnumerable<string> Pilots { get; set; }

      /// <summary>
      /// An array of Film URL Resources that this starship has appeared in
      /// </summary>
      public IEnumerable<string> Films { get; set; }

      /// <summary>
      /// The ISO 8601 date format of the time that this resource was created
      /// </summary>
      public string Created { get; set; }

      /// <summary>
      /// The ISO 8601 date format of the time that this resource was edited
      /// </summary>
      public string Edited { get; set; }

      /// <summary>
      /// The hypermedia URL of this resource
      /// </summary>
      public string Url { get; set; }
   }
}