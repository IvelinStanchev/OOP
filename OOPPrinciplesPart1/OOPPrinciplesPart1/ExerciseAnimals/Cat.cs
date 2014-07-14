public class Cat : Animal, ISound
{
    public Cat(string name, int age, char sex)
        : base(name, age, sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public void ProduceSound()
    {
        System.Console.WriteLine("{0} says: Myau", Name);
    }
}
