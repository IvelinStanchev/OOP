using System;
using System.Collections.Generic;
using System.Linq;

class StudentsAndWorkers
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        students.Add(new Student("Sussen", "Utaie", 5));
        students.Add(new Student("Phad", "Ildd", 2));
        students.Add(new Student("Etsden", "Soquaryn", 10));
        students.Add(new Student("Itenthe", "Burwor", 8));
        students.Add(new Student("Attan", "Yergos", 12));
        students.Add(new Student("Emosrad", "Myaz", 10));
        students.Add(new Student("Athasold", "Drapery", 3));
        students.Add(new Student("Suil", "Mosusk", 4));
        students.Add(new Student("Imtan", "Itar", 5));
        students.Add(new Student("Morimo", "Barova", 6));

        //I am sorting the students by grade
        var sortedStudentsByGrade = students.OrderBy(x => x.Grade);

        int counter = 1;
        Console.WriteLine("Sorted students by grade: ");
        foreach (var student in sortedStudentsByGrade)
        {
            Console.WriteLine("{0}. {1} {2} - {3}", counter, student.FirstName, student.SecondName, student.Grade);
            counter++;
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();

        List<Worker> workers = new List<Worker>();

        workers.Add(new Worker("Rhit", "Lahin", 1500, 9));
        workers.Add(new Worker("Vesbel", "Diss", 1000, 2));
        workers.Add(new Worker("Quatherban", "Ikalo", 1100, 8));
        workers.Add(new Worker("Essen", "Schiachkal", 2800, 15));
        workers.Add(new Worker("Elmack", "Nebel", 800, 7));
        workers.Add(new Worker("Deliti", "Rotht", 700, 8));
        workers.Add(new Worker("Issechdel", "Enggar", 1500, 9));
        workers.Add(new Worker("Neraz", "Hurori", 1500, 10));
        workers.Add(new Worker("Keirroth", "Nalmorer", 1300, 6));
        workers.Add(new Worker("Dindra", "Yenda", 3500, 14));

        //I am sorting the workers by their money per hour
        var sortedWorkersByTheirHourSalary = workers.OrderByDescending(x => x.MoneyPerHour(x.WeekSalary, x.WorkHoursPerDay));

        counter = 1;
        Console.WriteLine("Sorted workers by their hour salary: ");
        foreach (var worker in sortedWorkersByTheirHourSalary)
        {
            Console.WriteLine("{0}. {1} {2} - {3:F2}", counter, worker.FirstName, worker.SecondName, worker.SalarayPerHour);
            counter++;
        }

        //Slows down the program
        System.Threading.Thread.Sleep(8000);
        var mergedLists = sortedWorkersByTheirHourSalary.Concat<Human>(sortedStudentsByGrade).ToList();
        mergedLists = mergedLists.OrderBy(x => x.FirstName).ThenBy(x => x.SecondName).ToList();

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();
        Console.WriteLine("Ordered people by first name and second name: ");
        foreach (var person in mergedLists)
        {
            Console.WriteLine(person.FirstName + " " + person.SecondName);
        }
    }
}
