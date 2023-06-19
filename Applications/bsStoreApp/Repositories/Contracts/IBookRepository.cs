using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository:IRepositoryBase<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges);
        Task<Book> GetBookByIdAsync(int id,bool trackChanges);
        void CreateBook (Book book);
        void UpdateBook (Book book);
        void DeleteBook (Book book);
    }
}
