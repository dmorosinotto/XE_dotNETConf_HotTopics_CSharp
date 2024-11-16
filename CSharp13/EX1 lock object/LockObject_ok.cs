namespace CSharp13;
using System.Threading;
class EX1_LockObject_ok : ISample
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
        Lock mapLock = new(); //NEW Lock OBJECT optimized!
        // object mapLock = new Lock(); //DON'T DO THIS!!

        public partial Span<byte> Map // PARTIAL IMPLEMENTATION FOR props!
        {
            get
            {
                lock (mapLock) { return map; } //lock statement with Lock object
            }
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