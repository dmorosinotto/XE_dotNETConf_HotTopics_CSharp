namespace CSharp12;
using System.Collections.Immutable;
using Grade = double; //decimal -> double JUST FUN WITH FLOATING POINT IEEE754 ^_^
using Skill = (string lang, double lvl);

class EX2_CollectionExpr_ok : ISample
{
    public class Person(string name)
    {
        public string Name { get; set; } = name;
    }
    public class Developer(string name, int id, ImmutableArray<Skill> Langs) : Person(name) //<- CHANGE TYPE Array->List->ImmutableArray
    {
        public int Id => id;
        public Developer(string name, int id) : this(name, id, []) { } //COLLECTION EXPRESSION EMPTY LIST!!
        public Grade Level => Langs.Select(l => l.lvl).ToList() switch
        {
        [] => 4.2,
        [var grade] => grade,
        [.. var all] => all.Average()
        };
    }

    public void Run()
    {
        var my = new Developer("Daniele", 200375, [("C#", 1.01), ("JS", 2.02), ("TS", 3.00)]); //INIT COLLECTION EXPRESSION
        Console.WriteLine(my);
        Console.WriteLine(my.GetType().FullName);
        Console.WriteLine($"- Id: {my.Id}");
        my.Name = "Daniele Morosinotto";
        Console.WriteLine($"- Name: {my.Name}");
        Console.WriteLine($"- Level: {my.Level} <- 🧐"); //NOTICE SOMETHING STRANGE YES EVEN C# 0.1+0.2!==0.3😜
        var mirco = new Developer("Mirco", 261166, [(lang: "C#", lvl: 101.3), .. XE.Imperatore]); //SPRED COLLECTION EXPRESSION
        Console.WriteLine($"{mirco.Name} - Skill: {mirco.Level} - 👴🏻: {mirco is Person}");
    }

}