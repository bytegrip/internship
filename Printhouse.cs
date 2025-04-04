using Internship.PrintJobs;

namespace Internship;

public class Printhouse : ICloneable
{
    private string name;
    private int activePrinters;
    private List<PrintJob> printJobs;
    
    public string Name 
    { 
        get { return name; } 
        private set { name = value; } 
    }

    public int ActivePrinters 
    { 
        get { return activePrinters; } 
        set { activePrinters = value > 0 ? value : 1; } 
    }

    public Printhouse(string name, int activePrinters)
    {
        this.name = name;
        this.activePrinters = activePrinters > 0 ? activePrinters : 1;
    }

    public double CalculateTotalCost(double discount)
    {
        return CalculateTotalCost() * (1 - discount);
    }

    public object Clone()
    {
        var printhouse = new Printhouse(Name, ActivePrinters);
        foreach (var job in printJobs)
        {
            printhouse.AddPrintJob(job);
        }
        return printhouse;
    }
}