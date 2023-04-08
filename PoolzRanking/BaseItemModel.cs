namespace PoolzRanking;

public class BaseItemModel
{
    public BaseItemModel(KeyValuePair<string,decimal> keyValuePair)
    {
        Address = keyValuePair.Key;
        Amount= keyValuePair.Value;
    }
    public BaseItemModel(string address, decimal amount)
    {
        Address = address;
        Amount = amount;
    }
    public string Address { get; set; }
    public decimal Amount { get; set; }
}
