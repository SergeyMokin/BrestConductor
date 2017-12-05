using System.Collections.Generic;
using ControlerAPI.Models;

namespace ControlerAPI.Repository
{
    public interface IRepository
    {
        IEnumerable<Post> Get();
        IEnumerable<Post> GetAll();
        void Edit(Post _post);
        void Add(Post _post);
        void Delete(Post _post);
        TotalCountPosts Count { get; set; }
    }
}