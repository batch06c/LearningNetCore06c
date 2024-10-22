using Microsoft.EntityFrameworkCore;
using Session.Models;

namespace Session
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<LoginusingsessionContext>(options =>
			{
				options.UseSqlServer(builder.Configuration.GetConnectionString("Session"));
			});

			builder.Services.AddSession(timer =>
			{
				timer.IdleTimeout = TimeSpan.FromMinutes(30);
			});
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
			}
			app.UseStaticFiles();
			app.UseSession();
			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Login}/{id?}");

			app.Run();
		}
	}
}
