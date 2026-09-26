using LeGiaHung2410900041_exam.Models;
using Microsoft.EntityFrameworkCore;

namespace LeGiaHung2410900041_exam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("LghStudentContext") ?? throw new InvalidOperationException("Connection string 'LghStudentContext' not found.");

            builder.Services.AddDbContext<LghStudentContext>(options => options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           builder.Services.AddDbContext<LghStudentContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("LghStudentConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
