using MegoStore.Application.Dtos;
using MegoStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MegoStore.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("AllCategory")]
        public async Task<IActionResult> GetAllCategoryAsync()
        {
            var result=await _categoryService.GetAllCategoryAsync();
            if(result == null)
                return NotFound("Category Not found");
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
                return NotFound("Category Not found");

            return Ok(category);
        }

        [HttpPost("AddCategory")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddCategoryAsync(CategoryDto dto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryService.AddCategoryAsync(dto);
         

            return Ok(category);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            if(id<=0)
                return BadRequest("Id not found");
            var category = await _categoryService.DeleteCategoryAsync(id);
            if (!category)
                return NotFound("Category Not found");

            return Ok("Category Deleted Successfully");
        }

            [HttpPut("{id}")]
            [Authorize (Roles ="Admin")]
            public async Task<IActionResult> UpdateCategoryAsync(CategoryDto dto,int id)
            {
                if (id <= 0)
                    return BadRequest("Id not found");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var category = await _categoryService.UpdateCategoryAsync( dto,id);
                if (category == null)
                    return NotFound("Category Not Found");

                return Ok(category);

            }
        }
    }
