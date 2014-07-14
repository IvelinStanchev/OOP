using System;

class ClassPerson
{
    static void Main()
    {
        Person firstPerson = new Person("pesho", 5);
        Person secondPerson = new Person("kiro");
        Person thirdPerson = new Person("pesho and kiro", null);

        Console.WriteLine("Specified age: \n{0}", firstPerson.ToString());
        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();
        Console.WriteLine("Unspecified ages: \n\n{0}", secondPerson.ToString());
        Console.WriteLine();
        Console.WriteLine(thirdPerson.ToString());
    }
}
