Console.Clear();
Console.WriteLine("Welcome to C# 12");
run(new CSharp12.Live());
// run(new CSharp12.EX0_TypeAlias_init());
// run(new CSharp12.EX0_TypeAlias_mid());
// run(new CSharp12.EX0_TypeAlias_ok());
// run(new CSharp12.EX1_PrimaryCtor_init());
// run(new CSharp12.EX1_PrimaryCtor_mid());
// run(new CSharp12.EX1_PrimaryCtor_ok());
// run(new CSharp12.EX2_CollectionExpr_init());
// run(new CSharp12.EX2_CollectionExpr_mid());
// run(new CSharp12.EX2_CollectionExpr_ok());
run(new CSharp12.LiveColl());
// run(new CSharp12.EX2_CollectionExpr_all());
// run(new CSharp12.EX2_CollectionExpr_aok());
run(new CSharp12.Extra_DU_ValidEmail());
run(new CSharp12.Extra_DU_Union());

void run(ISample sample)
{
    Console.Clear();
    Console.WriteLine(sample.GetType().FullName);
    sample.Run();
    Console.WriteLine("".PadRight(40, '-'));
    Console.WriteLine();
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}
public interface ISample { void Run(); }
internal static class XE
{
    static internal ReadOnlySpan<(string, double)> Imperatore => new[] { ("C", 4.04), ("C++", 26.11 - 19.66), ("AGE", 57) };
}