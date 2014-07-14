using System;

public class Account
{
    public int NumberOfMonths { get; set; }
    public double Balance { get; set; }
    public double InterestRate { get; set; }//Monthly based
    public Customer OneCustomer { get; set; }

    public Account(Customer oneCustomer, double balance, double interestRate, int numberOfMonth)
    {
        this.OneCustomer = oneCustomer;
        this.Balance = balance;
        this.InterestRate = interestRate;
        this.NumberOfMonths = numberOfMonth;
    }

    public virtual void Deposit(double money)
    {
        this.Balance += money;
    }

    public virtual void Draw(double money)
    {
        if (money > this.Balance)
        {
            throw new ArgumentOutOfRangeException("You don't have enough money in your account");
        }
        this.Balance += money;
    }

    public virtual double CalculateInterestAmount()
    {
        return this.NumberOfMonths * this.InterestRate;
    }
}
