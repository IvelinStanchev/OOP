using System.Collections.Generic;

public class School : Class
{
    private List<Class> classes;

    public Class[] Classes
    {
        get
        {
            return this.classes.ToArray();
        }
        private set
        {
        }
    }

    public School(Class[] classes)
    {
        this.classes = new List<Class>(classes);
    }

    public void AddClass(Class classInSchool)
    {
        this.classes.Add(classInSchool);
    }

    public void RemoveClass(Class classInSchool)
    {
        this.classes.Remove(classInSchool);
    }
}
