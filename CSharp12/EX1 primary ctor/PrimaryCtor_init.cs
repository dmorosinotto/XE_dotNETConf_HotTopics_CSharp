namespace CSharp12;
using Grade = decimal;

class EX1_PrimaryCtor_init
{
    public void Run()
    {
        var mads = new Student("Mads Torgersen", 900751, new[] { 3.5m, 2.9m, 1.8m });
        Console.WriteLine(mads.GetType().FullName);
        Console.WriteLine(mads.Name);
        Console.WriteLine(mads.GPA);
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