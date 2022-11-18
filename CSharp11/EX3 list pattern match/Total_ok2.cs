namespace CSharp11;
using System.Numerics;
class EX3_Total_ok2
{
    public void Run()
    {
        // int[] arr = new int[] { };
        var arr = new[] { 1, 2, 3, .4 };
        Console.Write($"Total Span of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr.AsSpan()));
    }

    T Total<T>(Span<T> values) where T : INumber<T> => values switch
    {
        [] => T.Zero,
        [var first, .. var rest] => first + Total(rest),
        // [var first, _, ..var middle, var last] => first + last, //SPAN OPTIMIZE INDEX ACCESS
    };
}
