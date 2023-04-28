using PoolzRanking;
using Xunit;

namespace TestPoolzRanking;

public class TestPoolzRanking
{
    internal string address = "0x54545454sdf5445454dasf";
    internal decimal amount = 54m;
    internal BaseItemModel BaseTestItem => new BaseItemModel(address, amount);
    internal Dictionary<string, decimal> TestItems => new Dictionary<string, decimal>()
    { { "A",15000}, { "B", 14000 }, { "User3", 10000}, { "User4", 10000}, { "User5", 10000},
      { "User6", 8000},{ "User7", 7000}, { "User8", 6000}, { "User9", 6000},{ address, amount}
    };
    internal int count => TestItems.Count;
    internal RankedItem LastItem => RankedItem.MakeLastItem(BaseTestItem, count);
    internal BaseItemModel BaseItemById(int id) => new BaseItemModel(TestItems.ElementAt(id));
    
    [Fact]
    public void TestBaseItemCtor()
    {
        Assert.Equal(address, BaseTestItem.Address);
        Assert.Equal(amount, BaseTestItem.Amount);
    }
    [Fact]
    public void TestBaseItemCtor2()
    {
        KeyValuePair<string, decimal> keyValuePair = new KeyValuePair<string, decimal>(address, amount);
        var item = new BaseItemModel(keyValuePair);

        Assert.Equal(keyValuePair.Key, item.Address);
    }
    [Fact]
    public void TestMakeLastItem()
    {
        Assert.Equal(count, LastItem.Rank);
        Assert.Equal(count, LastItem.Index);
    }
    [Fact]
    public void TestRankedItemCtor_SameAmount()
    {
        var item = new RankedItem(LastItem, LastItem);
        Assert.Equal(LastItem.Rank, item.Rank);
        Assert.Equal(LastItem.Index, item.Index + 1);
    }
    [Fact]
    public void TestRankedItemCtor_DiffrentAmount()
    {
        var nextitem = BaseItemById(count - 2); // 1 from count is last. need 2nd last
        var item = new RankedItem(nextitem, LastItem);
        Assert.Equal(LastItem.Rank, item.Rank + 1);
        Assert.Equal(LastItem.Index, item.Index + 1);
    }
    [Fact]
    public void TestRankedItemThrowsWhenDataNotOrderedByAmount()
    {
        var baseItem = new BaseItemModel("Address 1", 100);
        var lastItem = RankedItem.MakeLastItem(new BaseItemModel("Address 2", 200), 2);

        Assert.Throws<ArgumentException>(() => new RankedItem(baseItem, lastItem));
    }
    [Fact]
    public void TestSettingsConstructorAndProperties()
    {
        decimal totalAlocation = 1000m;
        decimal top = 0.5m;
        decimal bottom = 0.1m;
        int totalItems = 10;

        var settings = new Settings(totalAlocation, top, bottom, totalItems);

        Assert.Equal(totalAlocation, settings.TotalAlocation);
        Assert.Equal(top, settings.Top);
        Assert.Equal(bottom, settings.Bottom);
        Assert.Equal(totalItems, settings.TotalItems);
    }
    [Fact]
    public void TestResultItemConstructorAndProperties()
    {
        string address = "0x1234567890123456789012345678901234567890";
        decimal amount = 1000m;
        decimal allocation = 0.5m;

        var resultItem = new ResultItem(1 ,address, amount, allocation);

        Assert.Equal(address, resultItem.Address);
        Assert.Equal(amount, resultItem.Amount);
        Assert.Equal(allocation, resultItem.Allocation);
    }
}