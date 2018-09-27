using System.Collections.Generic;
using TecRad.Models.Category;

namespace TecRad.Services.Interfaces
{
	public interface ICategoryService
	{
		IEnumerable<CategoryDTO> GetAllCategories();
		CategoryDetailDTO GetCategoryById(int categoryId);
		int CreateNewCategory(CategoryInputModel category);
		void UpdateCategoryById(CategoryInputModel category, int categoryId);
		void DeleteCategoryById(int categoryId);
		void LinkNewsItemToCategory(int categoryId, int newsItemId);
	}
}