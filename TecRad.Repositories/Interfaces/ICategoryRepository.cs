using System.Collections.Generic;
using TecRad.Models.Category;

namespace TecRad.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int categoryId);
        int CreateNewCategory(CategoryInputModel category);
        void UpdateCategoryById(CategoryInputModel category, int categoryId);
        void DeleteCategory(Category category);
        void LinkNewsItemToCategory(int categoryId, int newsItemId);

    }
}