namespace Internship.PrintMaterials;

public class Paper(string type, string size, double pricePerUnit) : PrintMaterial(type, size, pricePerUnit)
{
    public override double CalculateCost(int quantity)
    {
        return PricePerUnit * quantity;
    }
}