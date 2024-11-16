namespace CSharp13;
using Grade = decimal;
using Skill = (string lang, decimal lvl); //TYPE ALIAS WORKS EVEN FOR NAMED TUPLES
//using unsafe ONLYMIRCO = int*; //AND EVEN POINTER (IN unsafe CONTEXT ASK MIRCO!)

class EX2_PartialMembers_ok : ISample
{
    public record Developer(string Name, int Id, Skill[] Langs)
    {   //EXTRACT grades JUST TO SHOW Grade[] USE + AVOID LAMBDA MADNESS ^_^
        Grade[] grades => Langs.Select(l => l.lvl).ToArray();
        public Grade Level => grades switch //YOU CAN INLINE IF YOU WISH ^_^
        { //REFACTOR CODE AS readonly GETTER USING PATTERN MATCHING & LAMBDA
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
        //NOTICE THAT record AUTOMAGICALLY EXPOSE Id, Name AS init,readonly PROPS
        my = my with { Id = 123 }; //record ARE IMMUTABLE YOU CAN USE with -> 🆕!!
        Console.WriteLine($"- Id: {my.Id}");
        Console.WriteLine($"- Name: {my.Name}");
        Console.WriteLine($"- Level: {my.Level}"); //CALL THE NEW GETTER
    }
}