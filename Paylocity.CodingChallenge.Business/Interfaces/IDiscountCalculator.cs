using Paylocity.CodingChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Paylocity.CodingChallenge.Business.Interfaces
{
    public interface IDiscountCalculator
    {
        /// <summary>
        /// This method calculates the applicable discount rate for a given person.
        /// </summary>
        /// <param name="person">The person whose discount should be calcuated.</param>
        /// <returns>Discount rate (percentage in decimal form)</returns>
        decimal GetDiscountRate(Person person);
    }
}
