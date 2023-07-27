using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.LinkModels;
using Entities.Models;
using Entities.RequestFeatures;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
        private readonly IBookLinks _bookLinks;
        public BookManager(IRepositoryManager manager, ILoggerService logger , IMapper mapper,IBookLinks bookLinks)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _bookLinks = bookLinks;
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

        public async Task<(LinkResponse linkResponse, MetaData metaData)> GetAllBooksAsync(LinkParameters linkParameters, bool trackChanges)
        {
            if (!linkParameters.BookParameters.ValidPriceRange)
                throw new PriceOutOfRangeBadRequestException();

            var booksWithMetaData= await _manager
                .Book
                .GetAllBooksAsync(linkParameters.BookParameters, trackChanges);
             var booksDto=_mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            var links = _bookLinks.TryGenerateLinks(booksDto, linkParameters.BookParameters.Fields,linkParameters.HttpContext);
            return (linkResponse : links, metaData : booksWithMetaData.MetaData);
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
