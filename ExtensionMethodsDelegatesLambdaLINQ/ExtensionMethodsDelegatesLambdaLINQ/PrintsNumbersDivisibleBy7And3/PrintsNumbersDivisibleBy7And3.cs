/*Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
 Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.*/
using System;
using System.Linq;

class PrintsNumbersDivisibleBy7And3
{
    static void Main()
    {
        int[] numbers = new int[] { 1, 2, 5, 7, 9, 15, 21, 42, 51, 125};

        //With lambda

        //var divisibleNumbers = numbers
        //    .Where(x => x % 7 == 0 && x % 3 == 0)
        //    .Select(x => x);

        //With LINQ
        var divisibleNumbers =
            from number in numbers
            where number % 7 == 0 && number % 3 == 0
            select number;

        foreach (var number in divisibleNumbers)
        {
            Console.WriteLine(number);
        }
    }
}
