using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Vinyl(MaterialTypes type, PaperSize size, decimal pricePerUnit, bool waterproof = true)
    : PrintMaterial(type, size, pricePerUnit)
{
    private bool Waterproof { get; } = waterproof;

    public override decimal CalculateCost(int quantity)
    {
        var baseCost = PricePerUnit * quantity * 2.0m;
        return Waterproof ? baseCost * 1.2m : baseCost;
    }
}