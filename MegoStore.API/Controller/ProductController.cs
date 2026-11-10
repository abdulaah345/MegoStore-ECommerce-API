using MegoStore.Application.Dtos;
using MegoStore.Application.Interfaces;
using MegoStore.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegoStore.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("AllProduct")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await _productService.GetAllProductsAsync();
            if(result == null) 

               return NotFound("Product Not found");

            return Ok(result);

        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product=await _productService.GetByIdAsync(id);
            if (product!=null)
               return Ok(product);


            return NotFound(); 
        }
        [HttpPost("AddProduct")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> AddProductAsync([FromBody] ProductDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result=await _productService.AddProductAsync(dto);
            return Ok(result);

            
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> UpdateProductAsync([FromBody] ProductDto dto,int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (id <=0)
                return BadRequest("Id not found");

            var result = await _productService.UpdateProductAsync(dto,id);
            if (result == null)
                return NotFound("Product Not Found");

            return Ok(result);


        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteProductAsync( int id)
        {
          
            if (id <= 0)
                return BadRequest("Id not found");

            var result = await _productService.DeleteProductAsync(id);
            if (!result )
                return NotFound("Product Not Found");

            return Ok("Product Deleted Successfully");

        }

    }



    }

