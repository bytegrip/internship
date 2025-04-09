using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public abstract class PrintMaterial(MaterialTypes type, PaperSize size, double pricePerUnit)
{
    public MaterialTypes Type { get; } = type;
    public PaperSize Size { get; } = size;
    protected double PricePerUnit { get; } = pricePerUnit;

    public abstract double CalculateCost(int quantity);
    
    public virtual double GetShippingCost(int quantity = 1, double baseRate = 5.0)
    {
        return baseRate + (quantity * 0.1);
    }
}