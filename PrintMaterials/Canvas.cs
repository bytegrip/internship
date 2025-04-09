using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public class Canvas(string type, PaperSize size, double pricePerUnit) : PrintMaterial(type, size, pricePerUnit)
{
    public override double CalculateCost(int quantity)
    {
        return PricePerUnit * quantity * 1.5;
    }
}