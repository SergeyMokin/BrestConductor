using System.Web.Http;
using SpamBotVK.Service;
using SpamBotVK.Repository;
using System.Threading;

namespace SpamBotVK.Controllers
{
    public class BotController : ApiController
    {
        public IHttpActionResult Get()
        {
            IRepository rep = new BusstationRepository();
            BotService bot = new BotService(rep);
            new Thread(delegate() { bot.StartSpam(); }).Start();
            return Ok("Bot start working");
        }
    }
}
