namespace CSharp13;

class EX4_RefStruct_ok : ISample
{
    T Identity<T>(T p)
    where T : allows ref struct //NEW CONSTRAINT allow ref struct TO BE USED IN GENERICS!
    => p;   //VEDI ANCHE IEnumerable<T> https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Collections/Generic/IEnumerable.cs,12
            //VEDI ANCHE Action<T> https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Action.cs,486d58da4553e12d 

    public void Run()
    {
        // Okay in C# 13
        Span<int> local = Identity(new Span<int>(new int[10]));
    }
}