# MAYBE FUTURE C#13+

## `explicit/implicit extension`

[VIDEO](https://www.youtube.com/watch?v=rp1iX26T_LE) Mads & Kathleen talking about Future of C# 13+ aka **EXTENSION EVRYWHERE**

### DataObject **extension** -> _"wrapper"_ of generic `Dictionary<string, object>`

```csharp
//DEFAINE A GENERIC DataObject AS A "WRAPPER" (extension) TO Dictionary<string, object>
public explicit extension DataSet<T>
        : Dictionary‹string, T>
        where T : DataItem
{ … }
```

### JsonString **extension** of string -> method Parse (string = JSON)

```csharp
//GENERIC PARSE FOR STRING "AS JSON"
public explicit extension JsonString for string
{
    public DataObject Parse() {  … parse as Json …  }
}

//GENERIC USE OF PARSE FOR STRING "AS JSON"
void Display(string json) {  … json.Parse(); …  }
Display("""{ "customer" : { "name" : "Microsoft" ... } }""");
```

### XmlString **extension** of string -> method Parse (string = XML)

```csharp
//SAME INTERFACE PARSE BUT WITH DIFFERENT "IMPLEMENTATION" string "AS XML"
public explicit extension XmlString for string
{
    public DataObject Parse { … parse as XML …  }
}
```

### Customer, Order extension = **wrapper** -> DataObject _"Shape structural-tyoe ala TS"_

```csharp
//SOMETHING LIKE "TYPESCRIPT" STRUCT TYPE TO ACCESS STRICT DATA SHAPE FOR GENERIC/dynamic DataObject
public explicit extension Customer for DataObject
{
public string Name => this["Name"];
public string Address => this["Address"];
public IEnumerable<Order> Orders => this["Orders"];
}

//SAME AS ABOVE BUT WITH DIFFERENT "ORDER SHAPE"
public explicit extension Order for DataObject
{
public Customer Customer => this["Customer"];
public string Description => this["Description"];
}
```

### `implicit extension` -> add Method to DataObject

```csharp
//AUTOMATIC APPLY THIS EXTENSION METHOD TO ALL DataObject
//THIS ARE EXTENSION METHODS ON STEROID -> EXTENSION EVERYWHERE
public implicit extension JsonObject for DataObject
{ //REAL IMPLEMENTATION OF METHOD ATTACHED TO EVERY DataObject
    public JsonString ToJson() { … this … }
    public static DataObject FromJson(JsonString json) { … }
}
```

#### Using method from `DataObject`

```csharp
//SAMPLE USE CASE OF ABOVE -> INTELLISENSE SUGGESTION OF EXTENSIONS METHODS: From/ToJson() ON EVERY DataObject
void Send(DataObject o) { … o.ToJson() … }
DataObject Receive() { … return Databject.FromJson("...") ; … }

```

### Even **implementing Interface** from _"Outside"_

```csharp
namespace EX3_CSharp12_FUTURE;
//AUTOMATIC APPLY THIS EXTENSION METHOD TO ALL DataObject
//ADDING EVEN EXTERNAL INTERFACE IMPLEMENTATION
public implicit extension JsonObject for DataObject
: IParsable<DataObject> //EXTERNAL INTERFACE IMPLEMENTATION
{
    public JsonString ToJson() { … this … }
    public static DataObject FromJson(JsonString json) { … }

    //EXPLICIT INTERFACE IMPLEMENTATION
    static DataObject IParseable<DataObject>.Parse(string s) => FromJson(s);
}

//SAMPLE USE CASE OF ABOVE -> INTELLISENSE SUGGESTION OF EXTENSIONS METHODS: From/ToJson() ON EVERY DataObject
void Send(DataObject o) { … o. ToJson() … }
DataObject Receive() { … return DataObject.FromJson("...") ; … }
```
