using Logic.ILogic;
using API.IServices;
using Microsoft.AspNetCore.Mvc;
using Entities.Entities;

namespace API.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageLogic _imageLogic;

        public ImageService(IImageLogic imageLogic)
        {
            _imageLogic = imageLogic;
        }
        public void DeleteImage(int Id)
        {
            _imageLogic.DeleteImage(Id);
        }

        public List<ImageItem> GetAll()
        {
            return _imageLogic.GetAll();
        }

        public List<ImageItem> GetImageByCriteria(string Category)
        {
            return _imageLogic.GetImageByCriteria(Category);
        }

        public List<ImageItem> GetImageById(int id)

        {
            return _imageLogic.GetImageById(id);
        }

        public int InsertImage(ImageItem imageItem)
        {
            _imageLogic.InsertImagetItem(imageItem);
            return imageItem.Id;
        }

        public void UpdateImage(ImageItem imagetItem)
        {
            _imageLogic.UpdateImage(imagetItem);
        }
    }
}
