namespace CSharp11;
class EX2_Total_init
{
    public void Run()
    {
        var arr = new[] { 1, 2, 3 };
        Console.Write($"Total of {arr} [{string.Join(',', arr)}] = ");
        Console.WriteLine(Total(arr));
    }

    int Total(int[] values)
    {
        int sum = 0;
        foreach (var val in values)
            sum += val;
        return sum;
    }

    double Total(double[] values)
    {
        double sum = 0;
        foreach (var val in values)
            sum += val;
        return sum;
    }
}
