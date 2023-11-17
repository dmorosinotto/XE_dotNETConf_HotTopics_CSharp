namespace CSharp12;
using System.Collections.Immutable;
class LiveColl : ISample

{
    public void Run()
    {
        Console.WriteLine("OLD way to initialize Collections depends on Specific Type!!");
        int[] x0 = Array.Empty<int>(); //EMPTY EXIST ONLY FOR ARRAYS
        WriteInt(x0);
        int[] x14 = new int[] { 1, 2, 3, 4 }; //INIT ARRAYS WITH VALUES
        WriteInt(x14);
        WriteByteArray(new[] { (byte)0, (byte)5, (byte)9 }); //MUST SPECIFY CAST 
        ImmutableArray<int> x68 = ImmutableArray.Create<int>(6, 7, 8);
        /*ImmutableArray<int> x5 = new() { 6, 7, 8 }; //THROW ERROR RUNTIME!*/
        WriteInt(x68);
        Span<DateTime> dates = stackalloc DateTime[] { GetDate(0), GetDate(1) }; //SPAN ALLOC
        WriteByteSpan(stackalloc[] { (byte)42, (byte)123, (byte)255 }); //AND MUST SPECIFY CAST
        List<int> x = new() { 0 }; x.AddRange(x0); x.AddRange(x14); x.Add(5); x.AddRange(x68); x.Add(9); //AGGREGATE
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