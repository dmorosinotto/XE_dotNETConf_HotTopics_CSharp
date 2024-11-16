Console.Clear();
Console.WriteLine("Welcome to C# 13");
run(new CSharp13.Live1());
//run(new CSharp13.EX0_ParamsCollections_init());
//run(new CSharp13.EX0_ParamsCollections_mid());
//run(new CSharp13.EX0_ParamsCollections_ok());
run(new CSharp13.Live2());
// run(new CSharp13.EX1_LockObject_init());
// run(new CSharp13.EX1_LockObject_mid());
// run(new CSharp13.EX1_LockObject_ok());
// run(new CSharp13.EX2_PartialMembers_init());
// run(new CSharp13.EX2_PartialMembers_mid());
// run(new CSharp13.EX2_PartialMembers_ok());
// run(new CSharp13.EX3_FieldKeyword_init());
// run(new CSharp13.EX3_FieldKeyword_mid());
// run(new CSharp13.EX3_FieldKeyword_ok());
// run(new CSharp13.EX4_EscapeSequence_ok());
// run(new CSharp13.EX4_FromEndIndex_ok());
// run(new CSharp13.EX4_RefStruct_ok());

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
