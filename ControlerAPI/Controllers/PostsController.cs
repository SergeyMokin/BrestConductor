using System.Web.Http;
using ControlerAPI.Models;
using ControlerAPI.Service;
using System.Web.Http.Cors;

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

        public IHttpActionResult GetPosts()
        {
            var posts = service.Get();
            if (posts != null)
                return Ok(posts);
            return NotFound();
        }

        public IHttpActionResult Put(Post _post)
        {
            service.Edit(_post);
            return Ok(_post);
        }


        public IHttpActionResult Post(Post _post)
        {
            service.Add(_post);
            return Ok(_post);
        }

    }
}
