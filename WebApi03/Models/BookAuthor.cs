namespace WebApi03.Models
{
    public class BookAuthor
    {
        public int Id { get; set; }
        public int? BooksID { get; set; }
        public int? AuthorsID { get; set; }
        public Books? Books { get; set; }
        public Authors? Author { get; set; }
    }
}
