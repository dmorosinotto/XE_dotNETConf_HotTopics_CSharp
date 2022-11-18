namespace CSharp11;
using System.Numerics;
class EX2_Total_ok2
{
    public void Run()
    {
        var arr = new[] { 1, 2, 3, 4 };
        Console.Write($"Total of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr));
    }

    T Total<T>(T[] values) where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        T sum = T.AdditiveIdentity;
        foreach (var val in values)
            sum += val;
        return sum;
    }
}
