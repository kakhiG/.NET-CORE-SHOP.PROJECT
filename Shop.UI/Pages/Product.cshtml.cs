using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Rewrite.Internal.ApacheModRewrite;
using Shop.Application.Cart;
using Shop.Application.Products;
using Shop.Database;
using Shop.Domain.Models;

namespace Shop.UI.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _ctx;

        public ProductModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public AddToCart.Request CartViewModel { get; set; }



        public GetProduct.ProductViewModel Product { get; set; }

        public async Task<IActionResult> OnGet(
            string name,
            [FromServices] GetProduct getProduct)
        {
            Product = await getProduct.Do(name.Replace("-", " "));
            if (Product == null)
                return RedirectToPage("Index");
            else
                return Page();
        }

        public async Task<IActionResult> OnPost([FromServices] AddToCart addToCart)
        {

            var stockAdded = await addToCart.Do(CartViewModel);

            if (stockAdded)
                return RedirectToPage("Cart");
            else
                //TODO add a warning
                return Page();
        }
    }
}