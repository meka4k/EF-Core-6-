using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Controllers
{
    public class ProductController : Controller
    {
        AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> List()
        {
            return View(await _context.Products.ToListAsync());
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            try
            {

                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            catch (DbUpdateConcurrencyException exception)
            {
                //hatalı olan exceptionun ilkini alır
                var exceptionEntry = exception.Entries.First();

                //şuanki mevcut değerler
                var currentProduct = exceptionEntry.Entity as Product;

                //exception fırlatıldığında veritabanınd hangi değerler var
                var databaseValues = exceptionEntry.GetDatabaseValues();


                //client değerleri
                var clientValues = exceptionEntry.CurrentValues;

                if (databaseValues == null)
                {
                    ModelState.AddModelError(String.Empty, "Bu ürün başka bir kullanıcı tarafından silindi");
                }
                else
                {
                    //güncel değerlerin propery olarak gelmesi
                    var databaseProduct = databaseValues.ToObject() as Product;
                    ModelState.AddModelError(String.Empty, "Bu ürün başka bir kullanıcı tarafından güncellendi");
                }

                return View(product);
            }
        }
    }
}
