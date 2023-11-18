namespace CSharp12;
using Grade = decimal; //WITH C#12 YOU CAN USE IT!!
using Skill = ValueTuple<string, decimal>; //EVEN HERE

class EX0_TypeAlias_mid : ISample
{
    public record class Developer(string Name, int Id, Skill[] Langs)
    {
        public Grade Level()
        { //REFACTOR CODE TO USE Grade CHECK INFERRED TYPE 👀
            var grades = Langs.Select(l => l.Item2).ToArray();
            if (grades.Length == 0) return 4.2m;
            if (grades.Length == 1) return grades[0];
            else return grades.Average();
        }
    }
    public void Run()
    {
        var my = new Developer("Daniele", 200375, new[] { ("C#", 1.01m), ("JS", 2.02m), ("TS", 3.00m) });
        Console.WriteLine(my);
        Console.WriteLine(my.GetType().FullName);
        //NOTICE THAT record class AUTOMAGICALLY EXPOSE Id, Name AS READONLY PROPS
        //my.Name = "Daniele Morosinotto"; //ERROR IT'S init readonly PROP //💥
        Console.WriteLine($"- Id: {my.Id}");
        Console.WriteLine($"- Name: {my.Name}");
        Console.WriteLine($"- Level: {my.Level()}"); //CALL OUR METHOD
    }
}