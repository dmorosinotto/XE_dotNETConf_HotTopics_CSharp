namespace CSharp12;
using IActionResult = Action; // ()=>void
using Invalid = (object, string err);
using OneOf;
//READ DOCS: https://github.com/mcintyre321/OneOf

class Extra_DU_Union : ISample
{
    public void Run()
    {
        var ret = GetCS(10);
        ret();  //RETURN 404 -> ASK Mirco
        ret = GetCS(12);
        ret();  //RETURN 200 -> C#12 infos
        ret = GetCS("42");
        ret();  //RETURN 200 -> TS FTW 💙
        ret = GetCS("Java");
        ret();  //RETURN 400 -> Invalid C#
    }

    IActionResult GetCS(StringOrNumber id)
    {
        OneOf<CSharp, NoInfo, Invalid> infos = FindCSharInfos(id);
        return infos.Match(
            cs => Ok(cs),
            noinfo => StatusCode(404, noinfo),
            invalid => BadRequest(invalid)
        );
    }

    OneOf<CSharp, NoInfo, Invalid> FindCSharInfos(StringOrNumber id)
    {
        var (isNumber, ver) = id.TryGetNumber();
        if (isNumber)
        {
            switch (ver)
            {
                case 9: return new CSharp("C#9", ["record", "top level app+namespace", "pattern match"]);
                case 12: return new CSharp("C#12", ["primary ctor", "collection expr", "type alias"]);
                case 42: return new CSharp("TS", ["THE WIN 😎 JUST"]);
                default: return new NoInfo(ver);
            }
        }
        else return (id, err: "is NOT a valid C#"); //Invalid tuple
    }

    record CSharp(string cs, string[] feat) { public override string ToString() { return $"For {string.Join(',', feat)} use {cs}"; } }
    class NoInfo(int ver) { public override string ToString() { return $"Ask Mirco for C# {ver} infos"; } }
    public class StringOrNumber : OneOfBase<string, int>
    {
        StringOrNumber(OneOf<string, int> _) : base(_) { }

        // optionally, define implicit conversions
        public static implicit operator StringOrNumber(string _) => new StringOrNumber(_);
        public static implicit operator StringOrNumber(int _) => new StringOrNumber(_);

        public (bool isNumber, int number) TryGetNumber() =>
            Match(
                s => (int.TryParse(s, out var n), n),
                i => (true, i)
            );
    }

    IActionResult Ok(object msg) => StatusCode(200, msg);
    IActionResult BadRequest(object msg) => StatusCode(400, msg);
    IActionResult StatusCode(int code, object detail)
    {
        ConsoleColor col = code switch
        {
            200 => ConsoleColor.Green,
            404 => ConsoleColor.Magenta,
            _ => ConsoleColor.Red,
        };
        return () =>
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = col;
            Console.Error.WriteLine($"RET {code} -> {detail ?? "<NULL>"}");
            Console.ForegroundColor = old;
        };
    }


}
