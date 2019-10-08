using DataAccessLayer.FactoryShoppingModel;
using System.Collections.Generic;

namespace BLL.ProductLayer
{
    public interface IProductRepository
    {
        List<Product> getallproduct();
        Product getProductById(int id); // get by id

        bool saveProduct(Product newproduct); //post  

        bool deleteProductById(int id); //Delete user by id 

        bool updateProduct(Product newproduct); //put
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}
