using DataAccessLayer.FactoryShoppingModel;
using DataContext;
using FactoryShopping.Models.FactoryShoppingModel;
using System;
using System.Linq;

namespace FactoryShopping.Domain.Order
{
    public class OrderService : IOrderRepository
    {
        private readonly FactoryShoppingDataContext _ocontext;

        public OrderService(FactoryShoppingDataContext ocontext)
        {
            _ocontext = ocontext;
        }

        public OrderDetails getOrdersByUserId(User UserId)
        {
            return _ocontext.myOrders.Find(UserId);
        }

        public bool saveorders(OrderDetails order)
        {
            try
            {
                var addOrder = _ocontext.cart.Where(o => o.UserId == order.UserId).FirstOrDefault();
                var product = _ocontext.Products.Where(p => p.PId == order.PId).FirstOrDefault();
                order.Price = addOrder.Price;
                order.OrderedQuantity = addOrder.OrderQuantity;
                order.PId = addOrder.PId;
                var productName = product.Name;
                _ocontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }    
    }
}
