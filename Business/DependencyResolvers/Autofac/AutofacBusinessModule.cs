using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = Assembly.GetExecutingAssembly();


            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<BrandManager>().As<IBrandService>();

            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<CarManager>().As<ICarService>();

            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();

            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<ColorManager>().As<IColorService>();


            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();


            builder.RegisterType<AuthManager>().As<IAuthService>();   
            
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<RentalManager>().As<IRentalService>();




            builder.RegisterAssemblyTypes(currentAssembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
