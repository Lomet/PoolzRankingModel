namespace PoolzRanking;

public class ResultItem : BaseItemModel
{
    public override string ToString()
    {
        return $"{Rank},{Address},{Amount},{Allocation}";
    }
    public ResultItem(int rank, string address, decimal amount, decimal Alocation) : base(address, amount)
    {
        this.Allocation = Alocation; 
        this.Rank = rank;
    }
    public decimal Allocation { get; set; }
    public int Rank { get; set; }
}
