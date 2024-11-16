namespace CSharp13;

class EX4_EscapeSequence_ok : ISample
{
    public void Run()
    {
        // Prior to C# 13
        Console.WriteLine("This is \u001b[1mOLD bold text\u001b[0m");
        // HIGLY DEPRECATED PROBLEMATIC IF AFTER 1b THERE IS ESADECIMAL CHARS
        Console.WriteLine("This is \x1b[1mDEPRECATED bold\x1b[0m");
        // With C# 13
        Console.WriteLine("This is \e[1m NEW! bold text\e[0m");
    }
}