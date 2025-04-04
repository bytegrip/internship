using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class DocumentPrint(string name, int pages, PrintMaterial material) : PrintJob(name, pages, material)
{
    public override double CalculateCost()
    {
        var baseCost = base.CalculateCost();
        return Pages > 100 ? baseCost * 0.9 : baseCost;
    }
}