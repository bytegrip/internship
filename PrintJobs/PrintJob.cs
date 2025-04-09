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

    public virtual decimal CalculateCost(decimal baseMarkup = 1.0m, bool includeShipping = false)
    {
        var materialCost = Material.CalculateCost(Pages);
        var urgentFee = IsUrgent ? materialCost * 0.25m : 0m;
        var totalCost = (materialCost + urgentFee) * baseMarkup;
        
        if (includeShipping)
        {
            totalCost += Material.GetShippingCost(Pages);
        }
        
        return totalCost;
    }

    public void MarkAsCompleted()
    {
        CompletedAt = DateTime.Now;
    }
}