using BadHabbits.DataAccess;
using BadHabbits.Layers;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddScoped<IHabbitsLayer, HabbitsLayer>();

        var connectionString = builder.Configuration.GetValue<string>("DbConnectionString");
        builder.Services.AddDbContext<BadHabbitsDbContext>(
            options => options.UseSqlServer(connectionString)
        );

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
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