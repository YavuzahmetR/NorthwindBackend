using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category : ControllerBase
    {
        private ICategoryService _categoryService;

        public Category(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("getall")]
        public IActionResult GetList() 
        {
            var result = _categoryService.GetList();

            if (result.Success)               
            {
                return Ok(result.Data);
            }
            else { return BadRequest(); }
        }
    }
}
