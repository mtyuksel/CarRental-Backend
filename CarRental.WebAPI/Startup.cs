using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CarRental.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Dependencies are configured with Autofac. 
            //#region Dependencies

            //#region Dals
            //services.AddSingleton<IBrandDal, EfBrandDal>();
            //services.AddSingleton<ICarDal, EfCarDal>();
            //services.AddSingleton<IColorDal, EfColorDal>();
            //services.AddSingleton<ICustomerDal, EfCustomerDal>();
            //services.AddSingleton<IRentalDal, EfRentalDal>();
            //services.AddSingleton<IUserDal, EfUserDal>();
            //#endregion

            //#region Managers
            //services.AddSingleton<IBrandService, BrandManager>();
            //services.AddSingleton<ICarService, CarManager>();
            //services.AddSingleton<IColorService, ColorManager>();
            //services.AddSingleton<ICustomerService, CustomerManager>();
            //services.AddSingleton<IRentalService, RentalManager>();
            //services.AddSingleton<IUserService, UserManager>();
            //#endregion

            //#endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
