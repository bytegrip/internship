namespace Internship.PrintMaterials;

public abstract class PrintMaterial(string type, string size, double pricePerUnit)
{
    public string Type { get; } = type;

    public string Size { get; } = size;

    protected double PricePerUnit { get; } = pricePerUnit;

    public abstract double CalculateCost(int quantity);
}