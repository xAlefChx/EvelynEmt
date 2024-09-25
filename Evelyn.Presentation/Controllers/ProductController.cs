using Evelyn.Application.Interfaces;
using Evelyn.Application.Requests.ProductRequests;
using Evelyn.Application.Requests.ProjectRequests;
using Evelyn.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace Evelyn.Application.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductServices _productServices;

        public ProductController (IProductServices productServices)
        {
            _productServices = productServices;
        }


        [HttpGet  (nameof(GetProductById))]
        public async Task<IActionResult> GetProductById(int productid)
        {
            var product = await _productServices.GetProductByIdAsync(productid);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost(nameof(CreateProduct))]
        public async Task<IActionResult> CreateProduct(AddProductRequest product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newProduct = await _productServices.CreateProductAsync(product);
            return CreatedAtAction(nameof(CreateProduct), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{productid}" + nameof(UpdateProductAsync))]
        public async Task<IActionResult> UpdateProductAsync(int productid, UpdateProductRequest request)
        {
            try
            {
                var updatedProduct = await _productServices.UpdateProductAsync(productid, request);
                return Ok(updatedProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _productServices.GetProductByIdAsync(productid) == null)
                {
                    return NotFound();
                }

                throw;
            }
        }

        [HttpDelete("{id}" + nameof(DeleteProductAsync))]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            var result = await _productServices.DeleteProductAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}