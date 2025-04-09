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

    public override double CalculateCost(double baseMarkup = 1.0, bool includeShipping = false)
    {
        double baseCost = base.CalculateCost(baseMarkup, includeShipping);
        
        if (Laminated)
        {
            baseCost *= 1.25;
        }
        
        if (HighResolution)
        {
            baseCost *= 1.4;
        }
        
        if (Material is Canvas)
        {
            baseCost *= 1.15;
        }
        else if (Material is Vinyl)
        {
            baseCost *= 1.1;
        }
        
        return baseCost;
    }
}