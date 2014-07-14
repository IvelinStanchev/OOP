using System;

class SchoolExercise
{
    static void Main()
    {
        Student firstStudent = new Student("Pesho", 1);
        Student secondStudent = new Student("Pesho2", 2);
        Student thirdStudent = new Student("Pesho3", 3);

        Student[] students = new Student[] { firstStudent, secondStudent, thirdStudent };

        Discipline firstDiscipline = new Discipline("javelin-throwing", 5, 10);
        Discipline secondDiscipline = new Discipline("weight-lifting", 5, 8);

        Teacher firstTeacher = new Teacher("Maria", new Discipline[] { firstDiscipline, secondDiscipline });
        Teacher secondTeacher = new Teacher("Petq", new Discipline[] { firstDiscipline, secondDiscipline });
        Teacher[] teachers = new Teacher[] { firstTeacher, secondTeacher };

        Class firstClass = new Class(students, teachers, "B");

        firstStudent.AddComment("I am Pesho and I can throw a javelin far away");
        secondStudent.AddComment("I am Pesho2 and I can lift heavy weights");
        firstTeacher.AddComment("Pesho is good");
        secondTeacher.AddComment("Pesho2 is not as good as Pesho");

        Console.WriteLine("{0} said: {1}", firstStudent.Name, firstStudent.Comments[0]);
        Console.WriteLine("{0} said: {1}", secondStudent.Name, secondStudent.Comments[0]);
        Console.WriteLine("{0} said: {1}", firstTeacher.Name, firstTeacher.Comments[0]);
        Console.WriteLine("{0} said: {1}", secondTeacher.Name, secondTeacher.Comments[0]);
    }
}
