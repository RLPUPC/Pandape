using Microsoft.Extensions.Configuration;
using Pandape.Infrastructure.Database;
using Pandape.Infrastructure.Database.Repository;
using Pandape.Infrastructure.Database.TypeConfigurations;

namespace Pandape.Application;

public static class OurServiceLocator
{
    private static IConfigurationRoot? _configurationRoot;

    public static IConfigurationRoot ConfigurationRoot =>
        _configurationRoot ?? new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
        .Build();


    public static IUnitOfWork GetUnitOfWork()
    {
        string? dbConnectionString = ConfigurationRoot.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(dbConnectionString))
            throw new Exception("Erro connection string");
        var entities = new IEntityConfiguration[]
        {
            new CandidateConfiguration(),
            new CandidateExperienceConfiguration()
        };
        var pandapeContext = new PandapeDbContext(dbConnectionString, entities);
        return new UnitOfWork(pandapeContext);
    }
}
