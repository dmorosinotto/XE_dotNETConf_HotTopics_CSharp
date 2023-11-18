namespace CSharp12;

using System.Drawing;
using ValueOf;
//READ DOCS: https://github.com/mcintyre321/valueof

class Extra_DU_ValidEmail : ISample
{
    public void Run()
    {
        ValidatedEmail email = ValidatedEmail.From("dmorosinotto@icloud.com");
        SendMail(email, "I'M SURE THAT IT'S A VALID EMAIL WHEN I CALL THIS!");
        //email.Value = "123";
        try
        {
            ValidatedEmail fail = ValidatedEmail.From("this is not an email");
            SendMail(fail, "NEVER ARRIVE HERE!!!", ConsoleColor.Yellow);
        }
        catch (Exception ex)
        {
            WriteWithCol(ConsoleColor.Red, "!!ERROR!! - ", ex.Message);
        }
    }

    void SendMail(ValidatedEmail addr, string body, ConsoleColor col = ConsoleColor.Green)
    {
        WriteWithCol(col, $"SEND MAIL -> {addr.Value} -", body);
    }

    void WriteWithCol(ConsoleColor col, string msg, object detail)
    {
        var old = Console.ForegroundColor;
        Console.ForegroundColor = col;
        Console.Error.WriteLine($"{msg} {detail ?? "<NULL>"}");
        Console.ForegroundColor = old;
    }

    public class ValidatedEmail : ValueOf<string, ValidatedEmail>
    {
        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Email cannot be null or empty");
            if (!Value.Contains("@"))
                throw new ArgumentException("Email must contains @ char");
            //... THIS IS ONLY FOR DEMO PURPOSE NOT A VALID EMAIL CHECKER
        }
    }


}


