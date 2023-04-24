using PoolzRanking.Models;

namespace PoolzRanking;

public class Program
{
    private static void Main(string[] args) 
    {
        Console.WriteLine("Welcome to PoolzRanking");
    }
    public static List<ResultItem> Run(List<SignUp> signUps, InputData inputData)
    {

        var filterd = signUps.Where(T => T.Amount >= inputData.MinAmount).ToDictionary(kvp => kvp.Address, kvp => kvp.Amount);
        var testModel = new RankingModel(filterd, inputData.TotalAllocation, inputData.Top, inputData.Bot);
        var set = testModel.GetResults().Last().Alocation * inputData.WinnersRatio;

        var rankingModel = new RankingModel(filterd, inputData.TotalAllocation - inputData.Take * set, inputData.Top, inputData.Bot).GetResults();
        rankingModel.AddRange(new RandomWinners(signUps, inputData.MinAmount, inputData.Take, set).Results);

        return rankingModel;
    }
}