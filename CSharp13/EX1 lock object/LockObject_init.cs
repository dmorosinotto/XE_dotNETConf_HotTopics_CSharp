namespace CSharp13;

class EX1_LockObject_init : ISample
{
    ref partial struct MyFile
    {
        public partial void Dispose(); //OLD partial methods!
    }

    //generated
    ref partial struct MyFile
    {
        Span<byte> map;
        object mapLock = new();

        public Span<byte> Map
        {
            get { lock (mapLock) { return map; } }
            private set { lock (mapLock) { map = value; } }
        }
        public partial void Dispose() => Map = default; //OLD partial method implementation!
        public MyFile() { }
    }

    public void Run()
    {
        Console.WriteLine("LOCK OBJECT + partial evreywhere");
    }
}