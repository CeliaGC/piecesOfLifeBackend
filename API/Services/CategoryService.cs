using API.IServices;
using Entities.Entities;
using Logic.ILogic;
using Logic.Logic;

namespace API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryLogic _categoryLogic;
        public void DeleteCategory(int Id)
        {
            _categoryLogic.DeleteCategory(Id);
        }

        public CategoryService(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        public List<CategoryItem> GetAllCategories()
        {
           return _categoryLogic.GetAllCategories();
        }

        public List<CategoryItem> GetCategoryById(int id)
        {
            return _categoryLogic.GetCategoryById(id);
        }

        public int InsertCategory(CategoryItem categoryItem)
        {
            _categoryLogic.InsertCategory(categoryItem);
            return categoryItem.IdCategory;
        }

        public void UpdateCategory(CategoryItem categoryItem)
        {
            _categoryLogic.UpdateCategory(categoryItem);
        }
    }
}
