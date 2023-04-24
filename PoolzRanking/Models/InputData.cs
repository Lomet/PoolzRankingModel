namespace PoolzRanking.Models;

public class InputData
{
    public int SignUpId { get; set; }
    public int TotalAllocation { get; set; }
    public decimal Top { get; set; }
    public decimal Bot { get; set; }
    public int MinAmount { get; set; }
    public decimal WinnersRatio { get; set; }
    public int Take { get; set; }
}
