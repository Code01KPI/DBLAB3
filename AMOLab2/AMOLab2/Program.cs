using System.Diagnostics;
using AMOLab2;

Methods methods = new Methods();

Stopwatch stopwatch;
int item;
string? strItem;

while (true)
{
    Console.WriteLine("1. Method 4 - QR factorization");
    Console.WriteLine("Choose menu item: "); 
    strItem = Console.ReadLine();
    if (strItem is null || !int.TryParse(strItem, out item))
        throw new ArgumentNullException("Tou entered invalid menu item!", nameof(item));

    switch (item)
    {
        case 1:
            break;
        default:
            Console.WriteLine("There isn't such menu item!");
            break;
    }
}
