using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsApp.Models;
using StarWarsApp.Utilities;

namespace StarWarsAppTests
{
   [TestClass]
   public class ParserValidationUtilityTests
   {
      [TestMethod]
      public void IsUserInputValid_Given_Positive_Int_Returns_True()
      {
         // Arrange
         string mockInput = "1";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsUserInputValid(mockInput);
         // Assert
         Assert.IsTrue(result);
      }

      [TestMethod]
      public void IsUserInputValid_Given_Negative_Int_Returns_False()
      {
         // Arrange
         string mockInput = "-1";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsUserInputValid(mockInput);
         // Assert
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void IsUserInputValid_Given_NaN_Returns_False()
      {
         // Arrange
         string mockInput = "abc";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsUserInputValid(mockInput);
         // Assert
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void ParseNumberOfDays_Returns_Correct_Number_Of_Days_Given_Days()
      {
         // Arrange
         string mockConsumables = "85 days";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.ParseNumberOfDays(mockConsumables);
         // Assert
         Assert.AreEqual(85, result);
      }

      [TestMethod]
      public void ParseNumberOfDays_Returns_Correct_Number_Of_Days_Given_Weeks()
      {
         // Arrange
         string mockConsumables = "9 weeks";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.ParseNumberOfDays(mockConsumables);
         // Assert
         Assert.AreEqual(63, result);
      }

      [TestMethod]
      public void ParseNumberOfDays_Returns_Correct_Number_Of_Days_Given_Months()
      {
         // Arrange
         string mockConsumables = "6 months";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.ParseNumberOfDays(mockConsumables);
         // Assert
         Assert.AreEqual(180, result);
      }

      [TestMethod]
      public void ParseNumberOfDays_Returns_Correct_Number_Of_Days_Given_Years()
      {
         // Arrange
         string mockConsumables = "3 years";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.ParseNumberOfDays(mockConsumables);
         // Assert
         Assert.AreEqual(1095, result);
      }

      [TestMethod]
      public void IsConsumablesValid_Given_Positive_Number_And_Valid_TimePeriod_Returns_True()
      {
         // Arrange
         string mockConsumables = "day 1";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsConsumablesValid(mockConsumables);
         // Assert
         Assert.IsTrue(result);
      }

      [TestMethod]
      public void IsConsumablesValid_Given_Zero_And_Valid_TimePeriod_Returns_True()
      {
         // Arrange
         string mockConsumables = "year 0";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsConsumablesValid(mockConsumables);
         // Assert
         Assert.IsTrue(result);
      }

      [TestMethod]
      public void IsConsumablesValid_Given_Positive_Number_And_Invalid_TimePeriod_Returns_False()
      {
         // Arrange
         string mockConsumables = "abc 1";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsConsumablesValid(mockConsumables);
         // Assert
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void IsConsumablesValid_Given_Negative_Number_And_Invalid_TimePeriod_Returns_False()
      {
         // Arrange
         string mockConsumables = "week";
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsConsumablesValid(mockConsumables);
         // Assert
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void IsSpeedValid_Given_Numeric_Positive_Speed_Returns_True()
      {
         // Arrange
         var mockStarship = new Starship { MGLT = "10", Name = "mockStarship" };
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsSpeedValid(mockStarship);
         // Assert
         Assert.IsTrue(result);
      }

      [TestMethod]
      public void IsSpeedValid_Given_Numeric_Zero_Speed_Returns_False()
      {
         // Arrange
         var mockStarship = new Starship { MGLT = "0", Name = "mockStarship" };
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsSpeedValid(mockStarship);
         // Assert
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void IsSpeedValid_Given_Numeric_Negative_Speed_Returns_False()
      {
         // Arrange
         var mockStarship = new Starship { MGLT = "-1", Name = "mockStarship" };
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsSpeedValid(mockStarship);
         // Assert
         Assert.IsFalse(result);
      }

      [TestMethod]
      public void IsSpeedValid_Given_NonNumeric_Speed_Returns_False()
      {
         // Arrange
         var mockStarship = new Starship { MGLT = "b", Name = "mockStarship" };
         var sut = new ParserValidationUtility();
         // Act
         var result = sut.IsSpeedValid(mockStarship);
         // Assert
         Assert.IsFalse(result);
      }
   }
}