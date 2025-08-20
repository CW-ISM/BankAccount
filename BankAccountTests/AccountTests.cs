using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankAccount.BankAccountTests;

[TestClass()]
public class AccountTests
{
    [TestMethod]
    [DataRow(10.01)]
    public void DepositTest(decimal deposit)
    {
        // Arrange
        var account = new Account { AccountNumber = "1234-ABCDE" };
        // Act
        var result = account.Deposit(deposit);
        // Assert
        Assert.AreEqual(result, account.Balance);
    }

    [TestMethod()]
    public void WithdrawTest()
    {
        Assert.Fail();
    }
}