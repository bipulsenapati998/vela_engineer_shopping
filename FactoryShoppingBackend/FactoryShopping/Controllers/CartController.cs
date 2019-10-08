using BLL.CartFuntionality;
using DataAccessLayer.FactoryShoppingModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FactoryShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository cartService;

        public CartController(ICartRepository _cartService)
        {
            cartService = _cartService;
        }
        //  GET: api/Cart
        [HttpGet("{userId}")]
        public IEnumerable<Cart> List(int userId)
        {
            return cartService.GetCarts(userId);
        }

        // POST: api/Cart/addtobag
        [HttpPost("addtobag")]
        public bool AddToCart([FromBody] Cart value) // add data to bag
        {
            value.Amount = value.Price * value.OrderQuantity;
            value.CartDate = DateTime.Now.ToUniversalTime();
            return cartService.AddToCart(value);
        }
        //  GET: api/Cart
        [HttpGet("getcartbyproductid")]
        public Cart GetCartByProductId(int productId, int userId)
        {
            return cartService.GetCartByProductId(productId, userId);
        }

        // Delete: api/Cart/deleteFromCart
        [HttpDelete("deleteFromCart/{cartId}")]
        public void DeleteRowCart([FromRoute]int cartId) // delete row in a cart 
        {
            cartService.DeleteCart(cartId);
        }

        //Delete: api/Cart/deletebyqty
        [HttpDelete("emptycart/{userId}")]
        public bool EmptyCart([FromRoute]int userId)// delete by quantity
        {
            cartService.EmptyCart(userId);
            return true;
        }

        //POST: api/Cart/totalamtinCart
        [HttpGet("updatequantitytocart/{cartId}/{quantity}")]
        public void UpdateQuantityToCart([FromRoute] int cartId, [FromRoute] int quantity) //add total amount in cart
        {
            cartService.UpdateQuantityToCart(cartId, quantity);
        }

    }
}
