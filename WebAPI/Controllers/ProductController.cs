using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BussinessLayer.BussinessUtil;
using BussinessLayer.Models;
namespace WebAPI.Controllers
{
   // [Route("api/[controller]")]
    //[Route("api/[controller]")]
    public class ProductController : ApiController
    {
        private ProductUtility productUtility;
        public ProductController()
        {
            productUtility = new ProductUtility();
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        
        [HttpPost]
        // POST api/<controller>
        public async  Task<ServiceResponse<object>> PostProduct([FromBody] Product product)
        {
            ServiceResponse<object> serviceResponse = new ServiceResponse<object>();
            product = new Product { ProductName = "Rahul", ProductDescription = "Demoo" };
             await productUtility.AddProduct(product);
            return serviceResponse;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}