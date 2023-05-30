using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N_Tier.BusinessLogic.Abstractions;
using N_Tire.BusinessLogic.Models.DTO.Product;
using System.Threading.Tasks;

namespace N_Tire.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsLogics _logic;
        public ProductController(IProductsLogics logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _logic.ProductList());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductUIDTO p)
        {
            if (ModelState.IsValid)
            {
                bool product = await _logic.AddProduct(p);
                if (product)
                {
                    return Ok("Successfully");
                }
                else
                {
                    return BadRequest("Unsuccessfully");
                }
            }
            else
            {
                return BadRequest("Unsuccessfully");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductUIDTO p)
        {
            if (ModelState.IsValid)
            {
                bool product = await _logic.UpdateProduct(p);
                if (product)
                {
                    return Ok("Successfully");
                }
                else
                {
                    return BadRequest("Unsuccessfully");
                }
            }
            else
            {
                return BadRequest("Unsuccessfully");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetProductById(int id)
        {
            return Ok(await _logic.ProductById(id));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(DeleteProductUIDTO p)
        {
            if (ModelState.IsValid)
            {
                bool product = await _logic.Deleteproduct(p);
                if (product)
                {
                    return Ok("Successfully");
                }
                else
                {
                    return BadRequest("Unsuccessfully");
                }
            }
            else
            {
                return BadRequest("Unsuccessfully");
            }
        }

    }
}
