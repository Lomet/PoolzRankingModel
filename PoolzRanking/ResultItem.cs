namespace PoolzRanking;

public class ResultItem : BaseItemModel
{
    public ResultItem(string address, decimal amount, decimal Alocation) : base(address, amount)
    {
        this.Alocation = Alocation; 
    }
    public decimal Alocation { get; set; }
}
