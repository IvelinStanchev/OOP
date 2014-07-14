public abstract class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    public char Sex { get; set; }

    public Animal(string name, int age, char sex)
    {
        this.Name = name;
        this.Age = age;
        this.Sex = sex;
    }

    public static double AverageAge(Animal[] arrayOfOneTypeAnimal)
    {
        double averageAge = 0.0;

        for (int i = 0; i < arrayOfOneTypeAnimal.Length; i++)
        {
            averageAge += arrayOfOneTypeAnimal[i].Age;
        }

        return averageAge / arrayOfOneTypeAnimal.Length;
    }
}
