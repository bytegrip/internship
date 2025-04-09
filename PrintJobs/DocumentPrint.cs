using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class DocumentPrint(
    string name,
    int pages,
    PrintMaterial material,
    bool isUrgent = false,
    bool doubleSpaced = false,
    bool colored = false)
    : PrintJob(name, pages, material, isUrgent)
{
    public bool DoubleSpaced { get; } = doubleSpaced;
    public bool Colored { get; } = colored;

    public override decimal CalculateCost(decimal baseMarkup = 1.0m, bool includeShipping = false)
    {
        var baseCost = base.CalculateCost(baseMarkup, includeShipping);
        
        if (Pages > 100)
        {
            baseCost *= 0.9m;
        }
        
        if (DoubleSpaced)
        {
            baseCost *= 1.1m;
        }
        
        if (Colored)
        {
            baseCost *= 1.25m;
        }
        
        return baseCost;
    }
}