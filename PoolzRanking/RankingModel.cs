namespace PoolzRanking;

public class RankingModel : Settings
{
    public RankingModel(Dictionary<string, decimal> keyValuePairs, decimal TotalAlocation, decimal Top, decimal Bottom) :
        base(TotalAlocation, Top, Bottom, keyValuePairs.Count)
    {
        TotalAmounts = keyValuePairs.Sum(kvp => kvp.Value);
        var lastItem = keyValuePairs.Last();
        var last = CalculationItem.MakeLastItem(this, new BaseItemModel(lastItem));
        CalculationItems.Add(last);
        foreach (var item in keyValuePairs.Reverse().Skip(1))
        {
            var thisItem = new CalculationItem(this, new BaseItemModel(item), last);
            CalculationItems.Insert(0, thisItem);
            last = thisItem;
        }
    }
    public decimal TotalAmounts { get; set; }
    public decimal TotalPoints => CalculationItems.Sum(ci => ci.Points);
    internal List<CalculationItem> CalculationItems { get; set; } = new List<CalculationItem>();
    public List<ResultItem> GetResults()
    {
        return CalculationItems.Select(item => new ResultItem(item.Rank ,item.Address, item.Amount, item.GetFinalAlocation(TotalAlocation, TotalAmounts, TotalPoints))).ToList();
    }
}
