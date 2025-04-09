using Internship.PrintMaterials;

namespace Internship.PrintJobs;

public abstract class PrintJob(string name, int pages, PrintMaterial material, bool isUrgent = false)
{
    public string Name { get; } = name;
    public int Pages { get; } = pages > 0 ? pages : 1;
    public PrintMaterial Material { get; private set; } = material;
    public bool IsUrgent { get; set; } = isUrgent;
    public DateTime CreatedAt { get; } = DateTime.Now;
    public DateTime? CompletedAt { get; private set; }

    public virtual double CalculateCost(double baseMarkup = 1.0, bool includeShipping = false)
    {
        double materialCost = Material.CalculateCost(Pages);
        double urgentFee = IsUrgent ? materialCost * 0.25 : 0;
        double totalCost = (materialCost + urgentFee) * baseMarkup;
        
        if (includeShipping)
        {
            totalCost += Material.GetShippingCost(Pages);
        }
        
        return totalCost;
    }
    
    public bool ChangeMaterial(PrintMaterial newMaterial)
    {
        if (CompletedAt != null)
        {
            return false;
        }
        
        Material = newMaterial;
        return true;
    }
    
    public void MarkAsCompleted()
    {
        CompletedAt = DateTime.Now;
    }
}