using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IBookService
    {
        Task<(IEnumerable<BookDto> books,MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
        Task<BookDto> GetBookByIdAsync(int id,bool trackChanges);
        Task<BookDto> CreateBookAsync(BookDtoForInsertion book);
        Task UpdateBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
        Task DeleteBookAsync(int id, bool trackChanges);
        Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetBookForPatchAsync(int id, bool trackChanges);

        Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate,Book book);
    }
}
