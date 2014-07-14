/*Implement a set of extension methods for IEnumerable<T> that implement the following group functions: sum, product, min, max, average.*/
using System;
using System.Collections.Generic;

public static class Extensions
{
    public static T Sum<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic sum = 0;

        foreach (var item in input)
        {
            sum += item;
        }

        return sum;
    }

    public static T Product<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic product = 1;

        foreach (var item in input)
        {
            product *= item;
        }

        return product;
    }

    public static T Min<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic min = int.MaxValue;

        foreach (var currentNumber in input)
        {
            if (currentNumber < min)
            {
                min = currentNumber;
            }
        }

        return min;
    }

    public static T Max<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic max = int.MinValue;

        foreach (var currentNumber in input)
        {
            if (currentNumber > max)
            {
                max = currentNumber;
            }
        }

        return max;
    }

    public static decimal Average<T>(this IEnumerable<T> input) where T : IComparable
    {
        dynamic sum = 0;
        decimal counter = 0;

        foreach (var item in input)
        {
            sum += item;
            counter++;
        }

        return sum / counter;
    }
}

class ExtensionMethodsForIEnumerableT
{
    static void Main()
    {
        int[] numbers = new int[10];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i + 1;
        }

        Console.WriteLine(numbers.Sum());
        Console.WriteLine(numbers.Product());
        Console.WriteLine(numbers.Max());
        Console.WriteLine(numbers.Min());
        Console.WriteLine(numbers.Average());
    }
}
