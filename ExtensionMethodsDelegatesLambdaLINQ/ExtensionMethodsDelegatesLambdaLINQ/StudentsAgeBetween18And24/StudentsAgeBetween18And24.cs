/*Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.*/
using System;
using System.Collections.Generic;
using System.Linq;

//I am getting the class of the previous task and insert an Age
public class Student
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public int Age { get; set; }

    public Student(string firstName, string secondName, int age)
    {
        this.FirstName = firstName;
        this.SecondName = secondName;
        this.Age = age;
    }
}

class StudentsAgeBetween18And24
{
    static void Main()
    {
        List<Student> allStudents = new List<Student>();

        allStudents.Add(new Student("Pesho", "Peshev", 15));
        allStudents.Add(new Student("Pesho", "Kirov", 24));
        allStudents.Add(new Student("Kiro", "Peshev", 23));
        allStudents.Add(new Student("Kiro", "Kirov", 18));

        var studentsByAge =
            from student in allStudents
            where student.Age >= 18 && student.Age <= 24
            select student;

        foreach (var student in studentsByAge)
        {
            Console.WriteLine(student.FirstName + " " + student.SecondName + " -> " + student.Age + " years old");
        }
    }
}
