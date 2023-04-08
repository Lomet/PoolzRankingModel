namespace PoolzRanking;

public class CalculationItem : RankedItem
{
    private CalculationItem(Settings settings, BaseItemModel baseItem) : base(baseItem, settings.TotalItems)
    {
        Multypler = settings.Bottom;
        Points = 1;
    }
    public CalculationItem(Settings settings, BaseItemModel baseItem, CalculationItem lastItem) : base(baseItem, lastItem)
    {
        Multypler = Rank < settings.TotalItems / 2 ? settings.Bottom : settings.Top;
        Points = lastItem.Points * (1 + (lastItem.Rank - Rank) * Multypler);
    }
    public static CalculationItem MakeLastItem(Settings settings, BaseItemModel baseItem)
    {
        return new CalculationItem(settings, baseItem);
    }
    internal decimal Multypler { get; set; }
    public decimal Points { get; set; }
    internal decimal GetPointsAlocation(decimal TotalAlocation, decimal TotalPoints) => TotalAlocation * Points / TotalPoints;
    internal decimal GetAmountAlocation(decimal TotalAlocation, decimal TotalAmounts) => TotalAlocation * Amount / TotalAmounts;
    public decimal GetFinalAlocation(decimal TotalAlocation, decimal TotalAmounts, decimal TotalPoints) =>
        (GetPointsAlocation(TotalAlocation, TotalPoints) + GetAmountAlocation(TotalAlocation, TotalAmounts)) / 2;
}
