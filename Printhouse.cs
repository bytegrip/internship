namespace Internship;

public class Printhouse
{
    private string name;
    private int activePrinters;

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
}