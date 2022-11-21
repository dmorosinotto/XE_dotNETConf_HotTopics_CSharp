namespace CSharp11;
using System.Numerics;
class EX3_Match
{
    public void Run()
    {
        // int[] arr = new int[] { };
        var arr = new[] { 1, 2, 3, .4 };
        Console.Write($"Total Span<{arr}> [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr.AsSpan()));
    }

    T Total<T>(Span<T> values) where T : INumber<T> => values switch
    {
        [] => T.Zero,
        [var first, .. var rest] => first + Total(rest),
    };
}
