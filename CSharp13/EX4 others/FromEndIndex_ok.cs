namespace CSharp13;

class EX4_FromEndIndex_ok : ISample
{
    class Numbers
    {
        public int[] Values { get; set; } = new int[10];
    }

    public void Run()
    {
        var x = new Numbers
        {
            Values =
            {
                [1] = 111,
                [^1] = 999,// Works starting in C# 13
                [^3]= 777, // Works starting in C# 13
                [5] = 555,
            }
            // x.Values[1] is 111
            // x.Values[9] is 999, since it is the last elemen  t
            // x.Values[7] is 777, since it is the 3rd element from the end
            // x.Values[5] is 555
        };

        for (int i = 0; i < x.Values.Length; i++)
            Console.WriteLine(x.Values[i]);
    }
}