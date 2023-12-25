namespace Blog.ViewModels.Blog
{
    public class BlogCreateVM
    {
        public string Title { get; set; }

        public string Descriptions { get; set; }
        public DateTime CreateAt { get; set; }

        public IFormFile ImgFile { get; set; }
        public string Author { get; set; }
    }
}
