using Microsoft.AspNetCore.Mvc;
using ProyectoACSyDBAR.Data.Models;
using ProyectoACSyDBAR.Data.Repository.Interfaces;
using ProyectoACSyDBAR.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoACSyDBAR.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //// GET: api/<ProductsController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ProductsController>/5

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var data = _productRepository.GetAllProductosAsync().Result;

            if (data == null)
            {
                return BadRequest("el producto no existe");
            }

            var response = _productRepository.DeleteProductoAsync(id).Result;

            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var response = _productRepository.GetAllProductosAsync().Result;
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var response = _productRepository.GetProductoByIdAsync(id).Result;
            return Ok(response);
        }

        //// POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDTO request)
        {
            var newProduct = new Producto
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Category = request.Category

            };

            _productRepository.CreateProductoAsync(newProduct).Wait();

            return Ok(true);
        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody] UpdateProductoDTO request)
        {
            var data = _productRepository.GetProductoByIdAsync(id).Result;

            if (data == null)
            {
                return BadRequest("el producto no existe");
            }

            data.Name = request.Name;
            data.Description = request.Description;
            data.Price = request.Price;
            data.Stock = request.Stock;
            data.Category = request.Category;

            var response = _productRepository.UpdateProductoAsync(id, data).Result;

            return Ok(response);
        }
    }
}

    //// PUT api/<ProductsController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] string value)
    //{
    //}

    //// DELETE api/<ProductsController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}


