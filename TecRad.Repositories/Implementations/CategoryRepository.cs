using System.Linq;
using AutoMapper;
using TecRad.Models.Category;
using TecRad.Repositories.Data;
using System.Collections.Generic;
using TecRad.Repositories.Interfaces;

namespace TecRad.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public IEnumerable<CategoryDTO> GetAllCategories() => 
            Mapper.Map<IEnumerable<CategoryDTO>>(DataContext._categories);
            
        public CategoryDTO GetCategoryById(int categoryId) => 
            Mapper.Map<CategoryDTO>(DataContext._categories.FirstOrDefault(c => c.Id == categoryId));

        public int CreateNewCategory(CategoryInputModel category){
            var nextId = DataContext._categories.Count();
            var entity = Mapper.Map<Category>(category);
            entity.Id = nextId;
            DataContext._categories.Add(entity);
            return nextId;
        }

        public void UpdateCategoryById(CategoryInputModel category, int categoryId) {
            var updateCategory = DataContext._categories.FirstOrDefault(c => c.Id == categoryId);

            if(updateCategory == null) return;

            updateCategory.Name = category.Name;
            updateCategory.ParentCategoryId = category.ParentCategoryId;
            updateCategory.Slug = category.Slug;
        }

        public void DeleteCategory(CategoryDTO category){
            DataContext._categories.Remove(Mapper.Map<Category>(category));
        }

        public void LinkNewsItemToCategory(int categoryId, int newsItemId){
            var newsItem = DataContext._newsItems.FirstOrDefault(n => n.Id == newsItemId);
            newsItem.CategoryId = categoryId;
        }
    }
}