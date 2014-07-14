public class Frog : Animal, ISound
{
    public Frog(string name, int age, char sex) 
        : base (name, age, sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public void ProduceSound()
    {
        System.Console.WriteLine("{0} says: Kwak", Name);
    }
}
