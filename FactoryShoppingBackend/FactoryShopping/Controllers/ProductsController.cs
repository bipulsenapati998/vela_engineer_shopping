using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.FactoryShoppingModel;
using BLL.ProductLayer;
using Microsoft.AspNetCore.Authorization;

namespace FactoryShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository ProductService;

        public ProductsController(IProductRepository _ProductService)
        {
            ProductService = _ProductService;
        }

        // GET: api/Products
        [HttpGet]
        public IList<Product> Getproduct()
        {
            return  ProductService.getallproduct();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
           return ProductService.getProductById(id);
            
        }

        // PUT: api/Products/5
        [HttpPut]
        [Authorize(Roles = "1")]
        public bool PutProduct(Product product)
        {
            return ProductService.updateProduct(product);
        }

      

        // POST: api/Products
        [HttpPost]
        [Authorize(Roles = "1")]
        public bool PostProduct(Product product)
        {
             return ProductService.saveProduct(product);
            //return CreatedAtAction("GetProduct", new { id = product.PId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "1")]
        public bool DeleteProduct(int id)
        {
            return ProductService.deleteProductById(id);
        }
     

        [HttpGet("getproductsbycategoryid/{id}")]
        public IActionResult GetProductByCategoryId(int id)
        {
            var res = ProductService.GetProductsByCategoryId(id);
            return Ok(res);
        }
                          
    }
}
