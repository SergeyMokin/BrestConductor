using System.Web.Http;
using ControlerAPI.Models;
using ControlerAPI.Service;
using System.Web.Http.Cors;
using System.Threading.Tasks;

namespace ControlerAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostsController : ApiController
    {
        private readonly IPostService service;

        public PostsController(IPostService _service)
        {
            service = _service;
        }

        public async Task<IHttpActionResult> GetPosts()
        {
            var posts = await service.Get();
            if (posts != null)
                return Ok(posts);
            return NotFound();
        }

        public async Task<IHttpActionResult> Put(Post _post)
        {
            await service.Edit(_post);
            return Ok(_post);
        }


        public async Task<IHttpActionResult> Post(Post _post)
        {
            await service.Add(_post);
            return Ok(_post);
        }

    }
}
