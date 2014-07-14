using System.Collections.Generic;

public class Teacher : Person, ICommentable
{
    private List<Discipline> disciplines;
    private List<string> comments;

    public Discipline[] Disciplines
    {
        get
        {
            return this.disciplines.ToArray();
        }
        private set
        {
        }
    }

    public string[] Comments
    {
        get
        {
            return this.comments.ToArray();
        }
        private set
        {
        }
    }

    public Teacher(string name, Discipline[] disciplines) : base(name)
    {
        this.disciplines = new List<Discipline>(disciplines);
        this.comments = new List<string>();
    }

    public void AddDiscipline(Discipline discipline)
    {
        this.disciplines.Add(discipline);
    }

    public void RemoveDiscipline(Discipline discipline)
    {
        this.disciplines.Remove(discipline);
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }
}
