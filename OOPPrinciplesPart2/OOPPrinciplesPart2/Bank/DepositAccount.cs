using System;

public class DepositAccount : Account, IDepositable, IDrawable
{
    private int depositPeriod;

    public DepositAccount(Customer oneCustomer, double balance, double interestRate, int depositPeriod)
        : base(oneCustomer, balance, interestRate, depositPeriod)
    {
        this.depositPeriod = depositPeriod;
    }

    public override void Deposit(double money)
    {
        this.Balance += money;
    }

    public override void Draw(double moneyForDrawing)
    {
        if (this.Balance < moneyForDrawing)
        {
            throw new ArgumentOutOfRangeException("There are not enough money in your account");
        }
        else
        {
            this.Balance -= moneyForDrawing;
        }
    }

    public override double CalculateInterestAmount()
    {
        if (this.Balance < 1000)
        {
            return 0;
        }
        else
        {
            return this.NumberOfMonths * this.InterestRate;
        }
    }
}
