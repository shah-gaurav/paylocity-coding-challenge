using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Entities.Enums;
using Paylocity.CodingChallenge.Business.Code;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Paylocity.CodingChallenge.Business.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AnnualDeductionRateTests
    {
        [TestMethod]
        public void verify_employee_deduction_rate()
        {
            // Arrange
            var testPersonType = PersonType.Employee;
            var objectUnderTest = new AnnualDeductionRate();

            // Act
            var annualRate = objectUnderTest.Get(testPersonType);

            // Assert
            Assert.IsTrue(annualRate == Constants.EMPLOYEE_DEDUCTION_PER_YEAR);
        }

        [TestMethod]
        public void verify_spouse_deduction_rate()
        {
            // Arrange
            var testPersonType = PersonType.Spouse;
            var objectUnderTest = new AnnualDeductionRate();

            // Act
            var annualRate = objectUnderTest.Get(testPersonType);

            // Assert
            Assert.IsTrue(annualRate == Constants.DEPENDENT_DEDUCTION_PER_YEAR);
        }

        [TestMethod]
        public void verify_child_deduction_rate()
        {
            // Arrange
            var testPersonType = PersonType.Child;
            var objectUnderTest = new AnnualDeductionRate();

            // Act
            var annualRate = objectUnderTest.Get(testPersonType);

            // Assert
            Assert.IsTrue(annualRate == Constants.DEPENDENT_DEDUCTION_PER_YEAR);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void verify_exception_for_invalid_enum()
        {
            // Arrange
            var testPersonType = (PersonType)100;
            var objectUnderTest = new AnnualDeductionRate();

            // Act
            var annualRate = objectUnderTest.Get(testPersonType);

            // Assert
            // Should throw an exception
        }
    }
}
