using ASP_CORE_API.DTO;
using ASP_CORE_API.Models;
using ASP_CORE_API.Services.Categorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_CORE_API.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService; 
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            try
            {
                var list = _categoryService.FindAll();
                return Ok(new
                {
                    message = "Success",
                    data = list
                });
            }catch(Exception ex)
            {
                throw new Exception("Can not data controller " + ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return NotFound();
                }
                Category category = _categoryService.GetCategoryByid(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(new {
                    messgae = "Search Success",
                    data = category
                });
            }
            catch(Exception ex)
            {
                throw new Exception("Can not data controller " + ex);
            }
        }
        [HttpPost]
        public IActionResult Create(CategoryDTO categoryDTO)
        {
            Category category = _categoryService.Create(categoryDTO);
            return Ok(new { 
                   message = "Create Success",
                   data = category
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(Category category, int id) {
            Category categoryUpdate = _categoryService.Save(category, id);
            return Ok(new
            {
                messgae = "Update Success",
                data = categoryUpdate
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            try
            {
                if (id < 0) {
                    return NotFound();
                }
                _categoryService.DeleteById(id);
                return Ok(new { messages = "Delete succsess" });
            }catch(Exception ex)
            {
                return Ok(new { messages = "Delete False" });
            }
        }
    }
}
