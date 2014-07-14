public class LoanAccount : Account, IDepositable
{
    private int loanPeriod;

    public LoanAccount(Customer oneCustomer, double balance, double interestRate, int loanPeriod)
        : base (oneCustomer, balance, interestRate, loanPeriod)
    {
        this.loanPeriod = loanPeriod;
    }

    public override void Deposit(double money)
    {
        this.Balance += money;
    }

    public override double CalculateInterestAmount()
    {
        if (this.loanPeriod <= 3 && this.OneCustomer is IndividualCustomer)
        {
            return 0;
        }
        else if (this.loanPeriod <= 2 && this.OneCustomer is CompanyCustomer)
        {
            return 0;
        }
        else
        {
            return this.loanPeriod * this.InterestRate;
        }
    }
}
