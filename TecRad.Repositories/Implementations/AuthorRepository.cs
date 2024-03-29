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

		/* From teacher:
		"Betri leið væri að sækja stærsta Id 
		og incrementa það þegar verið er að vinna með lista." */
		private Author ToAuthor(AuthorInputModel author){
			var entity = Mapper.Map<Author>(author);
			entity.Id = _dataContext.getAuthors.Max(a => a.Id) +1; 
			return entity;
		}
		public IEnumerable<Author> GetAllAuthors() => 
			_dataContext.getAuthors;

		public Author GetAuthorById(int authorId) => 
			_dataContext.getAuthors.FirstOrDefault(a => a.Id == authorId);
	

		public IEnumerable<NewsItem> GetNewsItemsForAuthor(int authorId) => 
			_dataContext.getNewsItems.Where(n => n.AuthorId == authorId);

		public int CreateNewAuthor(AuthorInputModel author){
			var entity = ToAuthor(author);
			_dataContext.getAuthors.Add(entity);
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