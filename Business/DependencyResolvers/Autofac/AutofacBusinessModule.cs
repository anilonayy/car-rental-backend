using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var serviceAssembly = Assembly.GetExecutingAssembly();
            var dalAssembly = Assembly.GetAssembly(typeof(Context));

            builder.RegisterAssemblyTypes(serviceAssembly,dalAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(serviceAssembly, dalAssembly).Where(x => x.Name.EndsWith("Manager")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(serviceAssembly, dalAssembly).Where(x => x.Name.EndsWith("Dal")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
