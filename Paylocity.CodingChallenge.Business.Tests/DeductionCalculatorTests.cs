using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Entities;
using Paylocity.CodingChallenge.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeductionCalculatorTests
    {
        private const decimal ANNUAL_RATE = 10.0M;
        private const decimal DISCOUNT_RATE = 0.10M;
        private const decimal HUNDRED_PERCENT_DISCOUNT = 1.00M;
        private const int NUMBER_OF_PAYCHECKS_PER_YEAR = 26;

        [TestMethod]
        public void verify_discount_calculation()
        {
            // Arrange
            var testPerson = new Person() { Type = PersonType.Employee, Name = "ATestPerson" } ;

            var annualDeductionRate = A.Fake<IAnnualDeductionRate>();
            A.CallTo(() => annualDeductionRate.Get(testPerson.Type)).Returns(ANNUAL_RATE);

            var discountCalculator = A.Fake<IDiscountCalculator>();
            A.CallTo(() => discountCalculator.GetDiscountRate(testPerson)).Returns(DISCOUNT_RATE);

            var objectUnderTest = new DeductionCalculator(annualDeductionRate, discountCalculator);

            // Act
            var annualRatewithDiscount = objectUnderTest.CalculateDeductionWithDiscount(testPerson);

            // Assert
            var expectedAnnualRateWithDiscount = ANNUAL_RATE * (1 - DISCOUNT_RATE);
            Assert.IsTrue(annualRatewithDiscount == expectedAnnualRateWithDiscount);
        }

        [TestMethod]
        public void verify_100_percent_discount_calculation()
        {
            // Arrange
            var testPerson = new Person() { Type = PersonType.Employee, Name = "ATestPerson" };

            var annualDeductionRate = A.Fake<IAnnualDeductionRate>();
            A.CallTo(() => annualDeductionRate.Get(testPerson.Type)).Returns(ANNUAL_RATE);

            var discountCalculator = A.Fake<IDiscountCalculator>();
            A.CallTo(() => discountCalculator.GetDiscountRate(testPerson)).Returns(HUNDRED_PERCENT_DISCOUNT);

            var objectUnderTest = new DeductionCalculator(annualDeductionRate, discountCalculator);

            // Act
            var annualRatewithDiscount = objectUnderTest.CalculateDeductionWithDiscount(testPerson);

            // Assert
            var expectedAnnualRateWithDiscount = ANNUAL_RATE * (1 - HUNDRED_PERCENT_DISCOUNT);
            Assert.IsTrue(annualRatewithDiscount == expectedAnnualRateWithDiscount);
        }

        [TestMethod]
        public void verify_calculate_deduction_per_annum()
        {
            // Arrange
            var testPerson1 = new Person() { Type = PersonType.Employee, Name = "ATestPerson" };
            var testPerson2 = new Person() { Type = PersonType.Spouse, Name = "TestPerson" };

            var annualDeductionRate = A.Fake<IAnnualDeductionRate>();
            A.CallTo(() => annualDeductionRate.Get(testPerson1.Type)).Returns(ANNUAL_RATE);
            A.CallTo(() => annualDeductionRate.Get(testPerson2.Type)).Returns(ANNUAL_RATE);

            var discountCalculator = A.Fake<IDiscountCalculator>();
            A.CallTo(() => discountCalculator.GetDiscountRate(testPerson1)).Returns(DISCOUNT_RATE);
            A.CallTo(() => discountCalculator.GetDiscountRate(testPerson2)).Returns(0.0M);

            var objectUnderTest = new DeductionCalculator(annualDeductionRate, discountCalculator);

            // Act
            var deductionPerAnnum = objectUnderTest.CalculateDeductionPerAnnum(new List<Person>() { testPerson1, testPerson2 });

            // Assert
            var expectedDeductionPerAnnum = (ANNUAL_RATE * (1 - DISCOUNT_RATE)) + (ANNUAL_RATE * (1 - 0.0M));
            Assert.IsTrue(deductionPerAnnum == expectedDeductionPerAnnum);
        }

        [TestMethod]
        public void verify_calculate_deduction_per_paycheck()
        {
            // Arrange
            var testPerson1 = new Person() { Type = PersonType.Employee, Name = "ATestPerson" };
            var testPerson2 = new Person() { Type = PersonType.Spouse, Name = "TestPerson" };

            var annualDeductionRate = A.Fake<IAnnualDeductionRate>();
            A.CallTo(() => annualDeductionRate.Get(testPerson1.Type)).Returns(ANNUAL_RATE);
            A.CallTo(() => annualDeductionRate.Get(testPerson2.Type)).Returns(ANNUAL_RATE);

            var discountCalculator = A.Fake<IDiscountCalculator>();
            A.CallTo(() => discountCalculator.GetDiscountRate(testPerson1)).Returns(DISCOUNT_RATE);
            A.CallTo(() => discountCalculator.GetDiscountRate(testPerson2)).Returns(0.0M);

            var objectUnderTest = new DeductionCalculator(annualDeductionRate, discountCalculator);

            // Act
            var deductionPerPaycheck = objectUnderTest.CalculateDeductionPerPaycheck(new List<Person>() { testPerson1, testPerson2 }, NUMBER_OF_PAYCHECKS_PER_YEAR);

            // Assert
            var expectedDeductionPerPaycheck = ((ANNUAL_RATE * (1 - DISCOUNT_RATE)) + (ANNUAL_RATE * (1 - 0.0M))) / NUMBER_OF_PAYCHECKS_PER_YEAR;
            Assert.IsTrue(deductionPerPaycheck == expectedDeductionPerPaycheck);
        }
    }
}
