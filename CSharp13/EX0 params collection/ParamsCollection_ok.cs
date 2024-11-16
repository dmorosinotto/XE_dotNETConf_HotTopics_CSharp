namespace CSharp13;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;


class EX0_ParamsCollections_ok : ISample
{
    public void Run()
    {
        // Disposer.DisposeAll<StringReader>(new("Hello"), new("World")); //CALL USING params
        Disposer.DisposeAll<StringReader>([new("Hello"), new("World")]); //FROM C#12 Collection expression 

    }
    public static class Disposer
    {

        public static void DisposeAll<T>(IEnumerable<T> disposables) //OTHER methods overload WITH GENERICS<T>
            where T : IDisposable
        {
            foreach (IDisposable disposable in disposables) { disposable.Dispose(); }
        }

        [OverloadResolutionPriority(-1)]
        public static void DisposeAll<T>(params ReadOnlySpan<T> disposables) //OTHER methods overload WITH GENERICS<T>
            where T : IDisposable
        {
            foreach (IDisposable disposable in disposables) { disposable.Dispose(); }
        }
        public static void DisposeAll<T>(ImmutableArray<T> disposables) //OTHER methods overload WITH GENERICS<T>
            where T : IDisposable
        {
            foreach (IDisposable disposable in disposables) { disposable.Dispose(); }
        }
    }
}