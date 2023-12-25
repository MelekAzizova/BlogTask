using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        [Required,MinLength(3),MaxLength(25)]
        public string Title { get; set; }
        [Required,MinLength(6),MaxLength(32)]
        public string Descriptions { get; set; }
        public DateTime CreateAt { get; set; }
        [Required,MinLength(3),MaxLength(25)]
        public string Author { get; set; }
        public string Image { get; set; }
    }
}
