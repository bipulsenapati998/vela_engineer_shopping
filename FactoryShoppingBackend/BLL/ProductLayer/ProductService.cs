using DataAccessLayer.FactoryShoppingModel;
using DataContext;

using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL.ProductLayer
{
    public class ProductService : IProductRepository
    {
        private readonly FactoryShoppingDataContext _pcontext;
      
        public ProductService(FactoryShoppingDataContext pcontext)
        {
            _pcontext = pcontext;
        }

        public bool deleteProductById(int id)
        {
            if (checkvalid(id))
            {
                try
                {
                    var prod = _pcontext.Products.Find(id);
                    _pcontext.Products.Remove(prod);
                    _pcontext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Product> getallproduct()
        {
            return _pcontext.Products.ToList();
        }


        public Product getProductById(int id)
        {
            return _pcontext.Products.Find(id);
        }

        public bool saveProduct(Product newproduct)
        {
            try
            {
                _pcontext.Products.Add(newproduct);
                _pcontext.SaveChanges();
                return true;
            }
            catch (NotImplementedException ex)
            {
                throw ex;
            }
            // return false;
        }

        public bool updateProduct(Product newproduct)
        {
            try
            {
                var updatedprod = _pcontext.Products.Where(p => p.PId == newproduct.PId).FirstOrDefault();
                updatedprod.Name = newproduct.Name;
                updatedprod.Price = newproduct.Price;
                updatedprod.Quantity = newproduct.Quantity;
                updatedprod.Description = newproduct.Description;
                updatedprod.CategoryId = newproduct.CategoryId;
                _pcontext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool checkvalid(int id)
        {
            var checkid = _pcontext.Products.Where(i => i.PId == id).FirstOrDefault();
            if (checkid == null)
                return false;
            else
                return true;
        }


        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _pcontext.Products.Where(p => p.CategoryId == categoryId);
        }
    }
}
