using Microsoft.AspNetCore.Mvc;
using WebApi03.CustomActionFilter;
using WebApi03.DTO;
using WebApi03.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }

        [HttpGet("get-all-books")]
        public IActionResult GetAll()
        {
            // su dung reposity pattern
            var allBooks = _bookRepository.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("get-book-by-id/{id}")]
        public IActionResult GetBookById([FromRoute] int id)
        {
            var bookWithIdDTO = _bookRepository.GetBookById(id);
            return Ok(bookWithIdDTO);
        }


        [HttpPost("and-book")]
        [ValidateModel]
        public IActionResult AddBook([FromBody] AddBookRequestDTO addBookRequestDTO)
        {
            //validate request
            if (!ValidateAddBook(addBookRequestDTO))
            {
                return BadRequest(ModelState);
            }
            // before add data
            if (ModelState.IsValid)
            {
                var bookAdd = _bookRepository.AddBook(addBookRequestDTO);
                return Ok(bookAdd);
            }
            else return BadRequest(ModelState);

        }


        [HttpPut("update-book-by-id/{id}")]
            public IActionResult UpdateBookById(int id, [FromBody] AddBookRequestDTO bookDTO)
            {
                var updateBook = _bookRepository.UpdateBookById(id, bookDTO);
                return Ok(updateBook);

            }


            [HttpDelete("delete-book-by-id/{id}")]
            public IActionResult DeleteBookById(int id)
            {
                var deleteBook = _bookRepository.DeleteBookById(id);
                return Ok(deleteBook);
            }
        #region Private methods 
        private bool ValidateAddBook(AddBookRequestDTO addBookRequestDTO)
        {
            if (addBookRequestDTO == null)
            {
                ModelState.AddModelError(nameof(addBookRequestDTO), $"Please add book data"); 
            return false;
            }
            // kiem tra Description NotNull
            if (string.IsNullOrEmpty(addBookRequestDTO.Description))
            {
                ModelState.AddModelError(nameof(addBookRequestDTO.Description),
               $"{nameof(addBookRequestDTO.Description)} cannot be null");
            }
            // kiem tra rating (0,5) 
            if (addBookRequestDTO.Rate < 0 || addBookRequestDTO.Rate > 5)
            {
                ModelState.AddModelError(nameof(addBookRequestDTO.Rate),
               $"{nameof(addBookRequestDTO.Rate)} cannot be less than 0 and more than 5");
            }
            if (ModelState.ErrorCount > 0)
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}


