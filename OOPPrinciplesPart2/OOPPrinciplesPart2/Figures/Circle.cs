using System;

public class Circle : Shape
{
    public Circle(double radius)//Here I add only the radius implemented as height
    {
        this.Height = radius;
        this.Width = radius;//Here I make width equal to the height
    }

    public override double CalculateSurface()//Override the abstract method
    {
        return Math.PI * this.Height * this.Width;
    }
}
