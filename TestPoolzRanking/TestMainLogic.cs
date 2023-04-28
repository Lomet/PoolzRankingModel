using PoolzRanking;
using Xunit;

namespace TestPoolzRanking;

public class TestMainLogic
{
    [Fact]
    public void TestRankingModel()
    {
        var keyValuePairs = new Dictionary<string, decimal>
    {
        { "A", 15000 },
        { "B", 14000 },
        { "User3", 10000 },
        { "User4", 10000 },
        { "User5", 10000 },
        { "User6", 8000 },
        { "User7", 7000 },
        { "User8", 6000 },
        { "User9", 6000 },
        { "0x54545454sdf5445454dasf", 54m }
    };
        var totalAllocation = 100m;
        var top = 1m;
        var bottom = 0.5m;

        var rankingModel = new RankingModel(keyValuePairs, totalAllocation, top, bottom);

        Assert.Equal(keyValuePairs.Sum(x => x.Value), rankingModel.TotalAmounts);
        Assert.Equal(keyValuePairs.Count, rankingModel.TotalItems);
        Assert.Equal(totalAllocation, rankingModel.TotalAlocation);
    }
    [Fact]
    public void TestRankingModel2()
    {
        var keyValuePairs = new Dictionary<string, decimal>
    {
        { "A", 15000 },
        { "B", 14000 },
        { "User3", 10000 },
        { "User4", 10000 },
        { "User5", 10000 },
        { "User6", 8000 },
        { "User7", 7000 },
        { "User8", 6000 },
        { "User9", 6000 },
        { "0x54545454sdf5445454dasf", 54m }
    };
        var totalAllocation = 100m;
        var top = 1m;
        var bottom = 0.5m;

        var results = new RankingModel(keyValuePairs, totalAllocation, top, bottom).GetResults();

        Assert.Equal(keyValuePairs.Sum(x => x.Value), results.Sum(r=>r.Amount));
        Assert.Equal(keyValuePairs.Count, results.Count);
        Assert.Equal(totalAllocation, results.Sum(r=>r.Allocation));

        var firstItem = results.First();
        foreach (var item in results.Skip(1))
        {
            Assert.True(firstItem.Allocation >= item.Allocation);
            Assert.True(firstItem.Amount >= item.Amount);
            firstItem = item;
        }
    }

}
