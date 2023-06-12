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
        IQueryable<Book> GetAllBooks(bool trackChanges);
        Book GetBookById(int id,bool trackChanges);
        void CreateBook (Book book);
        void UpdateBook (Book book);
        void DeleteBook (Book book);
    }
}
