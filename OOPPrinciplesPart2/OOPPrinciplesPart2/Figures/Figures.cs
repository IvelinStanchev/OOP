using System;

class Figures
{
    static void Main()
    {
        Shape[] figures = new Shape[]
        {
            new Rectangle(5.5, 8.4),
            new Triangle(5, 2),
            new Circle(5),
            new Triangle(4.6, 8.9),
            new Circle(4.8),
        };

        foreach (Shape figure in figures)//Testing the method CalculateSurface()
        {
            Console.Write("{0} with surface: ", figure.GetType().Name);
            Console.WriteLine("{0:F2}", figure.CalculateSurface());
        }
    }
}
