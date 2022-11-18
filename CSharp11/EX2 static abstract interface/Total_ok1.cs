namespace CSharp11;
using System.Numerics;
class EX2_Total_ok1
{
    public void Run()
    {
        var arr = new[] { 1, 2, 3 };
        Console.Write($"Total of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr));
    }

    T Total<T>(T[] values) where T : INumber<T>
    {
        T sum = /*0, //ERROR*/ T.Zero; //T.AdditiveIdentity; 
        foreach (var val in values)
            sum += val;
        return sum;
    }
}
