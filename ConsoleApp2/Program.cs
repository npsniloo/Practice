// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

var a = new data(1,"a");
var b = new data(2, "b");
b.Id = a.Id;
a.Id = 3;
Console.WriteLine(b.Id);


Console.WriteLine("Hello, World!");
var myData = GetNumbers();
var test = ChangeData(myData);
foreach (var item in myData)
{
    Console.WriteLine($"{item.Id},{item.Name}");    
}
//foreach(var item in GetNumbers())
//{
//    Console.WriteLine(item);
//}
//var myData = GetNumbers();
//var t =myData.GroupBy(s => s.Name).Select(d=>new { id= d.Key }).ToList();
//int i = 0;
//int? nullebal;
// string ToStringNull(int? s)
//{
//    return s;
//}
List<data> ChangeData(List<data> data)
{
    List<data> test= new List<data>();  

    foreach (var item in data)
    {
        test.Add(new data(item.Id, item.Name.Clone().ToString()));
        item.Name = "changed";
        item.Id = 111;
    }
    return test;
}
List<data> GetNumbers()
{
    return new List<data>()
    {
        new data(1,"niloofar"),
        new data(2,"niloofar"),
        new data(1,"niloo"),
        new data(10,"niloofar")
    };
}

public class data
{
    public int Id;  
    public string Name;

    public data(int id, string name)
    {
        Id = id;
        Name = name;
    }
}