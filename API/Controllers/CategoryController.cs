using API.IServices;
using Data;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

using System.Security.Authentication;
using System.Web.Http.Cors;

namespace Apii.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("[controller]/[action]")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        private readonly ServiceContext _serviceContext;

        public CategoryController(ICategoryService categoryService, ServiceContext serviceContext)
        {
            _categoryService = categoryService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertCategory")]
        public IActionResult Post([FromBody] CategoryItem categoryItem )
        {

            return Ok(_categoryService.InsertCategory(categoryItem));
        }

        [HttpDelete(Name = "DeleteCategory")]
        public void Delete([FromQuery] int Id)
        {

            _categoryService.DeleteCategory(Id);

        }

        [HttpPatch(Name = "ModifyCategory")]
        public IActionResult Patch([FromBody] CategoryItem categoryItem)

        {
            _categoryService.UpdateCategory(categoryItem);
            return Ok();
        }


        [HttpGet(Name = "GetCategoryById")]
        public List<CategoryItem> GetCategoryById([FromQuery] int id)
        {

            return _categoryService.GetCategoryById(id);
        }

        [HttpGet(Name = "GetAllCategories")]
        public List<CategoryItem> GetAllCategories()
        {

            return _categoryService.GetAllCategories();
        }
    }
}
