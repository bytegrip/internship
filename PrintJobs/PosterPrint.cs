using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class PosterPrint(string name, int pages, PrintMaterial material, bool laminated)
    : PrintJob(name, pages, material)
{
    private bool Laminated { get; } = laminated;

    public override double CalculateCost()
    {
        var baseCost = base.CalculateCost();
        return Laminated ? baseCost * 1.25 : baseCost;
    }
}