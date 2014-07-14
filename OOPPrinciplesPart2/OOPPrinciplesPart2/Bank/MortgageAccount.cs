public class MortgageAccount : Account, IDepositable
{
    private int mortgagePeriod;

    public MortgageAccount(Customer oneCustomer, double balance, double interestRate, int mortgagePeriod)
        : base(oneCustomer, balance, interestRate, mortgagePeriod)
    {
        this.mortgagePeriod = mortgagePeriod;
    }

    public override void Deposit(double money)
    {
        this.Balance += money;
    }

    public override double CalculateInterestAmount()
    {
        if (this.mortgagePeriod <= 12 && this.OneCustomer is CompanyCustomer)
        {
            return this.mortgagePeriod * (this.InterestRate / 2);
        }
        else if (this.mortgagePeriod <= 6 && this.OneCustomer is IndividualCustomer)
        {
            return 0;
        }
        else
        {
            return this.mortgagePeriod * this.InterestRate;
        }
    }
}
