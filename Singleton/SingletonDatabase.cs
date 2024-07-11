using MoreLinq;

namespace design_patterns_udemy;

public class SingletonDatabase : IDatabase
{
    private Dictionary<string, int> capitals;

    private SingletonDatabase()
    {
        this.capitals = File.ReadAllLines("capitals.txt")
            .Batch(2).ToDictionary(list => list.ElementAt(0), list => int.Parse(list.ElementAt(1)));
    }

    public int GetPopulation(string name)
    {
        return capitals[name];
    }

    private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
    public static SingletonDatabase Instance => instance.Value;
}