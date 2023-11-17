namespace CSharp12;
using Grade = decimal;
using Skill = (string lang, decimal lvl);

class EX1_PrimaryCtor_init : ISample
{
    public class Developer(string Name, int Id, Skill[] Langs) //PRIMARY CTOR FOR class !!
    {
        Grade[] grades => Langs.Select(l => l.lvl).ToArray();
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
        //ERROR NO AUTOMATIC Id, Name PROPERTY EXPOSED BY class THEY ARE PRIMARY CTOR PARAMS (DIFF FROM record!!)
        //Console.WriteLine($"- Id: {my.Id}");      //💥
        //Console.WriteLine($"- Name: {my.Name}");  //💥
        Console.WriteLine($"- Level: {my.Level}");
    }
}