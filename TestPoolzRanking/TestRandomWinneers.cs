using PoolzRanking;
using PoolzRanking.Models;
using Xunit;

namespace TestPoolzRanking;

public class RandomWinnersTests
{
    [Fact]
    public void TestRandomWinners()
    {
        // Arrange
        var allPlayers = new List<SignUp>()
        {
            new SignUp { Address = "Alice", Amount = 10m },
            new SignUp { Address = "Bob", Amount = 20m },
            new SignUp { Address = "Charlie", Amount = 30m },
            new SignUp { Address = "David", Amount = 40m },
            new SignUp { Address = "Eve", Amount = 50m }
        };
        var min = 50m;
        var take = 2;
        var set = 100m;

        // Act
        var winners = new RandomWinners(allPlayers, min, take, set);

        // Assert
        Assert.Equal(2, winners.Results.Count);
        Assert.Equal(100m, winners.Results[0].Allocation);
        Assert.Equal(100m, winners.Results[1].Allocation);
    }
}
