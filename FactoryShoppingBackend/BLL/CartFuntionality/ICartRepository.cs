using DataAccessLayer.FactoryShoppingModel;
using System.Collections.Generic;

namespace BLL.CartFuntionality
{
    public interface ICartRepository
    {
        bool AddToCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(int cartId);
        void EmptyCart(int userId);
        Cart GetCart(int userId);
        Cart GetCartByProductId(int productId, int userId);
        void UpdateQuantityToCart(int cartId, int quantity);
        IEnumerable<Cart> GetCarts(int userId);
    }
}
