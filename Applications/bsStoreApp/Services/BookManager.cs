using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entities.Exceptions.BadRequestException;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger = null, IMapper mapper = null)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task <BookDto> CreateBookAsync(BookDtoForInsertion bookDto)
        {
            var entity = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateBook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookAndCheckExists(id, trackChanges);
            _manager.Book.DeleteBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(IEnumerable<BookDto> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges)
        {
            if (!bookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            var booksWithMetaData= await _manager
                .Book
                .GetAllBooksAsync(bookParameters, trackChanges);
             var booksDto=_mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            return (booksDto, booksWithMetaData.MetaData);
        }

        public async Task <BookDto> GetBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExists(id, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task <(BookDtoForUpdate bookDtoForUpdate, Book book)> GetBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookAndCheckExists(id, trackChanges);        
            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges )
        {
            var entity = await GetOneBookAndCheckExists(id, trackChanges);
            entity=_mapper.Map<Book>(bookDto);    
            _manager.Book.UpdateBook(entity);
            await _manager.SaveAsync();
        }
        private async Task<Book> GetOneBookAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetBookByIdAsync(id, trackChanges);
            if (entity is null)
                throw new BookNotFoundException(id);
            return entity;
        }
    }
}
