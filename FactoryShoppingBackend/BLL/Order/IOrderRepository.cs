using DataAccessLayer.FactoryShoppingModel;
using FactoryShopping.Models.FactoryShoppingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryShopping.Domain.Order
{
    public interface IOrderRepository
    {
        bool saveorders(OrderDetails order);

        OrderDetails getOrdersByUserId(User UserId); // get by user id
    }
}
