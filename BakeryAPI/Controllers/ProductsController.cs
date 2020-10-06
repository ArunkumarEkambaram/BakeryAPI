using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BakeryAPI.Models;

namespace BakeryAPI.Controllers
{
    [RoutePrefix("api/Bakery")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private BakeryAppEntities _bakeryApp = null;

        public ProductsController()
        {
            _bakeryApp = new BakeryAppEntities();
        }


        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<Product> GetProducts()
        {
            return _bakeryApp.Products.ToList();
        }

        [HttpPost]
        [Route("AddNew")]
        public void AddNewProduct([FromBody] Product product)
        {
            try
            {
                _bakeryApp.Products.Add(product);
                _bakeryApp.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
