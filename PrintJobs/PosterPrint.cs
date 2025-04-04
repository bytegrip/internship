using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public class PosterPrint : PrintJob
{
    private bool laminated;

    public bool Laminated 
    { 
        get { return laminated; } 
        set { laminated = value; } 
    }

    public PosterPrint(string name, int pages, PrintMaterial material, bool laminated) 
        : base(name, pages, material)
    {
        this.laminated = laminated;
    }

    public override double CalculateCost()
    {
        double baseCost = base.CalculateCost();
        return laminated ? baseCost * 1.25 : baseCost;
    }
}