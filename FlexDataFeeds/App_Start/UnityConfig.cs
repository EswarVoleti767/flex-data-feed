using FlexDataFeed.Data;
using FlexDataFeed.Services.Category;
using Microsoft.Extensions.Configuration;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace FlexDataFeeds
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICategoryServices, CategoryServices>();
            container.RegisterType<IDapperRepository, DapperRepository>();
            //container.RegisterType<IConfiguration>();
            //container.RegisterType<IConfiguration>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

        }
    }
}