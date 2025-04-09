using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class BannerPrint(
    string name,
    PrintMaterial material,
    decimal width,
    decimal height,
    bool grommets = false,
    bool isUrgent = false)
    : PrintJob(name, 1, material, isUrgent)
{
    public decimal Width { get; } = width > 0m ? width : 1m;
    public decimal Height { get; } = height > 0m ? height : 1m;
    public bool Grommets { get; } = grommets;

    public override decimal CalculateCost(decimal baseMarkup = 1.0m, bool includeShipping = false)
    {
        var area = Width * Height;
        var materialCost = Material.CalculateCost(1) * (decimal)area * 10m;
        
        if (Grommets)
        {
            materialCost += 2.5m * (Width + Height) / 0.5m;
        }
        
        var urgentFee = IsUrgent ? materialCost * 0.25m : 0m;
        var totalCost = (materialCost + urgentFee) * baseMarkup;

        if (!includeShipping) return totalCost;
        var vinyl = Material as Vinyl;
        if (vinyl != null)
        {
            totalCost += vinyl.GetShippingCost(1) * area * 1.5m;
        }
        else
        {
            totalCost += Material.GetShippingCost(1) * area * 2;
        }

        return totalCost;
    }
}