using System.Collections.Generic;

public class Discipline : ICommentable
{
    private string name;
    private int numberOfLectures;
    private int numberOfExercises;
    private List<string> comments;

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

    public int NumberOfLectures 
    {
        get
        {
            return this.numberOfLectures;
        }
        set
        {
            this.numberOfLectures = value;
        }
    }

    public int NumberOfExercises
    {
        get
        {
            return this.numberOfExercises;
        }
        set
        {
            this.numberOfExercises = value;
        }
    }

    public string[] Comments
    {
        get
        {
            return this.comments.ToArray();
        }
    }

    public Discipline(string name, int numberOfLectures, int numberOfExercises)
    {
        this.Name = name;
        this.NumberOfLectures = numberOfLectures;
        this.NumberOfExercises = numberOfExercises;
        this.comments = new List<string>();
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }
}
