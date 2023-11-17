namespace CSharp12;
using Grade = decimal;
using Skill = (string lang, decimal lvl);

class EX1_PrimaryCtor_mid : ISample
{
    public class Developer(string name, int id, Skill[] Langs) //PRIMARY CTOR
    {
        public string Name { get; set; } = name; //PROPERTY INITIALIZER WITH PRIMARY CTOR PARAMS
        public int Id => id; //CLOSURE TO PRIMARY CTOR PARAMS (READONLY)
        Grade[] grades => Langs.Select(l => l.lvl).ToArray(); //CLOSURE TO PARAM Langs NO Langs PROPERTY EXPOSED BY class
        public Grade Level => grades switch
        {
        [] => 4.2m,
        [var grade] => grade,
        [.. var all] => all.Average()
        };
    }
    public void Run()
    {
        var my = new Developer("Daniele", 200375, new[] { (lang: "C#", lvl: 1.01m), (lang: "JS", lvl: 2.02m), (lang: "TS", lvl: 3.00m) });
        Console.WriteLine(my);
        Console.WriteLine(my.GetType().FullName);
        Console.WriteLine($"- Id: {my.Id}");
        //my.Id = 123; //ERROR READONLY PROPERTY
        my.Name = "Daniele Morosinotto"; //WORKS
        Console.WriteLine($"- Name: {my.Name}");
        //Console.Write(my.Langs) //ERROR NO Langs PROPERTY EXPOSED BY class
        Console.WriteLine($"- Level: {my.Level}");
    }
}