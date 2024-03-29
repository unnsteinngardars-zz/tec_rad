using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Models.Exceptions;
using TecRad.Models.NewsItem;
using TecRad.Repositories;
using TecRad.Repositories.Interfaces;
using TecRad.Services.Interfaces;
using AutoMapper;

namespace TecRad.Services
{
	public class AuthorService : IAuthorService
	{
		private readonly IAuthorRepository _repo;

		public AuthorService(IAuthorRepository repo)
		{
			_repo = repo;
		}
		public int CreateNewAuthor(AuthorInputModel author)
		{
			return _repo.CreateNewAuthor(author);
		}

		public void DeleteAuthorById(int authorId)
		{
			var author = _repo.GetAuthorById(authorId);
			if (author == null) { throw new ResourceNotFoundException($"Author with id {authorId} was not found."); }

			_repo.DeleteAuthor(author);
		}

		public IEnumerable<AuthorDTO> GetAllAuthors()
		{
			return Mapper.Map<IEnumerable<AuthorDTO>>(_repo.GetAllAuthors());
		}

		public AuthorDetailDTO GetAuthorById(int authorId)
		{
			var author = _repo.GetAuthorById(authorId);
			if (author == null) { throw new ResourceNotFoundException($"Author with id {authorId} was not found."); }

			return Mapper.Map<AuthorDetailDTO>(author);
		}

		public IEnumerable<NewsItemDTO> GetNewsItemsForAuthor(int authorId)
		{
			var author = _repo.GetAuthorById(authorId);
			if (author == null) { throw new ResourceNotFoundException($"Author with id {authorId} was not found."); }

			return Mapper.Map<IEnumerable<NewsItemDTO>>(_repo.GetNewsItemsForAuthor(authorId));
		}

		public void LinkAuthorToNewsItem(int authorId, int newsItemId)
		// TODO: Athuga hvort að við eigum að taka inn newsItem repo líka til að athuga með ID og kasta þá exceptioni 
		{
			var author = _repo.GetAuthorById(authorId);
			if (author == null) { throw new ResourceNotFoundException($"Author with id {authorId} was not found."); }
			_repo.LinkAuthorToNewsItem(authorId, newsItemId);
		}

		public void UpdateAuthorById(AuthorInputModel author, int authorId)
		{
			var validAuthor = _repo.GetAuthorById(authorId);
			if (validAuthor == null) { throw new ResourceNotFoundException($"Author with id {authorId} was not found."); }

			_repo.UpdateAuthorById(author, authorId);
		}
	}
}