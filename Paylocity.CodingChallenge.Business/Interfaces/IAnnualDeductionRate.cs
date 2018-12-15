using Paylocity.CodingChallenge.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IAnnualDeductionRate
    {
        /// <summary>
        /// Returns the annual benefits deduction amount for a given person type.
        /// </summary>
        /// <param name="personType">Type of person whose annual deduction is requested.</param>
        /// <returns>Annual benefits deduction amount</returns>
        decimal Get(PersonType personType);
    }
}
