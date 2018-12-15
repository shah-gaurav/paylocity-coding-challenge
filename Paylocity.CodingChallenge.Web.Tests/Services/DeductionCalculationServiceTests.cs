using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Business.Interfaces;
using Paylocity.CodingChallenge.Web.Services;
using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Paylocity.CodingChallenge.Web.Tests.Services
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DeductionCalculationServiceTests
    {
        [TestMethod]
        public void verify_employee_yearly_salary_after_deduction_calculation()
        {
            // Arrange
            var testEmployee = new Employee() { Name = "Employee", YearlySalary = 10000, NumberOfPaychecksPerYear = 10 };

            var deductionCalculator = A.Fake<IDeductionCalculator>();
            A.CallTo(() => deductionCalculator.CalculateDeductionPerAnnum(A<List<Entities.Person>>._)).Returns(1000);

            var objectUnderTest = new DeductionCalculationService(deductionCalculator);

            // Act
            var calculationResults = objectUnderTest.CalculateDeductions(testEmployee);

            // Assert
            var expectedYearlySalaryAfterDeduction = 10000 - 1000;
            Assert.IsTrue(expectedYearlySalaryAfterDeduction == calculationResults.EmployeeYearlyPayAfterDeductions);
        }

        [TestMethod]
        public void verify_employee_paycheck_after_deduction_calculation()
        {
            // Arrange
            var testEmployee = new Employee() { Name = "Employee", YearlySalary = 10000, NumberOfPaychecksPerYear = 10 };

            var deductionCalculator = A.Fake<IDeductionCalculator>();
            A.CallTo(() => deductionCalculator.CalculateDeductionPerPaycheck(A<List<Entities.Person>>._,A<int>._)).Returns(100);

            var objectUnderTest = new DeductionCalculationService(deductionCalculator);

            // Act
            var calculationResults = objectUnderTest.CalculateDeductions(testEmployee);

            // Assert
            var expectedPaycheckAfterDeduction = 1000 - 100;
            Assert.IsTrue(expectedPaycheckAfterDeduction == calculationResults.EmployeePaycheckAfterDeductions);
        }

        [TestMethod]
        public void verify_deduction_calculation_calls_are_made()
        {
            // Arrange
            var testEmployee = new Employee() { Name = "Employee", YearlySalary = 10000, NumberOfPaychecksPerYear = 10 };

            var deductionCalculator = A.Fake<IDeductionCalculator>();
            var objectUnderTest = new DeductionCalculationService(deductionCalculator);

            // Act
            var calculationResults = objectUnderTest.CalculateDeductions(testEmployee);

            // Assert
            A.CallTo(() => deductionCalculator.CalculateDeductionPerPaycheck(A<List<Entities.Person>>._, A<int>._)).MustHaveHappened();
            A.CallTo(() => deductionCalculator.CalculateDeductionPerAnnum(A<List<Entities.Person>>._)).MustHaveHappened();
        }
    }
}
