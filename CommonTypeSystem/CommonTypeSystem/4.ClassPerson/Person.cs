using System.Text;
public class Person
{
    private string name;
    private int? age;

    public Person(string name, int? age = null)
    {
        this.name = name;
        this.age = age;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append(string.Format("Name: {0}", this.name));

        if (this.age == null)
        {
            result.Append("\nThe age is unspecified (contains null value)");
        }
        else
        {
            result.Append(string.Format("\nAge: {0}", this.age));
        }

        return result.ToString();
    }
}
