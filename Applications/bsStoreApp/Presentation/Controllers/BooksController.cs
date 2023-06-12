using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _manager.BookService.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _manager.BookService.GetBookById(id, false);
                if (book is null)
                    return NotFound();
                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateBook([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); //400
                _manager.BookService.CreateBook(book);
                return StatusCode(201, book);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return BadRequest(); //400
                _manager.BookService.UpdateBook(id, book, true);
                return NoContent(); //20
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                _manager.BookService.DeleteBook(id, false);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
        {
            try
            {
                // check entity
                var entity = _manager.BookService.GetBookById(id, true);
                if (entity is null)
                    return NotFound(); // 404

                bookPatch.ApplyTo(entity);
                _manager.BookService.UpdateBook(id, entity, true);
                return NoContent(); // 204
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
