namespace CSharp11;
using System.Numerics;
class EX0_Json
{
    /*
    { 
        "message": "XE .NET Conf {{year}} Hot Topics",
        "speaker": {
            "name": "Daniele Morosinotto",
            "dev": ['TS','JS',"{{lang}}"]
        }
        "level": 101
    }
    */
    public void Run()
    {
        var lang = "C#";
        var year = 2022;
        var know = new[] { "TS", "JS" };
        var json = $$"""
            { 
                "message": "XE .NET Conf {{year}} Hot Topics",
                "speaker": {
                    "name": "Daniele Morosinotto",
                    "dev": [{{string.Join(',',
                                know.OrderBy(s => s)
                                    .Select(s => $"'{s}'")
                            )}},"{{lang}}"]
                }
                "level": 101
            }
        """;

        Console.WriteLine(json);
    }
}
