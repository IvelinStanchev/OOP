class Worker : Human
{
    public int WeekSalary { get; set; }
    public int WorkHoursPerDay { get; set; }

    public double SalarayPerHour
    {
        get
        {
            return MoneyPerHour(this.WeekSalary, this.WorkHoursPerDay);
        }
        set
        {
        }
    }

    public Worker(string firstName, string secondName, int weekSalary, int workHoursPerDay)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double MoneyPerHour(int weekSalary, int workHoursPerDay)
    {
        double moneyPerHour;
        moneyPerHour = ((double)weekSalary / 7) / (double)workHoursPerDay;
        return moneyPerHour;
    }
}
