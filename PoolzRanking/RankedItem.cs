namespace PoolzRanking;

public class RankedItem : BaseItemModel
{
    internal RankedItem(BaseItemModel baseItem, int TotalItems) : base(baseItem.Address, baseItem.Amount)
    {
        Rank = Index = TotalItems;
    }
    /// <summary>
    /// This will make the next ranked item, for the first last item use the MakeLastItem()
    /// </summary>
    /// <param name="baseItem"></param>
    /// <param name="lastItem"></param>
    public RankedItem(BaseItemModel baseItem, RankedItem lastItem) : base(baseItem.Address, baseItem.Amount)
	{
        if (lastItem.Amount > baseItem.Amount)
        {
            throw new ArgumentException("Data is not ordered by amount in descending order.");
        }
        Index = lastItem.Index - 1;
		Rank = lastItem.Amount == baseItem.Amount ? lastItem.Rank : Index;
    }
	public static RankedItem MakeLastItem(BaseItemModel baseItem,int TotalItems)
    {
        return new RankedItem(baseItem, TotalItems);
    }
    public int Rank { get; set; }
	public int Index { get; set; }
}
