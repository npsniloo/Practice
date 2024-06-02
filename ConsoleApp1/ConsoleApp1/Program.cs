// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");
string end = "0";
while (end != "1")
{
    var c = new Class1();
    c.add();
    Console.WriteLine("Count=" + c.get());
    Console.WriteLine("Continue?(0/1)");
    end = Console.ReadLine();

}

