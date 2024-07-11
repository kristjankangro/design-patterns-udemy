// See https://aka.ms/new-console-template for more information

using design_patterns_udemy;

Console.WriteLine("Hello, World!");

var db = SingletonDatabase.Instance;

Console.WriteLine(db.GetPopulation("tokyo"));