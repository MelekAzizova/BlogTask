using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels.Blog
{
    public class BlogListItemVM
    {
        public int Id { get; set; }
       
        public string Title { get; set; }
        
        public string Descriptions { get; set; }
        public DateTime CreateAt { get; set; }
        
        public string ImgFile { get; set; }
        public string Author { get; set; }
    }
}
