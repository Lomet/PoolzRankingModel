using PoolzRanking.Models;

namespace PoolzRanking;

public class Program
{
    private static void Main(string[] args) 
    {
        Console.WriteLine("Welcome to PoolzRanking");
    }
    public static string Run(List<SignUp> signups, decimal totalAllocation, decimal top, decimal bot, int min, decimal winnersRatio, int take)
    {
        var filterd = signups.Where(T => T.Amount >= min).ToDictionary(kvp => kvp.Address, kvp => kvp.Amount);
        var testModel = new RankingModel(filterd, totalAllocation, top, bot);
        var set = testModel.GetResults().Last().Alocation * winnersRatio;

        var rankingModel = new RankingModel(filterd, totalAllocation - take * set, top, bot).GetResults();
        rankingModel.AddRange(new RandomWinners(signups, min, take, set).Results);

        return string.Join(Environment.NewLine, rankingModel);
    }
}