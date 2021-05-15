using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;

namespace CarRental.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();
            builder.RegisterType<EfCarImages>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
               .EnableInterfaceInterceptors(new ProxyGenerationOptions()
               {
                   Selector = new AspectInterceptorSelector()
               }).SingleInstance();
        }
    }
}
