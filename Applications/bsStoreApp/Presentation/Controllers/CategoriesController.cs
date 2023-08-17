using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController:ControllerBase
    {
        private readonly IServiceManager _services;

        public CategoriesController(IServiceManager services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _services
                .CategoryService
                .GetAllCategoriesAsync(false));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryById([FromRoute]int id)
        {
            return Ok(await _services
                .CategoryService
                .GetOneCategoryByIdAsync(id,false));
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody]Category category)
        {
            var categories= await _services.CategoryService.CreateCategoryAsync(category);
            return StatusCode(201,categories);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody]Category category)
        {
            if (category is null)
                return BadRequest(); //400
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422
            await _services.CategoryService.UpdateCategoryAsync(id,category,false);
            return NoContent(); //204
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            await _services.CategoryService.DeleteCategoryAsync(id,false);
            return NoContent(); //204
        }
    }
}
