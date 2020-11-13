using System;
namespace csharp9.Test_PositionalRecord
{
    //POSITIONAL RECORD = record + Ctor/Destructor - SINTASSI MINIMAL ALLA TS ^_^
    record Person(string Firstname, string Lastname);

    //ESEMPIO DI EREDITARIETA' RECORD -> PER ORA SI PUO' ESTENDERE SOLO record DA record FUTURO DA class!
    record Student(string Firstname, string Lastname) : Person(Firstname, Lastname)
    {
        public int ID { get; init; }

        //TODO CUSTOM ToString() -> ALTRIMENTI STAMPA ClassName + { prop = val, ...} = PrintMembers
        /*public override string ToString()
        {
            System.Text.StringBuilder sb = new();
            //base.PrintMembers(sb); //! IN VSCode/Omnisharp NON TROVA PrintMembers 
            //MA LA DOCUMENTAZIONE DICE CHE ESISTE https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types
            return sb.ToString();
        }*/
    }

    public static class Sample4
    {
        public static void Run()
        {
            Console.Write($"{nameof(Sample4)}\n{"".PadRight(80, '_')}\n");
            //RECORD POSITION -> DEVO USARE COSTRUTTORE ESPLICITO PER CREARE IMMUTABLE CLASS (record)
            var p = new Person("Zio", "Paperone");
            //NON POSSO PIU' USARE object-initializer DIRETTAMENTE :-(
            //p = new Person { Lastname = "Paperone", Firstname = "Zio" }; //TODO DECOMMENT SHOW ERROR
            DisplayPerson(p);
            var (first, last) = p; //ESEMPIO DESTRUCTOR
            DisplayPerson((first, last));

            //PERO' POSSO SEMPRE USARE with-expression PER CREARE NUOVI OGGETTI -> non-destructive mutation 
            var o = p with { Lastname = "Paperino" }; // ? NOTARE CHE with-expression USA object-initializer
            DisplayPerson(o);
            Console.WriteLine($"{o} == {p}? {o == p}"); //false OVVIO

            Console.WriteLine("".PadRight(80, '-'));
            //ESEMPIO DI CREAZIONE OGGETTO EREDITATO + object-initializer PER PROPS AGGIUNTIVE
            p = new Student("Pippo", "Pluto")
            {
                ID = 123
            };
            DisplayPerson(p);
            Console.WriteLine($"p? {p is Student} -> {p}"); //true OVVIO

            //! NOTARE CHE with-expression CLONA Realtime-Type ANCHE SE PARTO DA base-type
            var s = p with { Lastname = "Paperino" }; //? NOTARE CHE p E' DI TIPO Person!!
            DisplayPerson(s);
            Console.WriteLine($"s? {s is Student} -> {s}"); //! TRUE!!!

            Console.Write($"{"".PadRight(80, '=')}\n\n\n");
        }

        static void DisplayPerson(Person p)
        {
            Console.WriteLine($"Ciao @{p}\n");
        }
        static void DisplayPerson((string Firstname, string Lastname) t)
        {
            Console.WriteLine($"t E' UNA TUPLA: {t.Firstname} {t.Lastname}");
        }
    }


}