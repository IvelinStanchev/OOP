public class Person
{
    private string name;

    public string Name 
    { 
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    public Person(string name)
    {
        this.name = name;
    }
}
