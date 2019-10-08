using FactoryShopping.Models.FactoryShoppingModel;

namespace FactoryShopping.Domain.Order
{
    public interface IAddressRepository
    {
        bool saveAddress(Address_Checkout newAddress); //post  
    }
}
