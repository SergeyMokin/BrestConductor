using System.Collections.Generic;
using ControlerAPI.Models;
using ControlerAPI.Repository;

namespace ControlerAPI.Service
{
    public class PostService
        : IPostService 
    {
        private PostContext db;
        private IRepository repository;
        private PostsDatabaseInitializer initializer;

        public PostService(PostContext _db, IRepository _repository, PostsDatabaseInitializer _initializer)
        {
            db = _db;
            repository = _repository;
            initializer = _initializer;
        }

        public IEnumerable<Post> Get()
        {
            return initializer.GetPosts();
        }

        public void Edit(Post _post)
        {
            repository.Edit(_post);
        }

        public void Add(Post _post)
        {
            initializer.SendPost(_post);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
        }
    }
}