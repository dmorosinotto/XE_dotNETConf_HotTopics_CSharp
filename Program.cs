using System;
using System.Threading.Tasks;

namespace csharp9
{
    class Program
    {
        static void Main(string[] args)
        {
            csharp9.Test_Class.Sample0.Run();
            // csharp9.Test_InitOnlyProp.Sample1.Run();
            // csharp9.Test_Immutable.Sample2.Run();
            // csharp9.Test_Record.Sample3.Run();
            // csharp9.Test_PositionalRecord.Sample4.Run();
            // csharp9.Test_TargetTypeNewExpression.Sample5.Run();
            // csharp9.Test_PatternMatch.Sample6.Run();












            /*
            //TODO Sample0 - DECOMMENTARE QUESTE RIGHE E COMMENTARE namespace + class Program + static void Main!
            Console.WriteLine("Top-Level Program - NO MORE namespace + class Program + static void MAIN!");
            await Task.Delay(3); //TOP-LEVEL await WORKS!
            if (args is not null && args.Length > 0)
            {
                Console.WriteLine($"But magic ARGS= {string.Join('\t', args)} is in scope ^_^");
                return args.Length;
            }
            else return -1; //RETURN STATUS OF MAIN
            //TODO COMMENTARE ANCHE LE 3 GRAFFE QUI SOTTO
            */
        }
    }
}
