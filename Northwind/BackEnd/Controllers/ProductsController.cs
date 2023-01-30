using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductsDAL productsDAL;

        #region Constructor
        public ProductsController()
        {
            productsDAL = new ProductsDALImpl(new Entities.Entities.NorthWindContext());
        }

        #endregion

        #region Consultar
        // GET: api/<ProductsController>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<Product> products = productsDAL.GetAll();


            return new JsonResult(products);
        }
                

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Product product;
            product = productsDAL.Get(id);


            return new JsonResult(product);
        }

        #endregion

        #region  Agregar
        // POST api/<ProductsController>
        [HttpPost]
        public JsonResult Post([FromBody] Product products)
        {
            productsDAL.Add(products);
            return new JsonResult(products);
        }

        #endregion

        #region Modificar
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public JsonResult Put([FromBody] Product products)
        {
            productsDAL.Update(products);
            return new JsonResult(products);
        }

        #endregion

        #region Eliminar
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            Product products = new Product { ProductId = id };
            productsDAL.Remove(products);

            return new JsonResult(products);
        }

        #endregion
    }
}
