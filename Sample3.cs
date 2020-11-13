using System;
namespace csharp9.Test_Record
{
    //NUOVO record -> E' UNA class (OSSIA RefType) PENSATO PER SEMPLIFICARE IMMUTABLE (-> COMPORTAMENTI DA Value-Type)
    public record Person
    {
        //SPECIFICO LE PROPS TIPICAMENTE Init-Only -> object initializer + IMMUTABLE!
        public string? Firstname { get; init; }
        public string? Lastname { get; init; }
    }

    public static class Sample3
    {
        public static void Run()
        {
            Console.Write($"{nameof(Sample3)}\n{"".PadRight(80, '_')}\n");
            //record CON init-props -> POSSO USARE object-initializer
            var p = new Person
            {
                Lastname = "Paperone",
                Firstname = "Zio"
            };
            DisplayPerson(p);

            //OGGETTO IMMUTABLE (AMMENO CHE NON USI PROP set - SCONSIGLIATO!!)
            //p.Lastname = "Paperino"; //TODO DECOMMENT SHOW ERROR -> OK NO mutable props!!

            //! SINTASSI with-expression PER CREARE NUOVI OGGETTI -> non-destructive mutation
            // ? GRAZIE A CTOR protected CloneXXX CHE ACCETTA p COME PARAMETRO E COPIA TUTTI I CAMPI UNO A UNO!!
            var o = p with { Lastname = "Paperino" }; // ? NOTARE CHE with-expression POI USA object-initializer
            DisplayPerson(o);
            Console.WriteLine($"{o} == {p}? {o == p}"); //false OVVIO

            //! record SI COMPORTA COME UN Value-Type (FACILITA IMMUTABILITA')
            //DIMOSTRAZIONE ToString() <- ClassName + { base.PrintMembers(sb) }
            Console.WriteLine("".PadRight(80, '-'));
            var p1 = p; //OVVIA REFERENCE-EQUALITY
            Console.WriteLine($"p:{p} =?= p1:{p1}"); //ToString <- Tipo + {prop = val,...}
            Console.WriteLine($"1.op== {p == p1}"); //true OVVIO
            Console.WriteLine($"1.EQ = {Equals(p, p1)}"); //true OVVIO
            Console.WriteLine($"1.REF= {ReferenceEquals(p, p1)}"); //true OVVIO
            Console.WriteLine($"1.HASH {p.GetHashCode() == p1.GetHashCode()}"); //true OVVIO

            //! DIMOSTRAZIONE VALUE-BASE EQUALITY <- OTTIMO PER IMMUTABILITY
            Console.WriteLine("".PadRight(80, '-'));
            //COSTRUISCO ALTRO p2 SEMPRE CON with-expression E RIPORTO Lastname = STESSI VALORI p -> VALUE-EQULITY
            //var p2 = new Person { Firstname = "Zio", Lastname = "Paperone" }; //TODO MA POTREI ANCHE GENERALO DA ZERO!
            var p2 = p1 with { Lastname = "Paperone" };
            Console.WriteLine($"p:{p} =?= p2:{p2}"); //ToString 
            Console.WriteLine($"2.op== {p == p2}"); //TRUE!!!
            Console.WriteLine($"2.EQ = {Equals(p, p2)}"); //TRUE!!!
            Console.WriteLine($"2.RE2= {ReferenceEquals(p, p2)}"); //FALSE!!!
            Console.WriteLine($"2.HASH {p.GetHashCode() == p2.GetHashCode()}"); //TRUE!!!

            Console.Write($"{"".PadRight(80, '=')}\n\n\n");
        }

        static void DisplayPerson(Person p)
        {
            Console.WriteLine($"Ciao @{p.GetType().FullName}: {p.Firstname} {p.Lastname}");
        }
    }


}