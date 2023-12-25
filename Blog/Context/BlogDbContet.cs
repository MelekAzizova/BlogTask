using Microsoft.EntityFrameworkCore;

namespace Blog.Context
{
    public class BlogDbContet:DbContext
    {
        public BlogDbContet(DbContextOptions<BlogDbContet> options)
        : base(options) { }

       public DbSet<Models.BlogModel> blogs { get; set; }
     }
}
