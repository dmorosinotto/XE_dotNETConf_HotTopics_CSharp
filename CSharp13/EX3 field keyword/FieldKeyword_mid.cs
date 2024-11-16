namespace CSharp13;
using System.Threading;
class EX3_FieldKeyword_mid : ISample
{
    ref partial struct MyFile
    {
        public partial void Dispose();
        public partial Span<byte> Map { get; private set; }
    }

    //generated
    ref partial struct MyFile
    {
        Span<byte> map;
        Lock mapLock = new();

        public partial Span<byte> Map
        {
            get; //AUTO PROPRERTY (no body)
            // {
            //     lock (mapLock) { return field; } //FIELD keyword (accessing auto-backing fiield!)
            // }
            private set { lock (mapLock) { field = value; } } //SETTING auto-backing field!
        }
        public partial void Dispose() => Map = default;
        public MyFile() { }
    }

    public void Run()
    {
        Console.WriteLine("FIELD keywork (preview)");
    }
}