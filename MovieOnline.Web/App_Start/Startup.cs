using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using MovieOnline.Data;
using MovieOnline.Data.Infrastructure;
using MovieOnline.Data.Repositories;
using MovieOnline.Service;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(MovieOnline.Web.App_Start.Startup))]

namespace MovieOnline.Web.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigAutofac(app);
        }

        private void ConfigAutofac(IAppBuilder app)
        {

            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            //repository

            // Repositories
            builder.RegisterAssemblyTypes(typeof(MovieRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Services
            builder.RegisterAssemblyTypes(typeof(MovieService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);
        }
    }
}