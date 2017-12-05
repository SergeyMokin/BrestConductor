[assembly: WebActivator.PostApplicationStartMethod(typeof(ControlerAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace ControlerAPI.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Integration.Web;
    using ControlerAPI.Models;
    using ControlerAPI.Service;
    using ControlerAPI.Repository;
    using VkNet;

    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            InitializeContainer(container);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<VkApi>(() => new VkApi(), Lifestyle.Singleton);
            container.Register<VkAutorization>(() => new VkAutorization(container.GetInstance<VkApi>()), Lifestyle.Singleton);
            container.Register<Post>(Lifestyle.Scoped);
            container.Register<TotalCountPosts>(Lifestyle.Scoped);
            container.Register<PostContext>(Lifestyle.Singleton);
            container.Register<IRepository>(() => new PostRepository(container.GetInstance<PostContext>()), Lifestyle.Scoped);
            container.Register<PostsDatabaseInitializer>(() => new PostsDatabaseInitializer(container.GetInstance<IRepository>(), container.GetInstance<VkApi>()), Lifestyle.Singleton);
            container.Register<IPostService>(() => new PostService(container.GetInstance<PostContext>(), container.GetInstance<IRepository>(), container.GetInstance<PostsDatabaseInitializer>()), Lifestyle.Scoped);
        }
    }
}