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
    [DataRow(10, 10)]
    [DataRow(5.001, 5.001)]
    [DataRow(0.000001, 0.000001)]
    public void IsWithinRange_MinInclusiveBound_ReturnsTrue(double minBoundary, double valueToCheck)
    {
        // Arrange
        Validator validator = new Validator();
        double maxBoundary = minBoundary + 100;
        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    [DataRow(10, 10)]
    [DataRow(1000, 1000)]
    [DataRow(0.000001, 0.000001)]
    public void IsWithinRange_MaxInclusiveBound_ReturnsTrue(double maxBoundary, double valueToCheck)
    {
        // Arrange
        Validator validator = new Validator();
        double minBoundary = maxBoundary - 100;
        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    [DataRow(10, 15, 12.5)]
    [DataRow(-1, 1, 0.5)]
    [DataRow(0, 100, 50)]
    public void IsWithinRange_WithinRange_ReturnsTrue(double minBoundary, double maxBoundary, double valueToCheck)
    {
        // Arrange
        Validator validator = new Validator();
        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        // Assert
        Assert.IsTrue(result);
    }

    [TestMethod()]
    [DataRow(1, -1)]
    [DataRow(0, -10)]
    [DataRow(100, 99)]
    public void IsWithinRange_ValueLessThanMin_ReturnsFalse(double minBoundary, double valueToCheck)
    {
        // Arrange
        Validator validator = new Validator();
        double maxBoundary = minBoundary + 100;
        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    [DataRow(1, 2)]
    [DataRow(0.01, 0.10)]
    [DataRow(100, 101)]
    public void IsWithinRange_ValueGreaterThanMax_ReturnsFalse(double maxBoundary, double valueToCheck)
    {
        // Arrange
        Validator validator = new Validator();
        double minBoundary = maxBoundary - 100;
        // Act
        bool result = validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary);
        // Assert
        Assert.IsFalse(result);
    }

    [TestMethod()]
    [DataRow(15.0, 10.0)]
    [DataRow(100.0, 50.0)]
    [DataRow(0.0001, 0.00001)]
    public void IsWithinRange_MinGreaterThanMax_ThrowsArgumentException(double minBoundary, double maxBoundary)
    {
        // Arrange
        Validator validator = new Validator();
        double valueToCheck = 0.0;
        // Act & Assert
        Assert.ThrowsExactly<ArgumentException>(() =>
            validator.IsWithinRange(valueToCheck, minBoundary, maxBoundary));
    }
}