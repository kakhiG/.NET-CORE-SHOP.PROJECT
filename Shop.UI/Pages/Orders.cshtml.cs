using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop.Application.Orders;
using Shop.Database;

namespace Shop.UI.Pages
{
    public class OrderModel : PageModel
    {

        public GetOrder.Response Order { get; set; }

        public void OnGet(
            string reference,
            [FromServices] GetOrder getOrder)
        {
            Order = getOrder.Do(reference);
        }
    }
}