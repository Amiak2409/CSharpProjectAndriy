



class Transaction : ITransaction
{
    public void makeTransaction(Account sourceAccount, Account targetAccoun, float amount)
    {
        if (sourceAccount.GetBalance >= amount)
        {
            sourceAccount.GetBalance -= amount;
            targetAccoun.GetBalance += amount;
            Console.WriteLine("Transaction Finishet");
        }
        else
        {
            Console.WriteLine($"Transaction Failed. Account {sourceAccount.GetAccNumber} dont have {amount}$");
        }
    }
}

class Account : IComparable<Account>
{
    private int _accountNumber = 0;
    private float _balance = 0.0f;
    public Account(int accountNumber, float balance)
    {
        _accountNumber = accountNumber;
        _balance = balance;

    }

    public int GetAccNumber { get { return _accountNumber; } set { _accountNumber = value; } }
    public float GetBalance { get { return _balance; } set { _balance = value; } }
    public void Deposit(float amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Great! Your deposi: {amount}$ hes been confirmed! Now your balance is {_balance}$");
        }
        else
        {
            Console.WriteLine("Error: 0x002c51 (Summ of deposit must be greaten then 0)");
        }
    }
    public void Withdraw(float amount)
    {
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
            Console.WriteLine($"Great! Your withdraw: {amount}$ hes been confirmed! Now your balance is {_balance}$");
        }
        else
        {
            Console.WriteLine($"Error: 0x238f12 (You dont have {amount}$)");
        }
    }
    public int CompereTo(Account? otherAccount)
    {
        if(_balance > otherAccount._balance)
        {
            return 1;
        }
        else
        {
            return 0;
        }

    }

    public int CompareTo(Account? other)
    {
        throw new NotImplementedException();
    }
    public void DispalyBalance()
    {
        Console.WriteLine($"{_balance}$");
    }
}

interface ITransaction 
{
    public void makeTransaction(Account sourceAccount, Account targetAccoun, float amount);

    
}

class SavingsAccount
{
    private float interestRate { get; set; }

    public SavingsAccount(float InterestRate) 
    {
        interestRate = InterestRate;
    }
    public void CalculateInterest(Account account1)
    {
        float interest = account1.GetBalance * interestRate;
        account1.GetBalance += interest;
        Console.WriteLine($"Interest calculate.Now Your Balnce {account1.GetBalance}");
    }


}


class CheckingAccount 
{
    private float overdraftLimit { get; set; }
    public CheckingAccount(float OverdraftLimit)
    {
        overdraftLimit = OverdraftLimit;
    }
    public void Withdraw(Account account1,float amount)
    {
        if(amount <= overdraftLimit + account1.GetBalance)
        {
            account1.GetBalance -= amount;
            Console.WriteLine($"Great! Your withdraw: {amount}$ hes been confirmed! Now your balance is {account1.GetBalance}$");
        }
        else
        {
            Console.WriteLine($"Error: 0x023c45 (OverdraftLimit is: {overdraftLimit}$)");
        }
    }

}
class InvestmentAccount
{
    private string investmentType { get;set; }

    public InvestmentAccount(string InvestmentType)
    {
        investmentType = InvestmentType;
    }
    public void Invest(Account account1,float amount)
    {
        if(amount <= account1.GetBalance && amount > 0)
        {
            account1.GetBalance -= amount;
            Console.WriteLine($"Congratulation! You Invested {amount}$ in {investmentType}");
        }
        else
        {
            Console.WriteLine($"Error: 0x238f12 (You dont have {amount}$)");
        }
    }

}

class BankManager
{
    public void OpenAccount(string AccountType,float initialbalance)
    {
        
    }

}
