using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount;

public class Validator
{
    /// <summary>
    /// Checks to ensure a value is between inclusive range.
    /// </summary>
    /// <param name="value">Value to check</param>
    /// <param name="min">Minimum inclusive boundary</param>
    /// <param name="max">Maximum inclusive boundary</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public bool IsWithinRange(double value, double min, double max)
    {
        if (min > max)
        {
            throw new ArgumentException("Minimum value cannot be greater than maximum value.");
        }
        return value >= min && value <= max;
    }
}
