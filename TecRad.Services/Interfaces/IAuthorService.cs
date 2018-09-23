using System.Collections.Generic;
using TecRad.Models.Author;
using TecRad.Models.NewsItem;

namespace TecRad.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDTO> GetAllAuthors();
        AuthorDTO GetAuthorById(int authorId);
        IEnumerable<NewsItemDTO> GetNewsItemsForAuthor(int authorId);
        int CreateNewAuthor(AuthorInputModel author);
        void UpdateAuthorById(AuthorInputModel author, int authorId);
        void DeleteAuthorById(int authorId);
        void LinkAuthorToNewsItem(int authorId, int newsItemId);
    }
}