namespace CSharp11;
using System.Numerics;
class EX2_Point
{
    public void Run()
    {
        var pt = new Point<int>(1, 2);
        var off = new Delta<int>(3, 4);
        var final = pt + off;
        Console.WriteLine(pt);
        Console.WriteLine(off);
        Console.WriteLine(final);


        var pt2 = new Point<double>(.1, .2);
        var off2 = new Delta<double>(.3, .4);
        var final2 = pt2 + off2;
        Console.WriteLine(pt2);
        Console.WriteLine(off2);
        Console.WriteLine(final2);
    }

    public record Delta<T>(T XOffset, T YOffset) : IAdditiveIdentity<Delta<T>, Delta<T>>
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Delta<T> AdditiveIdentity =>
            new Delta<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
    }


    public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Delta<T>, Point<T>>
        where T : IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>
    {
        public static Point<T> operator +(Point<T> left, Delta<T> right) =>
            left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
    }
}