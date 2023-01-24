using Microsoft.EntityFrameworkCore;
using TAKSCODE5.DAL;

namespace TAKSCODE5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(Opt=>
            {
                Opt.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL"));
            }
            );
            var app = builder.Build();
            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(name: "areas",pattern: "{area:exists}/{controller=List}/{action=Index}/{id?}");
            app.MapControllerRoute(name:"default",pattern:"{Controller=Home}/{action=index}/{id?}");
            app.Run();
        }
    }
}