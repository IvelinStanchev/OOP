/*Using delegates write a class Timer that has can execute certain method at each t seconds.*/
using System;
using System.Diagnostics;

public delegate void Timer (string message, int seconds);

class ClassTimer
{
    public static void LoopMethod(string message, int seconds)
    {
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();

        while (true)
        {
            if (stopWatch.ElapsedMilliseconds == seconds * 1000)
            {
                Console.WriteLine(message);
                stopWatch.Restart();
            }
        }
    }

    static void Main()
    {
        Timer timer = new Timer(LoopMethod);
        timer("This will be repeated every one second!", 1);
    }
}
