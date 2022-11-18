namespace CSharp11;
using System.Numerics;
class EX3_Total_mid2
{
    public void Run()
    {
        // int[] arr = new int[] { };
        var arr = new[] { 1, 2, 3, .4 };
        Console.Write($"Total of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr));
    }

    T Total<T>(T[] values) where T : INumber<T> => values switch
    {
        [] => T.Zero,
        [var first] => first,
        [var first, .. var middle, var last] => first + last + Total(middle),
        // [var first, var second] => first + second, //ERROR already handled
    };
}
