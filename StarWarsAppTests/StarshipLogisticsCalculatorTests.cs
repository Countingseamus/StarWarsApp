using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsApp.Utilities;

namespace StarshipsTests
{
   [TestClass]
   public class StarshipLogisticsCalculatorTests
   {
      [TestMethod]
      public void CalculateNumberOfStops_Returns_Correct_Number_Of_Stops()
      {
         // Arrange
         int mockJourneyTimeWithoutStops = 250;
         int mockDaysBeforeResupply = 25;
         var sut = new StarshipLogisticsCalculator();
         // Act
         var result = sut.CalculateNumberOfStops(mockJourneyTimeWithoutStops, mockDaysBeforeResupply);
         // Assert
         Assert.AreEqual(10, result);
      }

      [TestMethod]
      public void CalculateNumberOfStops_Given_Zero_DaysBeforeResupply_Returns_Zero()
      {
         // Arrange
         int mockJourneyTimeWithoutStops = 250;
         int mockDaysBeforeResupply = 0;
         var sut = new StarshipLogisticsCalculator();
         // Act
         var result = sut.CalculateNumberOfStops(mockJourneyTimeWithoutStops, mockDaysBeforeResupply);
         // Assert
         Assert.AreEqual(0, result);
      }

      [TestMethod]
      public void CalculateETAWithoutResupply_Returns_CorrectResult()
      {
         // Arrange
         int mockDistance = 480;
         int mockSpeed = 10;
         var sut = new StarshipLogisticsCalculator();
         // Act
         var result = sut.CalculateETAWithoutResupply(mockDistance, mockSpeed);
         // Assert
         Assert.AreEqual(2, result);
      }
   }
}