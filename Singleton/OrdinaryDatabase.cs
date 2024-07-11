using MoreLinq;

namespace design_patterns_udemy;

public class OrdinaryDatabase
{
    private readonly Dictionary<string, int> _capitals;

    public OrdinaryDatabase()
    {
        _capitals = File.ReadAllLines("capitals.txt")
            .Batch(2).ToDictionary(list => list.ElementAt(0), list => int.Parse(list.ElementAt(1)));
    }

    public int GetPopulation(string name)
    {
        return _capitals[name];
    }

}