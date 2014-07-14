using System.Collections.Generic;

public class Student : Person, ICommentable
{
    private int uniqueClassNumber;
    private List<string> comments;

    public int UniqueClassNumber 
    { 
        get
        {
            return this.uniqueClassNumber;
        }
        set
        {
            this.uniqueClassNumber = value;
        }
    }

    public string[] Comments
    {
        get
        {
            return this.comments.ToArray();
        }
    }

    public Student(string name, int uniqueClassNumber) : base(name)
    {
        this.UniqueClassNumber = uniqueClassNumber;
        this.comments = new List<string>();
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }
}
