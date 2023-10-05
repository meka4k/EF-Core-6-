using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst.DAL;
using UdemyEFCore.CodeFirst.DTOs;
using UdemyEFCore.CodeFirst.Mappers;


using(var context = new AppDbContext())
{
    using(var transaction= context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
    {
        var product = context.Products.First();
        product.Price = 2000;
        context.SaveChanges();

        transaction.Commit();
    }
}

