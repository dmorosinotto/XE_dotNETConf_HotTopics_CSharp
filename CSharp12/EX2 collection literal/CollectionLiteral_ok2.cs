namespace CSharp12;

using System.Collections.Immutable;
using Grade = decimal;
class EX2_CollectionLiteral_ok2

{
    public void Run()
    {
        var mads = new Student("Mads Torgersen", 900751, [3.5m, 2.9m, 1.8m, .. Grades.MIRCO]); //spread operator (works with other colleciton types!)
        Console.WriteLine(mads.GetType().FullName);
        Console.WriteLine(mads.GPA);
        Console.WriteLine(mads.Name);
    }
    public class Student(string name, int id, List<Grade> /*ImmutableArray<Grade> Grade[]*/ Grades)
    {
        public string Name { get; set; } = name;
        public int Id => id;
        public Student(string name, int id) : this(name, id, []) { } //empty in collection literal (infer right type!)
        public decimal GPA => Grades switch
        {
        [] => 4.0m, //empty collection in pattern matching
        [var grade] => grade,
        [.. var all] => all.Average() //slice operator in pattern  matching
        };
    }

    internal static class Grades
    {
        static internal ReadOnlySpan<Grade> MIRCO => new[] { 4.2m, 19.66m, 5.7m };
    }
}