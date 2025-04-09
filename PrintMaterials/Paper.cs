using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Paper(MaterialTypes type, PaperSize size, decimal pricePerUnit, bool doubleSided = false)
    : PrintMaterial(type, size, pricePerUnit)
{
    private bool DoubleSided { get; } = doubleSided;

    public override decimal CalculateCost(int quantity)
    {
        var baseCost = PricePerUnit * quantity;
        return DoubleSided ? baseCost * 1.5m : baseCost;
    }
}