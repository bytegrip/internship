using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public abstract class PrintMaterial(MaterialTypes type, PaperSize size, decimal pricePerUnit)
{
    public MaterialTypes Type { get; } = type;
    public PaperSize Size { get; } = size;
    protected decimal PricePerUnit { get; } = pricePerUnit;

    public abstract decimal CalculateCost(int quantity);
    
    public virtual decimal GetShippingCost(int quantity = 1, decimal baseRate = 5.0m)
    {
        return baseRate + (quantity * 0.1m);
    }
}