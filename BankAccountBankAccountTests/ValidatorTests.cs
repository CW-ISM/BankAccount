using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount.BankAccountTests;

[TestClass()]
public class ValidatorTests
{
    [TestMethod()]
    public void IsWithinRange_MinInclusiveBound_ReturnsTrue()
    {
        // Arrange
        Validator validator = new Validator();
        double value = 5.0;
        double min = 5.0;
        double max = 10.0;
        // Act
        bool result = validator.IsWithinRange(value, min, max);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void IsWithinRange_MaxInclusiveBound_ReturnsTrue()
    {
        // Arrange
        Validator validator = new Validator();
        double value = 10.0;
        double min = 5.0;
        double max = 10.0;
        // Act
        bool result = validator.IsWithinRange(value, min, max);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void IsWithinRange_WithinRange_ReturnsTrue()
    {
        // Arrange
        Validator validator = new Validator();
        double value = 7.5;
        double min = 5.0;
        double max = 10.0;
        // Act
        bool result = validator.IsWithinRange(value, min, max);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    public void IsWithinRange_ValueLessThanMin_ReturnsFalse()
    {
        // Arrange
        Validator validator = new Validator();
        double value = 4.0;
        double min = 5.0;
        double max = 10.0;
        // Act
        bool result = validator.IsWithinRange(value, min, max);
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void IsWithinRange_ValueGreaterThanMax_ReturnsFalse()
    {
        // Arrange
        Validator validator = new Validator();
        double value = 11.0;
        double min = 5.0;
        double max = 10.0;
        // Act
        bool result = validator.IsWithinRange(value, min, max);
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    public void IsWithinRange_MinGreaterThanMax_ThrowsArgumentException()
    {
        // Arrange
        Validator validator = new Validator();
        double value = 5.0;
        double min = 10.0;
        double max = 5.0;
        // Act & Assert
        Assert.ThrowsExactly<ArgumentException>(() =>
            validator.IsWithinRange(value, min, max));
    }
}