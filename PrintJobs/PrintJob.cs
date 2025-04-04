using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public abstract class PrintJob(string name, int pages, PrintMaterial material)
{
    public string Name { get; } = name;

    public int Pages { get; } = pages > 0 ? pages : 1;

    public PrintMaterial Material { get; } = material;

    public virtual double CalculateCost()
    {
        return Material.CalculateCost(Pages);
    }
}