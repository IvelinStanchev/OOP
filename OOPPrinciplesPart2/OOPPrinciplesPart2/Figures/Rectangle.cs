class Rectangle : Shape
{
    public Rectangle(double width, double height)//Constructor
    {
        this.Width = width;
        this.Height = height;
    }

    public override double CalculateSurface()//Override the abstract method
    {
        return this.Width * this.Height;
    }
}
