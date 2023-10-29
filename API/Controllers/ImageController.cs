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
    public class ImageController : ControllerBase
    {

        private readonly IImageService _imageService;
        private readonly ServiceContext _serviceContext;

        public ImageController(IImageService imageService, ServiceContext serviceContext)
        {
            _imageService = imageService;
            _serviceContext = serviceContext;

        }

        [HttpPost(Name = "InsertImage")]
        public IActionResult Post([FromBody] ImageItem imageItem)
        {
           
                return Ok(_imageService.InsertImage(imageItem));
        }

        [HttpDelete(Name = "DeleteImage")]
        public void Delete([FromQuery] int Id)
        {

                _imageService.DeleteImage(Id);

        }

        [HttpPatch(Name = "ModifyImage")]
        public IActionResult Patch([FromBody] ImageItem imageItem)

        {
                _imageService.UpdateImage(imageItem);
                return Ok();
        }

        [HttpGet(Name = "GetImagesByCriteria")]
        public List<ImageItem> GetImageByCriteria([FromQuery] string Category)
        {

            return _imageService.GetImageByCriteria(Category);
        }

        [HttpGet(Name = "GetImagesById")]
        public List<ImageItem> GetImageById([FromQuery] int id)
        {

            return _imageService.GetImageById(id);
        }

        [HttpGet(Name = "GetAllImages")]
        public List<ImageItem> GetAll()
        {

            return _imageService.GetAll();
        }
    }
}

