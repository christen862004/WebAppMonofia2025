using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebAppMonofia2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. Day8
            // Built in Service 
            //    1) define and register
            //    2) define need to registre(AddSession)
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(
                option=>option.IdleTimeout=TimeSpan.FromMinutes(30)
                );//set session setting
            builder.Services.AddDbContext<ITIContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
            });


            // Custom Service Register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            
            var app = builder.Build(); //builder readonly

            #region Custom Middleware (Inline MiddleWare anonums delege)
            //app.Use(async (httpContext, nextMiddleware) =>
            //{
            //    await httpContext.Response.WriteAsync("1- Middelware 1\n");  
            //    await nextMiddleware.Invoke();//call next middleware
            //    await httpContext.Response.WriteAsync("1-1 Middelware 1\n");

            //});
            //app.Use(async (httpContext, nextMiddleware) =>
            //{
            //    await httpContext.Response.WriteAsync("2- Middelware 2\n");
            //    await nextMiddleware.Invoke();
            //    await httpContext.Response.WriteAsync("2-2 Middelware 2\n");

            //});

            //app.Run(async(httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3- Terminate\n");

            //});
            #endregion
            //Configure the HTTP request pipeline. Middleware Day2
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//handel reqq extension path  ==>wwwroot

            app.UseRouting();//handel mvc reeust

            app.UseSession();//setting  up in service berfor v=builder build

            app.UseAuthorization();
            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            
            app.Run();//run web app
        }
    }
}