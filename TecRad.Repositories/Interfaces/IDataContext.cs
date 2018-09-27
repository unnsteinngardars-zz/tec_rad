using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Models.Category;
using TecRad.Models.NewsItem;

namespace TecRad.Repositories.Interfaces
{
	public interface IDataContext
	{
		List<NewsItem> getNewsItems { get; set; }
		List<Category> getCategories { get; set; }
		List<Author> getAuthors { get; set; }
	}
}