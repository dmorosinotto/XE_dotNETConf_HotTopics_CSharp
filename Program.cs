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
            * //RIFERIMENTI
            * REPO CODICE ESEMPI: https://github.com/dmorosinotto/XE_dotNETConf_HotTopics_CSharp9
            * NOTE RILASCIO C# 9: https://devblogs.microsoft.com/dotnet/c-9-0-on-the-record/
            * DOCS WHAT'S NEW C#: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9 
            * VIDEO FUTURE OF C#: @Mads Torgersen https://usergroup.tv/videos/the-future-of-c/
            */










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
