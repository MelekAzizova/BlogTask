using Blog.Context;
using Blog.Helpers;
using Blog.Models;
using Blog.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public BlogController(BlogDbContet db)
        {
            _db = db;
        }

        BlogDbContet _db { get; }
        public async Task<IActionResult> Index(BlogListItemVM vm)
        {
            var blog = await  _db.blogs.Select(s => new BlogListItemVM
            {
                Id = s.Id,
                Title = s.Title,
                Descriptions = s.Descriptions,
                Author = s.Author,
                CreateAt = s.CreateAt
            }).ToListAsync();
            return View(blog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(BlogCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            BlogModel blog = new BlogModel
            {
                Title=vm.Title,
                Author=vm.Author,
                Descriptions=vm.Descriptions,
                CreateAt=vm.CreateAt =DateTime.Now,
                Image= await vm.ImgFile.SaveAsync(PathContains.Blog)

        };
            await _db.blogs.AddAsync(blog);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

           
           // _db.blogs.AddAsync(data);
           
        }


        public async  Task<IActionResult> Delete(int? id)
        {
            if (id == null || id < 0) return BadRequest();
            var data = await _db.blogs.FindAsync(id);
            if (data == null) return NotFound();

            _db.blogs.Remove(data);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 0) return BadRequest();
            var data = await _db.blogs.FindAsync(id);
            if (data == null) return NotFound();
            BlogUptadeVM model = new BlogUptadeVM
            {
                Author = data.Author,
                Title = data.Title,
                CreateAt = data.CreateAt = DateTime.Now,
                Descriptions = data.Descriptions
                

            };
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Update(int? id,BlogUptadeVM vm)
        {
            if (id == null || id < 0) return BadRequest();
            var data = await _db.blogs.FindAsync(id);
            if (data == null) return NotFound();
            data.CreateAt = vm.CreateAt;
            data.Author = vm.Author;
            data.Descriptions = vm.Descriptions;
            data.Title = vm.Title;


            data.Image = await vm.ImgFile.SaveAsync(PathContains.Blog);


            return RedirectToAction(nameof(Index));
        }
    }
}
