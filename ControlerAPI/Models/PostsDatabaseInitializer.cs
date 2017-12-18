using VkNet;
using VkNet.Model.RequestParams;
using System.Linq;
using ControlerAPI.Repository;
using System.Collections.Generic;

namespace ControlerAPI.Models
{

    public class PostsDatabaseInitializer
    {
        private VkApi api;
        private IRepository db;

        public PostsDatabaseInitializer(IRepository _db, VkApi _api)
        {
            db = _db;
            api = _api;
        }

        public IEnumerable<Post> GetPosts()
        {
            WallGetParams parametrs = new WallGetParams
            {
                OwnerId = -72869598
            };
            try
            {
                VkNet.Model.WallGetObject posts = new VkNet.Model.WallGetObject();
                parametrs.Count = api.Wall.Get(parametrs).TotalCount - db.Count.TotalCount;
                if (parametrs.Count > 0)
                {
                    posts = api.Wall.Get(parametrs);
                    db.Count = new TotalCountPosts{
                        Id = 0
                        , TotalCount = db.Count.TotalCount + parametrs.Count 
                    };
                }
                if (posts.WallPosts.Count != 0)
                {
                    foreach (var el in posts.WallPosts)
                    {
                        Post post = new Post
                        {
                            Id = el.Id,
                            Date = el.Date,
                            Message = el.Text,
                            LastConfirmDate = el.Date
                        };
                        if (!db.GetAll().Where(x => x.Date == x.Date).Where(x => x.Message.Equals(post.Message)).Any())
                        {
                            System.Console.WriteLine(post.Message);
                            db.Add(post);
                        }
                    }
                }
                return db.Get();
            }
            catch
            {
                return db.Get();
            }
        }

        public void SendPost(Post _post)
        {
            WallPostParams parametrs = new WallPostParams
            {
                OwnerId = -72869598,
                Message = _post.Message
            };
            try
            {
                api.Wall.Post(parametrs);
                db.Add(_post);
            }
            catch
            {
                return;
            }
        }
    }
}