
BankManager bankManager = new BankManager();

SavingsAccount savingsAccount = (SavingsAccount)bankManager.OpenAccount("Savings", 1000);
InvestmentAccount investmentAccount = (InvestmentAccount)bankManager.OpenAccount("Investment", 500);

savingsAccount.Deposit(500); 
investmentAccount.Deposit(200); 

bankManager.MakeTransaction(savingsAccount, investmentAccount, 300);

float savingsBalance = savingsAccount.GetBalance;
float CheckBalance = investmentAccount.GetBalance;
Console.WriteLine(savingsBalance);
Console.WriteLine(CheckBalance);



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
    public virtual void Withdraw(float amount)
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

class SavingsAccount : Account
{
    private float _interestRate { get;set; }

    public SavingsAccount ( int accountNumber, float balance)
        :base(accountNumber, balance)
    {
        _interestRate = balance;
    }
    public void CalculateInterest()
    {
        float interest = GetBalance * _interestRate;
        GetBalance += interest;
        Console.WriteLine($"Interest calculate.Now Your Balnce {GetBalance}");
    }
}

class CheckingAccount : Account
{
    public float _overdraftLimit { get; set; }
    public CheckingAccount(int accountNumber, float balance)
        : base(accountNumber, balance)
    {

    }
    public void Withdraw(float amount, float overdraftLimit)
    {
        _overdraftLimit = overdraftLimit;
        if (amount <= _overdraftLimit + GetBalance)
        {
            GetBalance -= amount;
            Console.WriteLine($"Great! Your withdraw: {amount}$ hes been confirmed! Now your balance is {GetBalance}$");
        }
        else
        {
            Console.WriteLine($"Error: 0x023c45 (OverdraftLimit is: {_overdraftLimit}$)");
        }
    }
}

class InvestmentAccount : Account
{
    public string _investmentType { get; set; }

    public InvestmentAccount(int accountNumber, float balance)
        :base(accountNumber, balance)
    {
    }

    public void Invest(float amount, string InvestmentType)
    {
        _investmentType = InvestmentType;

        if (amount <= GetBalance && amount > 0)
        {
            GetBalance -= amount;
            Console.WriteLine($"Congratulation! You Invested {amount}$ in {_investmentType}");
        }
        else
        {
            Console.WriteLine($"Error: 0x238f12 (You dont have {amount}$)");

        }
    }
}

class BankManager
{
    private int accountNumber = 1;
    public Account _account;
    public Account OpenAccount(string AccountType,float initialBalance)
    {
        if( AccountType.ToLower() == "savings")
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance);
            _account = account;
            accountNumber++;

        }
        else if (AccountType.ToUpper() == "checking")
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance);
            _account = account;
            accountNumber++;


        }
        else if( AccountType.ToLower() == "investment")
        {
            InvestmentAccount account = new InvestmentAccount(accountNumber, initialBalance);
            _account = account;
            accountNumber++;

        }
        else
        {
            return null;
        }
        return _account;
    }

    public float CheckAccount(Account account)
    {
        return account.GetBalance;
    }

    public void MakeTransaction(Account sourceAccount, Account targetAccoun, float amount)
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
