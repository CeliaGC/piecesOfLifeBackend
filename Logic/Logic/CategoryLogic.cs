using Data;
using Entities.Entities;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class CategoryLogic : BaseContextLogic, ICategoryLogic
    {
        public CategoryLogic(ServiceContext serviceContext) : base(serviceContext) { }

        public int InsertCategory(CategoryItem categoryItem)
        {
            _serviceContext.Categories.Add(categoryItem);
            _serviceContext.SaveChanges();
            return categoryItem.IdCategory;
        }


        public void DeleteCategory(int id)
        {
            _serviceContext.Categories.Remove(_serviceContext.Set<CategoryItem>().Where(c => c.IdCategory == id).FirstOrDefault());
            _serviceContext.SaveChanges();
        }

        public List<CategoryItem> GetCategoryById(int id)
        {
            var nameFilter = new CategoryItem();
            nameFilter.IdCategory = id;

            var resultList = _serviceContext.Set<CategoryItem>()
                .Where(c => c.IdCategory == id);

            if (nameFilter.IdCategory == id)
            {
                resultList = resultList.Where(i => i.IdCategory == id);
            }

            return resultList.ToList();
        }

        public List<CategoryItem> GetAllCategories()
        {
            var allCategories = _serviceContext.Set<CategoryItem>().ToList();
            return allCategories;
        }

        public void UpdateCategory(CategoryItem categoryItem)
        {
                _serviceContext.Categories.Update(categoryItem);
                _serviceContext.SaveChanges();
            }
    }
    
}
