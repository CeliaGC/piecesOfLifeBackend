﻿using Entities.Entities;

namespace API.IServices
{
    public interface ICategoryService
    {

        int InsertCategory(CategoryItem categoryItem);

        void DeleteCategory(int Id);

        //List<CategoryItem> GetCategoryByCriteria(string Category);

        public List<CategoryItem> GetCategoryById(int id);

        List<CategoryItem> GetAllCategories();

        void UpdateCategory(CategoryItem categoryItem);
    }
}
