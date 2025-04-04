using Internship;
using Internship.PrintJobs;
using Internship.PrintMaterials;

var printhouse = new Printhouse("Printhouse Incorporated", 3);
            
var paper = new Paper("Glossy", "A4", 0.2);
var canvas = new Canvas("Premium", "A2", 2.5);
            
var document = new DocumentPrint("Annual Report", 35, paper);
var poster = new PosterPrint("Marketing Campaign", 1, canvas, true);
            
printhouse.AddPrintJob(document);
printhouse.AddPrintJob(poster);
            
Console.WriteLine($"Printhouse: {printhouse.Name}");
Console.WriteLine($"Active printers: {printhouse.ActivePrinters}");
Console.WriteLine($"Total print jobs: {printhouse.PrintJobCount}");
Console.WriteLine();
            
Console.WriteLine("Print Jobs:");
foreach (var job in printhouse)
{
    Console.WriteLine($"- {job.Name} ({job.GetType().Name})");
    Console.WriteLine($"  Pages: {job.Pages}");
    Console.WriteLine($"  Material: {job.Material.Type} {job.Material.Size}");
    Console.WriteLine($"  Cost: ${job.CalculateCost():F2}");
    Console.WriteLine();
}
         
Console.WriteLine($"Total cost: ${printhouse.CalculateTotalCost():F2}");
Console.WriteLine($"10% Discounted cost: ${printhouse.CalculateTotalCost(0.1):F2}");
            
var clonedPrinthouse = (Printhouse)printhouse.Clone();
Console.WriteLine($"Cloned printhouse: {clonedPrinthouse.Name}");
Console.WriteLine($"Cloned jobs count: {clonedPrinthouse.PrintJobCount}");