using System.Collections.Generic;
using ControlerAPI.Models;
using ControlerAPI.Repository;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<Post>> Get()
        {
            var _task = new Task<IEnumerable<Post>>(delegate () { return initializer.GetPosts(); });
            _task.Start();
            return await _task;
        }

        public async Task Edit(Post _post)
        {
            var _task = new Task(delegate() {  repository.Edit(_post); });
            _task.Start();
            await _task;
        }

        public async Task Add(Post _post)
        {
            var _task = new Task(delegate () { initializer.SendPost(_post); }); ;
            _task.Start();
            await _task;
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