namespace CSharp13;
using System.Runtime.CompilerServices;
using System.Collections.Immutable;

class Live1 : ISample
{
    public void Run()
    {
        Disposer.DisposeAll<StringReader>(new("Hello"), new("World")); //CALL USING params
        /* Disposer.DisposeAll<StringReader>([new("Hello"), new("World")]); //FROM C#12 Collection expression 
                                                                       //(pick the "most relevevant" Type!)*/
    }
    public static class Disposer
    {
        public static void DisposeAll<T>(params T[] disposables) //OLD params ONLY ARRAY!
            where T : IDisposable
        {
            foreach (IDisposable disposable in disposables) { disposable.Dispose(); }
        }
        // public static void DisposeAll<T>(IEnumerable<T> disposables) //OTHER methods overload WITH GENERICS<T>
        //     where T : IDisposable
        // {
        //     foreach (IDisposable disposable in disposables) { disposable.Dispose(); }
        // }
    }
}