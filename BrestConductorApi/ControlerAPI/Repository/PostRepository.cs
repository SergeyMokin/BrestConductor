using System.Collections.Generic;
using System.Linq;
using ControlerAPI.Models;
using System.Data;

namespace ControlerAPI.Repository
{
    public class PostRepository
        : IRepository
    {
        private PostContext db;

        public TotalCountPosts Count {
            get
            {
                return db.TotalCount.ToList().Last();
            }

            set
            {
                var count = db.TotalCount.Find(1);
                count.TotalCount = value.TotalCount;
                db.Entry(count).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public PostRepository(PostContext _db)
        {
            db = _db;
        }

        public IEnumerable<Post> Get()
        {
            return db.Posts.OrderByDescending(x => x.LastConfirmDate).Take(20).ToList();
        }

        public void Edit(Post _post)
        {
            var post = db.Posts.Find(_post.Id);
            post.LastConfirmDate = _post.LastConfirmDate;
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Add(Post _post)
        {
            if (_post != null)
            {
                if (_post.Date != null && _post.Message != null)
                {
                    _post.Id += db.Posts.ToList().Last().Id;
                    db.Entry(_post).State = EntityState.Added;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(Post _post)
        {
            db.Entry(_post).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public IEnumerable<Post> GetAll()
        {
            return db.Posts.ToList();
        }
    }
}