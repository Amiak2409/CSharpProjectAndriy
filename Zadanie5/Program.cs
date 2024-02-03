

//Account account1 = new Account(10294,50.5f);
//account1.Deposit(100.5f);
//account1.Withdraw(10.5f);
//Account account2 = new Account(10638, 1000.5f);
//account2.Deposit(40.0f);
//account2.Withdraw(0.5f);

Transaction transaction = new Transaction();

//transaction.makeTransaction(account2, account1, 500.0f);
//Console.WriteLine(account1.GetBalance);
//Console.WriteLine(account2.GetBalance);

SavingsAccount savingsAccount = new SavingsAccount(10365,100.0f);
savingsAccount.Deposit(40);
savingsAccount.Withdraw(40);
CheckingAccount checkingAccount = new CheckingAccount(10324,150.0f);
checkingAccount.Deposit(90);
checkingAccount.Withdraw(40);
InvestmentAccount investmentAccount = new InvestmentAccount(10289,500.0f);
investmentAccount.Deposit(100);
investmentAccount.Withdraw(10);
investmentAccount.Invest(400,"Apple");


BankManager bankManager = new BankManager();


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
    public virtual void Deposit(float amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Great! Your deposit: {amount}$ hes been confirmed! Now your balance is {_balance}$");
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
    private float commission = 5;
    private int _accountNumber = 0;
    private float _balance = 0.0f;
    
    public SavingsAccount(int accountNumber, float balance) : 
        base(accountNumber, balance)
    {
        _accountNumber = accountNumber;
        _balance = balance;
    }
    public void GetAccount()
    {
        Console.WriteLine($"Account number is: {_accountNumber} \nBalance is: {_balance}");
    }
    void Deposit(float amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
        else
        {
            Console.WriteLine("Error");
        }
    }
    public override void Withdraw(float amount)
    {
        float amountCommission = amount * (commission / 100);
        amount += amountCommission;
        if(amount > 0 && amount <= _balance)
        {
            _balance -= amount;
        }
        Console.WriteLine($"Great! Your withdraw: {amount - amountCommission}$ hes been confirmed! Now your balance is {_balance}$ commision is: {amountCommission}$");

    }
}

class CheckingAccount : Account
{
    public float _balance = 0.0f;
    private int _accountNumber = 0;
    private float commission = 1;

    public CheckingAccount( int accountNumber,float balance):
        base(accountNumber,balance)
    {
        _balance = balance;
        _accountNumber = accountNumber;
    }   
    public void Deposit(int amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Great! Your deposit: {amount}$ hes been confirmed! Now your balance is {_balance}$");
        }
        else
        {
            Console.WriteLine("Error: 0x002c51 (Summ of deposit must be greaten then 0)");
        }
    }
    public override void Withdraw(float amount)
    {
        float amountCommission = amount * (commission / 100);
        amount += amountCommission;
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
        }
        Console.WriteLine($"Great! Your withdraw: {amount - amountCommission}$ hes been confirmed! Now your balance is {_balance}$ commision is: {amountCommission}$");

    }


}

class InvestmentAccount : Account
{
    public string _investmentType { get; set; }
    private float _balance = 0.0f;
    private int _accountNumber = 0;
    private float commission = 5;

    public InvestmentAccount(int accountNumber, float balance)
        :base(accountNumber, balance)
    {
        _balance = balance;
        _accountNumber = accountNumber;
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
    public void Deposit(int amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"Great! Your deposit: {amount}$ hes been confirmed! Now your balance is {_balance}$");
        }
        else
        {
            Console.WriteLine("Error: 0x002c51 (Summ of deposit must be greaten then 0)");
        }
    }
    public override void Withdraw(float amount)
    {
        float amountCommission = amount * (commission / 100);
        amount += amountCommission;
        if (amount > 0 && amount <= _balance)
        {
            _balance -= amount;
        }
        Console.WriteLine($"Great! Your withdraw: {amount - amountCommission}$ hes been confirmed! Now your balance is {_balance}$ commision is: {amountCommission}$");

    }
}

class BankManager
{
    private int accountNumber = 1;
    List<Account> accounts = new List<Account>();
    public Account _account;
    public Account OpenAccount(string AccountType,float initialBalance)
    {
        if( AccountType.ToLower() == "savings")
        {
            SavingsAccount account = new SavingsAccount(accountNumber, initialBalance);
            _account = account;
            accounts.Add(account);
            accountNumber++;
        }
        else if (AccountType.ToUpper() == "checking")
        {
            CheckingAccount account = new CheckingAccount(accountNumber, initialBalance);
            _account = account;
            accountNumber++;
            accounts.Add(account);
        }
        else if( AccountType.ToLower() == "investment")
        {
            InvestmentAccount account = new InvestmentAccount(accountNumber, initialBalance);
            _account = account;
            accountNumber++;
            accounts.Add(account);
        }
        else
        {
            return null;
        }
        return _account;
    }
    public void CloseAccount(int accountNumber)
    {
        accounts.Remove(accounts[accountNumber]);
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
            Console.WriteLine("Transaction Finished");
        }
        else
        {
            Console.WriteLine($"Transaction Failed. Account {sourceAccount.GetAccNumber} dont have {amount}$");
        }
    }
}
