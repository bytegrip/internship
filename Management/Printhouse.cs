using System.Collections;
using Internship.PrintJobs;

namespace Internship.Management;

public class Printhouse(string name, int activePrinters) : IEnumerable<PrintJob>, ICloneable
{
    private readonly List<PrintJob> _printJobs = [];
    private readonly Dictionary<string, double> _customerDiscounts = [];

    public string Name { get; } = name;
    public int ActivePrinters { get; private set; } = activePrinters > 0 ? activePrinters : 1;
    public int PrintJobCount => _printJobs.Count;
    public bool AcceptsUrgentJobs { get; set; } = true;
    public double DefaultMarkup { get; set; } = 1.2;

    public void AddPrintJob(PrintJob job)
    {
        if (job.IsUrgent && !AcceptsUrgentJobs)
        {
            throw new InvalidOperationException("This printhouse does not accept urgent jobs.");
        }
        
        _printJobs.Add(job);
    }

    public double CalculateTotalCost(double discount = 0, bool includeShipping = false)
    {
        double total = 0;
        foreach (var job in _printJobs)
        {
            total += job.CalculateCost(DefaultMarkup, includeShipping);
        }
        return total * (1 - discount);
    }
    
    public void AddCustomerDiscount(string customerName, double discountRate)
    {
        if (discountRate < 0 || discountRate > 0.5)
        {
            throw new ArgumentOutOfRangeException(nameof(discountRate), "Discount must be between 0 and 0.5");
        }
        
        _customerDiscounts[customerName] = discountRate;
    }
    
    public double GetCustomerDiscount(string customerName)
    {
        return _customerDiscounts.TryGetValue(customerName, out double discount) ? discount : 0;
    }
    
    public void UpdateActivePrinters(int count, bool redistributeJobs = false)
    {
        if (count <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(count), "Printer count must be positive");
        }
        
        ActivePrinters = count;
        
        if (redistributeJobs && _printJobs.Count > 0)
        {
            var prioritizedJobs = new List<PrintJob>();
            
            foreach (var job in _printJobs)
            {
                if (job.IsUrgent)
                {
                    prioritizedJobs.Add(job);
                }
            }
            
            foreach (var job in _printJobs)
            {
                if (!job.IsUrgent)
                {
                    prioritizedJobs.Add(job);
                }
            }
                
            _printJobs.Clear();
            foreach (var job in prioritizedJobs)
            {
                _printJobs.Add(job);
            }
        }
    }
    
    public PrintJob[] GetJobsByType(Type jobType)
    {
        var result = new List<PrintJob>();
        foreach (var job in _printJobs)
        {
            if (job.GetType() == jobType || jobType.IsInstanceOfType(job))
            {
                result.Add(job);
            }
        }
        return result.ToArray();
    }
    
    public PrintJob[] GetPendingJobs()
    {
        var result = new List<PrintJob>();
        foreach (var job in _printJobs)
        {
            if (job.CompletedAt == null)
            {
                result.Add(job);
            }
        }
        return result.ToArray();
    }
    
    public bool CompletePrintJob(string jobName)
    {
        foreach (var job in _printJobs)
        {
            if (job.Name == jobName && job.CompletedAt == null)
            {
                job.MarkAsCompleted();
                return true;
            }
        }
        return false;
    }
    
    public double CalculateJobCost(string jobName, string customerName = "", bool includeShipping = false)
    {
        PrintJob job = null;
        foreach (var j in _printJobs)
        {
            if (j.Name == jobName)
            {
                job = j;
                break;
            }
        }
        
        if (job == null)
        {
            throw new ArgumentException($"Job '{jobName}' not found", nameof(jobName));
        }
        
        double discount = GetCustomerDiscount(customerName);
        return job.CalculateCost(DefaultMarkup, includeShipping) * (1 - discount);
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
        var printhouse = new Printhouse(Name, ActivePrinters)
        {
            AcceptsUrgentJobs = AcceptsUrgentJobs,
            DefaultMarkup = DefaultMarkup
        };
        
        foreach (var job in _printJobs)
        {
            printhouse.AddPrintJob(job);
        }
        
        foreach (var kvp in _customerDiscounts)
        {
            printhouse.AddCustomerDiscount(kvp.Key, kvp.Value);
        }
        
        return printhouse;
    }
}