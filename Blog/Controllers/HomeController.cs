
using Blog.Context;
using Blog.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(BlogDbContet db)
        {
            _db = db;
        }

        BlogDbContet _db { get; }

        public async Task<IActionResult> Index()
        {

            var blog = await _db.blogs.Select(s => new BlogListItemVM
            {
                Id = s.Id,
                Title = s.Title,
                Descriptions = s.Descriptions,
                Author = s.Author,
                CreateAt = s.CreateAt
            }).ToListAsync();
            return View(blog);
        }

      

       
    }
}
