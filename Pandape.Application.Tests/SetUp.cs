using Microsoft.Extensions.Configuration;
using Pandape.Infrastructure.Database.TypeConfigurations;
using Pandape.Infrastructure.Database;

namespace Pandape.Application;

[SetUpFixture]
public class SetUp
{
    [OneTimeSetUp]
    public void RunBeforeAnyTest() 
    {
        string? dbConnectionString = OurServiceLocator.ConfigurationRoot.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(dbConnectionString))
            throw new ArgumentNullException(nameof(dbConnectionString));
        var entities = new IEntityConfiguration[]
        {
            new CandidateConfiguration(),
            new CandidateExperienceConfiguration()
        };
        var pandapeContext = new PandapeDbContext(dbConnectionString, entities);
        pandapeContext.Database.EnsureCreated();
    }
}
