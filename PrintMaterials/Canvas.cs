using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Canvas(MaterialTypes type, PaperSize size, double pricePerUnit, bool stretchedFrame = false)
    : PrintMaterial(type, size, pricePerUnit)
{
    public bool StretchedFrame { get; } = stretchedFrame;

    public override double CalculateCost(int quantity)
    {
        double baseCost = PricePerUnit * quantity * 1.5;
        return StretchedFrame ? baseCost * 1.3 : baseCost;
    }
    
    public override double GetShippingCost(int quantity = 1, double baseRate = 5)
    {
        return baseRate * 1.5 + (quantity * 0.2);
    }
}