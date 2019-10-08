using DataAccessLayer.FactoryShoppingModel;
using DataContext;
using System.Collections.Generic;
using System.Linq;

namespace BLL.CartFuntionality
{
    public class CartSevice : ICartRepository
    {
        private readonly FactoryShoppingDataContext _cartcontext;
        public CartSevice(FactoryShoppingDataContext cartcontext)
        {
            _cartcontext = cartcontext;
        }

        public bool AddToCart(Cart cart)
        {
            var existingCart = GetCartByProductId(cart.PId, cart.UserId);
            if (existingCart == null)
            {
                _cartcontext.cart.Add(cart);
                _cartcontext.SaveChanges();
            }
            else
            {
                existingCart.OrderQuantity = existingCart.OrderQuantity + cart.OrderQuantity;
                existingCart.Amount = existingCart.Price * existingCart.OrderQuantity;
                UpdateCart(existingCart);
            }

            return true;
        }

        public void DeleteCart(int cartId)
        {
            _cartcontext.cart.Remove(GetCart(cartId));
            _cartcontext.SaveChanges();
        }

        public Cart GetCart(int cartId)
        {
            return _cartcontext.cart.Find(cartId);
        }

        public void EmptyCart(int userId)
        {
            //Delete all rows associted to userId
            var carts = GetCarts(userId);

            _cartcontext.cart.RemoveRange(carts);
            _cartcontext.SaveChanges();
        }

        public IEnumerable<Cart> GetCarts(int userId)
        {
            return _cartcontext.cart.Where(c => c.UserId == userId);
        }

        public void UpdateQuantityToCart(int cartId, int quantity)
        {
            Cart cart = GetCart(cartId);
            cart.OrderQuantity = quantity;
            cart.Amount = cart.Price * cart.OrderQuantity;
            UpdateCart(cart);
        }

        public void UpdateCart(Cart cart)
        {
            _cartcontext.cart.Update(cart);
            _cartcontext.SaveChanges();
        }

        public Cart GetCartByProductId(int productId, int userId)
        {
            return _cartcontext.cart.SingleOrDefault(c => c.UserId == userId && c.PId == productId);
        }










        //public bool AddToCart(Cart newCartItem)
        //{
        //    var prod = _cartcontext.Products.Where(u => u.PId == newCartItem.PId).FirstOrDefault();
        //    var valid = _cartcontext.cart.Where(u => u.PId == newCartItem.PId && u.UserId == newCartItem.UserId).FirstOrDefault();
        //    var quantity = prod.Quantity;
        //    if (quantity > newCartItem.OrderQuantity)
        //    {
        //        if (valid == null)
        //        {
        //            _cartcontext.cart.Add(newCartItem);
        //            valid.ProductName = prod.Name;
        //            valid.ProductImage = prod.ImagePath;
        //            valid.Price = prod.Price;
        //            valid.Amount = valid.OrderQuantity * prod.Price;
        //            _cartcontext.SaveChanges();
        //            return true;
        //        }
        //        else // if cart alredy has any item
        //        {
        //            valid.OrderQuantity = valid.OrderQuantity + newCartItem.OrderQuantity;
        //            valid.Amount = valid.Amount + (valid.Price * newCartItem.OrderQuantity);
        //            _cartcontext.SaveChanges();
        //            return true;
        //        }
        //    }
        //    else
        //        return false;
        //}

        //public void DeleteCartitem(Cart erase) //delte entire row from table
        //{
        //    var check = _cartcontext.cart.Where(p => p.PId == erase.PId && p.UserId == erase.UserId).FirstOrDefault();
        //    _cartcontext.Entry(check).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //    _cartcontext.SaveChanges();      

        //}

        //public IEnumerable<Cart> GetCartValue(Cart model)
        //{
        //    var cartdata = _cartcontext.cart.Where(c => c.UserId == model.UserId);
        //    return cartdata;

        //}

