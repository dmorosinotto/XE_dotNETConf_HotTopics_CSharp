namespace CSharp12;
using Grade = double; //decimal -> double JUST FUN WITH FLOATING POINT IEEE754 ^_^
using Skill = (string lang, double lvl);

class EX2_CollectionExpr_init : ISample
{
    public class Person(string name)
    {
        public string Name { get; set; } = name;
    }
    public class Developer(string name, int id, Skill[] Langs) : Person(name)
    {
        public int Id => id;
        public Developer(string name, int id) : this(name, id, Array.Empty<Skill>()) { }
        Grade[] grades => Langs.Select(l => l.lvl).ToArray();
        public Grade Level => grades switch
        {
        [] => 4.2,
        [var grade] => grade,
        [.. var all] => all.Average()
        };
    }


    public void Run()
    {
        var my = new Developer("Daniele", 200375, new[] { (lang: "C#", lvl: 1.01), (lang: "JS", lvl: 2.02), (lang: "TS", lvl: 3.00) });
        Console.WriteLine(my);
        Console.WriteLine(my.GetType().FullName);
        Console.WriteLine($"- Id: {my.Id}");
        my.Name = "Daniele Morosinotto";
        Console.WriteLine($"- Name: {my.Name}");
        Console.WriteLine($"- Level: {my.Level} <- 🧐"); //NOTICE SOMETHING STRANGE YES EVEN C# 0.1+0.2!==0.3😜
        var mirco = new Developer("Mirco", 261166);
        Console.WriteLine($"{mirco.Name} - Skill: {mirco.Level} - 👴🏻: {mirco is Person}");
    }
}