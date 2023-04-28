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
        // Filter sign-ups with the minimum amount
        var filteredSignUps = signUps
            .Where(s => s.Amount >= inputData.MinAmount)
            .ToDictionary(kvp => kvp.Address, kvp => kvp.Amount);

        var rankingModel = new RankingModel(
            filteredSignUps,
            inputData.TotalAllocation,
            inputData.Top,
            inputData.Bot
        );

        // Calculate the allocation for winners
        var allocationForWinners = rankingModel.GetResults().Last().Allocation * inputData.WinnersRatio;
        // Calculate the number of random winners to take
        int randomWinnersToTake = Math.Min(inputData.Take, signUps.Count - filteredSignUps.Count);
        // If there are no random winners, return the results from the ranking model
        if (randomWinnersToTake == 0)
        {
            return rankingModel.GetResults();
        }
        // Otherwise, calculate the results for the filtered sign-ups
        var finalResults = new RankingModel(
            filteredSignUps,
            inputData.TotalAllocation - randomWinnersToTake * allocationForWinners,
            inputData.Top,
            inputData.Bot
        ).GetResults();

        // Add random winners to the final results
        finalResults.AddRange(
            new RandomWinners(
                signUps,
                inputData.MinAmount,
                randomWinnersToTake,
                allocationForWinners
            ).Results
        );

        return finalResults;
    }
}