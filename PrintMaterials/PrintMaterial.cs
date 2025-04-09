using Internship.PrintJobs;

namespace Internship.PrintMaterials;

public abstract class PrintMaterial(string type, PaperSize size, double pricePerUnit)
{
    public string Type { get; } = type;

    public PaperSize Size { get; } = size;

    protected double PricePerUnit { get; } = pricePerUnit;

    public abstract double CalculateCost(int quantity);
}