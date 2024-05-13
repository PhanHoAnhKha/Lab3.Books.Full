using System;
using WebApi03.Data;
using WebApi03.DTO;
using WebApi03.Models;

namespace WebApi03.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dpContext)
        {
            _dbContext = dpContext;
        }
        public List<BookDTO> GetAllBooks()
        {
            var allBooksDTO = _dbContext.Books.Select(book => new BookDTO
            {
                Id = book.BookID,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorName = book.Book_Authors.Select(n => n.Author.FullName).ToList(),
            }).ToList();
            return allBooksDTO;
        }

        public BookDTO GetBookById(int id)
        {
            var bookWithDomain = _dbContext.Books.Where(n => n.BookID == id);
            //Map Domain Model to DTOs
            var bookWithIdDTO = bookWithDomain.Select(book => new BookDTO()
            {
                Id = book.BookID,
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publishers.Name,
                AuthorName = book.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).FirstOrDefault();
            return bookWithIdDTO;
        }

        public AddBookRequestDTO AddBook(AddBookRequestDTO addBookRequestDTO)
        {
            var bookDomainModel = new Books
            {
                Title = addBookRequestDTO.Title,
                Description = addBookRequestDTO.Description,
                IsRead = addBookRequestDTO.IsRead,
                DateRead = addBookRequestDTO.DateReaad,
                Rate = addBookRequestDTO.Rate,
                Genre = addBookRequestDTO.Genre,
                CoverUrl = addBookRequestDTO.CoverUrl,
                DateAdded = addBookRequestDTO.DateAdded,
                PublisherID = addBookRequestDTO.PublisherID
            };
            _dbContext.Books.Add(bookDomainModel);
            _dbContext.SaveChanges();
            foreach (var id in addBookRequestDTO.AuthorIDs)
            {
                var _book_author = new BookAuthor()
                {
                    BooksID = bookDomainModel.BookID,
                    AuthorsID = id
                };
                _dbContext.BookAuthor.Add(_book_author);
                _dbContext.SaveChanges();
            }
            return addBookRequestDTO;
        }


        public AddBookRequestDTO? UpdateBookById(int id, AddBookRequestDTO bookDTO)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.BookID == id);
            if (bookDomain != null)
            {
                bookDomain.Title = bookDTO.Title;
                bookDomain.Description = bookDTO.Description;
                bookDomain.IsRead = bookDTO.IsRead;
                bookDomain.DateRead = bookDTO.DateReaad;
                bookDomain.Rate = bookDTO.Rate;
                bookDomain.Genre = bookDTO.Genre;
                bookDomain.CoverUrl = bookDTO.CoverUrl;
                bookDomain.DateAdded = bookDTO.DateAdded;
                bookDomain.PublisherID = bookDTO.PublisherID;
            }
            var existingAuthors = _dbContext.BookAuthor.Where(a => a.BooksID == id).ToList();
            _dbContext.BookAuthor.RemoveRange(existingAuthors);

            foreach (var authorId in bookDTO.AuthorIDs)
            {
                var _book_author = new BookAuthor
                {
                    BooksID = id,
                    AuthorsID = authorId
                };
                _dbContext.BookAuthor.Add(_book_author);
            }
            _dbContext.SaveChanges();
            return bookDTO;
        }

        public Books? DeleteBookById(int id)
        {
            var bookDomain = _dbContext.Books.FirstOrDefault(n => n.BookID == id);
            if (bookDomain != null)
            {
                _dbContext.Books.Remove(bookDomain);
                _dbContext.SaveChanges();
            }
            return bookDomain;
        }

    }
}

