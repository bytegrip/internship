using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class DocumentPrint : PrintJob
{
    public bool DoubleSpaced { get; }
    public bool Colored { get; }

    public DocumentPrint(string name, int pages, PrintMaterial material, bool isUrgent = false, 
        bool doubleSpaced = false, bool colored = false) 
        : base(name, pages, material, isUrgent)
    {
        DoubleSpaced = doubleSpaced;
        Colored = colored;
    }

    public override double CalculateCost(double baseMarkup = 1.0, bool includeShipping = false)
    {
        double baseCost = base.CalculateCost(baseMarkup, includeShipping);
        
        if (Pages > 100)
        {
            baseCost *= 0.9;
        }
        
        if (DoubleSpaced)
        {
            baseCost *= 1.1;
        }
        
        if (Colored)
        {
            baseCost *= 1.25;
        }
        
        return baseCost;
    }
}