using System;
namespace csharp9.Test_Class
{
    //class NORMALE CON PROP get/set PER CONSENTIRE SINTASSI object-initializer
    class Person
    {
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
    }

    public static class Sample0
    {
        public static void Run()
        {
            Console.Write($"\n{nameof(Sample0)}\n{"".PadRight(80, '_')}\n");
            //SINTASSI object-initializer
            var p = new Person
            {
                Lastname = "Paperone",
                Firstname = "Zio"
            };
            DisplayPerson(p);

            //NOTARE PROBLEMA PROP mutation
            p.Lastname = "Paperino";
            DisplayPerson(p);

            Console.Write($"{"".PadRight(80, '=')}\n\n\n");
        }

        static void DisplayPerson(Person p)
        {
            Console.WriteLine($"Ciao @{p.GetType().FullName}: {p.Firstname} {p.Lastname}");
        }
    }
}