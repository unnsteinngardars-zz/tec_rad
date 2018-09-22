using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Models.NewsItem;

namespace TecRad.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> GetAllAuthors(int pageSize, int pageNumber);
        AuthorDTO GetAuthorById(int authorId);
        IEnumerable<NewsItemDTO> GetNewsItemsForAuthor(int authorId);
        int CreateNewAuthor(AuthorInputModel author);
        void UpdateAuthorById(AuthorInputModel author, int authorId);
        void DeleteAuthorById(int authorId);
    }
}