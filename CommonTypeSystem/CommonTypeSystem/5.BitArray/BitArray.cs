using System;

class BitArray
{
    static void Main()
    {
        BitArray64 firstNumber = new BitArray64(50);

        foreach (var bit in firstNumber)
        {
            Console.Write(bit);
        }
        Console.WriteLine();

        for (int i = 63; i >= 50; i--)
        {
            firstNumber[i] = 1;
        }

        foreach (var bit in firstNumber)
        {
            Console.Write(bit);
        }
        Console.WriteLine();

        BitArray64 secondNumber = new BitArray64(ulong.MaxValue);

        foreach (var bit in secondNumber)
        {
            Console.Write(bit);
        }
        Console.WriteLine();
    }
}
