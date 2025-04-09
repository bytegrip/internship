using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Paper(string type, PaperSize size, double pricePerUnit) : PrintMaterial(type, size, pricePerUnit)
{
    public override double CalculateCost(int quantity)
    {
        return PricePerUnit * quantity;
    }
}