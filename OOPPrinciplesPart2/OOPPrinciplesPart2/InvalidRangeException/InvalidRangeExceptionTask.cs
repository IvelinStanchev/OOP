using System;

class InvalidRangeExceptionTask
{
    static void Main()
    {
        //Checking if the program works for int numbers
        InvalidRangeException<int> intRanges = 
            new InvalidRangeException<int>("You have entered a number which doesnt fit in the range 1 - 100!", 1, 100);

        Console.WriteLine("Enter 5 numbers in the range 1 - 100");
        for (int i = 0; i < 5; i++)
        {
            int number = int.Parse(Console.ReadLine());

            if (number < intRanges.Start || number > intRanges.End)
            {
                throw intRanges;
            }
            else
            {
                Console.WriteLine("You have entered a correct number!");
            }
        }

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();

        //Checking if the program works for dates
        string startingDate = "1.1.1980";
        string endingDate = "31.12.2013";

        InvalidRangeException<DateTime> dateAndTimeRanges = 
            new InvalidRangeException<DateTime>("You have entered an incorrect date!", DateTime.Parse(startingDate), DateTime.Parse(endingDate));

        Console.WriteLine("Enter 5 dates in the format [ dd.mm.yyyy ] in the range 1.1.1980 - 31.12.2013");
        for (int i = 0; i < 5; i++)
        {
            string date = Console.ReadLine();
            DateTime currentDate = DateTime.Parse(date);

            if (currentDate < dateAndTimeRanges.Start || currentDate > dateAndTimeRanges.End)
            {
                throw dateAndTimeRanges;
            }
            else
            {
                Console.WriteLine("You have entered a correct date!");
            }
        }
    }
}
