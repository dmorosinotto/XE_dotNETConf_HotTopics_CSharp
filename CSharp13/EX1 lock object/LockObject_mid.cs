namespace CSharp13;

class EX1_LockObject_mid : ISample
{
    ref partial struct MyFile
    {
        public partial void Dispose();
        public partial Span<byte> Map { get; private set; } //PARTIAL DECLARATION OF props!
    }

    //generated
    ref partial struct MyFile
    {
        Span<byte> map;
        object mapLock = new();

        public partial Span<byte> Map // PARTIAL IMPLEMENTATION FOR props!
        {
            get { lock (mapLock) { return map; } }
            private set { lock (mapLock) { map = value; } }
        }
        public partial void Dispose() => Map = default;
        public MyFile() { }
    }

    public void Run()
    {
        Console.WriteLine("LOCK OBJECT + partial evreywhere");
    }
}