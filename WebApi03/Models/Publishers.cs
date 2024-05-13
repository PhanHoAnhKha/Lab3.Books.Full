using System.ComponentModel.DataAnnotations;

namespace WebApi03.Models
{
    public class Publishers
    {
        [Key]
        public int PublishersID { get; set; }
        public string? Name { get; set; }
        public List<Books>? Books { get; set; }
    }
}
