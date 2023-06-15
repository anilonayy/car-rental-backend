using Autofac;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;

namespace ConsoleUI.Modules
{
    public class RepoServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var consoleAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(EfGenericDal<>));
            var serviceAssembly = Assembly.GetAssembly(typeof(GenericService<>));

            builder.RegisterAssemblyTypes(consoleAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Dal")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(consoleAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

        }
    }
}
