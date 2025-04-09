using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Canvas(MaterialTypes type, PaperSize size, decimal pricePerUnit, bool stretchedFrame = false)
    : PrintMaterial(type, size, pricePerUnit)
{
    private bool StretchedFrame { get; } = stretchedFrame;

    public override decimal CalculateCost(int quantity)
    {
        var baseCost = PricePerUnit * quantity * 1.5m;
        return StretchedFrame ? baseCost * 1.3m : baseCost;
    }
    
    public override decimal GetShippingCost(int quantity = 1, decimal baseRate = 5)
    {
        return baseRate * 1.5m + (quantity * 0.2m);
    }
}