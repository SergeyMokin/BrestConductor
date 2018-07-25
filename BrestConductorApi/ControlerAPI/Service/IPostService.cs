using System.Collections.Generic;
using ControlerAPI.Models;
using System.Threading.Tasks;

namespace ControlerAPI.Service
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> Get();

        Task Edit(Post _post);

        Task Add(Post _post);
    }
}