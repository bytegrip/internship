namespace Internship.PrintMaterials;

public abstract class PrintMaterial
{
    private string type;
    private string size;
    private double pricePerUnit;

    public string Type 
    { 
        get { return type; } 
        set { type = value; } 
    }

    public string Size 
    { 
        get { return size; } 
        set { size = value; } 
    }

    public double PricePerUnit 
    { 
        get { return pricePerUnit; } 
        set { pricePerUnit = value; } 
    }

    public PrintMaterial(string type, string size, double pricePerUnit)
    {
        this.type = type;
        this.size = size;
        this.pricePerUnit = pricePerUnit;
    }

    public abstract double CalculateCost(int quantity);
}