namespace PoolzRanking;

public class ResultItem : BaseItemModel
{
    public override string ToString()
    {
        return $"{Address},{Amount},{Alocation}";
    }
    public ResultItem(int rank, string address, decimal amount, decimal Alocation) : base(address, amount)
    {
        this.Alocation = Alocation; 
        this.Rank = rank;
    }
    public decimal Alocation { get; set; }
    public int Rank { get; set; }
}
