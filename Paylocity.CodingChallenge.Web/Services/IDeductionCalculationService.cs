using Paylocity.CodingChallenge.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paylocity.CodingChallenge.Web.Services
{
    public interface IDeductionCalculationService
    {
        /// <summary>
        /// This method takes an employee and returns the deductions calculated for that employee. 
        /// </summary>
        /// <param name="employee">Employee with this dependents and basic salary informaton needed to calculate deductions.</param>
        /// <returns></returns>
        DeductionCalculationResults CalculateDeductions(Employee employee);
    }
}
