namespace Internship.PrintJobs;

public abstract class PrintJob
{
    private string name;
    private int pages;
    // To Do
    // Add materials
    // Ideas: Paper? Papyrus? Canvas? Photopaper?
    private PrintMaterial material;

    public string Name 
    { 
        get { return name; } 
        set { name = value; } 
    }

    public int Pages 
    { 
        get { return pages; } 
        set { pages = value > 0 ? value : 1; } 
    }

    public PrintMaterial Material 
    { 
        get { return material; } 
        set { material = value; } 
    }

    public PrintJob(string name, int pages, PrintMaterial material)
    {
        this.name = name;
        this.pages = pages > 0 ? pages : 1;
        this.material = material;
    }

    public virtual double CalculateCost()
    {
        return Material.CalculateCost(Pages);
    }
}