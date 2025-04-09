using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class BannerPrint : PrintJob
{
    public double Width { get; }
    public double Height { get; }
    public bool Grommets { get; }

    public BannerPrint(string name, PrintMaterial material, double width, double height, 
        bool grommets = false, bool isUrgent = false)
        : base(name, 1, material, isUrgent)
    {
        Width = width > 0 ? width : 1;
        Height = height > 0 ? height : 1;
        Grommets = grommets;
    }

    public override double CalculateCost(double baseMarkup = 1.0, bool includeShipping = false)
    {
        double area = Width * Height;
        double materialCost = Material.CalculateCost(1) * area * 10;
        
        if (Grommets)
        {
            materialCost += 2.5 * (Width + Height) / 0.5;
        }
        
        double urgentFee = IsUrgent ? materialCost * 0.25 : 0;
        double totalCost = (materialCost + urgentFee) * baseMarkup;
        
        if (includeShipping)
        {
            var vinyl = Material as Vinyl;
            if (vinyl != null)
            {
                totalCost += vinyl.GetShippingCost(1) * area * 1.5;
            }
            else
            {
                totalCost += Material.GetShippingCost(1) * area * 2;
            }
        }
        
        return totalCost;
    }
}