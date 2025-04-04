namespace Internship.PrintJobs;

public class DocumentPrint : PrintJob
{
    public DocumentPrint(string name, int pages, PrintMaterial material) 
        : base(name, pages, material)
    {
    }

    public override double CalculateCost()
    {
        double baseCost = base.CalculateCost();
        return Pages > 100 ? baseCost * 0.9 : baseCost;
    }
}