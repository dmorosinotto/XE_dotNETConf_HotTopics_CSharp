using System;
namespace csharp9.Test_Immutable
{
    //SOLUZIONE IMMUTABLE MACCHINOSA... readonly + ctor + NO MORE object-intializer
    class Person
    {
        //IMMUTABLE reaonly fields
        readonly string firstname;
        readonly string lastname;
        public string Firstname
        {
            get => firstname;
            //set => firstname = value; 
        }
        public string Lastname
        {
            get { return this.lastname; }
            //set { this.lastname = value; }
        }

        public Person(string firstname, string lastname)
        { //COSTRUTTORE ESPLICITO PER INIZIALIZZARE readonly field
            this.firstname = firstname;
            this.lastname = lastname;
        }
        public Person()
        { //DEFAULT ctor PER object intializer (INUTILE...)
            this.firstname = "<immutable class>";
            this.lastname = "NO obj initializer";
        }

        //SE VOGLIO FARE VERAMENTE OGGETTI IMMUTABILI...
        public Person MutateLastname(string lastname)
        { //DEVO FARMI IO DEI METODI X MUTARE -> CREARE NUOVI OGGETTI IMMUTABLE
            return new Person(this.firstname, lastname);
        }

        //TODO EVENTUALE IMPLEMENTAZIONE ToString() ALTRIMENTI -> ClassName
        //public override string ToString() => firstname + " " + lastname;

        //TODO EVENTUALE IMPLEMENTAZIONE Equals ALTRIMENTI -> ReferenceEquals
        //public override bool Equals(object? obj) => obj is Person p && p.Firstname == firstname && p.Lastname == lastname;
    }

    public static class Sample2
    {
        public static void Run()
        {
            Console.Write($"{nameof(Sample2)}\n{"".PadRight(80, '_')}\n");
            //IMMUTABLE CLASS -> NO POSSO PIU' USARE object-initializer
            var p = new Person()/* //TODO DECOMMENT SHOW ERROR
            { //NO set prop -> NO MORE object-initializer
                Lastname = "Paperone",
                Firstname = "Zio"
            }*/;
            DisplayPerson(p);

            //DEVO SCRIVERE/USARE COSTRUTTORE ESPLICITO!
            p = new Person("Zio", "Paperone");
            DisplayPerson(p);
            //PERO' RISOLVO PROBLEMA OGGETTO IMMUTABLE
            //p.Lastname = "Paperino"; //TODO DECOMMENT SHOW ERROR -> OK NO MORE mutable prop
            var o = p.MutateLastname("Paperino");
            DisplayPerson(o);
            Console.WriteLine($"{o} == {p}? {o == p}"); //false OVVIO

            //REFERENCE EQUALITY + ToString() -> ClassName
            Console.WriteLine("".PadRight(80, '-'));
            var p1 = p;
            Console.WriteLine($"{p} =?= {p1}"); //ToString
            Console.WriteLine($"op== {p == p1}"); //true
            Console.WriteLine($"EQ = {Equals(p, p1)}"); //true
            Console.WriteLine($"REF= {ReferenceEquals(p, p1)}"); //true
            Console.WriteLine($"HASH {p.GetHashCode() == p1.GetHashCode()}"); //true

            Console.WriteLine("".PadRight(80, '-'));
            p1 = new Person("Zio", "Paperone");
            Console.WriteLine($"{p} =?= {p1}"); //ToString 
            Console.WriteLine($"op== {p == p1}"); //false
            Console.WriteLine($"EQ = {Equals(p, p1)}"); //false
            Console.WriteLine($"REF= {ReferenceEquals(p, p1)}"); //false
            Console.WriteLine($"HASH {p.GetHashCode() == p1.GetHashCode()}"); //false

            Console.Write($"{"".PadRight(80, '=')}\n\n\n");
        }

        static void DisplayPerson(Person p)
        {
            Console.WriteLine($"Ciao @{p.GetType().FullName}: {p.Firstname} {p.Lastname}");
        }
    }


}