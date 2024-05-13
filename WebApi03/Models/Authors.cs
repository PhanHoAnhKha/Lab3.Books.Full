using System.ComponentModel.DataAnnotations;

namespace WebApi03.Models
{
    public class Authors
    {
        [Key]
        public int AuthorsID { get; set; }
        public string? FullName { get; set; }
        public List<BookAuthor>? Book_Authors { get; set; }
    }
}
