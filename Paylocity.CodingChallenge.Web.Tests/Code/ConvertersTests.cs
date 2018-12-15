using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.CodingChallenge.Entities.Enums;
using Paylocity.CodingChallenge.Web.Code;
using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Paylocity.CodingChallenge.Web.Tests.Code
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ConvertersTests
    {
        [TestMethod]
        public void verify_dependenttype_child_converts_to_persontype_child()
        {
            // Arrange
            var expectedType = PersonType.Child;
            var typeToConvert = DependentType.Child;

            // Act
            var returnedType = Converters.ConvertDependentTypeToPersonType(typeToConvert);

            // Assert
            Assert.IsTrue(returnedType == expectedType);
        }

        [TestMethod]
        public void verify_dependenttype_spouse_converts_to_persontype_spouse()
        {
            // Arrange
            var expectedType = PersonType.Spouse;
            var typeToConvert = DependentType.Spouse;

            // Act
            var returnedType = Converters.ConvertDependentTypeToPersonType(typeToConvert);

            // Assert
            Assert.IsTrue(returnedType == expectedType);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void verify_exception_for_invalid_dependenttype()
        {
            // Arrange
            var typeToConvert = (DependentType)100;

            // Act
            var returnedType = Converters.ConvertDependentTypeToPersonType(typeToConvert);

            // Assert
            // Should throw an exception
        }

        [TestMethod]
        public void verify_convertemployeetopersonlist_returns_one_person_if_the_employee_doesnt_have_any_dependents()
        {
            // Arrange
            var testEmployee = new Employee() { Name = "NameThatDoesntStartWithA" };

            // Act
            var returnedPersonList = Converters.ConvertEmployeeToPersonList(testEmployee);

            // Assert
            Assert.IsTrue(returnedPersonList.Count == 1);
            Assert.IsTrue(returnedPersonList[0].Type == PersonType.Employee);
        }

        [TestMethod]
        public void verify_convertemployeetopersonlist_returns_three_persons_if_the_employee_has_two_dependents()
        {
            // Arrange
            var testEmployee = new Employee()
            {
                Name = "Employee Name",
                Dependents = new List<Dependent>()
                 {
                     new Dependent() {Name = "Dependent 1", Type = DependentType.Spouse },
                     new Dependent() {Name = "Dependent 2", Type = DependentType.Child }
                 }
            };

            // Act
            var returnedPersonList = Converters.ConvertEmployeeToPersonList(testEmployee);

            // Assert
            Assert.IsTrue(returnedPersonList.Count == 3);
            Assert.IsTrue(returnedPersonList.Count(p => p.Type == PersonType.Employee) == 1);
            Assert.IsTrue(returnedPersonList.Count(p => p.Type == PersonType.Spouse) == 1);
            Assert.IsTrue(returnedPersonList.Count(p => p.Type == PersonType.Child) == 1);
        }
    }
}
