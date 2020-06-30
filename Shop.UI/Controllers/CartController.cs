﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Cart;

namespace Shop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne(int stockId, [FromServices] AddToCart addToCart)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };
            var success = await addToCart.Do(request);
            if (success)
            {
                return Ok("Item added to cart");
            }

            return BadRequest("Failed to add to cart");
        }

        public async Task<IActionResult> RemoveOne(int stockId, [FromServices] RemoveFromCart removeFromCart)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var success = await removeFromCart.Do(request);
            if (success)
            {
                return Ok("Item removed from cart");
            }

            return BadRequest("Failed to remove item from cart");
        }
        public async Task<IActionResult> RemoveAll(int stockId, [FromServices] RemoveFromCart removeFromCart)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                All = true
            };

            var success = await removeFromCart.Do(request);
            if (success)
            {
                return Ok("Item removed all from cart");
            }

            return BadRequest("Failed to remove all item from cart");
        }
    }
}
