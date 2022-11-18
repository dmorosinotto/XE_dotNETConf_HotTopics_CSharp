namespace CSharp11;
using System.Numerics;
class EX1_Person_ok
{
    public void Run()
    {
        var p = new Person { FirstName = "Andrea", MiddleName = "de", LastName = "Amicis" };
        var dottor = new Dev { FirstName = "Andrea", LastName = "Dottor" /*, Skills = 42 */};
        var mirco = /* new Person { LastName = "Vanini" } //NOW ERROR IF MISSIN FirstName !!!*/
                    new Dev { LastName = "Vanini", FirstName = "Mirco", Skills = int.MaxValue };
        Console.WriteLine(p);
        Console.WriteLine(dottor);
        Console.WriteLine(mirco);
    }

    public class Person
    {
        public required string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public required string LastName { get; init; }

        public override string ToString() => $"{FirstName} {MiddleName ?? ""}{LastName}";
    }

    public class Dev : Person
    {
        public /*required*/ int Skills { get; init; } = 42; //IF MARK required NOT USE default init Value
        public override string ToString() => base.ToString() + $" is DEV #{Skills + FirstName.Length}";
    }

}
