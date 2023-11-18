namespace EX3_CSharp12_FUTURE;

public class Student_FIELDACCESSOR(string name, int id, List<decimal> Grades)
{
    // public string Name { get; set => field = value.Trim(); } = name; //AUTO PROPERTY + BACKING field+value ACCESSOR
    //PROBLEM BREACKING CHANGE IF CLASS HAS EXISTING  field OR value PROPERTY
    // string field; //field backing property
    // string value; //value backing property
    //SAME PROBLEM WITH var OR nameof SOMETIMES USED...
    public int Id => id;

    public Student_FIELDACCESSOR(string name, int id) : this(name, id, []) { }
    public decimal GPA => Grades switch
    {
    [] => 4.0m,
    [var grade] => grade,
    [.. var all] => all.Average()
    };
}