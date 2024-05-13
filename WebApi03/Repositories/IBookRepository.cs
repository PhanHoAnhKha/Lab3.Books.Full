using WebApi03.DTO;
using WebApi03.Models;

namespace WebApi03.Services
{
        public interface IBookRepository
        {
            List<BookDTO> GetAllBooks();
            BookDTO GetBookById(int id);
            AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO);
            AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO);
            Books? DeleteBookById(int id);
        }
    }

