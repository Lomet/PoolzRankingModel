namespace PoolzRanking
{
    public class RandomWinners
    {
        public RandomWinners(Dictionary<string, decimal> allPlayers, decimal min, int take, decimal set)
        {
            var players = allPlayers.Where(T => T.Value < min);
            var random = new Random();
            var shuffledPlayers = players.OrderBy(player => random.Next() * player.Value).ToList();
            for (var i = 0; i < Math.Min(take, players.Count()); i++)
            {
                var player = shuffledPlayers[i];
                Results.Add(new ResultItem(player.Key, player.Value, set));
            }
        }

        public List<ResultItem> Results { get; } = new List<ResultItem>();
    }
}
