namespace PoolzRanking;

public class Settings
{
    public Settings(decimal totalAlocation, decimal top, decimal bottom, int totalItems)
    {
        TotalAlocation = totalAlocation;
        Top = top;
        Bottom = bottom;
        TotalItems = totalItems;
    }
    public decimal TotalAlocation { get; set; }
    public decimal Top { get; set; }
    public decimal Bottom { get; set; }
    public int TotalItems { get; set; }
}
