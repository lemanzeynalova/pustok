using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Pustok.Contexts;
using Pustok.Helpers;

namespace WebApplication5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<PustokDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration["ConnectionStrings:MSSql"]);
            });
            builder.Services.AddSession();

            //builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<LayoutService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(
             name: "shop",
             pattern: "magaza",
             defaults: new
          {
              Controller = "Shop",
              Action = "Index"
             }
           );
            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}/{id?}");
            PathConstants.RootPath = builder.Environment.WebRootPath;

            app.MapRazorPages();

            app.Run();
        }
    }
}