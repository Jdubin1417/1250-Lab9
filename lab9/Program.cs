/**
*--------------------------------------------------------------------
* File name: Program.cs
* Project name: lab9
*--------------------------------------------------------------------
* Author’s name and email: Justin Dubin, dubinj@etsu.edu
* Course-Section: CSCI 1250-001
* Creation Date: 20 Apr 2022
*
-------------------------------------------------------------------
*/
int accountNumber = 1;

decimal initialDeposit = 0.0M;
do{
    System.Console.Write("Enter an initial Deposit: ");
    initialDeposit = Convert.ToDecimal(Console.ReadLine());
} while (initialDeposit < 0.0M);

System.Console.Write("Enter your First Name: ");
string firstName = Console.ReadLine();

System.Console.Write("Enter your Last Name: ");
string lastName = Console.ReadLine();

char type;
if (initialDeposit >= 1000.0M) {type = 'M'; }
else if (initialDeposit >= 5.0M) {type = 'S'; }
else type = 'C';

BankAccount myAccount = new BankAccount(type, initialDeposit, accountNumber++, firstName, lastName);

//deposit an invalid amount
if(myAccount.Deposit(-5.0M) == false) {Console.WriteLine("Invalid Deposit Amount -- cannot deposit a negative amount"); }

//wiothdraw a negative amount
if(myAccount.Withdraw(-5.0M) == false) {Console.WriteLine("Invalid withdrawal: Cannot withdraw negative amount");}

//withdraw an amount > than the balance
if(myAccount.Withdraw(myAccount.GetBalance()+1) == false) { Console.WriteLine("Invalid withdrawal"); }

//deposit valid amount
myAccount.Deposit(27.50M);
System.Console.WriteLine("===== After Depositing 27.50 =====");
System.Console.WriteLine(myAccount);

//withdraw valid amount
myAccount.Withdraw(15.40M);
System.Console.WriteLine("===== After Withdrawing 15.40 =====");
System.Console.WriteLine(myAccount);

//calculate interest after 4 months
for(int i = 0; i < 4; i++)
{
    System.Console.WriteLine($"Interest for month {i + 1}:\t{myAccount.MonthlyInterest()}");
}
System.Console.WriteLine("=====After 4 months interest =====");
System.Console.WriteLine(myAccount);

BankAccount copyOfMyAccount = new BankAccount(myAccount);
System.Console.WriteLine("=====Copy of MyAccount=====");
System.Console.WriteLine(copyOfMyAccount);

copyOfMyAccount.LastName = "Hall";
//should be true
System.Console.WriteLine(copyOfMyAccount.Equals(myAccount));

copyOfMyAccount.Withdraw(50.00M);
//should be false
System.Console.WriteLine(copyOfMyAccount.Equals(myAccount));