using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Repositories.Data;
using System.Linq;
using TecRad.Models.NewsItem;
using AutoMapper;
using TecRad.Repositories.Interfaces;

namespace TecRad.Repositories
{
	public class AuthorRepository : IAuthorRepository
	{
		private readonly IDataContext _dataContext;
		public AuthorRepository(IDataContext dataContext){
			_dataContext = dataContext;			
		}
		public IEnumerable<Author> GetAllAuthors() => 
			_dataContext.getAuthors;

		public Author GetAuthorById(int authorId) => 
			_dataContext.getAuthors.FirstOrDefault(a => a.Id == authorId);
	

		public IEnumerable<NewsItem> GetNewsItemsForAuthor(int authorId) => 
			_dataContext.getNewsItems.Where(n => n.AuthorId == authorId);

		public int CreateNewAuthor(AuthorInputModel author){
			var items = _dataContext.getAuthors;
            var entity = Mapper.Map<Author>(author);
            entity.Id = items.Count +1;
            items.Add(entity);

            return entity.Id;
		}

		public void UpdateAuthorById(AuthorInputModel author, int authorId){
			var updateAuthor = _dataContext.getAuthors.FirstOrDefault(a => a.Id == authorId);
			updateAuthor.Name = author.Name;
			updateAuthor.Bio = author.Bio;
			updateAuthor.ProfileImgSource = author.ProfileImgSource;
		}

		public void DeleteAuthor(Author author){
			_dataContext.getAuthors.Remove(author);
		}

        public void LinkAuthorToNewsItem(int authorId, int newsItemId)
        {
			var author = _dataContext.getAuthors.FirstOrDefault(a => a.Id == authorId);
			var newsItem = _dataContext.getNewsItems.FirstOrDefault(n => n.Id == newsItemId);

			newsItem.AuthorId = authorId;
        }
    }
}