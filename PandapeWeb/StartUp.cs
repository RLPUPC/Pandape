using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Pandape.Infrastructure.Database;
using Pandape.Infrastructure.Database.Repository;
using Pandape.Infrastructure.Database.TypeConfigurations;

namespace PandapeWeb;

public class StartUp
{
    public StartUp(IConfiguration configuration) 
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services) {


        services.AddSingleton<IEntityConfiguration, CandidateConfiguration>();
        services.AddSingleton<IEntityConfiguration, CandidateExperienceConfiguration>();

        string? dbConnectionString = Configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<PandapeDbContext>(options =>
        {
            options.UseSqlServer(dbConnectionString);
        });


        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddControllersWithViews();
    }

    public void Configure(WebApplication app) 
    {
        using (var scope = app.Services.CreateScope())
        {
            PandapeDbContext context = scope.ServiceProvider.GetRequiredService<PandapeDbContext>();
            context.Database.EnsureCreated(); //Create if not exists
        }

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    }
}
