using System;
using System.Collections.Generic;

class Bank
{
    static void Main()
    {
        List<Customer> customers = new List<Customer>();
        customers.Add(new IndividualCustomer("Pesho", "Peshov", 20, 'm'));
        customers.Add(new IndividualCustomer("Kiro", "Kirov", 25, 'm'));
        customers.Add(new CompanyCustomer("Kiro", "Peshov", 23, 'm'));
        customers.Add(new CompanyCustomer("Pesho", "Kirov", 24, 'm'));

        List<Account> accounts = new List<Account>();
        accounts.Add(new DepositAccount(customers[0], 1500, 3.5, 5));
        accounts.Add(new MortgageAccount(customers[1], 2800, 2.9, 15));
        accounts.Add(new DepositAccount(customers[2], 900, 3, 8));
        accounts.Add(new LoanAccount(customers[3], 4800, 3.2, 4));

        Console.WriteLine("{0} - Balance of {1} account", accounts[0].Balance, 1);
        Console.WriteLine("{0} - Balance of {1} account", accounts[1].Balance, 2);
        Console.WriteLine("{0} - Balance of {1} account", accounts[2].Balance, 3);
        Console.WriteLine("{0} - Balance of {1} account", accounts[3].Balance, 4);

        accounts[0].Deposit(1500);//This will add 1500 levas to the balance
        accounts[1].Draw(1500);//This will draw 1500 levas to the balance
        accounts[2].Deposit(1000);//This will add 1000 levas to the balance
        accounts[3].Draw(500);//This will draw 500 levas to the balance

        Console.WriteLine();
        Console.WriteLine("{0} - Balance of {1} account AFTER Depositing 1500 levas", accounts[0].Balance, 1);
        Console.WriteLine("{0} - Balance of {1} account AFTER Drawing 1500 levas ", accounts[1].Balance, 2);
        Console.WriteLine("{0} - Balance of {1} account AFTER Depositing 1000 levas", accounts[2].Balance, 3);
        Console.WriteLine("{0} - Balance of {1} account AFTER Drawing 500 levas", accounts[3].Balance, 4);

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();

        int counter = 1;

        foreach (var account in accounts)
        {
            Console.WriteLine("{0} account - Interest amount - {1}", counter, account.CalculateInterestAmount());

            counter++;
        }
    }
}