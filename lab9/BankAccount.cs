/**
*--------------------------------------------------------------------
* File name: BankAccount.cs
* Project name: lab9
*--------------------------------------------------------------------
* Author’s name and email: Justin Dubin, dubinj@etsu.edu
* Course-Section: CSCI 1250-001
* Creation Date: 20 Apr 2022
*
-------------------------------------------------------------------
*/
public class BankAccount
{
    private int accountNumber;
    private char type;
    private decimal balance;
    public string FirstName { get; set; }
    public string LastName { get; set; }

    //constructors
    //parameterized constructor
    public BankAccount(char type, decimal initialDeposit, int accountNumber, string firstName, string lastName)
    {
       this.type = type;
       this.balance = initialDeposit;
       this.accountNumber = accountNumber;
       FirstName = firstName;
       LastName = lastName;
    }

    //copy constructor
    public BankAccount(BankAccount obj)
    {
        this.type = obj.type;
        this.balance = obj.balance;
        this.accountNumber = obj.accountNumber;
        FirstName = obj.FirstName;
        LastName = obj.LastName;
    }

    public int GetAccountNumber() {return accountNumber; }
    public decimal GetBalance() {return balance; }
    
    public string GetAccountTypeAsAString() 
    {
       if(type == 'C' || type == 'c') {return "Checking Account"; }
       else if(type == 'S' || type == 's') {return "Savings Account"; } 
       else return "Money Market Account (MMA)"; 
    }
   
    public decimal GetMonthlyInterestRate()
    {
        if(type == 'C' || type == 'c') return 0.5M;
       else if(type == 'S' || type == 's') return 2.4M; 
       else return 8.0M;
    }

    public bool Deposit(decimal amount)
    {
        if(amount <= 0) {return false; }
        
            balance += amount;
            return true;
        
    }

    public bool Withdraw(decimal amount)
    {
        if(amount <= 0) {return false; }

        //Savings Account logic
        if (type == 'S')
        {
            if((balance - amount) < 5.0M) {return false; } 
            // savings withdrawal amounts cannot exceed $500.00
            if(amount > 500) { return false; }
        }

        //MMA Account Logic
        if(type == 'M')
        {
            //MMA Must always have at least 1000.00 minimum balance
            if ((balance - amount) < 1000.0M) {return false; }
            //MMA Withdrawals cannot exceed 250.00
            if(amount > 250.0M) {return false; }
        }

        balance -= amount;
        return true;
    }
    
    public decimal MonthlyInterest()
    {
        var addedInterest = balance * (GetMonthlyInterestRate()/100);
        balance += addedInterest;
        return addedInterest;
    }

    public override bool Equals(object obj)
    {
        BankAccount accountToCompare = (BankAccount)obj;
        return type == accountToCompare.type && 
            accountNumber == accountToCompare.accountNumber &&
            balance == accountToCompare.balance;
    }

    public override string ToString()
    {
        string accountString = "";
        accountString += $"Name:\t\t\t{FirstName} {LastName}\n";
        accountString += $"Account Number:\t\t{accountNumber}\n";
        accountString += $"Account Type:\t\t{GetAccountTypeAsAString()}\n";
        accountString += $"Current Balance:\t${balance}\n";
        accountString += $"Monthly Interest Rate:\t{GetMonthlyInterestRate()}\n";
        return accountString;
    }
}