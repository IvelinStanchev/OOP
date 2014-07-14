/*Implement an extension method Substring(int index, int length) for the class StringBuilder that returns new StringBuilder 
 and has the same functionality as Substring in the class String.*/
using System;
using System.Text;

public static class Extensions
{
    public static StringBuilder Substring(this StringBuilder result, int index, int length)
    {
        if (index + length > result.Length)
        {
            throw new ArgumentException("The new index is bigger than the stringbuilder's variable");
        }

        if (index < 0)
        {
            throw new IndexOutOfRangeException("Index must be non-negative");
        }

        if (index > result.Length)
        {
            throw new IndexOutOfRangeException("Index must be lower than the StringBuilder's one");
        }

        if (length > result.Length)
        {
            throw new IndexOutOfRangeException("The input length is bigger than the length of the current item");
        }

        if (length < 0)
        {
            throw new IndexOutOfRangeException("The length must be non-negative");
        }

        StringBuilder substringedResult = new StringBuilder();

        for (int i = index; i < index + length; i++)
        {
            substringedResult.Append(result[i]);
        }

        return substringedResult;
    }
}

class SubstringForStringBuilder
{
    static void Main()
    {
        StringBuilder substringedResult = new StringBuilder();
        substringedResult.Append("Telerik Academy");
        substringedResult = substringedResult.Substring(0, 5);
        Console.WriteLine(substringedResult);
    }
}
