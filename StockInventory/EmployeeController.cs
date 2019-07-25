using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stock.Web.Data;
using Stock.Web.Data.Repository;

namespace EFCoreCodeFirstSample.Controllers
{
    [Route("api/batch")]
    //[ApiController]
    public class ProductStockController : ControllerBase
    {
        private readonly IDataRepository<ProductStock> _dataRepository;

        public ProductStockController(IDataRepository<ProductStock> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/productstock
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<ProductStock> employees = _dataRepository.GetAll();
            return Ok(employees);
        }

        // GET: api/ProductStock/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            ProductStock ProductStock = _dataRepository.Get(id);

            if (ProductStock == null)
            {
                return NotFound("The ProductStock record couldn't be found.");
            }

            return Ok(ProductStock);
        }

        // POST: api/ProductStock
        [HttpPost]
        public IActionResult Post([FromBody] ProductStock ProductStock)
        {
            if (ProductStock == null)
            {
                return BadRequest("ProductStock is null.");
            }

            _dataRepository.Add(ProductStock);
            return CreatedAtRoute(
                  "Get",
                  new { Id = ProductStock.ProductStockID },
                  ProductStock);
        }

        // PUT: api/ProductStock/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductStock ProductStock)
        {
            if (ProductStock == null)
            {
                return BadRequest("ProductStock is null.");
            }

            ProductStock employeeToUpdate = _dataRepository.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The ProductStock record couldn't be found.");
            }

            _dataRepository.Update(employeeToUpdate, ProductStock);
            return NoContent();
        }

        // DELETE: api/ProductStock/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            ProductStock stock = _dataRepository.Get(id);
            if (stock == null)
            {
                return NotFound("The Stock record couldn't be found.");
            }

            _dataRepository.Delete(stock);
            return NoContent();
        }
    }
}