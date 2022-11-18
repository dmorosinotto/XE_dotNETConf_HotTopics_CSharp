namespace CSharp11;
class EX2_Total_mid
{
    public void Run()
    {
        var arr = new[] { 1, 2, 3 };
        Console.Write($"Total of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr));
    }

    T Total<T>(T[] values)
    {
        return default(T)!;
        // T sum = 0; //ERROR 0 
        // foreach (var val in values)
        //     sum += val; //ERROR +=
        // return sum;
    }
}
