namespace CSharp12;
using Grade = decimal;

class EX1_PrimaryCtor_ok
{
    public void Run()
    {
        var mads = new Student("Mads Torgersen", 900751, new[] { 3.5m, 2.9m, 1.8m });
        Console.WriteLine(mads.GetType().FullName);
        Console.WriteLine(mads.GPA);
        Console.WriteLine(mads.Name);
    }
    public class Student(string name, int id, Grade[] Grades) : Person(name) //primary ctor -> call base ctor
    {
        public int Id => id;
        public Student(string name, int id) : this(name, id, Array.Empty<Grade>()) { } //other ctor -> MUST call primary ctor
        public decimal GPA => Grades switch
        {
        [] => 4.0m,
        [var grade] => grade,
        [.. var all] => all.Average()
        };
    }

    public class Person(string name)
    {
        public string Name { get; set; } = name;
    }
}