namespace CSharp11;
using System.Numerics;
class EX3_Total_init
{
    public void Run()
    {
        int[] arr = new int[] { };
        // var arr = new[] { 1, 2, 3, .4 };
        Console.Write($"Total of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr));
    }

    T Total<T>(T[] values) where T : INumber<T> => values switch
    {
        [] => T.Zero,
        //WARN MISSING CASES
    };
}
