using System.Collections.Generic;

public class Class : ICommentable
{
    private List<Student> students;
    private List<Teacher> teachers;
    private List<string> comments;
    private string uniqueTextIdentifier;

    public Student[] Students
    {
        get 
        { 
            return this.students.ToArray();
        }
        private set
        {
        }
    }

    public Teacher[] Teachers
    {
        get
        {
            return this.teachers.ToArray();
        }
        private set
        {
        }
    }

    public string UniqueTextIdentifier 
    {
        get
        {
            return this.uniqueTextIdentifier;
        }
        set
        {
            this.uniqueTextIdentifier = value;
        }
    }

    public string[] Comments
    {
        get
        { 
            return this.comments.ToArray(); 
        }
    }

    //constructor
    public Class()
    { 
    }

    public Class(Student[] students, Teacher[] teachers, string uniqueTextIdentifier) : base()
    {
        this.students = new List<Student>(students);
        this.teachers = new List<Teacher>(teachers);
        this.uniqueTextIdentifier = uniqueTextIdentifier;
        this.comments = new List<string>();
    }

    public void AddStudent(Student student)
    {
        this.students.Add(student);
    }

    public void RemoveStudent(Student student)
    {
        this.students.Remove(student);
    }

    public void AddTeacher(Teacher teacher)
    {
        this.teachers.Add(teacher);
    }

    public void RemoveTeacher(Teacher teacher)
    {
        this.teachers.Remove(teacher);
    }

    public void AddComment(string comment)
    {
        this.comments.Add(comment);
    }
}
