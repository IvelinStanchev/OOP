class Student : Human
{
    private int grade;

    public int Grade 
    { 
        get
        {
            return this.grade;
        }
        set
        {
            this.grade = value;
        }
    }

    public Student(string firstName, string secondName, int grade)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Grade = grade;
    }
}
