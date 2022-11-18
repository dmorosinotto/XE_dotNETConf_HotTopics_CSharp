namespace CSharp11;
using System.Numerics;
class EX1_Person_mid
{
    public void Run()
    {
        var p = new Person { FirstName = "Andrea", MiddleName = "de", LastName = "Amicis" };
        var dottor = new Dev { FirstName = "Andrea", LastName = "Dottor" };
        var mirco = new Person { LastName = "Vanini" }; //NO ERROR MISSIN FirstName -> CHANGE TO Dev EX!!!
        Console.WriteLine(p);
        Console.WriteLine(dottor);
        Console.WriteLine(mirco);
    }

    public class Person
    {
        public string FirstName { get; init; } //= ""; //WARN non-nullable MAYBE null
        public string? MiddleName { get; init; }
        public string LastName { get; init; } = null!;

        public override string ToString() => $"{FirstName} {MiddleName ?? ""}{LastName}";
    }

    public class Dev : Person
    {
        public int Skills { get; init; } = 42;
        public override string ToString() => base.ToString() + $" is DEV #{Skills + FirstName.Length}";
    }

}
