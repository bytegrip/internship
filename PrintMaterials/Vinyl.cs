using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Vinyl(MaterialTypes type, PaperSize size, double pricePerUnit, bool waterproof = true)
    : PrintMaterial(type, size, pricePerUnit)
{
    public bool Waterproof { get; } = waterproof;

    public override double CalculateCost(int quantity)
    {
        double baseCost = PricePerUnit * quantity * 2.0;
        return Waterproof ? baseCost * 1.2 : baseCost;
    }
}