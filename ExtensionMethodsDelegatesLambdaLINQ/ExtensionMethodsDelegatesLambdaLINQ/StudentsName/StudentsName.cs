/*Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
 * Use LINQ query operators.*/
using System;
using System.Collections.Generic;
using System.Linq;

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

class StudentsName
{
    static void Main()
    {
        //I make a list in which I will save the students
        List<Student> allStudents = new List<Student>();
        
        allStudents.Add(new Student("Pesho", "Peshev"));
        allStudents.Add(new Student("Pesho", "Kirov"));
        allStudents.Add(new Student("Kiro", "Peshev"));
        allStudents.Add(new Student("Kiro", "Kirov"));
        allStudents.Add(new Student("A", "B"));//A is before B so it will be printed on the console
        allStudents.Add(new Student("B", "A"));//B is after A so it wont be printed on the console

        var selectedStudents =
            from eachStudent in allStudents
            where eachStudent.FirstName.CompareTo(eachStudent.SecondName) < 0
            select eachStudent;

        foreach (var selectedStudent in selectedStudents)
        {
            Console.WriteLine(selectedStudent.FirstName + " " + selectedStudent.SecondName);
        }
    }
}
