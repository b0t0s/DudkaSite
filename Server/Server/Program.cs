using Microsoft.EntityFrameworkCore;
using Serilog;
using Site.Server.Application;
using Site.Server.Domain;
using Site.Server.Domain.Entities;
using Site.Server.Infrastructure.Repositories;
using Site.Shared.Logging;

namespace Site.Server;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = SiteLoggerManager.CreateConfiguration().CreateLogger();

        try
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddScoped<IRepository<Customer>, ClientsRepository>();
            builder.Services.AddScoped<IRepository<Order>, OrdersRepository>();
            builder.Services.AddScoped<IRepository<Shop>, ShopsRepository>();

            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddScoped<HttpClient>();

            /* this is used instead of .UseSerilog to add Serilog to providers */
            builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            var controllerSettings = builder.Configuration.GetSection("ControllersOptions");

            // Bind the ControllersOptions from appsettings.json
            builder.Services.Configure<ControllersOptions>(controllerSettings);

            // Add the DbContext to the services
            builder.Services.AddDbContext<SiteDbContext>(options =>
            {
                options.UseInMemoryDatabase("ShopSite");
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
