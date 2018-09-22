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
		public AuthorRepository(){
			
		}
		public IEnumerable<AuthorDTO> GetAllAuthors(int pageSize, int pageNumber) => 
			// TODO: Athuga með þetta pageSize og pageNumber
			Mapper.Map<IEnumerable<AuthorDTO>>(DataContext._authors);

		public AuthorDTO GetAuthorById(int authorId) => 
			Mapper.Map<AuthorDTO>(DataContext._authors.FirstOrDefault(a => a.Id == authorId));
	

		public IEnumerable<NewsItemDTO> GetNewsItemsForAuthor(int authorId) => 
			Mapper.Map<IEnumerable<NewsItemDTO>>(DataContext._newsItems.Where(n => n.AuthorId == authorId));

		public int CreateNewAuthor(AuthorInputModel author){
			var nextId = DataContext._authors.Count() + 1;
			Author entity = Mapper.Map<Author>(author);
			entity.Id = nextId;
			DataContext._authors.Add(entity);
			return nextId;
		}

		public void UpdateAuthorById(AuthorInputModel author, int authorId){
			var updateAuthor = DataContext._authors.FirstOrDefault(a => a.Id == authorId);

			if(updateAuthor == null) return;

			updateAuthor.Name = author.Name;
			updateAuthor.Bio = author.Bio;
			updateAuthor.ProfileImgSource = author.ProfileImgSource;
		}

		public void DeleteAuthor(AuthorDTO author){
			DataContext._authors.Remove(Mapper.Map<Author>(author));
		}
			
	}
}