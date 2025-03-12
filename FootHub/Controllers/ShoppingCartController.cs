using FootHub.Models.DataBase;
using FootHub.Models.Entitites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;


namespace FootHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : Controller
    {
        private readonly FootHubDBContext dbContext;
        public ShoppingCartController(FootHubDBContext dBContext)
        {
            this.dbContext = dbContext;
        }

        [HttpDelete]
        public IActionResult RemoveFromCart(int id)
        {
            var shoeToDelete = dbContext.ShoppingCarts.Find(id);
            if (shoeToDelete != null)
            {
                return NotFound();
            }
            dbContext.ShoppingCarts.Remove(shoeToDelete);
            dbContext.SaveChanges();

            return Ok();
        }
        [HttpGet]
        public IActionResult SumOfCart(int userId)
        {

            decimal sum = dbContext.ShoppingCarts
                .Include(x => x.Shoe)
                .Where(x => x.UserId == userId)
                .Sum(x => x.Shoe.ShoePrice * x.Quantity);

            if (sum == 0)
                return Ok("You haven't added anything in the cart!");
            else
                return Ok(sum);
        }
        [HttpGet]
        public IActionResult AddToCart(int shoeId, int userId)
        {
            var entry = dbContext.Shoes
                .FirstOrDefault(x => x.Id == shoeId);
            if (entry == null)
                return NotFound("The shoe that you have chosen is unfortunately out of stock!");

            var existingItem = dbContext.ShoppingCarts
                .FirstOrDefault(x => x.ShoeId == shoeId && x.UserId == userId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
                dbContext.Update(existingItem);
            }
            else
            {
                var cart = new ShoppingCart
                {
                    UserId = userId,
                    ShoeId = shoeId,
                    Quantity = 1

                };
                dbContext.ShoppingCarts.Add(cart);
            };
            dbContext.SaveChanges();
            return Ok("The shoe has been successfully added to the cart!");

        }
        [HttpGet]
        public IActionResult GetCartItems(int userId)
        {
            var allShoesInShoppingCart = dbContext.ShoppingCarts
                .Include(x => x.Shoe)
                .Where(x => x.UserId == userId)
                .ToList();
            if (allShoesInShoppingCart == null)
            {
               return NotFound("Your shopping cart is empty!");
            }
            else
                return Ok(allShoesInShoppingCart);
        }
        [HttpGet]
        public IActionResult IncrementShoeCount(int shoeId, int userId)
        {
            var entry = dbContext.ShoppingCarts
                .FirstOrDefault(x => x.UserId == userId && x.ShoeId == shoeId);

            if (entry != null)
            {
                entry.Quantity++;
            }
            else
            {
                return NotFound();
            }
            dbContext.Update(entry);
            dbContext.SaveChanges();
            return Ok();
        }
        [HttpGet]
        public IActionResult DeleteFromDataBase(int userId)
        {
            var entries = dbContext.ShoppingCarts
                .Where(x => x.UserId == userId)
                .ToList();
            if (!entries.Any())
            {
                return Ok("Your shopping cart is already empty!");
            }

            dbContext.ShoppingCarts.RemoveRange(entries);
            dbContext.SaveChanges();

            return Ok("You've successfully made you're purchase!");

        }
        [HttpGet]
        public IActionResult SearchShoesInCart(int userId, string shoeName)
        {
            var cartItems = dbContext.ShoppingCarts
                .Include(x => x.Shoe)
                .Where(x => x.UserId == userId && x.Shoe.ShoeName.Contains(shoeName))
                .ToList();

            if (!cartItems.Any())
            {
                return NotFound("No shoes matching that name were found in your cart.");
            }

            return Ok(cartItems);
        }

    }
}
