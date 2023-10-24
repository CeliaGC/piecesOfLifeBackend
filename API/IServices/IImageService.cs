using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.IServices
{
    public interface IImageService
    {
        int InsertImage(ImageItem imagetItem);

        void DeleteImage(int Id);

        void UpdateImage(ImageItem imagetItem);

        List<ImageItem> GetImageByCriteria(string Category);

        public List<ImageItem> GetImageById(int id);

        List<ImageItem> GetAll();
      
    }
}
