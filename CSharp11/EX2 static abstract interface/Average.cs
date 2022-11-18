namespace CSharp11;

using System.Globalization;
using System.Numerics;
class EX2_Average
{
    public void Run()
    {
        Console.Write("First number: ");
        var left = ParseInvariant<float>(Console.ReadLine()!);

        Console.Write("Second number: ");
        var right = ParseInvariant<float>(Console.ReadLine()!);

        Console.WriteLine($"Result: {Average<float, float>(left, right)}");
    }

    TResult Average<T, TResult>(T first, T second) where T : INumber<T> where TResult : INumber<TResult>
    {
        return TResult.CreateChecked((first + second) / T.CreateChecked(2));
    }

    T ParseInvariant<T>(string s) where T : IParsable<T>
    {
        return T.Parse(s, CultureInfo.InvariantCulture);
    }

}