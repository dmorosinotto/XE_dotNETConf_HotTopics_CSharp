namespace EX3_CSharp12_FUTURE;
/*
//AUTOMATIC APPLY THIS EXTENSION METHOD TO ALL DataObject 
//THIS ARE EXTENSION METHODS ON STEROID -> EXTENSION EVERYWHERE
public implicit extension IsonObject for Databject
: IParsable<Databject> //EXTERNAL INTERFACE IMPLEMENTATION
{ 
    public JsonString ToJson() { … this … }
    public static Databject FromJson(JsonString json) { … }
    
    //EXPLICIT INTERFACE IMPLEMENTATION
    static Databject IParseable<Databject>.Parse(string s) => FromJson(s);
}

//SAMPLE USE CASE OF ABOVE -> INTELLISENSE SUGGESTION OF EXTENSIONS METHODS: From/ToJson() ON EVERY DataObject
void Send(Databject o) { … o. ToJson() … }
Databject Receive() { … return Databject.FromJson("...") ; … }
*/ 