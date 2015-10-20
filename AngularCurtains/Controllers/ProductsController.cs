using BusinessEntities;
using BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularCurtains.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductServices _productServices;
        public ProductsController()
        {
            _productServices = new ProductServices();
        }
        // GET: api/Products
        public IEnumerable<ProductEntity> Get()
        {
            var products = _productServices.GetAllProducts();
            //return new string[] { "value1", "value2" };
            return products.ToList();
        }

        public IEnumerable<string> Get1()
        {
          
            return new string[] { "value1", "value2" };
            
        }

        // GET: api/Products/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
