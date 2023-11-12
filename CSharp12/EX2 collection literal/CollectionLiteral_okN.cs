namespace CSharp12;

using System.Collections.Immutable;
using Grade = decimal;
class EX2_CollectionLiteral_okN

{
    public void Run()
    {
        var mads = new Student("Mads Torgersen", 900751, [3.5m, 2.9m, 1.8m, /* ["JS":3.5m, "TS":2.9m, "C#":1.8m]*/]); //IN FUTURE INTERFACE + DICTIONARY INITIALIZER
        Console.WriteLine(mads.GetType().FullName);
        Console.WriteLine(mads.GPA);
        Console.WriteLine(mads.Name);
    }
    public class Student(string name, int id, IEnumerable<Grade>/* IReadOnlyDictionary<string, Grade> */ Grades)
    {
        public string Name { get; set; } = name;
        public int Id => id;
        public Student(string name, int id) : this(name, id, []) { } //WHAT TARGET TYPE WILL IT USE FOR INTERFACE?
        public decimal GPA => Grades switch
        {
            // THIS DOESN'T WORK WITH INTERFACE COLLECITON!!!
            // [] => 4.0m, //empty collection in pattern matching
            // [var grade] => grade,
            // [.. var all] => all.Average() //slice operator in pattern  matching
        };
    }
}