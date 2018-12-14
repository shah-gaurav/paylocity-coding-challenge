using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Entities;
using Paylocity.CodingChallenge.Business.Code;
using System.Diagnostics.CodeAnalysis;

namespace Paylocity.CodingChallenge.Business.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DiscountByNameCalculatorTests
    {
        [TestMethod]
        public void verify_no_discount_if_name_does_not_start_with_letter_a()
        {
            // Arrange
            var testPerson = new Person() { Name = "NameThatDoesntStartWithA" };
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == Constants.ZERO_PERCENT_DISCOUNT_RATE);
        }

        [TestMethod]
        public void verify_10_percent_discount_rate_if_name_starts_with_letter_a()
        {
            // Arrange
            var testPerson = new Person() { Name = "ANameThatStartsWithLetterA" };
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == Constants.TEN_PERCENT_DISCOUNT_RATE);
        }

        [TestMethod]
        public void verify_no_discount_if_person_is_null()
        {
            // Arrange
            Person testPerson = null;
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == Constants.ZERO_PERCENT_DISCOUNT_RATE);
        }

        [TestMethod]
        public void verify_no_discount_if_person_name_is_null()
        {
            // Arrange
            Person testPerson = new Person();
            var objectUnderTest = new DiscountByNameCalculator();

            // Act
            var discountRate = objectUnderTest.GetDiscountRate(testPerson);

            // Assert
            Assert.IsTrue(discountRate == Constants.ZERO_PERCENT_DISCOUNT_RATE);
        }
    }
}
