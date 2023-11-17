namespace CSharp12;
using Grade = System.Decimal; //ALIAS TYPE REQUIRED FULLTYPE NAME FOR .NET7 <= C#11 NOT ALLOW decimal !!
using Skill = ValueTuple<string, decimal>; //MUST DEFINE TUPLE WITHOUT NAMES, BUT YOU CAN USE deciaml 🙃

class Live : ISample
{
    public record struct Developer(string Name, int Id, Skill[] Langs)
    {
        public /*Grade, decimal*/ System.Decimal Level() //NOTICE HERE YOU CAN USE Grade OR decimal OR System.Decimal
        { //OLD STYLE METHOD THAT HANDLE ALL CASES TO CALC AVG LEVEL
            if (Langs == null || Langs.Length == 0) return 4.2m;
            if (Langs.Length == 1) return Langs[0].Item2;
            else return Langs.Select(l => l.Item2).Average();
        }
    }
    public void Run()
    {
        var my = new Developer("Daniele", 200375, new[] { ("C#", 1.01m), ("JS", 2.02m), ("TS", 3.00m) });
        Console.WriteLine(my);
        Console.WriteLine(my.GetType().FullName);
        //NOTICE THAT record struct AUTOMAGICALLY EXPOSE Id, Name PROPS
        Console.WriteLine($"- Id: {my.Id}");
        Console.WriteLine($"- Name: {my.Name}");
        Console.WriteLine($"- Level: {my.Level()}"); //OUR METHOD CALL
    }
}