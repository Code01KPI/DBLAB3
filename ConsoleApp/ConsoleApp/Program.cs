using ConsoleApp;


using (SchoolContext db = new SchoolContext())
{
    var authors = db.Authors.ToList();
    foreach (var author in authors)
        Console.Write($"{author.FullName} - {author.CountryOfOrigin}\n");
}







