using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StarWarsApp.Controllers;
using StarWarsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StarWarsAppTests
{
   [TestClass]
   public class StarshipApiControllerTests
   {
      /// <summary>
      /// Brittle as external service being tested, ideally would mock this out
      /// with HTTP handler, time permitting. Still a valuable test as it
      /// indicates whether service is live and data schema is up to date
      /// </summary>
      [TestMethod]
      public void GetStarshipsApiResult_Returns_StarshipsApiResult()
      {
         // Arrange
         var client = new HttpClient();
         client.BaseAddress = new Uri("https://swapi.co/api/starships");
         // Add an Accept header for JSON format.
         client.DefaultRequestHeaders.Accept.Add(
         new MediaTypeWithQualityHeaderValue("application/json"));
         var sut = new StarshipApiController(client);
         // Act
         var result = sut.GetStarshipsApiResult();
         // Assert
         Assert.IsNotNull(result);
         Assert.AreEqual(typeof(StarshipsApiResult), result.GetType());
      }

      [TestMethod]
      public void GetStarships_Returns_Starships_Given_Valid_StarshipsApiResult()
      {
         // Arrange
         var mockStarshipsApiResult = new StarshipsApiResult() { Results = new List<Starship> { new Starship(), new Starship() } };
         Mock<HttpClient> mockHttpHandler = new Mock<HttpClient>();
         var sut = new StarshipApiController(mockHttpHandler.Object);
         // Act
         var result = sut.GetStarships(mockStarshipsApiResult);
         // Assert
         Assert.AreEqual(2, result.Count());
      }

      [TestMethod]
      public void GetStarships_Returns_Null_Given_Null_StarshipsApiResult()
      {
         // Arrange
         Mock<HttpClient> mockHttpHandler = new Mock<HttpClient>();
         var sut = new StarshipApiController(mockHttpHandler.Object);
         // Act
         var result = sut.GetStarships(null);
         // Assert
         Assert.IsNull(result);
      }

      [TestMethod]
      public void GetStarships_Returns_Null_Given_StarshipsApiResult_Null_Results()
      {
         // Arrange
         var mockStarshipsApiResult = new StarshipsApiResult() { Results = null };
         Mock<HttpClient> mockHttpHandler = new Mock<HttpClient>();
         var sut = new StarshipApiController(mockHttpHandler.Object);
         // Act
         var result = sut.GetStarships(mockStarshipsApiResult);
         // Assert
         Assert.IsNull(result);
      }

      [TestMethod]
      public void GetStarships_Returns_Empty_Starship_List_Given_StarshipsApiResult_Empty_Results()
      {
         // Arrange
         var mockStarshipsApiResult = new StarshipsApiResult() { Results = new List<Starship>() };
         Mock<HttpClient> mockHttpHandler = new Mock<HttpClient>();
         var sut = new StarshipApiController(mockHttpHandler.Object);
         // Act
         var result = sut.GetStarships(mockStarshipsApiResult);
         // Assert
         Assert.AreEqual(0, result.Count());
      }
   }
}
