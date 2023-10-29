using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface ICategoryLogic

    {
        int InsertCategory(CategoryItem categoryItem);

        void DeleteCategory(int Id);

        //List<CategoryItem> GetCategoryByCriteria(string Category);

        public List<CategoryItem> GetCategoryById(int id);

        List<CategoryItem> GetAllCategories();

        void UpdateCategory(CategoryItem categoryItem);
    }
}
