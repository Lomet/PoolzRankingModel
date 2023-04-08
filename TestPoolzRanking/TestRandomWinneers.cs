using PoolzRanking;
using Xunit;

namespace TestPoolzRanking;

public class RandomWinnersTests
{
    [Fact]
    public void TestRandomWinners()
    {
        // Arrange
        var allPlayers = new Dictionary<string, decimal>()
        {
            { "Alice", 10m },
            { "Bob", 20m },
            { "Charlie", 30m },
            { "David", 40m },
            { "Eve", 50m }
        };
        var min = 50m;
        var take = 2;
        var set = 100m;

        // Act
        var winners = new RandomWinners(allPlayers, min, take, set);

        // Assert
        Assert.Equal(2, winners.Results.Count);
        Assert.Equal(100m, winners.Results[0].Alocation);
        Assert.Equal(100m, winners.Results[1].Alocation);
    }
}
