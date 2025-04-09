using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class PosterPrint(
    string name,
    int pages,
    PrintMaterial material,
    bool laminated = false,
    bool highResolution = false,
    bool isUrgent = false)
    : PrintJob(name, pages, material, isUrgent)
{
    public bool Laminated { get; } = laminated;
    public bool HighResolution { get; } = highResolution;

    public override decimal CalculateCost(decimal baseMarkup = 1.0m, bool includeShipping = false)
    {
        var baseCost = base.CalculateCost(baseMarkup, includeShipping);
        
        if (Laminated)
        {
            baseCost *= 1.25m;
        }
        
        if (HighResolution)
        {
            baseCost *= 1.4m;
        }
        
        if (Material is Canvas)
        {
            baseCost *= 1.15m;
        }
        else if (Material is Vinyl)
        {
            baseCost *= 1.1m;
        }
        
        return baseCost;
    }
}