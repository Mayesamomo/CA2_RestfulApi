using AutoMapper;
using CrudAPI.Domain.Models;
using CrudAPI.Domain.Serrvices;
using CrudAPI.Extensions;
using CrudAPI.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        //an instance of ICategoryService is injected. Mapping the category class
    //since it is not a safe approach to expose the class object directly
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        //the constructor is invoked when a new instance of this class is created 
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        //define a http method that handles the GET request.
        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);

            return resources;
        }


        //define a http method that handles the POST request.
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

        // //define a http method that handles the PUT request.

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }

         //define a http method that handles the DELETE request.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Category);
            return Ok(categoryResource);
        }
    }
   

}
