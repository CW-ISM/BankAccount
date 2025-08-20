namespace BankAccount;

/// <summary>
/// Represents a individual bank account.
/// </summary>
public class Account
{
    /// <summary>
    /// AccountNumbers must start with 4 digits, followed by a dash,
    /// and then 5 characters (A-Z) not case sensitive.
    /// </summary>
    public required string AccountNumber { get; set; }

    /// <summary>
    /// The current balance of the account.
    /// </summary>
    public decimal Balance { get; private set; }

    /// <summary>
    /// Deposits a specified amount into the account.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public decimal Deposit(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, "Deposit cannot be zero or less.");

        Balance += amount;
        return Balance;
    }

    /// <summary>
    /// Widthdraws a specified amount from the account.
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public decimal Withdraw(decimal amount)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(amount, "Withdraw cannot be zero or less.");
        ArgumentOutOfRangeException.ThrowIfGreaterThan(amount, Balance, "Withdrawal amount cannot exceed balance.");
 
        Balance -= amount;
        return Balance;
    }
}
