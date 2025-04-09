using Internship.Management;
using Internship.PrintJobs;
using Internship.PrintMaterials;

var printhouse = new Printhouse("Printhouse Incorporated", 3)
{
    DefaultMarkup = 1.3,
    AcceptsUrgentJobs = true
};

var standardPaper = new Paper(MaterialTypes.Standard, PaperSize.A4, 0.1);
var premiumPaper = new Paper(MaterialTypes.Premium, PaperSize.A2, 0.2, doubleSided: true);
var glossyCanvas = new Canvas(MaterialTypes.Glossy, PaperSize.A4, 2.5, stretchedFrame: true);
var matteVinyl = new Vinyl(MaterialTypes.Matte, PaperSize.Letter, 3.0);

var document = new DocumentPrint("Annual Report", 35, premiumPaper, doubleSpaced: true, colored: true);
var poster = new PosterPrint("Marketing Campaign", 1, glossyCanvas, laminated: true, highResolution: true);
var banner = new BannerPrint("Grand Opening", matteVinyl, width: 2.0, height: 1.0, grommets: true);
var urgentFlyers = new DocumentPrint("Event Flyers", 100, standardPaper, isUrgent: true);

printhouse.AddPrintJob(document);
printhouse.AddPrintJob(poster);
printhouse.AddPrintJob(banner);
printhouse.AddPrintJob(urgentFlyers);

printhouse.AddCustomerDiscount("Regular Client", 0.1);
printhouse.AddCustomerDiscount("VIP Client", 0.2);

Console.WriteLine($"Printhouse: {printhouse.Name}");
Console.WriteLine($"Active printers: {printhouse.ActivePrinters}");
Console.WriteLine($"Total print jobs: {printhouse.PrintJobCount}");
Console.WriteLine($"Accepts urgent jobs: {printhouse.AcceptsUrgentJobs}");
Console.WriteLine();

Console.WriteLine("Print Jobs:");
foreach (var job in printhouse)
{
    Console.WriteLine($"- {job.Name} ({job.GetType().Name})");
    Console.WriteLine($"  Pages: {job.Pages}");
    Console.WriteLine($"  Material: {job.Material.Type} {job.Material.Size}");
    
    if (job is DocumentPrint docPrint)
    {
        Console.WriteLine($"  Double Spaced: {docPrint.DoubleSpaced}");
        Console.WriteLine($"  Colored: {docPrint.Colored}");
    }
    else if (job is PosterPrint posterPrint)
    {
        Console.WriteLine($"  Laminated: {posterPrint.Laminated}");
        Console.WriteLine($"  High Resolution: {posterPrint.HighResolution}");
    }
    else if (job is BannerPrint bannerPrint)
    {
        Console.WriteLine($"  Dimensions: {bannerPrint.Width}m x {bannerPrint.Height}m");
        Console.WriteLine($"  Grommets: {bannerPrint.Grommets}");
    }
    
    var urgentJob = job as PrintJob;
    if (urgentJob != null && urgentJob.IsUrgent)
    {
        Console.WriteLine($"  URGENT JOB");
    }
    
    Console.WriteLine($"  Base Cost: ${job.CalculateCost():F2}");
    Console.WriteLine($"  Cost with Shipping: ${job.CalculateCost(includeShipping: true):F2}");
    Console.WriteLine();
}

Console.WriteLine($"Total cost: ${printhouse.CalculateTotalCost():F2}");
Console.WriteLine($"Total cost with shipping: ${printhouse.CalculateTotalCost(includeShipping: true):F2}");
Console.WriteLine($"10% Discounted cost: ${printhouse.CalculateTotalCost(discount: 0.1):F2}");
Console.WriteLine($"Regular Client cost: ${printhouse.CalculateTotalCost(printhouse.GetCustomerDiscount("Regular Client")):F2}");
Console.WriteLine($"VIP Client cost: ${printhouse.CalculateTotalCost(printhouse.GetCustomerDiscount("VIP Client")):F2}");
Console.WriteLine();

Console.WriteLine("Print job details:");
var posterJobs = printhouse.GetJobsByType(typeof(PosterPrint));
foreach (var job in posterJobs)
{
    Console.WriteLine($"  - {job.Name} (PosterPrint)");
}

Console.WriteLine("\nCompleting jobs:");
if (printhouse.CompletePrintJob("Event Flyers"))
{
    Console.WriteLine("  Completed: Event Flyers");
}

Console.WriteLine("\nPending jobs:");
foreach (var job in printhouse.GetPendingJobs())
{
    Console.WriteLine($"  - {job.Name}");
}

var clonedPrinthouse = (Printhouse)printhouse.Clone();
Console.WriteLine($"\nCloned printhouse: {clonedPrinthouse.Name}");
Console.WriteLine($"Cloned jobs count: {clonedPrinthouse.PrintJobCount}");

printhouse.UpdateActivePrinters(4, redistributeJobs: true);
Console.WriteLine($"\nNew printer count: {printhouse.ActivePrinters}");