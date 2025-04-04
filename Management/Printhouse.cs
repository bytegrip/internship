using System.Collections;
using Internship.PrintJobs;

namespace Internship.Management;

public class Printhouse(string name, int activePrinters) : IEnumerable<PrintJob>, ICloneable
{
    private readonly List<PrintJob> _printJobs = [];

    public string Name { get; } = name;

    public int ActivePrinters { get; } = activePrinters > 0 ? activePrinters : 1;

    public int PrintJobCount => _printJobs.Count;

    public void AddPrintJob(PrintJob job)
    {
        _printJobs.Add(job);
    }

    public double CalculateTotalCost()
    {
        return _printJobs.Sum(job => job.CalculateCost());
    }

    public double CalculateTotalCost(double discount)
    {
        return CalculateTotalCost() * (1 - discount);
    }

    public IEnumerator<PrintJob> GetEnumerator()
    {
        return _printJobs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public object Clone()
    {
        var printhouse = new Printhouse(Name, ActivePrinters);
        foreach (var job in _printJobs)
        {
            printhouse.AddPrintJob(job);
        }
        return printhouse;
    }
}