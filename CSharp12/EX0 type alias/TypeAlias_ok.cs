namespace CSharp12;
using Grade = decimal;
using Pair = (int First, int Second);
// #pragma warning disable '0227' //suppress warning CS0227 for unsafe code
// using unsafe OnlyForMirco = decimal*; //unsafe require /unsafe compiler option

class EX0_TypeAlias_ok
{
    public void Run()
    {
        var mads = new Student("Mads Torgersen", 900751, new[] { 3.5m, 2.9m, 1.8m });
        Console.WriteLine(mads.GetType().FullName);
        Console.WriteLine(mads);
    }
    public record class Student(string Name, int Id, Grade[] Grades)
    {
        public Student(string name, int id) : this(name, id, Array.Empty<Grade>()) { }
        public decimal GPA => Grades switch
        {
        [] => 4.0m,
        [var grade] => grade,
        [.. var all] => all.Average()
        };
    }
}