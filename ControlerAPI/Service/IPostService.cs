using System.Collections.Generic;
using ControlerAPI.Models;

namespace ControlerAPI.Service
{
    public interface IPostService
    {
        IEnumerable<Post> Get();

        void Edit(Post _post);

        void Add(Post _post);
    }
}