using Autofac;
using NUnit.Framework;

namespace design_patterns_udemy;

[TestFixture]
public class SingletonTest
{
    [Test]
    public void IsSingletonTest()
    {
        var db1 = SingletonDatabase.Instance;
        var db2 = SingletonDatabase.Instance;
        Assert.That(db1, Is.SameAs(db2));
    }

    [Test]
    public void SingletonTotalPopulationTest()
    {
        var rf = new ConfigurableSingletonUser(new DummyDb());
        var names = new[] { "a", "b" };
        var tp = rf.GetTotalPop(names);
        Assert.That(tp, Is.EqualTo(3));
    }

    [Test]
    public void DIPopulationTest()
    {
        var cb = new ContainerBuilder();
        cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance();
        cb.RegisterType<ConfigurableSingletonUser>();
        using (var c = cb.Build())
        {
            var rf = c.Resolve<ConfigurableSingletonUser>();
        }
    }
}

public class DummyDb : IDatabase
{
    private Dictionary<string,int> dict = new Dictionary<string, int>
    {
        ["a"] = 1,
        ["b"] = 2,
        ["c"] = 3
        
    };
    public int GetPopulation(string name)
    {
        return dict[name];
    }
}