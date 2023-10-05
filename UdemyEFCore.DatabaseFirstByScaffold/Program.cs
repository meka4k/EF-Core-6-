// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UdemyEFCore.DatabaseFirstByScaffold.Models;

using (var context = new UdemyEFCoreDatabaseFirstDbContext())
{
    var products = await context.Products.ToListAsync();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id} : {p.Name} - {p.Price} - {p.Stock}");
    });
}
