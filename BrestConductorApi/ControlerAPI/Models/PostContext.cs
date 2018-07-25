using System.Data.Entity;

namespace ControlerAPI.Models
{
    public class PostContext
        : DbContext
    {
        public PostContext()
            :base()
        {

        }

        public DbSet<TotalCountPosts> TotalCount { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}