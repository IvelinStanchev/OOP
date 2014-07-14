using System;
using System.Text;

public class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string PermanentAddress { get; set; }
    public string MobilePhone { get; set; }
    public string EMail { get; set; }
    public int Course { get; set; }
    public Specialty Specialty { get; set; }
    public University University { get; set; }
    public Faculty Faculty { get; set; }

    public Student()
    {
    }

    public Student(string firstName, string middleName, string lastName, string socialSecurityNumber, string permanentAddress,
        string mobilePhone, string eMail, int course, Specialty specialty, University university, Faculty faculty)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SocialSecurityNumber = socialSecurityNumber;
        this.PermanentAddress = permanentAddress;
        this.MobilePhone = mobilePhone;
        this.EMail = eMail;
        this.Course = course;
        this.Specialty = specialty;
        this.University = university;
        this.Faculty = faculty;
    }

    //Override the standard methods, inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.

    public static bool operator ==(Student firstStudent, Student secondStudent)
    {
        return Student.Equals(firstStudent, secondStudent);
    }
    public static bool operator !=(Student firstStudent, Student secondStudent)
    {
        return !(Student.Equals(firstStudent, secondStudent));
    }
    public override int GetHashCode()
    {
        return this.FirstName.GetHashCode() ^ this.SocialSecurityNumber.GetHashCode();
    }

    public override bool Equals(object param)
    {
        Student student = param as Student;

        if (student == null)
        {
            return false;
        }
        if (!Object.Equals(this.FirstName, student.FirstName))
        {
            return false;
        }
        if (!Object.Equals(this.MiddleName, student.MiddleName))
        {
            return false;
        }
        if (!Object.Equals(this.LastName, student.LastName))
        {
            return false;
        }
        if (!Object.Equals(this.SocialSecurityNumber, student.SocialSecurityNumber))
        {
            return false;
        }

        return true;
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.Append(string.Format("First name: {0}\n", this.FirstName));
        result.Append(string.Format("Middle name: {0}\n", this.MiddleName));
        result.Append(string.Format("Last name: {0}\n", this.LastName));
        result.Append(string.Format("Social Security Number: {0}\n", this.SocialSecurityNumber));
        result.Append(string.Format("Permanent address: {0}\n", this.PermanentAddress));
        result.Append(string.Format("Mobile phone: {0}\n", this.MobilePhone));
        result.Append(string.Format("E-mail: {0}\n", this.EMail));
        result.Append(string.Format("Course: {0}\n", this.Course));
        result.Append(string.Format("Specialty: {0}\n", this.Specialty));
        result.Append(string.Format("University: {0}\n", this.University));
        result.Append(string.Format("Faculty: {0}", this.Faculty));

        return result.ToString();
    }

    object ICloneable.Clone()
    {
        return this.Clone();
    }

    public Student Clone()
    {
        Student cloned = new Student
            (
            this.FirstName,
            this.MiddleName,
            this.LastName,
            this.SocialSecurityNumber,
            this.PermanentAddress,
            this.MobilePhone,
            this.EMail,
            this.Course,
            this.Specialty,
            this.University,
            this.Faculty
            );

        return cloned;
    }

    public int CompareTo(Student student)
    {
        if (this.FirstName != student.FirstName)
        {
            return String.Compare(this.FirstName, student.FirstName);
        }
        if (this.MiddleName != student.MiddleName)
        {
            return String.Compare(this.MiddleName, student.MiddleName);
        }
        if (this.LastName != student.LastName)
        {
            return String.Compare(this.LastName, student.LastName);
        }
        if (this.SocialSecurityNumber != student.SocialSecurityNumber)
        {
            return String.Compare(this.SocialSecurityNumber, student.SocialSecurityNumber);
        }

        return 0;
    }
}
