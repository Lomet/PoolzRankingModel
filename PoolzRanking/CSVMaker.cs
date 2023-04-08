using System.Globalization;

namespace PoolzRanking;

internal class CSVMaker
{
    public CSVMaker(string fileName)
    {
        FileName = fileName;
    }

    public string FileName { get; set; }

    public void SaveToCsv(List<ResultItem> results)
    {
        using var writer = new StreamWriter(FileName);
        var culture = CultureInfo.InvariantCulture;
        writer.WriteLine("Address,Amount,Alocation,USDtoPOOLX,Linear");
        var totalAlocation = results.Sum(T => T.Alocation);
        var totalAmounts = results.Sum(T => T.Amount);
        foreach (var result in results)
        {
            writer.WriteLine($"{result.Address},{result.Amount},{result.Alocation},{result.Ratio},{result.Amount* totalAlocation / totalAmounts}");
        }
    }

}
