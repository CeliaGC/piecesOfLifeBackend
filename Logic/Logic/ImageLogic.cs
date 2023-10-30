using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Data;
using Entities.Entities;
using Logic.ILogic;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Logic.Logic
{
    public class ImageLogic : BaseContextLogic, IImageLogic
    {

        public ImageLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public void DeleteImage(int id)
        {
            //_serviceContext.Images.Remove(_serviceContext.Set<ImageItem>().Where(i => i.Id == id).FirstOrDefault());
            //_serviceContext.SaveChanges();

            var imageToDelete = _serviceContext.Images.Find(id);
            if (imageToDelete != null)
            {
                _serviceContext.Images.Remove(imageToDelete);
                _serviceContext.SaveChanges();
            }
        }

        public List<ImageItem> GetAll()
        {
            var allImages = _serviceContext.Set<ImageItem>().ToList();
            return allImages;
        }

        public List<ImageItem> GetImageByCriteria(string Category)
        {
            var categoryFilter = new ImageItem();
            categoryFilter.Category = Category;

            var resultList = _serviceContext.Set<ImageItem>()
                                .Where(i => i.Category == Category);

            if (categoryFilter.Category == Category)
            {
                resultList = resultList.Where(i => i.Category == Category);
            }


            return resultList.ToList();
        }

        public List<ImageItem> GetImageById(int id)

        {
            var nameFilter = new ImageItem();
            nameFilter.Id = id;

            var resultList = _serviceContext.Set<ImageItem>()
                .Where(i => i.Id == id);

            if (nameFilter.Id == id)
            {
                resultList = resultList.Where(i => i.Id == id);
            }

            return resultList.ToList();

        }
        int IImageLogic.InsertImagetItem(ImageItem imageItem)
        {


            var categoryInDataBase = _serviceContext.Set<CategoryItem>().Where(c => c.CategoryName == imageItem.Category).FirstOrDefault();
            //var imageToAdd = new ImageItem();
            imageItem.CategoryItemId = categoryInDataBase.IdCategory;
            _serviceContext.Images.Add(imageItem);
            _serviceContext.SaveChanges();
            return imageItem.Id;
        }

        public void UpdateImage(ImageItem imageItem)

        {


            _serviceContext.Images.Update(imageItem);
            _serviceContext.SaveChanges();
        }




    }
}


