using PoolzRanking.Models;

namespace PoolzRanking;

public class RandomWinners
{
    public RandomWinners(List<SignUp> allPlayers, decimal min, int take, decimal set)
    {
        var players = allPlayers.Where(T => T.Amount < min);
        var random = new Random();
        var shuffledPlayers = players.OrderBy(player => random.Next() * player.Amount).ToList();
        for (var i = 0; i < Math.Min(take, players.Count()); i++)
        {
            var player = shuffledPlayers[i];
            Results.Add(new ResultItem(allPlayers.Count - players.Count() + 1, player.Address, player.Amount, set));
        }
    }

    public List<ResultItem> Results { get; } = new List<ResultItem>();
}
