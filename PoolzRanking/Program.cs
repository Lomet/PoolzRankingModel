using Flurl.Http;
using Newtonsoft.Json.Linq;
using PoolzRanking;

Dictionary<string, decimal> Parsed = await SignUpProvider(103);

var TotalAlocation = 600000;
var Top = 0.005m;
var Bot = 0.001m;
var min = 250;
var Winners_Ratio = 0.5m;
var take = 10;

var filterd = Parsed.Where(T => T.Value >= min).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
var testModel = new RankingModel(filterd, TotalAlocation, Top, Bot);
var set = testModel.GetResults().Last().Alocation * Winners_Ratio;

var rankingModel = new RankingModel(filterd, TotalAlocation - take * set, Top, Bot).GetResults();
rankingModel.AddRange(new RandomWinners(Parsed, min, take, set).Results);

var csv = new CSVMaker($"Result{DateTime.Now.Ticks}.csv");
csv.SaveToCsv(rankingModel);
static async Task<Dictionary<string, decimal>> SignUpProvider(int id, decimal minamount = 1)
{
    var LeaderboardURL = @"https://api3.poolz.finance/signup?id=" + id;
    var Leaderboard = await LeaderboardURL.GetJsonAsync<JArray>();
    var Parsed = new Dictionary<string, decimal>();

    foreach (var item in Leaderboard)
    {
        var value = decimal.Parse(item["Amount"].ToString());
        if (value > minamount)
        Parsed.Add(item["Address"].ToString(), value);
    }

    return Parsed;
}