namespace CSharp12;
using System.Collections.Immutable;
class EX2_CollectionExpr_aok : ISample

{
    public void Run()
    {
        Console.WriteLine("NEW COLLECTION EXPRESSION UNIFORM INITIALIZE + COMPILER INFER TYPES AND USE BEST WAY TO CREATE IT!!");
        int[] x0 = []; //IDIOMATIC EMPTY ARRAY
        WriteInt(x0);
        int[] x14 = [1, 2, 3, 4]; //INIT ARRAY WITH VALUES
        WriteInt(x14);
        WriteByteArray([0, 5, 9/*,256*/]); //NO NEED TO CAST (byte) - BUT CHECK THE TYPES (REMOVE COMMENT 💥!!)
        ImmutableArray<int> x68 = [6, 7, 8]; //USE Immutable.Create F12 -> [CollectionBuilder(typeof(ImmutableArray), "Create")]
        WriteInt(x68);
        Span<DateTime> dates = [GetDate(0), GetDate(1)]; //NO NEED TO stackalloc
        WriteByteSpan([42, 123, 255]); //NO NEED TO stackalloc + NO NEED TO CAST (byte) - TRY SET 256 WILL💥!!
        List<int> x = [0, .. x0, .. x14, 5, .. x68, 9]; //SPRED EVEN FROM DIFFERENT TYPES -> AUTOMAGIC CONVERT
        WriteInt(x);
    }

    void WriteByteArray(byte[] bytes)
    {
        Console.WriteLine($"WriteByteArray: {string.Join(';', bytes)}");
    }

    void WriteByteSpan(Span<byte> span)
    {
        Console.WriteLine($"WriteByteSpan:");
        foreach (var b in span) Console.WriteLine(b);
    }

    void WriteInt(IEnumerable<int> ints)
    {
        Console.WriteLine($"WriteInt: [{string.Join(", ", ints)}]");
    }

    DateTime GetDate(int i) => DateTime.Now.AddDays(i);
}