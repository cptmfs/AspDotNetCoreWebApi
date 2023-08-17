using Entities.DataTransferObjects;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<(LinkResponse linkResponse, MetaData metaData)> GetAllBooksAsync(LinkParameters linkParameters, bool trackChanges);
        Task<BookDto> GetBookByIdAsync(int id,bool trackChanges);
        Task<BookDto> CreateBookAsync(BookDtoForInsertion book);
        Task UpdateBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
        Task DeleteBookAsync(int id, bool trackChanges);
        Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetBookForPatchAsync(int id, bool trackChanges);

        Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate,Book book);
        Task<List<Book>> GetAllBooksAsync(bool trackChanges);
        Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges);
    }
}
