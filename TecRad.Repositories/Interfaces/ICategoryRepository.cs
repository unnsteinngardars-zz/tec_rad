using System.Collections.Generic;
using TecRad.Models.Category;

namespace TecRad.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
         IEnumerable<CategoryDTO> GetAllCategories();
         CategoryDTO GetCategoryById(int categoryId);
        int CreateNewCategory(CategoryInputModel category);

        void UpdateCategoryById(CategoryInputModel category, int categoryId);
        void DeleteCategory(CategoryDTO category);

        void LinkNewsItemToCategory(int categoryId, int newsItemId);

    }
}