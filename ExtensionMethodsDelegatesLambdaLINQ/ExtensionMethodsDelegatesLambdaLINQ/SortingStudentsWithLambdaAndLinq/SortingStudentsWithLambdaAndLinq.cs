/*Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name in descending
 order. Rewrite the same with LINQ.*/
using System;
using System.Linq;
using System.Collections.Generic;

public class Student
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }

    public Student(string firstName, string secondName)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
    }
}

class SortingStudentsWithLambdaAndLinq
{
    static void Main()
    {
        List<Student> allStudents = new List<Student>();

        allStudents.Add(new Student("Pesho", "Peshev"));
        allStudents.Add(new Student("Pesho", "Kirov"));
        allStudents.Add(new Student("Kiro", "Peshev"));
        allStudents.Add(new Student("Kiro", "Kirov"));

        //With lambda expression
        var orderedStudents = allStudents.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.SecondName);

        //With LINQ

        //var orderedStudents =
        //    from student in allStudents
        //    orderby student.FirstName descending, student.SecondName descending
        //    select student;

        foreach (var student in orderedStudents)
        {
            Console.WriteLine(student.FirstName + " " + student.SecondName);
        }
    }
}
