namespace CSharp11;
using System.Numerics;
class EX1_Person_init
{
    public void Run()
    {
        var p = new Person("Andrea", "de", "Amicis");
        var dottor = new Dev("Andrea", "Dottor");
        Console.WriteLine(dottor);
        Console.WriteLine(p);
    }

    public class Person
    {
        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }

        public Person(string first, string last)
        {
            FirstName = first;
            LastName = last;
            //SHORT SINTAX (FirstName, LastName) = (first, last);
        }

        public Person(string first, string middle, string last)
        {
            (FirstName, MiddleName, LastName) = (first, middle, last);
        }

        public override string ToString() => $"{FirstName} {MiddleName ?? ""}{LastName}";
    }

    // public class Student : Person { } //ERROR NO constructor WITH 0 ARGS...
    public class Dev : Person
    {
        public int Skills { get; init; }
        public Dev(string first, string last, int skills = 42) : base(first, last) { Skills = skills; }
        public override string ToString() => base.ToString() + $" is DEV #{Skills + FirstName.Length}";
    }
}