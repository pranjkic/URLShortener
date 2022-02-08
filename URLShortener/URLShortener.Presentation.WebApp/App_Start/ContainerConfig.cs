using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using URLShoretener.Core.Ports.RepositoryInterfaces;
using URLShortener.Core.Ports.ServiceInterfaces;
using URLShortener.Core.ServiceAdapters.Services;
using URLShortener.Repositories.DBRepository;

namespace URLShortener.Presentation.WebApp.App_Start
{
    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<URLService>().As<IURLService>();
            builder.RegisterType<URLRepository>().As<IURLRepository>();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}