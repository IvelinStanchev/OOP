using System;

public enum Specialty
{
    Telecommunications, Marketing, Business, Entrepreneurship, Phisics, Mathematics, Informatics, Law, Philosophy
}

public enum University
{
    SU, TU, UNSS, NBU
}

public enum Faculty
{
    Mathematics, Business, Management, Phisics, Telecommunications, Philosophy, Law
}

class ClassStudentTest
{
    static void Main()
    {
        Student firstStudent = new Student("Pesho", "Peshov", "Peshov", "1515232", "Pesho street", "0888122321", 
            "pesho@abv.bg", 2, Specialty.Business, University.NBU, Faculty.Philosophy);

        Student secondStudent = new Student("Kiro", "Kirov", "Kirov", "8213782", "Kiro street", "0888218541",
            "kiro@abv.bg", 3, Specialty.Marketing, University.NBU, Faculty.Telecommunications);

        //Student secondStudent = new Student("Pesho", "Peshov", "Peshov", "1515232", "Pesho street", "0888122321", 
        //    "pesho@abv.bg", 2, Specialty.Business, University.NBU, Faculty.Philosophy);

        Console.WriteLine(firstStudent.ToString());//Printing the characteristics of the first student using the overriden method ToString()

        Console.WriteLine();

        firstStudent.Clone();//cloning the first student
        secondStudent.Clone();//cloning the second student

        Console.WriteLine("The first student is equal to the second one: {0}", firstStudent.Equals(secondStudent));

        if (firstStudent != secondStudent)
        {
            Console.WriteLine("The first student isn't equal to the second one");
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();

        if (firstStudent.CompareTo(secondStudent) < 0)
        {
            Console.WriteLine("The first student is lower than the second student according to the ASCII table");
        }
        if (firstStudent.CompareTo(secondStudent) == 0)
        {
            Console.WriteLine("The first student is the same like the second student according to the ASCII table");
        }
        if (firstStudent.CompareTo(secondStudent) > 0)
        {
            Console.WriteLine("The first student is bigger than the second student according to the ASCII table");
        }
    }
}
