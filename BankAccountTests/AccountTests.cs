using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccount.BankAccountTests;

[TestClass()]
public class AccountTests
{
    [TestMethod]
    [DataRow(10.01)]
    public void DepositTest(double deposit)
    {
        // Arrange
        var account = new Account { AccountNumber = "1234-ABCDE" };
        // Act
        var result = account.Deposit(deposit);
        // Assert
        Assert.AreEqual(result, account.Balance);
    }

    [TestMethod()]
    [DataRow(10.01)]
    public void WithdrawTest(double withdraw)
    {
        // Arrange
        var account = new Account { AccountNumber = "1234-ABCDE" };
        // Act
        var beforeWidthrawl = account.Deposit(withdraw * 2);
        var result = account.Withdraw(withdraw);
        // Assert
        Assert.IsLessThan(beforeWidthrawl, result);
    }
}