        //public bool RemoveCart(Cart item)
        //{
        //    var dltitem = _cartcontext.cart.Where(p => p.PId == item.PId && p.UserId == item.UserId).FirstOrDefault();
        //    if (dltitem.OrderQuantity == 1)// only one product in cart
        //    {
        //        _cartcontext.Entry(dltitem).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        //        _cartcontext.SaveChanges();
        //        return true;
        //    }
        //    else if (dltitem.OrderQuantity > 1) //more than one quantity selected
        //    {
        //        dltitem.OrderQuantity = dltitem.OrderQuantity - item.OrderQuantity;
        //        dltitem.Amount -= (dltitem.Price * item.OrderQuantity);
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public decimal TotalCartAmount(Cart cart)
        //{
        //    decimal tamt = 0;
        //    var total = from val in _cartcontext.cart where val.UserId == cart.UserId select val;
        //    foreach (var item in total)
        //    {
        //        tamt = tamt + item.CartTotal;
        //    }
        //    return tamt;
        //}
    }
}



















//            var prod = _cartcontext.Products.Where(u => u.PId == newCartItem.PId).FirstOrDefault();
//            var valid = _cartcontext.cart.Where(u => u.PId == newCartItem.PId && u.UserId == newCartItem.UserId).FirstOrDefault();

//            if (valid == null)
//            {
//                newCartItem.Price = newCartItem.OrderQuantity * prod.Price;

//                try
//                {
//                    _cartcontext.cart.Add(newCartItem);
//                    _cartcontext.SaveChanges();

//                    CartModel obj = new CartModel
//                    {
//                        Name = prod.Name,
//                        ImagePath = prod.ImagePath,
//                        Price = prod.Price,
//                        OrderQuantity = newCartItem.OrderQuantity,
//                        Amount = prod.Price * newCartItem.OrderQuantity;
//                }
//                }

//                }

//                }
//                catch (NullReferenceException ex)
//                {
//                    throw ex;
//                }
//                return obj;
//            }
//            else if(valid != null)
//            {
//                valid.OrderQuantity += newCartItem.OrderQuantity;
//                valid.Amount = valid.Amount + (newCartItem.OrderQuantity * valid.Price);
//                _cartcontext.SaveChanges();
//                return true;
//            }
//            else
//                return false;
//        }





//        public bool updateQty(Cart updateCart)
//        {
//            var valid = _cartcontext.cart.Where(u => u.PId == updateCart.PId && u.UserId == updateCart.UserId).FirstOrDefault();
//            if (valid!=null)
//            {
//                valid.OrderQuantity += updateCart.OrderQuantity;
//                valid.Amount = valid.Amount - (updateCart.OrderQuantity * valid.Price);
//                _cartcontext.SaveChanges();
//                return true;
//            }
//            else
//                return false;
//        }

//        public bool deleteCartitem(CartModel cart)
//        {
//            if (checkvaliduser(cart))
//            {
//                try
//                {
//                    var cartrmv = _cartcontext.cart.Where(x => x.UserId==cart.UserId && x.PId==cart.PId).FirstOrDefault();
//                    _cartcontext.cart.Remove(cartrmv);
//                    _cartcontext.SaveChanges();
//                }
//                catch (Exception ex)
//                {
//                    throw ex;
//                }
//                return true;
//            }
//            else
//            {
//                return false;
//            }

//        }
//        public bool checkvaliduser(CartModel cart)
//        {
//            var checkid = _cartcontext.Users.Where(i => i.UserId == cart.UserId).FirstOrDefault();
//            if (checkid == null)
//                return false;
//            else
//                return true;
//        }


//    }
//}

//var cartitem = _cartcontext.cart.Where(c => c.CartId == newCartItem.CartId).FirstOrDefault();

//var data = from prod_img in _cartcontext.Products
//           join cart_val in _cartcontext.cart
//           on prod_img.PId equals cart_val.PId
//           where cart_val.UserId == cartitem.UserId
//           select new
//           {
//               productName=prod_img.Name,
//               productImage=prod_img.ImagePath
//           };

//cartitem.Price = prod.Price;
//cartitem.Amount = cartitem.Price * cartitem.OrderQuantity;                    
//_cartcontext.SaveChanges();