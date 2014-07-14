class Triangle : Shape
{
    public Triangle(double height, double baseOfTheTriangle)
    {
        this.Height = height;
        this.Width = baseOfTheTriangle;
    }

    public override double CalculateSurface()//Override the abstract method
    {
        return (this.Width * this.Height) / 2;
    }
}
