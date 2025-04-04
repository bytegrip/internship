namespace Internship.PrintMaterials;

public class Canvas : PrintMaterial
{
    public Canvas(string type, string size, double pricePerUnit) 
        : base(type, size, pricePerUnit)
    {
    }

    public override double CalculateCost(int quantity)
    {
        return PricePerUnit * quantity * 1.5;
    }
}