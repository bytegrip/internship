using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Paper : PrintMaterial
{
    public bool DoubleSided { get; }

    public Paper(MaterialTypes type, PaperSize size, double pricePerUnit, bool doubleSided = false)
        : base(type, size, pricePerUnit)
    {
        DoubleSided = doubleSided;
    }

    public override double CalculateCost(int quantity)
    {
        double baseCost = PricePerUnit * quantity;
        return DoubleSided ? baseCost * 1.5 : baseCost;
    }
}