namespace design_patterns_udemy;

public class ConfigurableSingletonUser
{
    private IDatabase _database;

    public ConfigurableSingletonUser(IDatabase database)
    {
        _database = database;
    }
    public int GetTotalPop(IEnumerable<string> names)
    {
        int res = 0;
        foreach (var name in names)
        {
            res += _database.GetPopulation(name);
        }

        return res;
    }
}