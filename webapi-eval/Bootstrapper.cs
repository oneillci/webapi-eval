using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using webapi_eval.Controllers;

namespace webapi_eval
{
    public class Bootstrapper
    {
        public static void Configure()
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register the Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register other dependencies.
            builder.RegisterType<FoodRepository>().AsImplementedInterfaces();

            // Build the container.
            var container = builder.Build();

            // Create the depenedency resolver.
            var resolver = new AutofacWebApiDependencyResolver(container);

            // Configure Web API with the dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
  
    public class FoodRepository : IFoodRepository
    {
        public IList<Food> GetAll()
        {
            return new List<Food>()
            {
                new Food { Id = 1, Description = "Test", Measure = new List<string>()},
                new Food { Id = 1, Description = "Curry", Measure = new List<string>() },
            };
        }
    }
  
    public interface IFoodRepository
    {
        IList<Food> GetAll();
    }
}
