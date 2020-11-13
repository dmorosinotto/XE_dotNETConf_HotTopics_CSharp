using System;
using System.Collections.Generic;

namespace csharp9.Test_TargetTypeNewExpression
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        //COSTRUTTORE E ToString() INLINE SFRUTTA LAMBDA + TUPLE ^_^
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X},{Y})";
    }

    public static class Sample5
    {
        public static void Run()
        {
            Console.Write($"{nameof(Sample5)}\n{"".PadRight(80, '_')}\n");

            // var p = new Point(4,2); //? IO PREFERISCO var SON UN JAVASCRIPTARO ^_^
            Point p = new(9, 0); //UTILIZZO DI TARGET TYPE NEW 

            Console.WriteLine($"{p.GetType().FullName} {nameof(p)} = {p}");

            Point[] ps = { new(1, 2), new(3, 4), new(5, 6) }; //NOTARE INFER DEL TIPO DELL'ARRAY initializer
            Console.WriteLine($"{ps} -> {string.Join<Point>('\t', ps)}");

            //PER GLI INLINE funboy LIKE ME ^_^ //? NOTARE CHE INFERISCE IL DICTIONARY DALLA FIRMA DEL METODO
            DisplayPoints(() => new() { { "CIAO", ps }, { "PIPPO", new Point[] { new(7, 8) } } });

            Console.Write($"{"".PadRight(80, '=')}\n\n\n");
        }

        static void DisplayPoints(Func<Dictionary<string, Point[]>> GetPoints)
        {
            var dict = GetPoints();
            foreach (var key in dict.Keys)
            {
                Console.WriteLine($"@{key} {dict[key]} -> {string.Join<Point>('\t', dict[key])}");
            }
        }
    }


}