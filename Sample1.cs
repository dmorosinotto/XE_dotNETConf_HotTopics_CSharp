using System;
namespace csharp9.Test_InitOnlyProp
{
    //class CON init-only prop CONSENTE SINTASSI object-initializer MA POI DIVENTA IMMUTABLE!
    class Person
    {
        public string Firstname { get; set; } = "";
        public string Lastname { get; init; } = "";

        //UTILIZZO init-prop CON readonly
        private readonly string? _title;
        public string Title
        {
            get => _title!;
            init => _title = (value ?? throw new ArgumentNullException(nameof(Title)));
        }
    }

    public static class Sample1
    {
        public static void Run()
        {
            Console.Write($"{nameof(Sample1)}\n{"".PadRight(80, '_')}\n");
            //SINTASSI object-initializer
            var p = new Person
            {
                Lastname = "Paperone",
                Firstname = "Zio"
                //, Title = "Mr"
            };
            DisplayPerson(p);

            //NO MORE MOUTABLE PROP
            //p.Lastname = "Paperino"; //TODO DECOMMENT SHOW ERROR
            p.Firstname = "NR.1 di Zio"; //OK set -> ERROR SE init
            DisplayPerson(p);

            Console.Write($"{"".PadRight(80, '=')}\n\n\n");
        }

        static void DisplayPerson(Person p)
        {
            Console.WriteLine($"Ciao @{p.GetType().FullName}: {p.Title} {p.Firstname} {p.Lastname}");
        }
    }
}