using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFilters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    [ServiceFilter(typeof(LogFilterAttribute))]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public BooksController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        [ServiceFilter(typeof(ValidateMediaTypeAttribute))]
        public async Task<IActionResult> GetAllBooksAsync([FromQuery]BookParameters bookParameters)
        {
            var linkParameters = new LinkParameters()
            {
                BookParameters = bookParameters,
                HttpContext = HttpContext,
            };
            var result = await _manager
                .BookService
                .GetAllBooksAsync(linkParameters,false);

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.metaData));

            return result.linkResponse.HasLinks ?
                Ok(result.linkResponse.LinkedEntities) :
                Ok(result.linkResponse.ShapedEntities);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] int id)
        {
            var book = await _manager.BookService.GetBookByIdAsync(id, false);
            return Ok(book);
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> CreateBookAsync([FromBody] BookDtoForInsertion bookDto)
        {
            var book = await _manager.BookService.CreateBookAsync(bookDto);
            return StatusCode(201, book); // CreatedAtRoute()
        }
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
        {
            if (bookDto is null)
                return BadRequest(); //400
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422

            await _manager.BookService.UpdateBookAsync(id, bookDto, false);
            return NoContent(); //20
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync([FromRoute(Name = "id")] int id)
        {
            await _manager.BookService.DeleteBookAsync(id, false);
            return NoContent(); // 204
        }
        [HttpPatch("{id:int}")]
        public async Task<ActionResult> PartiallyUpdateBookAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
        {
            if (bookPatch is null)
                return BadRequest(); // 400

            var result = await _manager.BookService.GetBookForPatchAsync(id, true);

            bookPatch.ApplyTo(result.bookDtoForUpdate, ModelState);

            TryValidateModel(result.bookDtoForUpdate);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState); // 422

            await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);

            return NoContent(); // 204
        }
      
    }
}
