namespace Internship.PrintMaterials;

public class Paper : PrintMaterial
{
    public Paper(string type, string size, double pricePerUnit) 
        : base(type, size, pricePerUnit)
    {
    }

    public override double CalculateCost(int quantity)
    {
        return PricePerUnit * quantity;
    }
}